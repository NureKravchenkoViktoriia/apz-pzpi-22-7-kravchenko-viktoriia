// src/pages/AdminPage.jsx
import React, { useEffect, useState } from "react";
import axios from "axios";
import './AdminPage.css';
import { useTranslation } from 'react-i18next';

function AdminPage() {
  const [users, setUsers] = useState([]);
  const [selectedUserId, setSelectedUserId] = useState(null);
  const [newRole, setNewRole] = useState("");
  const [activeTab, setActiveTab] = useState("users");

  const [devices, setDevices] = useState([]);
  const [newDeviceType, setNewDeviceType] = useState("");
  const [newDeviceStatus, setNewDeviceStatus] = useState("");

  const { t, i18n } = useTranslation();

  const toggleLanguage = () => {
    const newLang = i18n.language === 'uk' ? 'en' : 'uk';
    i18n.changeLanguage(newLang);
  };

  const fetchUsers = async () => {
    try {
      const response = await axios.get("http://localhost:5000/api/users/list");
      setUsers(response.data);
    } catch (error) {
      alert(t('errorLoadUsers') || "Помилка при завантаженні користувачів");
    }
  };

  const deleteUser = async (userId) => {
    if (!window.confirm(t('confirmDelete') || "Ви впевнені, що хочете видалити цього користувача?")) return;
    try {
      await axios.delete(`http://localhost:5000/api/users/delete/${userId}`);
      fetchUsers();
    } catch (error) {
      alert(t('errorDeleteUser') || "Не вдалося видалити користувача");
    }
  };

  const changeUserRole = async () => {
    if (!selectedUserId || !newRole) {
      alert(t('selectUserAndRole') || "Оберіть користувача і вкажіть нову роль");
      return;
    }
    try {
      await axios.put(`http://localhost:5000/api/users/update-role?userId=${selectedUserId}&newRole=${newRole}`);
      fetchUsers();
      setNewRole("");
      setSelectedUserId(null);
    } catch (error) {
      alert(t('errorChangeRole') || "Не вдалося змінити роль");
    }
  };

  const fetchDevices = async () => {
    try {
      const res = await axios.get("http://localhost:5000/api/iot-devices/list");
      setDevices(res.data);
    } catch (error) {
      alert(t('errorLoadDevices') || "Не вдалося завантажити пристрої");
    }
  };

  const registerDevice = async () => {
    if (!newDeviceType || !newDeviceStatus) {
      alert(t('enterDeviceDetails') || "Введіть тип і статус пристрою");
      return;
    }
    try {
      await axios.post("http://localhost:5000/api/iot-devices/register", {
        deviceType: newDeviceType,
        status: newDeviceStatus,
      });
      fetchDevices();
      setNewDeviceType("");
      setNewDeviceStatus("");
    } catch (error) {
      alert(t('errorRegisterDevice') || "Не вдалося додати пристрій");
    }
  };

  const deleteDevice = async (deviceId) => {
    if (!window.confirm(t('confirmDeleteDevice') || "Ви впевнені, що хочете видалити цей пристрій?")) return;
    try {
      await axios.delete(`http://localhost:5000/api/iot-devices/delete/${deviceId}`);
      fetchDevices();
    } catch (error) {
      alert(t('errorDeleteDevice') || "Не вдалося видалити пристрій");
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  useEffect(() => {
    if (activeTab === "devices") {
      fetchDevices();
    }
  }, [activeTab]);

  return (
    <div className="admin-page">
      <div className="admin-header">
        <h2>{t('adminPanelTitle')}</h2>
        <button onClick={toggleLanguage} className="lang-btn">
          🌐 {t('changeLanguage')}
        </button>
      </div>

      <div className="tabs">
        <button onClick={() => setActiveTab("users")} className={activeTab === "users" ? "active" : ""}>
          👤 {t('usersTab')}
        </button>
        <button onClick={() => setActiveTab("devices")} className={activeTab === "devices" ? "active" : ""}>
          📟 {t('devicesTab')}
        </button>
      </div>

      {activeTab === "users" && (
        <div>
          <h3>{t('manageUsers')}</h3>

          <table className="user-table">
            <thead>
              <tr>
                <th>ID</th>
                <th>{t('username')}</th>
                <th>{t('email')}</th>
                <th>{t('role')}</th>
                <th>{t('actions')}</th>
              </tr>
            </thead>
            <tbody>
              {users.map(user => (
                <tr key={user.UserId}>
                  <td>{user.UserId}</td>
                  <td>{user.Username}</td>
                  <td>{user.Email}</td>
                  <td>{user.Role}</td>
                  <td>
                    <button onClick={() => deleteUser(user.UserId)}>🗑️ {t('delete')}</button>
                    <button onClick={() => setSelectedUserId(user.UserId)}>🔧 {t('changeRole')}</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>

          {selectedUserId && (
            <div className="role-editor">
              <h4>{t('changeRoleFor')} #{selectedUserId}</h4>
              <select value={newRole} onChange={(e) => setNewRole(e.target.value)}>
                <option value="">{t('selectRole')}</option>
                <option value="User">User</option>
                <option value="Admin">Admin</option>
              </select>
              <button onClick={changeUserRole}>💾 {t('save')}</button>
            </div>
          )}
        </div>
      )}

      {activeTab === "devices" && (
        <div>
          <h3>{t('manageDevices')}</h3>

          <form
            onSubmit={(e) => {
              e.preventDefault();
              registerDevice();
            }}
            className="device-form"
          >
            <input
              type="text"
              placeholder={t('deviceType')}
              value={newDeviceType}
              onChange={(e) => setNewDeviceType(e.target.value)}
            />
            <select value={newDeviceStatus} onChange={(e) => setNewDeviceStatus(e.target.value)}>
              <option value="">{t('selectStatus')}</option>
              <option value="Active">{t('active')}</option>
              <option value="Inactive">{t('inactive')}</option>
            </select>
            <button type="submit">➕ {t('addDevice')}</button>
          </form>

          <table className="device-table">
            <thead>
              <tr>
                <th>ID</th>
                <th>{t('deviceType')}</th>
                <th>{t('status')}</th>
                <th>{t('actions')}</th>
              </tr>
            </thead>
            <tbody>
              {devices.map((device) => (
                <tr key={device.DeviceId}>
                  <td>{device.DeviceId}</td>
                  <td>{device.DeviceType}</td>
                  <td>{device.Status}</td>
                  <td>
                    <button onClick={() => deleteDevice(device.DeviceId)}>🗑️ {t('delete')}</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}

export default AdminPage;
