using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Inventory.Model
{
    public class GiveKey : CollidableObject
    {
        protected bool z_Interacted = false;

        protected override void OnCollided(GameObject collidedObject)
        {
            if (Input.GetKey(KeyCode.E))
            {
                OnInteract();
            }
        }

        protected virtual void OnInteract()
        {
            if (!z_Interacted)
            {
                z_Interacted = true;
                Debug.Log("Interact With " + name);
            }
            //execute some code then
            //z_Interacted = false;
            //otherwise you wont be able to re-interact with objects
        }
    }
}
