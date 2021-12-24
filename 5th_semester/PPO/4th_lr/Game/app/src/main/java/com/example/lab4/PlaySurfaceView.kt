package com.example.lab4

import android.content.Context
import android.graphics.*
import android.util.AttributeSet
import android.util.Log
import android.view.SurfaceHolder
import android.view.SurfaceView
import java.util.*
import kotlin.math.cos
import kotlin.math.roundToInt
import kotlin.math.sin


class PlaySurfaceView(context: Context?, attrs: AttributeSet?) :
    SurfaceView(context), SurfaceHolder.Callback {
    var myThread: MyThread? = null
    private var mPaint: Paint? = null
    var platform: Rect? = null
    var platformWidth = 0
    var platformX = 0f
    var platformSpeed = 0f
    var ballX = 0
    var ballY = 0
    var ballRadius = 0
    var ballAngle = 0.0
    var ballSpeed = 0.0
    var maxAngleRandomModifier = 0.0
    var ballAcceleration = 0
    var currentAcceleration = 0
    private fun accelerateBall() {
        if (currentAcceleration++ == ballAcceleration) {
            ballSpeed += 0.1
            currentAcceleration = 0
        }
    }

    var lose = false
    var isActive = false
    override fun surfaceCreated(holder: SurfaceHolder) {
        mPaint = Paint()
        initPlatform()
        initBall()
        myThread = MyThread(getHolder(), this)
        myThread!!.setRunning(true)
        myThread!!.start()
    }

    override fun surfaceChanged(holder: SurfaceHolder, format: Int, width: Int, height: Int) {}
    override fun surfaceDestroyed(holder: SurfaceHolder) {
        var retry = true
        myThread!!.setRunning(false)
        while (retry) {
            try {
                myThread!!.join()
                retry = false
            } catch (e: InterruptedException) {
            }
        }
    }

    private fun initPlatform() {
        platform = Rect()
        platformWidth = 200
        platformX = (width / 2).toFloat()
        platformSpeed = 7f
    }

    private fun initBall() {
        ballX = width / 2
        ballY = height / 2
        ballRadius = 20
        ballSpeed = 6.0
        maxAngleRandomModifier = 6.0
        ballAcceleration = 1000
        val r = Random()
        val rand = -45 + 90 * r.nextDouble()
        ballAngle = 270.0 + rand
    }

    @JvmName("setPlatformX1")
    fun setPlatformX(platformX: Float) {
        if (platformX >= width - platformWidth / 2) {
            this.platformX = (width - platformWidth / 2).toFloat()
        } else if (platformX <= platformWidth / 2) {
            this.platformX = (platformWidth / 2).toFloat()
        } else this.platformX = platformX
    }

    fun movePlatform(value: Float) {
        if (isActive) setPlatformX(platformX + value * platformSpeed)
    }

    private fun rotateBall(angle: Double) {
        val r = Random()
        val rand = -maxAngleRandomModifier + 2 * maxAngleRandomModifier * r.nextDouble()
        ballAngle = (angle - ballAngle + rand) % 360
    }

    private fun moveBall() {
        if (isActive) {
            ballX += (ballSpeed * cos(Math.toRadians(ballAngle))).toInt()
            ballY -= (ballSpeed * sin(Math.toRadians(ballAngle))).toInt()
            if (ballY >= height - 100 && ballY <= height - 99 + ballSpeed && ballX >= platformX - platformWidth / 2 && ballX <= platformX + platformWidth / 2) {
                ballAngle = 360 - ballAngle
            } else if (ballY <= 0 && (ballX >= width || ballX <= 0)) {
                ballAngle = (ballAngle + 180) % 360.0
            } else if (ballY <= 0) {
                rotateBall(360.0)
            } else if (ballX >= width || ballX <= 0) {
                rotateBall(180.0)
            } else if (ballY > height) {
                isActive = false
                lose = true
            } else return
            ballX += (ballSpeed * cos(Math.toRadians(ballAngle))).toInt()
            ballY -= (ballSpeed * sin(Math.toRadians(ballAngle))).toInt()
        }
    }

    public override fun onDraw(canvas: Canvas?) {
        if (canvas != null) {
            canvas.drawColor(Color.BLACK)
            mPaint!!.color = Color.WHITE
            mPaint!!.style = Paint.Style.FILL
            canvas.drawCircle(ballX.toFloat(), ballY.toFloat(), ballRadius.toFloat(), mPaint!!)
            moveBall()
            accelerateBall()
            mPaint!!.color = Color.RED
            platform!![(platformX - platformWidth / 2).roundToInt(), height - 100, (platformX + platformWidth / 2).roundToInt()] =
                height - 50
            canvas.drawRect(platform!!, mPaint!!)
        }
    }

    init {
        holder.addCallback(this)
    }
}