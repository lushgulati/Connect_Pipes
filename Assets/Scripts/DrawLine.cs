using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    Grid grid;
    Vector3 point;
    Vector3 currentPosition;
    int i;
    Vector3[] takenPos=new Vector3[25];
    public bool isclicked;
    public GameObject takentile;
    private GameObject takenparent;
    public GameObject Destination;
    public GameObject Occupied;
    Occupied ocupy;
    DrawLine dest;
    public bool reached;
   
    void OnEnable()
    {
        grid = FindObjectOfType<Grid>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.parent.position);
        currentPosition = transform.parent.position;
        i = 0;
        for (int j = 0; j < takenPos.Length; j++)
        {
            //Debug.Log(takenPos[j]);
            takenPos[j] = transform.parent.position;
        }
        isclicked = false;
        ocupy = Occupied.GetComponent<Occupied>();
        reached = false;
        dest = Destination.GetComponent<DrawLine>();
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
       
    }

    
    private void ResetPos()
    {
        lineRenderer.positionCount = 1;
        i = 0;
        currentPosition = transform.parent.position;
        for(int j=0;j<takenPos.Length;j++)
        {
            //Debug.Log(takenPos[j]);
            takenPos[j] = transform.parent.position;
        }
        isclicked = false;
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        
    }

    private void ReachedDest()
    {
        ocupy.Occupy(lineRenderer.positionCount, takenPos);
        reached = true;
        isclicked = false;
        dest.reached = true;
        dest.isclicked = false;
        
    }
    void Update()
    {
        
        if(Input.GetMouseButton(0))
        {
            
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if((new Vector3(Mathf.RoundToInt(point.x), Mathf.RoundToInt(point.y), 0f) == transform.parent.position)&&reached==false){
                isclicked = true;
            }
            if(isclicked)
            SetLinePos(point);
            
        }
        if (Input.GetMouseButtonUp(0)&&!reached)
            ResetPos();
    }

    void SetLinePos(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        int count = 0;
        if (finalPosition.x <=4 && finalPosition.x>=0 && finalPosition.y<=4 && finalPosition.y>=0)
        {

            if (finalPosition.x - currentPosition.x!=0 && finalPosition.y - currentPosition.y != 0)
                return;
            else
            {

                if (currentPosition != finalPosition)
                {
                    lineRenderer.positionCount += 1;
                    i++;

                    //takenPos[i] = finalPosition;
                    takenparent=Instantiate(takentile, finalPosition, Quaternion.identity) as GameObject;
                    takenparent.transform.parent = this.transform;
                    takenPos[i] = finalPosition;
                    for (int j = 0; j < takenPos.Length; j++)
                    {
                        if (((finalPosition == takenPos[j])||(finalPosition==ocupy.occupied[j]))&&finalPosition!=Destination.transform.position)
                        count+= 1;
                    }
                    
                }
                if (count <= 1)
                {
                    currentPosition = finalPosition;
                    
                    lineRenderer.SetPosition(i, currentPosition);
                    count = 0;
                    if(currentPosition==Destination.transform.position)
                    {
                        ReachedDest();
                    }
                }
                else
                    ResetPos();
                
               

            }
        }
        
    }

}
