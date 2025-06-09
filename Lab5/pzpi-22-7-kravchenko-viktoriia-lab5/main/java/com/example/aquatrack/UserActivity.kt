package com.example.aquatrack

import android.content.Context
import android.content.SharedPreferences
import android.os.Bundle
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import com.google.android.material.tabs.TabLayout
import androidx.viewpager2.widget.ViewPager2
import com.google.android.material.tabs.TabLayoutMediator
import com.example.aquatrack.UserPagerAdapter

class UserActivity : AppCompatActivity() {

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
        setContentView(R.layout.activity_user)

        prefs = getSharedPreferences("settings", MODE_PRIVATE)
        currentLang = prefs.getString("lang", "uk") ?: "uk"

        val tabLayout = findViewById<TabLayout>(R.id.tabLayout)
        val viewPager = findViewById<ViewPager2>(R.id.viewPager)
        val btnToggleLanguage = findViewById<Button>(R.id.btnToggleLanguageUser)

        viewPager.adapter = UserPagerAdapter(this)

        TabLayoutMediator(tabLayout, viewPager) { tab, position ->
            tab.text = when (position) {
                0 -> getString(R.string.monitoring)
                1 -> getString(R.string.limits)
                else -> ""
            }
        }.attach()

        btnToggleLanguage.setOnClickListener {
            val newLang = if (currentLang == "uk") "en" else "uk"
            prefs.edit().putString("lang", newLang).apply()
            recreate()
        }
    }
}
