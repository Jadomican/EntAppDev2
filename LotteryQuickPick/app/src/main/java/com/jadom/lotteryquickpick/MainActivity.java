package com.jadom.lotteryquickpick;

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
        updateTitle();

    }

    protected void updateTitle() {
        TextView title = ((TextView) findViewById(R.id.titleTextView));
        String output = "Pick " + ((EditText) findViewById(R.id.howManyEditText)).getText()
                + " numbers from 1 to " + ((EditText) findViewById(R.id.maxEditText)).getText();
        title.setText(output);
    }

    public void pickButtonClicked(View v) {

        try {
            TextView pickTextView = findViewById(R.id.picksTextView);
            EditText howManyEditText = findViewById(R.id.howManyEditText);
            EditText maxEditText = findViewById(R.id.maxEditText);

            int howMany = Integer.parseInt(howManyEditText.getText().toString());
            int max = Integer.parseInt(maxEditText.getText().toString());

            if (max < howMany) {
                Toast.makeText(this, "Max is too small!",
                        Toast.LENGTH_LONG).show();
                return;
            }

            int[] picks = Lottery.pickNumbers(howMany, max);

            String data = "";
            for (int number : picks) {
                data += number + " ";
            }

            pickTextView.setText(data);
            updateTitle();

        } catch (Exception e) {
            Log.d("Exception", e.getMessage());
        }
    }


}
