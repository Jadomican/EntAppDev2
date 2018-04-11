package com.jadom.helloname;

import android.content.Context;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    // handler for onClick on button
    public void sayHello(View v)
    {
        // read name
        String name = ((EditText) findViewById(R.id.nameEditText)).getText().toString();
        //TextView showName = (TextView) findViewById(R.id.enterNameTextView);
        // display a 'toast' message with a greeting to the name
        Context context = getApplicationContext();
        CharSequence text = "Hello there " + name;

        int duration = Toast.LENGTH_LONG;
        Toast.makeText(context, (getString(R.string.hello, name)), duration).show();

        // write debug message to LogCat
        Log.d("Hello Name", "message displayed: " + (getString(R.string.hello, name)));
    }
}
