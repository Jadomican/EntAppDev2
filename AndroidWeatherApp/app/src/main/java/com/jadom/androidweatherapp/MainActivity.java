package com.jadom.androidweatherapp;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.AdapterView;
import android.widget.TextView;


import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity implements OnItemSelectedListener {

    private ArrayList<WeatherInformation> data;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        data = new ArrayList<WeatherInformation>();
        data.add(new WeatherInformation("Dublin", 17.2, WeatherConditions.Sunny));
        data.add(new WeatherInformation("Cork", 10, WeatherConditions.Cloudy));
        data.add(new WeatherInformation("Kildare", 12.2, WeatherConditions.Sunny));
        data.add(new WeatherInformation("Limerick", 4, WeatherConditions.Rainy));

        Spinner spinner = findViewById(R.id.citySpinner);

        List<String> cities = new ArrayList<String>();

        for (WeatherInformation weather : data) {
            cities.add(weather.getCity());
        }

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, cities);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner.setAdapter(adapter);

        spinner.setOnItemSelectedListener(this);


    }

    // item on picker selected
    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int pos, long id) {
        String city = parent.getItemAtPosition(pos).toString();
        TextView temperatureTextView = (TextView) findViewById(R.id.temperatureTextView);
        ImageView conditionsImageView = (ImageView) findViewById(R.id.conditionsImageView);

        // update UI i.e. temperature and conditions
        for (WeatherInformation w : data) {

            if (w.getCity().equalsIgnoreCase(city)) {
                temperatureTextView.setText(w.getTemperatureCelcius() + " Celsius");

                if (w.getWeatherConditions() == WeatherConditions.Sunny) {
                    conditionsImageView.setImageResource(R.drawable.sunny);
                } else if (w.getWeatherConditions() == WeatherConditions.Cloudy) {
                    conditionsImageView.setImageResource(R.drawable.cloudy);
                } else if (w.getWeatherConditions() == WeatherConditions.Rainy) {
                    conditionsImageView.setImageResource(R.drawable.rain);
                }
            }
        }
    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {
        // Another interface callback
    }

}
