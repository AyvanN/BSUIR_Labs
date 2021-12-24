package com.example.lab3

import android.content.Context
import android.content.Intent
import android.content.Intent.FLAG_ACTIVITY_NEW_TASK
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import androidx.core.content.ContextCompat.startActivity
import kotlinx.android.synthetic.main.music_picker.view.*


var currentSongPosition:Int = 0


class MySongAdapter(var context: Context) : BaseAdapter()
{
    override fun getView(postion: Int, p1: View?, p2: ViewGroup?): View {
        val inflater = context.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
        val myView= inflater.inflate(R.layout.music_picker, p2, false)
        val song= myListSong[postion]
        myView.tvSongName.text = song.Title
        myView.tvSongName.isSelected = true
        myView.buPlay.isSelected = true
        myView.buPlay.setOnClickListener{
            currentSongPosition = postion
            val intent = Intent(context, AudioActivity::class.java)
            intent.flags = FLAG_ACTIVITY_NEW_TASK
            startActivity(context,intent,null)
        }
        return  myView
    }

    override fun getItem(item: Int): Any {
        return myListSong[item]
    }

    override fun getItemId(p0: Int): Long {
        return  p0.toLong()
    }

    override fun getCount(): Int {
        return myListSong.size
    }
}
