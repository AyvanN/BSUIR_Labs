package com.example.lab2;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.provider.OpenableColumns;
import android.text.Editable;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListView;
import android.widget.Toast;

import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.gson.Gson;
import com.google.gson.JsonSyntaxException;
import com.google.gson.reflect.TypeToken;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.text.Collator;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.TreeSet;

public class MainActivity extends AppCompatActivity implements InputDialog.InputDialogListener {
    private BottomNavigationView navMenu;
    ApplicantAdapter applicantAdapter;
    ListView list;
    ArrayList<Applicant> applicants;

    private Boolean editMod;

    private Boolean getEditMod() {
        return editMod;
    }

    private void setEditMod(Boolean activate) {
        int mod;
        if (activate)
            mod = View.VISIBLE;
        else
            mod = View.GONE;
        navMenu.setVisibility(mod);
        editMod = activate;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu, menu);
        menu.getItem(0).setOnMenuItemClickListener(item -> {
            if (item.getItemId() == R.id.create) {
                createDialog();
            }
            return true;
        });
        menu.getItem(1).setOnMenuItemClickListener(item -> {
            if (item.getItemId() == R.id.search) {
                searchAddressDialog();
            }
            return true;
        });
        return super.onCreateOptionsMenu(menu);
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        navMenu = (BottomNavigationView) findViewById(R.id.navMenu);
        setEditMod(false);

        list = findViewById(R.id.list);

        applicants = new ArrayList();
        try {
            InputStream in_s = getResources().openRawResource(R.raw.applicants);
            byte[] b = new byte[in_s.available()];
            in_s.read(b);
            applyJsonStr(new String(b));
        } catch (Exception e) {}

        applicantAdapter = new ApplicantAdapter(this, R.layout.list_item, applicants);
        list.setAdapter(applicantAdapter);

        navMenu.setOnItemSelectedListener(item -> {
            if (item.getItemId() == R.id.cancel) {
                unselectAll();
                setEditMod(false);
            } else if (item.getItemId() == R.id.delete && getSelectedCount() > 0) {
                openDeleteDialog();
            }
            return true;
        });

        list.setOnItemClickListener((parent, view, position, id) -> {
            if (getEditMod())
                if (getSelection(position))
                    changeSelection(position, false);
                else
                    changeSelection(position, true);
            else
                editDialog(position);
        });

        list.setOnItemLongClickListener((parent, view, position, id) -> {
            if (!getEditMod()) {
                changeSelection(position, true);
                setEditMod(true);
            }
            return true;
        });
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private void openDeleteDialog() {
        DialogInterface.OnClickListener dialogClickListener = (dialog, which) -> {
            if (which == DialogInterface.BUTTON_POSITIVE) {
                deleteSelected();
                setEditMod(false);
            }
        };

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("Are you sure you want to delete " + getSelectedCount() +
                " elements?").setPositiveButton("Yes", dialogClickListener)
                .setNegativeButton("No", dialogClickListener).show();
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private void deleteSelected() {
        applicants.removeIf(i -> i.selected == true);
        applicantAdapter.notifyDataSetChanged();
    }

    private boolean getSelection(int position) {
        return applicants.get(position).selected;
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private int getSelectedCount() {
        return (int) applicants.stream().filter(i -> i.selected == true).count();
    }

    private void changeSelection(int position, boolean selection) {
        applicants.get(position).selected = selection;
        applicantAdapter.notifyDataSetChanged();
    }

    private void unselectAll() {
        for (int i = 0; i < applicants.size(); i++) {
            applicants.get(i).selected = false;
        }
        applicantAdapter.notifyDataSetChanged();
    }

    private void searchAddressDialog() {
        InputDialog inputDialog = new InputDialog("Search applicant by address", true);
        inputDialog.show(getSupportFragmentManager(), "dialog");
    }

    private void createDialog() {
        InputDialog inputDialog = new InputDialog("Create applicant");
        inputDialog.show(getSupportFragmentManager(), "dialog");
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private void editDialog(int position) {
        Applicant applicant = applicants.get(position);
        InputDialog inputDialog = new InputDialog(applicant.first_name, applicant.second_name,
                applicant.patronymic, applicant.address, applicant.marks,
                "Edit applicant", position);
        inputDialog.show(getSupportFragmentManager(), "dialog");
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    public void applyTexts(Editable first_name, Editable second_name, Editable patronymic,
                           Editable address, Editable  marks, int position, boolean searchMode) {
        Log.v("fdsafdsafdsa","");
        if (searchMode) {
            ArrayList<String> second_names = new ArrayList<>();
            for(int i = 0; i < applicants.size(); i++) {
                Applicant applicant = applicants.get(i);
                if (applicant.address.contains(address) && Double.parseDouble(applicant.getAverageMark()) > 4.5) {
                    second_names.add(applicant.second_name);
                }
            }
            Collections.sort(second_names);
            String result = "Found " + second_names.size() + " applicants\n";
            for(int i = 0; i < second_names.size(); i++) {
                result += second_names.get(i) + ",\n";
            }

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.setMessage(result).setPositiveButton("Ok", null).show();
        }
        else {
            if (position != -1) {
                Applicant applicant = applicants.get(position);
                applicant.first_name = first_name.toString();
                applicant.second_name = second_name.toString();
                applicant.patronymic = patronymic.toString();
                applicant.address = address.toString();
                applicant.marks = marks.toString();
            } else {
                applicants.add(new Applicant(first_name.toString(), second_name.toString(),
                        patronymic.toString(), address.toString(), marks.toString(), false));
            }
            applicantAdapter.notifyDataSetChanged();
        }
    }


    private String fromUriToStr(Uri uri) throws IOException {
        InputStreamReader inputStreamReader = new InputStreamReader(getContentResolver().openInputStream(uri));
        BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
        StringBuilder sb = new StringBuilder();
        String s;
        while ((s = bufferedReader.readLine()) != null) {
            sb.append(s);
        }
        return sb.toString();
    }

    private long getFileSize(Uri fileUri) {
        Cursor returnCursor = getContentResolver().
                query(fileUri, null, null, null, null);
        int sizeIndex = returnCursor.getColumnIndex(OpenableColumns.SIZE);
        returnCursor.moveToFirst();

        return returnCursor.getLong(sizeIndex);
    }

    private void applyJsonStr(String str) throws JsonSyntaxException {
        Gson gson = new Gson();
        ArrayList<Applicant> newApplicants = gson.fromJson(str,
                new TypeToken<ArrayList<Applicant>>(){}.getType());
        if (newApplicants == null)
            throw new JsonSyntaxException("Incorrect json format");
        applicants.clear();
        for(int i = 0; i < newApplicants.size(); i++) {
            applicants.add(newApplicants.get(i));
        }
        applicantAdapter.notifyDataSetChanged();
    }

    private void openFileChooser() {
        
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
        intent.setType("*/json");
        startActivityForResult(intent, 1);
    }
}