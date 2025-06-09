package com.example.aquatrack

import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentActivity
import androidx.viewpager2.adapter.FragmentStateAdapter
import com.example.aquatrack.MonitoringFragment
import com.example.aquatrack.LimitFragment

class UserPagerAdapter(activity: FragmentActivity) : FragmentStateAdapter(activity) {

    override fun getItemCount(): Int = 2

    override fun createFragment(position: Int): Fragment {
        return when (position) {
            0 -> MonitoringFragment()
            1 -> LimitFragment()
            else -> throw IllegalArgumentException("Invalid tab position")
        }
    }
}
