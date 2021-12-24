package com.example.lab4

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.TextView
import java.util.*

class RecordsAdapter(var context: Context, private var objects: ArrayList<Player>): BaseAdapter()
{
    private var lInflater: LayoutInflater? = null

    init {
        lInflater = context.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater?
    }

    override fun getCount(): Int
    {
        return objects.size
    }

    override fun getItem(position: Int): Any {
        return objects[position]
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        var view: View? = convertView
        if (view == null) {
            view = lInflater?.inflate(R.layout.record, parent, false)
        }
        val player = getItem(position) as Player

        val realName = view?.findViewById(R.id.realName) as TextView
        realName.text = player.realName

        val userName = view.findViewById(R.id.userName) as TextView
        userName.text = player.userName

        val time = view.findViewById(R.id.time) as TextView
        time.text = player.gameTime

        return view
    }
}