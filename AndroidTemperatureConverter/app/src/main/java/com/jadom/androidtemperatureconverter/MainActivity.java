package com.jadom.androidtemperatureconverter;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;

public class MainActivity extends AppCompatActivity {

    RadioGroup radioGroup;
    EditText celsiusET;
    EditText fahrenheitET;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        radioGroup = findViewById(R.id.radio_group);
        celsiusET = findViewById(R.id.celsiusEditText);
        fahrenheitET = findViewById(R.id.fahrenheitEditText);
        radioGroup.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {
                switch (checkedId) {
                    case R.id.radioF:
                        fahrenheitET.setEnabled(false);
                        celsiusET.setEnabled(true);
                        break;
                    case R.id.radioC:
                        fahrenheitET.setEnabled(true);
                        celsiusET.setEnabled(false);
                }

            }
        });

    }

    public void convert(View v) {

        String celsius = celsiusET.getText().toString().trim();
        String fahrenheit = fahrenheitET.getText().toString().trim();

        if (celsius.equals("")){
            celsius = ("0");
        }
        if (TextUtils.isEmpty(fahrenheit))
        {
            fahrenheit = "0";
        }


            radioGroup.getCheckedRadioButtonId();


        if (radioGroup.getCheckedRadioButtonId() == R.id.radioC) {
            double d = ((Double.parseDouble(fahrenheit) - 32) * (5.0 / 9.0));
            celsiusET.setText(getString(R.string.degrees, Double.toString(d)));

        }

        if (radioGroup.getCheckedRadioButtonId() == R.id.radioF) {
            double d = ((Double.parseDouble(celsius) * (9.0 / 5.0)) + 32);
            fahrenheitET.setText(getString(R.string.degrees, Double.toString(d)));
        }

    }


}
