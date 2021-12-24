package com.example.lab2;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.os.Bundle;
import android.text.Editable;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatDialogFragment;

public class InputDialog extends AppCompatDialogFragment {
    String first_name = "";
    String second_name = "";
    String patronymic = "";
    String address = "";
    String average = "";
    String label = "";
    int position = -1;
    boolean searchMode = false;

    private InputDialogListener listener;

    public InputDialog(String label, boolean searchMode) {
        this.label = label;
        this.searchMode = searchMode;
    }

    public InputDialog(String label) {
        this.label = label;
    }

    public InputDialog(String first_name, String second_name, String patronymic,
                       String address, String average, String label, int position) {
        this.first_name = first_name;
        this.second_name = second_name;
        this.patronymic = patronymic;
        this.address = address;
        this.average = average;
        this.label = label;
        this.position = position;
    }
    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

        LayoutInflater inflater = getActivity().getLayoutInflater();
        View view = inflater.inflate(R.layout.layout_dialog, null);

        EditText first_name_input = view.findViewById(R.id.first_name_input);
        EditText second_name_input = view.findViewById(R.id.second_name_input);
        EditText patronymic_input = view.findViewById(R.id.patronymic_input);
        EditText address_input = view.findViewById(R.id.address_input);
        EditText average_mark_input = view.findViewById(R.id.average_mark_input);

        if (searchMode) {
            first_name_input.setVisibility(View.GONE);
            second_name_input.setVisibility(View.GONE);
            patronymic_input.setVisibility(View.GONE);
            average_mark_input.setVisibility(View.GONE);
        }

        first_name_input.setText(first_name);
        second_name_input.setText(second_name);
        patronymic_input.setText(patronymic);
        address_input.setText(address);
        average_mark_input.setText(average);

        builder.setView(view)
                .setTitle(this.label)
                .setNegativeButton("cancel", (dialog, which) -> {

                })
                .setPositiveButton("ok", (dialog, which) -> {
                    listener.applyTexts(first_name_input.getText(), second_name_input.getText(),
                            patronymic_input.getText(), address_input.getText(),
                            average_mark_input.getText(), position, searchMode);
                });

        return builder.create();
    }

    @Override
    public void onAttach(@NonNull Context context) {
        super.onAttach(context);

        try {
            listener = (InputDialogListener) context;
        } catch (Exception e) {
            throw new ClassCastException(context.toString());
        }

    }

    public interface InputDialogListener {
        void applyTexts(Editable first_name, Editable second_name, Editable patronymic,
                        Editable address, Editable marks, int position, boolean searchMode);
    }
}
