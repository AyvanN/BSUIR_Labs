package com.example.lab4.db

import android.provider.BaseColumns

class MyDbNameClass : BaseColumns
{
    companion object {
        const val TABLE_NAME = "my_table"
        const val COLUMN_NAME_REAL_NAME = "realName"
        const val COLUMN_NAME_USER_NAME = "userName"
        const val COLUMN_NAME_GAME_TIME = "gameTime"

        const val DATABASE_VERSION = 2
        const val DATABASE_NAME = "MyDb.db"

        const val CREATE_TABLE = "CREATE TABLE  IF NOT EXISTS $TABLE_NAME (" +
                "${BaseColumns._ID} INTEGER PRIMARY KEY," +
                "$COLUMN_NAME_REAL_NAME TEXT,"+
                "$COLUMN_NAME_USER_NAME TEXT,"+
                "$COLUMN_NAME_GAME_TIME TEXT)"
        const val DELETE_TABLE = "DROP TABLE IF EXISTS $TABLE_NAME"
    }

}