/* Guess a Number app
 * The user thinks of a number and the machine tries to guess it
 * Uses indicates whether guess was correct, too high, or too low
 */
package com.jadom.guessnumber;

import android.app.Activity;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

// a simple Activity for the 'guess the number' game
public class MainActivity extends AppCompatActivity implements OnClickListener {
    // range for the guess, initially 0 .. 100
    private int min = 0;
    private int max = 100;

    // the current guess value
    private int guess;

    // the buttons
    private Button guessButton, correctButton, tooHighButton, tooLowButton;

    // text view for displaying the guess
    private TextView guessTextView;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        guessTextView = (TextView) findViewById(R.id.guessTextView);

        // hook up handlers for all buttons
        guessButton = (Button) findViewById(R.id.guessButton);
        guessButton.setOnClickListener(this);
        correctButton = (Button) findViewById(R.id.correctButton);
        correctButton.setOnClickListener(this);
        tooHighButton = (Button) findViewById(R.id.tooHighButton);
        tooHighButton.setOnClickListener(this);
        tooLowButton = (Button) findViewById(R.id.tooLowButton);
        tooLowButton.setOnClickListener(this);

        // setup button statuses
        guessButton.setVisibility(View.VISIBLE);
        correctButton.setVisibility(View.INVISIBLE);
        tooLowButton.setVisibility(View.INVISIBLE);
        tooHighButton.setVisibility(View.INVISIBLE);
    }


    @Override
    // any of the 4 buttons clicked
    public void onClick(View v) {
        // determine which button was clicked and choose appropriate action

        if (v.getId() == R.id.guessButton)                    // ask computer to guess
        {
            makeGuess();                                    // make the guess and display it

            guessButton.setEnabled(false);
            correctButton.setVisibility(View.VISIBLE);
            correctButton.setEnabled(true);
            tooLowButton.setVisibility(View.VISIBLE);
            tooLowButton.setEnabled(true);
            tooHighButton.setVisibility(View.VISIBLE);
            tooHighButton.setEnabled(true);
        } else if (v.getId() == R.id.correctButton)            // game over
        {
            // reset

            min = 0;
            max = 100;
            guessButton.setEnabled(true);
            correctButton.setEnabled(false);
            tooLowButton.setEnabled(false);
            tooHighButton.setEnabled(false);
        } else if (v.getId() == R.id.tooHighButton)            // guess was too high
        {
            // adjust max to value guessed which was too high
            max = Integer.parseInt(guessTextView.getText().toString());

            guessButton.setEnabled(true);
            correctButton.setEnabled(false);
            tooLowButton.setEnabled(false);
            tooHighButton.setEnabled(false);
        } else if (v.getId() == R.id.tooLowButton)            // guess was too low
        {
            // adjust min to value guessed which was too low
            min = Integer.parseInt(guessTextView.getText().toString());

            guessButton.setEnabled(true);
            correctButton.setEnabled(false);
            tooLowButton.setEnabled(false);
            tooHighButton.setEnabled(false);
        }

    }

    // make a guess in the range min..max, and display on text view
    private void makeGuess() {
        // generate a random number in range min .. max
        guess = min + (int) (Math.random() * ((max - min) + 1));

        // display
        guessTextView.setText("" + guess);

        // write debug message to LogCat
        Log.d("guess", "min: " + min + " max: " + max + " guess: " + guess);
    }
}