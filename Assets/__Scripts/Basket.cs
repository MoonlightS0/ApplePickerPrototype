using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start()
    {
        // Get a link to the ScoreCounter game object
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text component of this game object
        scoreGT = scoreGO.GetComponent<Text>(); // с
        //Set the initial number of points to 0
        scoreGT.text = "0";

        int diffLevel = DropDownHandler.diffValue;                  //From the DropDownHandler class, the difficulty is taken from the diffValue variable and assigned to a new local variable that will be used in if/else
        if (diffLevel == 0)                                         //easy difficulty
        {
            transform.localScale = new Vector3(10f, 1f, 4f);
        }
        else if (diffLevel == 1)                                    //normal difficulty
        {
            transform.localScale = new Vector3(3f, 1f, 4f);
        }
        else if (diffLevel == 2)                                    //hard difficulty
        {
            transform.localScale = new Vector3(1f, 1f, 4f);
        }
        else
        {
            Debug.Log("Difficulty Error:value is other or null");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current coordinates of the mouse pointer on the screen from Input
        Vector3 mousePos2D = Input.mousePosition;
        // The camera's Z coordinate determines how far away the mouse pointer is in three-dimensional space
        mousePos2D.z = -Camera.main.transform.position.z;
        // Convert a point on the two-dimensional plane of the screen to the three-dimensional coordinates of the game
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
        // Move the bucket along the X axis to the X coordinate of the mouse pointer
        Vector3 pos = this.transform.position; pos.x = mousePos3D.x; this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision coll)
    {
        //Find an apple that got into the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);


            // Convert text to scoreGT to an integer
            int score = int.Parse(scoreGT.text);
            // Add points for catching an apple
            score += 10;
            // Convert the number of points back to a string and display it on the screen
            scoreGT.text = score.ToString();

            //Remember the highest achievement
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }

        }
    }
}
