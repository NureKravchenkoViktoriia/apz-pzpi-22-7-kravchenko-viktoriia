package com.example.aquatrack

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.fragment.app.Fragment

class LimitFragment : Fragment() {

    private lateinit var limitStart: DatePicker
    private lateinit var limitEnd: DatePicker
    private lateinit var etAmount: EditText
    private lateinit var etDevice: EditText
    private lateinit var btnCreate: Button
    private lateinit var tvOutput: TextView

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val view = inflater.inflate(R.layout.fragment_limit, container, false)

        limitStart = view.findViewById(R.id.limitStartDate)
        limitEnd = view.findViewById(R.id.limitEndDate)
        etAmount = view.findViewById(R.id.etWaterAmount)
        etDevice = view.findViewById(R.id.etDeviceNumber)
        btnCreate = view.findViewById(R.id.btnCreateLimit)
        tvOutput = view.findViewById(R.id.tvLimitsResult)

        btnCreate.setOnClickListener {
            val start = "${limitStart.year}-${limitStart.month + 1}-${limitStart.dayOfMonth}"
            val end = "${limitEnd.year}-${limitEnd.month + 1}-${limitEnd.dayOfMonth}"
            val amount = etAmount.text.toString()
            val device = etDevice.text.toString()

            if (amount.isNotEmpty() && device.isNotEmpty()) {
                tvOutput.text = getString(R.string.limit_set, start, end, amount, device)
            } else {
                Toast.makeText(requireContext(), getString(R.string.fill_all_fields), Toast.LENGTH_SHORT).show()
            }
        }


        return view
    }
}
