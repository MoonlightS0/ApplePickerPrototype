using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppleTree : MonoBehaviour { 
	[Header("Set in Inspector")] // Template for creating apples
    public GameObject applePrefab;

    //The speed of movement of the apple tree
    public float speed = 1f;

    // The distance at which the direction of movement of the apple tree should change
    public float leftAndRightEdge = 10f;

    //The probability of a random change in direction
    public float chanceToChangeDirections = 0.1f;
    //Frequency of creating apple instances
    public float secondsBetweenAppleDrops = 1f;
	void Start () {
        // Drop apples once a second
        Invoke("DropApple",2f );
	}
	void DropApple () {
	GameObject apple=Instantiate<GameObject>(applePrefab);
	apple.transform.position = transform.position;
	Invoke("DropApple",secondsBetweenAppleDrops);
	}
    //Simple movement
    void Update () { 
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

        //Change of direction

        if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);     //Start moving to the right
        } else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);     //Start moving to the left
        }
	}

		void FixedUpdate() {
			if (Random.value < chanceToChangeDirections) {
			speed *= -1;	//change direction
			}
		}
}