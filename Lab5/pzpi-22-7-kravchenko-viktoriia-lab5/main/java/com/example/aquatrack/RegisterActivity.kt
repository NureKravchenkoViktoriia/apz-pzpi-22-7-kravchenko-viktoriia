package com.example.aquatrack

import android.content.Context
import android.content.Intent
import android.content.SharedPreferences
import android.os.Bundle
import android.widget.*
import androidx.appcompat.app.AppCompatActivity

class RegisterActivity : AppCompatActivity() {

    private lateinit var etUsername: EditText
    private lateinit var etEmail: EditText
    private lateinit var etPassword: EditText
    private lateinit var btnRegister: Button
    private lateinit var btnBackToLogin: Button
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
        setContentView(R.layout.activity_register)

        prefs = getSharedPreferences("settings", MODE_PRIVATE)
        currentLang = prefs.getString("lang", "uk") ?: "uk"

        etUsername = findViewById(R.id.etUsername)
        etEmail = findViewById(R.id.etEmail)
        etPassword = findViewById(R.id.etPassword)
        btnRegister = findViewById(R.id.btnRegister)
        btnBackToLogin = findViewById(R.id.btnBackToLogin)
        btnToggleLanguage = findViewById(R.id.btnToggleLanguage)

        btnRegister.setOnClickListener {
            val username = etUsername.text.toString().trim()
            val email = etEmail.text.toString().trim()
            val password = etPassword.text.toString()

            if (username.isEmpty() || email.isEmpty() || password.isEmpty()) {
                Toast.makeText(this, getString(R.string.fill_all_fields), Toast.LENGTH_SHORT).show()
            } else {
                val userPrefs = getSharedPreferences("user_data", MODE_PRIVATE)
                userPrefs.edit()
                    .putString("email", email)
                    .putString("password", password)
                    .putString("username", username)
                    .apply()

                Toast.makeText(this, getString(R.string.user_registered), Toast.LENGTH_SHORT).show()
                startActivity(Intent(this, LoginActivity::class.java))
                finish()
            }
        }

        btnBackToLogin.setOnClickListener {
            startActivity(Intent(this, LoginActivity::class.java))
            finish()
        }

        btnToggleLanguage.setOnClickListener {
            val newLang = if (currentLang == "uk") "en" else "uk"
            prefs.edit().putString("lang", newLang).apply()
            recreate()
        }
    }
}
