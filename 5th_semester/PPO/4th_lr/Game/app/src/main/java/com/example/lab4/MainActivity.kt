package com.example.lab4

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import com.example.lab4.db.MyDbManager
import kotlinx.android.synthetic.main.activity_main.*
import java.util.*

var currentPlayer: Player? = null
val players: ArrayList<Player> = ArrayList()

class MainActivity : AppCompatActivity() {

    private val myDbManager = MyDbManager(this)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        if(players.size == 0)
        {
            myDbManager.openDb()
            val dataList = myDbManager.readDbData()
             if(dataList.isEmpty())
            {
                myDbManager.insert("Ivan","kusodu","10:09")
                dataList.add(Player("Ivan","kusodu","10:09"))
                myDbManager.insert("Daniil","Pos9","10:05")
                dataList.add(Player("Daniil","Daniil","10:05"))
                myDbManager.insert("Egor","Kild","00:25")
                dataList.add(Player("Egor","Kild","00:25"))
            }
            for(item in dataList)
            {
                players.add(item)
            }
            myDbManager.closeDb()
        }

        btnPlay.setOnClickListener {
            if (currentPlayer != null)
            {
                btnLog.setText(R.string.btn_log_in)
                btnLog.setOnClickListener {
                    logInDialog()
                }
                val intent = Intent(this@MainActivity, PlayActivity::class.java)
                startActivity(intent)
            }
        }
        btnRecords.setOnClickListener {
            val intent = Intent(this@MainActivity, RecordsActivity::class.java)
            startActivity(intent)
        }
        btnLog.setOnClickListener {
            logInDialog()
        }
    }
    private fun logInDialog()
    {
        val builder = AlertDialog.Builder(this)
        val inflater: LayoutInflater = getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
        val view: View = inflater.inflate(R.layout.log_in_layot, null)
        builder.setView(view)
        builder.setPositiveButton("OK"
        ) { dialog, id ->
            logInPlayer(view)
            dialog.cancel()
        }
        builder.create()
        builder.show()
    }

    private fun logInPlayer(view: View)
    {
        val realName: String = (view.findViewById(R.id.editRealName) as EditText).text.toString()
        val userName: String = (view.findViewById(R.id.editUserName) as EditText).text.toString()
        if (players.indexOfFirst{it.userName == userName} == -1)
        {
            currentPlayer = Player(realName,userName,"00:00")
            btnLog.setText(R.string.btn_log_out)
            btnLog.setOnClickListener {
                logOutPlayer()
            }
        }
        else
        {
            Toast.makeText(applicationContext, R.string.user_name_exist, Toast.LENGTH_SHORT).show()
        }
    }
    private fun logOutPlayer()
    {
        currentPlayer = null
        btnLog.setText(R.string.btn_log_in)
        btnLog.setOnClickListener {
            logInDialog()
        }
    }
}