package com.example.lab2;

import android.os.Build;

import androidx.annotation.RequiresApi;

import java.util.Arrays;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.IntStream;

public class Applicant {
    public String first_name;
    public String second_name;
    public String patronymic;
    public String address;
    public String marks;
    public boolean selected = false;

    public Applicant() {}

    public Applicant(String first_name, String second_name, String patronymic,
                     String address, String marks, boolean selected) {

        this.first_name = first_name;
        this.second_name = second_name;
        this.patronymic = patronymic;
        this.address = address;
        this.marks = marks;
        this.selected = selected;
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    public String getAverageMark() {
        List<String> marksList = Arrays.asList(marks.split(","));
        if (marksList.size() < 1)
            return "-";
        double result = 0;
        for (int i = 0; i < marksList.size(); i++) {
            try {
                result += Double.parseDouble(marksList.get(i));
            }
            catch (NumberFormatException e) {
                return "-";
            }
        }
        return String.format("%.2f",result / marksList.size());
    }

    public String getFullName() {
        return this.first_name + " " + this.second_name + " " + this.patronymic;
    }
}
