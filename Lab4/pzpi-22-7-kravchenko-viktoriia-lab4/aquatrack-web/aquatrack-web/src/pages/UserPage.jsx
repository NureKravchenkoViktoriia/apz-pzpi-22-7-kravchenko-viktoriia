// src/pages/UserPage.jsx
import React, { useState, useEffect } from "react";
import axios from "axios";
import { useTranslation } from "react-i18next";

const API_BASE = "http://localhost:5000/api";

export default function UserPage() {
  const { t, i18n } = useTranslation();

  const userId = localStorage.getItem("userId");
  const role = localStorage.getItem("role");

  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [waterUsageData, setWaterUsageData] = useState([]);
  const [loadingUsage, setLoadingUsage] = useState(false);
  const [usageError, setUsageError] = useState("");

  const [limitStartDate, setLimitStartDate] = useState("");
  const [limitEndDate, setLimitEndDate] = useState("");
  const [limitValue, setLimitValue] = useState("");
  const [deviceId, setDeviceId] = useState("");
  const [limits, setLimits] = useState([]);
  const [loadingLimits, setLoadingLimits] = useState(false);
  const [limitsError, setLimitsError] = useState("");

  const [activeTab, setActiveTab] = useState("monitoring");

  const changeLanguage = (lng) => {
    i18n.changeLanguage(lng);
  };

const fetchWaterUsage = async () => {
  setLoadingUsage(true);
  setUsageError("");
  setWaterUsageData([]);
  try {
    const params = {};
    if (startDate) params.startDate = startDate;
    if (endDate) params.endDate = endDate;
    if (deviceId) params.deviceId = deviceId;

    const response = await axios.get(`${API_BASE}/water-usage/history`, { params });

const usageWithDates = response.data.map((item) => ({
  date: new Date(item.Timestamp),  
  usage: item.UsageValue,          
  id: item.UsageId
}));

    setWaterUsageData(usageWithDates);
  } catch (error) {
    console.error("Error loading water usage:", error);
    setUsageError(t("errorLoadingData"));
  } finally {
    setLoadingUsage(false);
  }
};


  const fetchLimits = async () => {
    setLoadingLimits(true);
    setLimitsError("");
    try {
      const response = await axios.get(`${API_BASE}/limits/list`);
      setLimits(response.data);
    } catch (error) {
      setLimitsError(t("errorLoadingData"));
    } finally {
      setLoadingLimits(false);
    }
  };

  const createLimit = async () => {
    if (!limitStartDate || !limitEndDate || !limitValue || !deviceId) {
      alert(t("fillAllFields"));
      return;
    }

    try {
      await axios.post(`${API_BASE}/limits/create`, {
        startDate: limitStartDate,
        endDate: limitEndDate,
        limitValue: Number(limitValue),
        deviceId: Number(deviceId),
        userId: Number(userId),
      });
      alert(t("limitCreated"));
      fetchLimits();
    } catch (error) {
      alert(t("errorCreatingLimit"));
    }
  };

  const removeLimit = async (limitId) => {
    if (!window.confirm(t("confirmDeleteLimit"))) return;
    try {
      await axios.delete(`${API_BASE}/limits/delete/${limitId}`);
      alert(t("limitDeleted"));
      fetchLimits();
    } catch (error) {
      alert(t("errorDeletingLimit"));
    }
  };

  useEffect(() => {
    fetchLimits();
  }, []);

  return (
    <div style={{ maxWidth: 900, margin: "0 auto", padding: 20 }}>
      {/* Заголовок і мова */}
      <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center" }}>
        <h1>AquaTrack</h1>
        <div>
          <button onClick={() => changeLanguage("uk")}>🌐 Українська</button>
          <button onClick={() => changeLanguage("en")}>🌐 English</button>
        </div>
      </div>

      <div style={{ marginTop: 20 }}>
        <button
          onClick={() => setActiveTab("monitoring")}
          style={{
            padding: "10px 20px",
            backgroundColor: activeTab === "monitoring" ? "#0078d7" : "#ddd",
            color: activeTab === "monitoring" ? "white" : "black",
            border: "none",
            cursor: "pointer",
            borderRadius: "4px 0 0 4px",
          }}
        >
          {t("monitoring")}
        </button>
        <button
          onClick={() => setActiveTab("limits")}
          style={{
            padding: "10px 20px",
            backgroundColor: activeTab === "limits" ? "#0078d7" : "#ddd",
            color: activeTab === "limits" ? "white" : "black",
            border: "none",
            cursor: "pointer",
            borderRadius: "0 4px 4px 0",
          }}
        >
          {t("limits")}
        </button>
      </div>

      {/* Моніторинг */}
      {activeTab === "monitoring" && (
        <div style={{ marginTop: 20 }}>
          <h2>{t("monitoring")}</h2>

          <div style={{ marginBottom: 10 }}>
            <label>
              {t("startDate")}:{" "}
              <input
                type="date"
                value={startDate}
                onChange={(e) => setStartDate(e.target.value)}
                style={{ marginRight: 10 }}
              />
            </label>

            <label>
              {t("endDate")}:{" "}
              <input
                type="date"
                value={endDate}
                onChange={(e) => setEndDate(e.target.value)}
                style={{ marginRight: 10 }}
              />
            </label>

            <button onClick={fetchWaterUsage} style={{ padding: "5px 10px" }}>
              {t("showData")}
            </button>
          </div>

          {loadingUsage && <p>{t("loading")}</p>}
          {usageError && <p style={{ color: "red" }}>{usageError}</p>}

          {waterUsageData.length > 0 ? (
            <table border="1" cellPadding="5" style={{ width: "100%", borderCollapse: "collapse" }}>
              <thead>
                <tr>
                  <th>{t("date")}</th>
                  <th>{t("usageValue")}</th>
                </tr>
              </thead>
              <tbody>
{waterUsageData.map((item, index) => {
  const formattedDate =
    item.date instanceof Date && !isNaN(item.date)
      ? item.date.toLocaleDateString(i18n.language)
      : t("invalidDate");

  return (
    <tr key={item.id || index}>
      <td>{formattedDate}</td>
      <td>{item.usage}</td>
    </tr>
  );
})}

              </tbody>
            </table>
          ) : (
            !loadingUsage && <p>{t("noData")}</p>
          )}
        </div>
      )}

      {/* Ліміти */}
      {activeTab === "limits" && (
        <div style={{ marginTop: 20 }}>
          <h2>{t("limits")}</h2>

          <div>
            <label>
              {t("startDate")}:{" "}
              <input
                type="date"
                value={limitStartDate}
                onChange={(e) => setLimitStartDate(e.target.value)}
                style={{ marginRight: 10 }}
              />
            </label>

            <label>
              {t("endDate")}:{" "}
              <input
                type="date"
                value={limitEndDate}
                onChange={(e) => setLimitEndDate(e.target.value)}
                style={{ marginRight: 10 }}
              />
            </label>
          </div>

          <div style={{ marginTop: 10 }}>
            <label>
              {t("waterAmount")}:{" "}
              <input
                type="number"
                min="0"
                value={limitValue}
                onChange={(e) => setLimitValue(e.target.value)}
                style={{ marginRight: 10 }}
              />
            </label>

            <label>
              {t("deviceNumber")}:{" "}
              <input
                type="number"
                min="1"
                value={deviceId}
                onChange={(e) => setDeviceId(e.target.value)}
              />
            </label>
          </div>

          <button onClick={createLimit} style={{ marginTop: 10 }}>
           ➕ {t("addLimit")}
          </button>

          {loadingLimits && <p>{t("loading")}</p>}
          {limitsError && <p style={{ color: "red" }}>{limitsError}</p>}

          {limits.length > 0 ? (
            <table
              border="1"
              cellPadding="5"
              style={{ width: "100%", marginTop: 10, borderCollapse: "collapse" }}
            >
              <thead>
                <tr>
                  <th>{t("startDate")}</th>
                  <th>{t("endDate")}</th>
                  <th>{t("waterAmount")}</th>
                  <th>{t("deviceNumber")}</th>
                  <th>{t("actions")}</th>
                </tr>
              </thead>
              <tbody>
                {limits.map((limit) => (
                  <tr key={limit.LimitId}>
                    <td>{new Date(limit.StartDate).toLocaleDateString(i18n.language)}</td>
                    <td>{new Date(limit.EndDate).toLocaleDateString(i18n.language)}</td>
                    <td>{limit.LimitValue}</td>
                    <td>{limit.DeviceId}</td>
                    <td>
                      <button onClick={() => removeLimit(limit.LimitId)}>🗑️ {t("remove")}</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            !loadingLimits && <p>{t("noLimits")}</p>
          )}
        </div>
      )}
    </div>
  );
}
