package com.example.aquatrack

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.fragment.app.Fragment


class MonitoringFragment : Fragment() {

    private lateinit var startDate: DatePicker
    private lateinit var endDate: DatePicker
    private lateinit var btnShowData: Button
    private lateinit var tvResult: TextView

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val view = inflater.inflate(R.layout.fragment_monitoring, container, false)

        startDate = view.findViewById(R.id.startDatePicker)
        endDate = view.findViewById(R.id.endDatePicker)
        btnShowData = view.findViewById(R.id.btnShowData)
        tvResult = view.findViewById(R.id.tvResult)

        btnShowData.setOnClickListener {
            val start = "${startDate.year}-${startDate.month + 1}-${startDate.dayOfMonth}"
            val end = "${endDate.year}-${endDate.month + 1}-${endDate.dayOfMonth}"
            tvResult.text = getString(R.string.usage_result, start, end)
        }

        return view
    }
}
