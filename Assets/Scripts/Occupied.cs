using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Occupied : MonoBehaviour
{
    public Vector3[] occupied = new Vector3[25];
    
    public int starting=0 ;

    public Text cells;
    public Text pipe;
    public int pipes;
    public GameObject complete;
    
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        for (int i = 0; i < occupied.Length; i++)
        {
            occupied[i] = new Vector3(-1f, -1f, -1f);
        }
        starting = 0;
        pipes = 0;
        complete.SetActive(false);
    }

    private void Update()
    {
        cells.text = "Cells: "+starting.ToString() + "/25";
        pipe.text = "Pipes: " + pipes.ToString() + "/5";
    }

    public void Occupy(int length, Vector3[] takenPositions)
    {
        for (int i = starting; i < length+starting; i++)
        {
            occupied[i] = takenPositions[i-starting];
            
            
        }
        
        
        starting += length;
        pipes += 1;
        
        if(occupied[24]!=new Vector3(-1f, -1f, -1f))
        {
            Debug.Log("Level Complete");
            Invoke("LevelComplete", 1f);
        }
    }
    public void LevelComplete()
    {
        complete.SetActive(true);
    }
    
}
