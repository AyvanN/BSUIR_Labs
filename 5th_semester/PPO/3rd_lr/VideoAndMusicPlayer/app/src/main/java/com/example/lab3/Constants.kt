package com.example.lab3

import android.content.Context

import android.graphics.BitmapFactory

import android.graphics.Bitmap
import java.lang.Error
import java.lang.Exception


object Constants {
    fun getDefaultAlbumArt(context: Context): Bitmap? {
        var bm: Bitmap? = null
        val options = BitmapFactory.Options()
        try {
            bm = BitmapFactory.decodeResource(
                context.getResources(),
                R.drawable.pause, options
            )
        } catch (ee: Error) {
        } catch (e: Exception) {
        }
        return bm
    }

    interface ACTION {
        companion object {
            const val MAIN_ACTION = "com.marothiatechs.customnotification.action.main"
            const val INIT_ACTION = "com.marothiatechs.customnotification.action.init"
            const val BACKWARD_ACTION = "com.marothiatechs.customnotification.action.prev"
            const val PLAY_ACTION = "com.marothiatechs.customnotification.action.play"
            const val FORWARD_ACTION = "com.marothiatechs.customnotification.action.next"
            const val STARTFOREGROUND_ACTION =
                "com.marothiatechs.customnotification.action.startforeground"
            const val STOPFOREGROUND_ACTION =
                "com.marothiatechs.customnotification.action.stopforeground"
        }
    }

    interface NOTIFICATION_ID {
        companion object {
            const val FOREGROUND_SERVICE = 101
        }
    }
}