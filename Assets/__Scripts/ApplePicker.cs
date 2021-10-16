using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject    basketPrefab;
    public int           numBaskets=3;
    public float         basketBottomY = -14f;
    public float         basketSpacingY = 2f;
    public List<GameObject> basketList;


    // Use this for initialization
    void Start () {
        basketList = new List<GameObject>();
		for (int i=0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

    }
    public void AppleDestroyed()
    {
        //Remove all the fallen apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");//b
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //Delete 1 basket
        //Get the index of the last basket in the basketList
        int basketIndex = basketList.Count - 1;
        //Get a link to this game object Basket
        GameObject tBasketGo = basketList[basketIndex];
        //Exclude the basket from the list and delete the game object itself
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        //If there are no buckets left, exit the menu
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0_MainMenu");
        }
    }
}
