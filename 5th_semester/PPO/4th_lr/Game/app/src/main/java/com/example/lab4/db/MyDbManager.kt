package com.example.lab4.db

import android.annotation.SuppressLint
import android.content.ContentValues
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.provider.BaseColumns
import com.example.lab4.Player

class MyDbManager(context: Context) {
    private val myDbHelper = MyDbHelper(context)
    private var db : SQLiteDatabase? = null

    fun openDb()
    {
        db = myDbHelper.writableDatabase
    }
    fun insert(title: String, content: String, time: String)
    {
        val values = ContentValues().apply {
            put(MyDbNameClass.COLUMN_NAME_REAL_NAME, title)
            put(MyDbNameClass.COLUMN_NAME_USER_NAME, content)
            put(MyDbNameClass.COLUMN_NAME_GAME_TIME, time)
        }
        db?.insert(MyDbNameClass.TABLE_NAME, null, values)
    }
    @SuppressLint("Range")
    fun readDbData() : ArrayList<Player>
    {
        val dataList = java.util.ArrayList<Player>()
        //val cursor = db?.query(MyDbNameClass.TABLE_NAME, null, null, null, null, null, MyDbNameClass.COLUMN_NAME_GAME_TIME)
        val cursor = db?.rawQuery("SELECT * FROM ${MyDbNameClass.TABLE_NAME} ORDER BY ${MyDbNameClass.COLUMN_NAME_GAME_TIME} DESC;", null)
        with(cursor)
        {
            while (this?.moveToNext()!!)
            {
                val realName = cursor?.getString(cursor.getColumnIndex(MyDbNameClass.COLUMN_NAME_REAL_NAME))
                val userName = cursor?.getString(cursor.getColumnIndex(MyDbNameClass.COLUMN_NAME_USER_NAME))
                val time = cursor?.getString(cursor.getColumnIndex(MyDbNameClass.COLUMN_NAME_GAME_TIME))
                dataList.add(Player(realName!!,userName!!,time!!))
            }
        }
        return  dataList
    }

    fun closeDb()
    {
        myDbHelper.close()
    }

}