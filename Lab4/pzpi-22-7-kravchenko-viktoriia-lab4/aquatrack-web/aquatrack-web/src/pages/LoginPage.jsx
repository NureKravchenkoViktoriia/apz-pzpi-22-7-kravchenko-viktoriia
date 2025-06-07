// src/pages/Login.jsx
import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import LanguageToggle from "../components/LanguageToggle";
import "../assets/styles.css";

const Login = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    email: "",
    passwordHash: "",
  });

  const [error, setError] = useState("");

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

const handleSubmit = async (e) => {
  e.preventDefault();
  setError("");

  try {
    const url = `http://localhost:5000/api/users/login?email=${encodeURIComponent(formData.email)}&password=${encodeURIComponent(formData.passwordHash)}`;
    const response = await axios.post(url, null);

    localStorage.setItem("userId", response.data.UserId);
    localStorage.setItem("username", response.data.Username);
    localStorage.setItem("role", response.data.Role);

    alert(t("loginSuccess"));

    if (response.data.Role === "Admin") {
      navigate("/admin");    // сторінка для адміністратора
    } else {
      navigate("/user");     // сторінка для звичайного користувача
    }
  } catch (err) {
    setError(t("loginError"));
  }
};


  return (
    <div className="form-container">
      <h2>{t("login")}</h2>

      <form onSubmit={handleSubmit}>
        <label>{t("email")}</label>
        <input
          type="text"
          name="email"
          value={formData.email}
          onChange={handleChange}
          required
        />

        <label>{t("password")}</label>
        <input
          type="password"
          name="passwordHash"
          value={formData.passwordHash}
          onChange={handleChange}
          required
        />

        {error && <p className="error">{error}</p>}

        <button type="submit">{t("login")}</button>
        <button type="button" onClick={() => navigate("/register")}>
          {t("goToRegister")}
        </button>
      </form>

      <LanguageToggle />
    </div>
  );
};

export default Login;
