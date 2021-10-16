using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour   //A class that extends the capabilities of the drop-down list.It is necessary to select the difficulty through the settings menu.
{

    public Dropdown ddgamediff;
    public static int diffValue { get; set; } //A variable for storing and passing values to the Basket class.

    private void Start()
    {
        ddgamediff.onValueChanged.AddListener(delegate
        {
            ddgamediffValueChangedHappened(ddgamediff);
        });
    }

    public void ddgamediffValueChangedHappened(Dropdown sender)
    {
        Debug.Log("Difficulty set :" + sender.value);
        diffValue = sender.value;  //Assigning a value to a new variable for transmission.
        Debug.Log("diffValue is =" + diffValue);
    }
}