package com.example.lab3

import android.annotation.SuppressLint
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ListAdapter
import android.widget.ListView
import android.provider.MediaStore

import android.content.ContentResolver
import android.database.Cursor
import android.net.Uri


val myListMovie: ArrayList<MovieInfo> = ArrayList()
var IsVideoLoaded:Boolean = false

class VideoFragment : Fragment() {

    var adapter:MyMovieAdapter?=null

    @SuppressLint("Range")
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val v: View = inflater.inflate(R.layout.fragment_video, null)

        if (!IsVideoLoaded) {
            val contentResolver: ContentResolver = context?.contentResolver!!
            val uri: Uri = MediaStore.Video.Media.EXTERNAL_CONTENT_URI

            val cursor: Cursor? = contentResolver.query(uri, null, null, null, null)

            if (cursor != null && cursor.moveToFirst()) {
                do {
                    val title: String =
                        cursor.getString(cursor.getColumnIndex(MediaStore.Video.Media.TITLE))
                    val duration: String =
                        cursor.getString(cursor.getColumnIndex(MediaStore.Video.Media.DURATION))
                    val data: String =
                        cursor.getString(cursor.getColumnIndex(MediaStore.Video.Media.DATA))
                    val videoModel = timeConversion(duration.toLong())?.let {
                        MovieInfo(title,
                            it, Uri.parse(data))
                    }

                    videoModel?.let { myListMovie.add(it) }
                } while (cursor.moveToNext())
            }
            IsVideoLoaded = true
        }

        adapter = myListMovie.let { activity?.let { it1 -> MyMovieAdapter(it1.baseContext, it) } }

        val lsListMovie: ListView? = v.findViewById(R.id.lsListMovie)

        lsListMovie?.adapter = adapter as ListAdapter?

        return v
    }

    private fun timeConversion(value: Long): String? {
        val videoTime: String
        val dur = value.toInt()
        val hrs = dur / 3600000
        val mns = dur / 60000 % 60000
        val scs = dur % 60000 / 1000
        videoTime = if (hrs > 0) {
            String.format("%02d:%02d:%02d", hrs, mns, scs)
        } else {
            String.format("%02d:%02d", mns, scs)
        }
        return videoTime
    }

}