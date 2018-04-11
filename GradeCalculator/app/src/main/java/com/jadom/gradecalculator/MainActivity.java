package com.jadom.gradecalculator;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    EditText markInput;
    int gradeIn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        markInput = findViewById(R.id.grade_edit);

        markInput.addTextChangedListener(new TextWatcher() {

            public void afterTextChanged(Editable s) {
            }

            public void beforeTextChanged(CharSequence s, int start,
                                          int count, int after) {
            }

            public void onTextChanged(CharSequence s, int start,
                                      int before, int count) {
                if (TextUtils.isEmpty((s.toString()))) {
                    s = "0";
                }else
                if (Integer.parseInt(s.toString()) > 100) {
                    markInput.setText("100");
                    s = "100";
                }

                gradeIn = Integer.parseInt(s.toString());
                showGrade();
            }
        });
    }

    // handle button click
    public void calculateGrade(View v) {
        showGrade();
    }

    public void showGrade() {
        String grade;
        if (gradeIn >= 0 && gradeIn <= 34) {
            grade = "F";
        } else if (gradeIn <= 39) {
            grade = "D";
        } else if (gradeIn <= 49) {
            grade = "C";
        } else if (gradeIn <= 54) {
            grade = "C+";
        } else if (gradeIn <= 59) {
            grade = "B-";
        } else if (gradeIn <= 69) {
            grade = "B";
        } else if (gradeIn <= 79) {
            grade = "B+";
        } else if (gradeIn <= 100) {
            grade = "A";
        } else {
            grade = "No Grade";
        }

        TextView gradeView = findViewById(R.id.grade);
        gradeView.setText(getString(R.string.grade, grade));
    }

}
