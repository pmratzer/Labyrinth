using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockingMinigame : MonoBehaviour
{
    public int Speed = 100;
    Transform anchor;
    bool isRunning = false;
    GameObject goal;
    public TMP_Text centerText;
    int numGoals;

    //when key enters goal collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        goal = collision.gameObject;
    }

    //when key exits goal collision
    private void OnTriggerExit2D(Collider2D collision)
    {
        goal = null;
    }

    private void Start()
    {
        anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        numGoals = GameObject.FindGameObjectsWithTag("Goal").Length;
    }

    private void Update()
    {
        //key motion -- rotates key around circle
        if (isRunning)
        {
            transform.RotateAround(anchor.position, Vector3.forward, Speed * Time.deltaTime);
        }

        //removes text and runs minigame
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!isRunning)
            {
                isRunning = true;
                centerText.text = "";
            }
        }

        //handles goal detection
        if ((Input.GetKeyDown(KeyCode.Space)) && (isRunning))
        { 
            if (goal != null)
            {
                Destroy(goal);
                Speed += 30;
                numGoals--;
            }
            else
            {
                Speed = 0;
                centerText.text = "Failed to unlock.";
            }
        }

        if ((numGoals == 0) && (isRunning))
        {
            Speed = 0;
            centerText.text = "Unlocked!";
        }
        
    }
}
