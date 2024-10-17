using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FielfOfViewScript : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static Vector3 GetVectorFromAngle(float angle)
    {
        //angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        
        return n;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField] private LayerMask layerMask; 
    private Mesh mesh;
    private float fov;
    private Vector3 origin;
    private float startingAngle;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void LateUpdate() 
    { 
        float fov = 40f;
        Vector3 origin = Vector3.zero;
        int rayCount = 100;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 1f;

        Vector3[] verticies = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[verticies.Length];
        int[] triangles = new int[rayCount * 3];

        verticies[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin,GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;

            }
            else
            {
                vertex = raycastHit2D.point;
            }
            verticies[vertexIndex] = vertex;
            
            if(i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            
            vertexIndex++;
            angle -= angleIncrease;
        }

        

        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void SetAimDirection(Vector2 movementInput)
    {
        startingAngle = GetAngleFromVectorFloat(movementInput);
    }
}
