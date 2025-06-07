// src/pages/Register.jsx
import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import LanguageToggle from "../components/LanguageToggle";
import "../assets/styles.css"; // стилі

const Register = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    username: "",
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
      await axios.post("http://localhost:5000/api/users/register", formData);
      alert("Реєстрація успішна!");
      navigate("/login");
    } catch (err) {
      setError("Помилка під час реєстрації. Спробуйте ще раз.");
    }
  };

  return (
    <div className="form-container">
      <h2>{t("register")}</h2>

      <form onSubmit={handleSubmit}>
        <label>{t("username")}</label>
        <input
          type="text"
          name="username"
          value={formData.username}
          onChange={handleChange}
          required
        />

        <label>{t("email")}</label>
        <input
          type="email"
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

        <button type="submit">{t("register")}</button>
        <button type="button" onClick={() => navigate("/login")}>
          {t("backToLogin")}
        </button>
      </form>

      <LanguageToggle />
    </div>
  );
};

export default Register;
