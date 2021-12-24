package com.example.lab4

import android.content.Intent
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler
import android.view.View
import android.widget.FrameLayout
import com.example.lab4.db.MyDbManager
import kotlinx.android.synthetic.main.activity_play.*
import java.lang.IllegalStateException
import kotlin.math.roundToInt

class PlayActivity : AppCompatActivity(), SensorEventListener {
    var sensorManager: SensorManager? = null
    var orientationSensor: Sensor? = null
    var playSurfaceView: PlaySurfaceView? = null
    var timerActive = false
    var time = 0.0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_play)
        supportActionBar!!.hide()
        sensorManager = getSystemService(SENSOR_SERVICE) as SensorManager
        orientationSensor = sensorManager!!.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)
        playSurfaceView = (findViewById<View>(R.id.frame_layout) as FrameLayout).getChildAt(0) as PlaySurfaceView
        notification.text = "Tap to PLAY"
        notification.setOnClickListener {
            playSurfaceView!!.isActive = true
            timerActive = true
            pause.visibility = View.VISIBLE
            notification.visibility = View.GONE
        }
        val handler = Handler()
        val runnable: Runnable = object : Runnable {
            override fun run() {
                try {
                    if (playSurfaceView!!.lose) {
                        notification.text = """Result is ${timer.text} 
                            |Tap to see records""".trimMargin()
                        notification.visibility = View.VISIBLE
                        pause.visibility = View.GONE
                        timer.visibility = View.GONE
                        timerActive = false
                        val myDbManager = MyDbManager(baseContext)
                        myDbManager.openDb()
                        myDbManager.insert(currentPlayer!!.realName, currentPlayer!!.userName, timer.text.toString())
                        myDbManager.closeDb()
                        currentPlayer!!.gameTime = timer.text.toString()
                        players.add(currentPlayer!!)
                        notification.setOnClickListener { summonDashboard() }
                        playSurfaceView!!.lose = false
                        currentPlayer = null
                    }
                    handler.postDelayed(this, 0)
                } catch (ed: IllegalStateException) {
                }
            }
        }
        handler.postDelayed(runnable, 0)
        val timerHandler = Handler()
        val timerRunnable: Runnable = object : Runnable {
            override fun run() {
                try {
                    if (timerActive) {
                        var seconds = time.roundToInt()
                        val minutes = seconds % 3600 / 60
                        seconds = seconds % 60
                        timer.text = String.format("%02d:%02d", minutes, seconds)
                        time += 0.01
                    }
                    timerHandler.postDelayed(this, 10)
                } catch (ed: IllegalStateException) {
                }
            }
        }
        timerHandler.postDelayed(timerRunnable, 0)
    }

    fun summonDashboard() {
        val intent = Intent(this, RecordsActivity::class.java)
        startActivity(intent)
    }

    fun omMenuPlayed(view: View?) {
        if (playSurfaceView!!.isActive) {
            playSurfaceView!!.isActive = false
            timerActive = false
            pause!!.setImageDrawable(getDrawable(R.drawable.play_white))
        } else {
            playSurfaceView!!.isActive = true
            timerActive = true
            pause!!.setImageDrawable(getDrawable(R.drawable.pause_white))
        }
    }

    override fun onSensorChanged(event: SensorEvent) {
        val ORIENTATION_UNKNOWN = -1
        val _DATA_X = 0
        val _DATA_Y = 1
        val _DATA_Z = 2
        if (event.sensor.type == Sensor.TYPE_ACCELEROMETER) {
            val values = event.values
            if (playSurfaceView != null) playSurfaceView!!.movePlatform(values[_DATA_Y])
        }
    }

    override fun onAccuracyChanged(sensor: Sensor, accuracy: Int) {}
    override fun onPause() {
        super.onPause()
        if (sensorManager != null) sensorManager!!.unregisterListener(this)
    }

    override fun onResume() {
        super.onResume()
        if (sensorManager != null) sensorManager!!.registerListener(
            this,
            orientationSensor,
            SensorManager.SENSOR_DELAY_NORMAL
        )
    }

}