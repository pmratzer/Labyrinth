using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGenerator : MonoBehaviour
{
    public UnlockingMinigame Anchor;
    public GameObject GoalPrefab;

    private void Start()
    {
        int amount = 6;
        int angle = 0;
        GenerateGoal(amount, angle);
    }

    //GenerateGoal() takes in amount of goals to generate, and the previous angle (for recursion)
    public void GenerateGoal(int amount, int prevAngle)
    {
        if (amount == 0)
        {
            return;
        }

        else
        {
            var newAngle = Random.Range(30, 80) + prevAngle;
            var offset = new Vector3(0, 0.013f, 0);

            var newGoal = Instantiate(GoalPrefab, Anchor.transform.position + offset, Quaternion.identity, Anchor.transform.parent);
            newGoal.transform.RotateAround(transform.position, Vector3.forward, newAngle);

            GenerateGoal(amount - 1, newAngle);
        }
    }
}
