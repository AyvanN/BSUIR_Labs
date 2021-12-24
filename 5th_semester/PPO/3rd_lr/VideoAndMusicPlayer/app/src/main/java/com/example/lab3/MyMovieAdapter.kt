package com.example.lab3

import android.content.Context
import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import androidx.core.content.ContextCompat
import kotlinx.android.synthetic.main.music_picker.view.*

var currentMoviePosition:Int = 0

class MyMovieAdapter(var context: Context, var myListMovie: ArrayList<MovieInfo>) : BaseAdapter()
{
    override fun getView(postion: Int, p1: View?, p2: ViewGroup?): View {
        val inflater = context.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
        val myView= inflater.inflate(R.layout.video_picker, p2, false)

        val movie = this.myListMovie[postion]
       myView.tvSongName.text = movie.Title
        //myView.buPlay.text = movie.duration

        myView.buPlay.setOnClickListener{
            currentMoviePosition = postion
            val intent = Intent(context, VideoActivity::class.java)
            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK
            ContextCompat.startActivity(context, intent, null)
        }
        return  myView
    }

    override fun getItem(item: Int): Any {
        return this.myListMovie[item]
    }

    override fun getItemId(p0: Int): Long {
        return  p0.toLong()
    }

    override fun getCount(): Int {
        return this.myListMovie.size
    }
}