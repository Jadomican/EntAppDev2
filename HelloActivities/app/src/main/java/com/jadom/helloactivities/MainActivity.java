package com.jadom.helloactivities;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.RatingBar;
import android.widget.TextView;

/**
 * @author GC
 * demo of multiple activities within one application
 * MainActivity allows user to enter a rating and review and move to InfoActivity where the data is displayed
 */

public class MainActivity extends AppCompatActivity
{
    public final static String REVIEW_MESSAGE = "org.gc.MESSAGE";
    private final String TAG = "HelloActivities";

    // Essentially an activity has 3 states:
    // "resumed" i.e. running
    // "paused" i.e. partially obscured by another activity
    // "stopped" i.e. totally obscured by another activity

    // while "paused" or "stopped" activity is still in memory and state is retained
    // but system could kill the activity if memory needed

    // called when activity is first created, not visible yet, happens once per lifecycle (i.e until destroyed)
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        Log.d(TAG, "onCreate() called in MainActivity");
        // restore state, UI state automatically saved by default implementation of onSaveInstanceState
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        // activity moves quickly into Created state after this and from Created state into Started state and
        // from there into Resumed state
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        return super.onOptionsItemSelected(item);
    }

    // reviewButton clicked, read rating and use intent to start info activity passing in review data
    public void review(View v)
    {
        CharSequence reviewMessage = "Review: " + ((TextView) findViewById(R.id.reviewEditText)).getText().toString();
        int stars = (int) ((RatingBar) findViewById(R.id.ratingBar)).getRating();
        reviewMessage = reviewMessage + " Star rating: " + stars;

        // call InfoActivity, this activity stops as a result
        Intent intent = new Intent(this, InfoActivity.class);	// an explicit intent
        intent.putExtra(REVIEW_MESSAGE, reviewMessage);			    // associate data with the call i.e. key/value pair
        startActivity(intent);
    }

    // moving from paused into Stopped state
    protected void onStop()
    {
        super.onStop();
        Log.d(TAG, "onStop() called in MainActivity");
    }

    // restarted from stopped into started state e.g. by back button from InfoActivity
    protected void onRestart()
    {
        super.onRestart();
        Log.d(TAG, "onRestart() called in MainActivity");
    }

    // moving into resumed state from started or paused state
    protected void onResume()
    {
        super.onResume();
        Log.d(TAG, "onResume() called in InfoActivity");
    }
}
