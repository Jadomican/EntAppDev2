/**
 * @author GC
 *  The info activity just displays the information about the review entered on MainActivity and received via the intent
 *  Both activities declared in manifest
 */

package com.jadom.helloactivities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

public class InfoActivity extends AppCompatActivity
{
    private final String TAG = "HelloActivities";

    // once per activity lifecycle
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        Log.d(TAG, "onCreate() called in InfoActivity");
        super.onCreate(savedInstanceState);

        // read data from intent
        Intent intent = getIntent();
        String reviewMessage = intent.getStringExtra(MainActivity.REVIEW_MESSAGE);
        setContentView(R.layout.activity_info);

        // display data read from intent on a text view
        TextView tv = (TextView) findViewById(R.id.reviewMessageTextView);
        tv.setText(reviewMessage);
    }

    // moving from paused into stopped state
    protected void onStop()
    {
        super.onStop();
        Log.d(TAG, "onStop() called in InfoActivity");
    }

    // using back button will destroy current activity
    protected void onDestroy()
    {
        super.onDestroy();
        Log.d(TAG, "onDestroy() called in InfoActivity");
    }
}
