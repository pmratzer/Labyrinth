using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    private Collider2D d_collider;
    [SerializeField]
    private ContactFilter2D d_filter;
    private List<Collider2D> d_collidedObjects = new List<Collider2D>(1); //only stores one object


    protected virtual void Start()
    {
        d_collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        d_collider.OverlapCollider(d_filter, d_collidedObjects);  //looks for collided objects and stores them in a list
        foreach(var o in d_collidedObjects)
        {
            OnCollided(o.gameObject);
        }
    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Collided with " + collidedObject.name);
    }
}
