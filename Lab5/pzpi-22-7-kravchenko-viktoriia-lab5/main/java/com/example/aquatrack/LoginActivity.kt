package com.example.aquatrack

import android.content.Context
import android.content.Intent
import android.content.SharedPreferences
import android.os.Bundle
import android.widget.*
import androidx.appcompat.app.AppCompatActivity

class LoginActivity : AppCompatActivity() {

    private lateinit var etEmail: EditText
    private lateinit var etPassword: EditText
    private lateinit var btnLogin: Button
    private lateinit var btnGoToRegister: Button
    private lateinit var btnToggleLanguage: Button

    private lateinit var prefs: SharedPreferences
    private var currentLang: String = "uk"

    override fun attachBaseContext(newBase: Context) {
        val prefs = newBase.getSharedPreferences("settings", Context.MODE_PRIVATE)
        val lang = prefs.getString("lang", "uk") ?: "uk"
        val context = LocaleHelper.setLocale(newBase, lang)
        super.attachBaseContext(context)
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        prefs = getSharedPreferences("settings", MODE_PRIVATE)
        currentLang = prefs.getString("lang", "uk") ?: "uk"

        etEmail = findViewById(R.id.etLoginEmail)
        etPassword = findViewById(R.id.etLoginPassword)
        btnLogin = findViewById(R.id.btnLogin)
        btnGoToRegister = findViewById(R.id.btnGoToRegister)
        btnToggleLanguage = findViewById(R.id.btnToggleLanguageLogin)

        btnLogin.setOnClickListener {
            val email = etEmail.text.toString().trim()
            val password = etPassword.text.toString()

            if (email.isEmpty() || password.isEmpty()) {
                Toast.makeText(this, getString(R.string.enter_email_password), Toast.LENGTH_SHORT).show()
            } else {
                val userPrefs = getSharedPreferences("user_data", MODE_PRIVATE)
                val storedEmail = userPrefs.getString("email", "")
                val storedPassword = userPrefs.getString("password", "")

                if (email == storedEmail && password == storedPassword) {
                    Toast.makeText(this, getString(R.string.login_success), Toast.LENGTH_SHORT).show()
                    startActivity(Intent(this, UserActivity::class.java))
                    finish()
                } else {
                    Toast.makeText(this, getString(R.string.invalid_credentials), Toast.LENGTH_SHORT).show()
                }
            }
        }

        btnGoToRegister.setOnClickListener {
            startActivity(Intent(this, RegisterActivity::class.java))
            finish()
        }

        btnToggleLanguage.setOnClickListener {
            val newLang = if (currentLang == "uk") "en" else "uk"
            prefs.edit().putString("lang", newLang).apply()
            recreate()
        }
    }
}
