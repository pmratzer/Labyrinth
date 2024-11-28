using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageDoor : InteractableObject
{
    public int sceneBuildIndex;
    protected override void OnInteract()
    {
        z_Interacted = true;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
