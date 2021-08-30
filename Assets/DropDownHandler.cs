using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour   //Класс раширяющий возможности выпадающего списка.Необходим для выбора сложности через меню настроек.
{

    public Dropdown ddgamediff;
    public static int diffValue { get; set; } //static нужен для доступа из другого класса.Переменная для хранения и передачи значения в класс Basket.

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
        diffValue = sender.value;  //Присвоение значения новой пременной для передачи.
        Debug.Log("diffValue is =" + diffValue);
    }
}