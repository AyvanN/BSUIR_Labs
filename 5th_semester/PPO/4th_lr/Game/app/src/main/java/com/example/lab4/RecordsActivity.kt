package com.example.lab4

import android.content.Intent
import android.os.Bundle
import android.widget.ListView
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_records.*

class RecordsActivity : AppCompatActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_records)

        btnBack.setOnClickListener {
            val intent = Intent(this@RecordsActivity, MainActivity::class.java)
            startActivity(intent)
        }

        val listAdapter = RecordsAdapter(this, players)

        val playersList: ListView = findViewById(R.id.playersList)

        playersList.adapter = listAdapter
    }
}