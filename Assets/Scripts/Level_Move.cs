using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_Move : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Zone Entered");

        if (other.tag == "Player")
        {
            Debug.Log("Entering Scene " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }

    }
}
