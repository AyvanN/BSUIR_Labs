package com.example.lab3

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ListAdapter
import android.widget.ListView
import androidx.fragment.app.Fragment
import com.mtechviral.mplaylib.MusicFinder
import kotlinx.coroutines.async
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking


val myListSong: ArrayList<SongInfo> = ArrayList<SongInfo>()
var IsAudioLoaded:Boolean = false

class AudioFragment : Fragment() {

    var adapter:MySongAdapter?=null

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        if (!IsAudioLoaded)
        {
            var songsJob = runBlocking{
                async{
                    val songFinder = MusicFinder(activity?.contentResolver)
                    songFinder.prepare()
                    songFinder.allSongs
                }
            }
            runBlocking{
                launch{
                    val songs = songsJob.await()
                    songs.forEach()
                    {
                        myListSong?.add(SongInfo(it.title,it.artist,it.uri))
                    }
                    IsAudioLoaded = true
                }
            }
        }
        val v: View = inflater.inflate(R.layout.fragment_music, null)

        adapter = myListSong?.let { activity?.let { it1 -> MySongAdapter(it1.baseContext) } }

        val lsListSongs: ListView? = v.findViewById(R.id.lsListSongs)

        lsListSongs?.adapter = adapter as ListAdapter?

        return v
    }

}