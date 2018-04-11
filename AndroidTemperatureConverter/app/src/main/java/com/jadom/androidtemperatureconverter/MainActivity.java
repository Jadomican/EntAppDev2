package com.jadom.androidtemperatureconverter;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void convert(View v) {

        EditText celsiusET = findViewById(R.id.celsiusEditText);
        String celsius = celsiusET.getText().toString().trim();

        RadioGroup radioGroup = findViewById(R.id.radio_group);

//        RadioButton radioC = findViewById(R.id.radioC);
//        RadioButton radioF = findViewById(R.id.radioF);

        radioGroup.getCheckedRadioButtonId();

        EditText fahrenheitET = findViewById(R.id.fahrenheitEditText);
        String fahrenheit = fahrenheitET.getText().toString().trim();

        if (radioGroup.getCheckedRadioButtonId() == R.id.radioC) {
            celsiusET.setText(((Double.parseDouble(fahrenheit) - 32) * (5.0 / 9.0)) + "");

        }

        if (radioGroup.getCheckedRadioButtonId() == R.id.radioF) {
            fahrenheitET.setText(((Double.parseDouble(celsius) * (9.0 / 5.0)) + 32) + "");
        }


        if (celsius.length() != 0)                // convert to fahrenheit
        {
        } else {
            if (fahrenheit.length() != 0)        // convert to celsius
            {
            }
        }

    }


}
