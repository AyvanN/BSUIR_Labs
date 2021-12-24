package com.example.lab4

import android.annotation.SuppressLint
import android.graphics.Canvas
import android.view.SurfaceHolder

class MyThread(private val mSurfaceHolder: SurfaceHolder, private val playSurfaceView: PlaySurfaceView) : Thread()
{
    private var mRunning = false
    fun setRunning(running: Boolean) {
        mRunning = running
    }

    @SuppressLint("WrongCall")
    override fun run() {
        var canvas: Canvas?
        while (mRunning) {
            canvas = null
            try {
                canvas = mSurfaceHolder.lockCanvas(null)
                synchronized(mSurfaceHolder) { playSurfaceView.onDraw(canvas) }
            } finally {
                if (canvas != null) mSurfaceHolder.unlockCanvasAndPost(canvas)
            }
        }
    }
}