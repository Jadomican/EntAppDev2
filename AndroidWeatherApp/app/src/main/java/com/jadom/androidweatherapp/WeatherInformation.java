package com.jadom.androidweatherapp;

/**
 * Created by jadom on 11/04/2018.
 */

enum WeatherConditions {
    Cloudy, Rainy, Sunny
}

public class WeatherInformation {

    private String city;

    private double temperatureCelcius;

    private WeatherConditions weatherConditions;


    public WeatherInformation(String city, double temperatureCelcius, WeatherConditions weatherConditions) {
        this.city = city;
        this.temperatureCelcius = temperatureCelcius;
        this.weatherConditions = weatherConditions;
    }

    public String getCity() {
        return city;
    }

    public double getTemperatureCelcius() {
        return temperatureCelcius;
    }

    public WeatherConditions getWeatherConditions() {
        return weatherConditions;
    }
}
