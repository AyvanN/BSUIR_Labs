package com.example.lab2;

import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

public class ApplicantAdapter extends ArrayAdapter<Applicant> {

    private LayoutInflater inflater;
    private int layout;
    private List<Applicant> applicants;

    public ApplicantAdapter(Context context, int resource, List<Applicant> applicants) {
        super(context, resource, applicants);
        this.applicants = applicants;
        this.layout = resource;
        this.inflater = LayoutInflater.from(context);
    }

    public View getView(int position, View convertView, ViewGroup parent) {
        View view = inflater.inflate(this.layout, parent, false);

        TextView full_name = view.findViewById(R.id.full_name);
        TextView addressView = view.findViewById(R.id.address);
        TextView averageMarkView = view.findViewById(R.id.average_mark);

        Applicant applicant = applicants.get(position);
        full_name.setText(applicant.getFullName());
        addressView.setText(applicant.address);
        averageMarkView.setText(applicant.getAverageMark());

        if (applicant.selected)
            view.setBackgroundColor(Color.YELLOW);
        else
            view.setBackgroundColor(Color.WHITE);

        return view;
    }
}