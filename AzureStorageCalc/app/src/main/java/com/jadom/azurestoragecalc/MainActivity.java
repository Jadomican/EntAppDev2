// sample soln to Android CA
// calculate monthly storage cost in Azure based on GB per month average use and redundancy requirement (local or geographical)

package com.jadom.azurestoragecalc;

import android.os.Bundle;
import android.app.Activity;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.view.Menu;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // initially both radio buttons are unchecked, so check the geographical redundant option
        ((RadioButton) findViewById(R.id.geographicalRadioButton)).toggle();
    }

    // called when "Calc Cost" button clicked
    public void calcStorageCost(View v) {

        // unit costs
        final double GeoCostPerGBLevel1 = 0.125;                // up to 1 TB, geographically redundant
        final double GeoCostPerGBLevel2 = 0.11;                 // for excess of I TB, geographically redundant
        final double LocalCostPerGBLevel1 = 0.093;              // up to 1 TB, locally redundant
        final double LocalCostPerGBLevel2 = 0.083;              // for excess of I TB, locally redundant


        // read status of "geographically redundant" radio button
        RadioButton geographicalRadio = (RadioButton) findViewById(R.id.geographicalRadioButton);
        boolean geographical = geographicalRadio.isChecked();

        // read storage amount entered
        EditText storageEditText = (EditText) findViewById(R.id.gigabyteStorageTextEdit);

        if (TextUtils.isEmpty(storageEditText.getText().toString())) {
            Toast.makeText(this, "Enter a number", Toast.LENGTH_SHORT).show();
            return;
        }
        double storage = Double.parseDouble(storageEditText.getText().toString());



        // calculate storage cost per GB per month based on usage requirements
        double cost = 0;
        if (geographical)                    // "Geographical"
        {
            if (storage > 1000)                // > 1 TB
            {
                cost = (1000 * GeoCostPerGBLevel1) + ((storage - 1000) * GeoCostPerGBLevel2);
            } else {
                cost = storage * GeoCostPerGBLevel1;
            }
        } else                                // "Local"
        {
            if (storage > 1000) {
                cost = (1000 * LocalCostPerGBLevel1) + ((storage - 1000) * LocalCostPerGBLevel2);
            } else                            // <= 1 TB
            {
                cost = storage * LocalCostPerGBLevel1;
            }
        }

        // output result
        TextView costTextView = (TextView) findViewById(R.id.costTextView);


        costTextView.setText(getString(R.string.cost, cost));
    }
}
