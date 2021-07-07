using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;
    public float Size { get { return size; } }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;
        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = 0;
       
       
        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        
            return result;
       
            
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(float x=0;x<5;x+=size)
        {
            for(float y=0;y<5;y+=size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, y, 0f));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }


}
