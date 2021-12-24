package com.example.lab3


import android.content.Intent
import android.os.Bundle
import android.os.Handler
import android.view.View
import android.widget.SeekBar
import android.widget.SeekBar.OnSeekBarChangeListener
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_video.*


class VideoActivity : AppCompatActivity() {

    lateinit var mHandler: Handler
    lateinit var handler: Handler
    private var visibility:Boolean = true
    private var pos: Int = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_video)
        setVideo()
        setTitle("Video");
    }


    private fun setVideo() {
        mHandler = Handler()
        handler = Handler()
        videoView.setOnPreparedListener {
            setVideoProgress()
        }
        playVideo()
        prevVideo()
        nextVideo()
        setForward()
        setPause()
        hideLayout()
    }

    // play video file
    private fun playVideo() {
        try {
            videoView.setVideoURI(myListMovie[currentMoviePosition].MovieURL)
            videoView.start()
            pause.setImageResource(R.drawable.pause_white)
        } catch (e: Exception) {
            e.printStackTrace()
        }
    }

    //pause video
    private fun setPause() {
        pause.setOnClickListener {
            if (videoView.isPlaying) {
                videoView.pause()
                pause.setImageResource(R.drawable.play_white)
            } else {
                videoView.start()
                pause.setImageResource(R.drawable.pause_white)
            }
        }
    }

    //play previous video
    private fun prevVideo() {
        prev.setOnClickListener {
            if (currentMoviePosition > 0) {
                currentMoviePosition--
                playVideo()
            }
        }
    }

    //play next video
    fun nextVideo() {
        next.setOnClickListener {
            if (currentMoviePosition < myListMovie.size - 1) {
                currentMoviePosition++
                playVideo()
            }
        }
    }


    private fun setForward()
    {
        backward.setOnClickListener {
            videoView.seekTo(videoView.currentPosition - 10000)
        }
        forward.setOnClickListener {
            videoView.seekTo(videoView.currentPosition + 10000)
        }
    }

    // display video progress
    private fun setVideoProgress() {
        //get the video duration
        var currentPos = videoView.currentPosition
        val totalDuration = videoView.duration

        //display video duration
        total.text = timeConversion(totalDuration)
        current.text = timeConversion(currentPos)
        seekBar.max = totalDuration
        val handler = Handler()
        val runnable: Runnable = object : Runnable {
            override fun run() {
                try {
                    currentPos = videoView.currentPosition
                    current.text = timeConversion(currentPos)
                    seekBar.progress = currentPos
                    handler.postDelayed(this, 1000)
                } catch (ed: IllegalStateException) {
                    ed.printStackTrace()
                }
            }
        }
        handler.postDelayed(runnable, 1000)

        //seekbar change listner
        seekBar.setOnSeekBarChangeListener(object : OnSeekBarChangeListener {
            override fun onProgressChanged(seekBar: SeekBar, progress: Int, fromUser: Boolean) {}
            override fun onStartTrackingTouch(seekBar: SeekBar) {}
            override fun onStopTrackingTouch(seekBar: SeekBar) {
                currentPos = seekBar.progress
                videoView.seekTo(currentPos)
            }
        })
    }

    //time conversion

    fun timeConversion(value: Int): String? {
        val songTime: String
        val hrs = value / 3600000
        val mns = value / 60000 % 60000
        val scs = value % 60000 / 1000
        songTime = if (hrs > 0) {
            String.format("%02d:%02d:%02d", hrs, mns, scs)
        } else {
            String.format("%02d:%02d", mns, scs)
        }
        return songTime
    }

    // hide progress when the video is playing
    private fun hideLayout() {
        relative.setOnClickListener {
            if (visibility) {
                val decorView = window.decorView
                // Hide the status bar.
                val uiOptions = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION)
                decorView.systemUiVisibility = uiOptions

                showProgress.visibility = View.GONE
                visibility = false
            } else {
                showProgress.visibility = View.VISIBLE
                visibility = true
            }
        }
    }
    override fun onRestoreInstanceState(savedInstanceState: Bundle) {
        super.onRestoreInstanceState(savedInstanceState)
        pos = savedInstanceState.getInt("position")
        videoView.seekTo(pos)
        //math_operation.text = savedInstanceState.getString("math_operation")
        //result_text.text = savedInstanceState.getString("result_text")
    }

    override fun onSaveInstanceState(outState: Bundle) {
        super.onSaveInstanceState(outState)
        outState.putInt("position", pos)
        //outState.putString("math_operation", math_operation.text.toString())
        //outState.putString("result_text", result_text.text.toString())
    }

    override fun onPause() {
        super.onPause()
        pos = videoView.currentPosition
    }
}