using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private const string SAVE_SEPERATOR = "#SAVE-VALUE";
    public Transform red;
    public Transform red1;
    public Transform blue;
    public Transform blue1;
    public Transform green;
    public Transform green1;
    public Transform purple;
    public Transform purple1;
    public Transform orange;
    public Transform orange1;
    string str;
    public GameObject Panel;
    public GameObject Occupied;
    public GameObject LevelSelector;
    
    Occupied ocupy;
    
    private void OnEnable()
    {
        ocupy = Occupied.GetComponent<Occupied>();
    }

    public void Level1()
    {
        str="./Level1.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level2()
    {
        str = "./Level2.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level3()
    {
        str = "./Level3.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level4()
    {
        str = "./Level4.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level5()
    {
        str = "./Level5.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level6()
    {
        str = "./Level6.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level7()
    {
        str = "./Level7.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level8()
    {
        str = "./Level8.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level9()
    {
        str = "./Level9.json";
        Load(str);
        Panel.SetActive(false);
    }
    public void Level10()
    {
        str = "./Level10.json";
        Load(str);
        Panel.SetActive(false);
    }

    public void Reset()
    {
        ocupy.Init();
        red.gameObject.SetActive(false);
        
        red1.gameObject.SetActive(false);
       
        blue.gameObject.SetActive(false);
       
        blue1.gameObject.SetActive(false);
        
        green.gameObject.SetActive(false);
       
        green1.gameObject.SetActive(false);
        
        purple.gameObject.SetActive(false);
        
        purple1.gameObject.SetActive(false);
       
        orange.gameObject.SetActive(false);
       
        orange1.gameObject.SetActive(false);
        Load(str);
    }

    public void LevelComplete()
    {
        ocupy.Init();
        red.gameObject.SetActive(false);

        red1.gameObject.SetActive(false);

        blue.gameObject.SetActive(false);

        blue1.gameObject.SetActive(false);

        green.gameObject.SetActive(false);

        green1.gameObject.SetActive(false);

        purple.gameObject.SetActive(false);

        purple1.gameObject.SetActive(false);

        orange.gameObject.SetActive(false);

        orange1.gameObject.SetActive(false);
        LevelSelector.SetActive(true);
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S)){
            Save();
        }*/
        
    }
    /*private void Save()
    {
        SaveObject saveObject = new SaveObject
        {
            red = red.position,
            red1 = red1.position,
            blue = blue.position,
            blue1 = blue1.position,
            green = green.position,
            green1=green1.position,
            purple=purple.position,
            purple1=purple1.position,
            orange=orange.position,
            orange1=orange1.position,

        };
        string json = JsonUtility.ToJson(saveObject);
        System.IO.File.WriteAllText(Application.dataPath + "/Level10.json", json);
    }*/

    private void Load(string lvl)
    {
        if(System.IO.File.Exists(Application.streamingAssetsPath+lvl))
        {
            string saveString = System.IO.File.ReadAllText(Application.streamingAssetsPath + lvl);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            
            red.position = (saveObject.red);
            red.gameObject.SetActive(true);
            red1.position = (saveObject.red1);
            red1.gameObject.SetActive(true);
            blue.position = (saveObject.blue);
            blue.gameObject.SetActive(true);
            blue1.position = (saveObject.blue1);
            blue1.gameObject.SetActive(true);
            green.position = (saveObject.green);
            green.gameObject.SetActive(true);
            green1.position = (saveObject.green1);
            green1.gameObject.SetActive(true);
            purple.position = (saveObject.purple);
            purple.gameObject.SetActive(true);
            purple1.position = (saveObject.purple1);
            purple1.gameObject.SetActive(true);
            orange.position = (saveObject.orange);
            orange.gameObject.SetActive(true);
            orange1.position = (saveObject.orange1);
            orange1.gameObject.SetActive(true);
        }
    }
    private class SaveObject
    {
        public Vector3 red ;
        public Vector3 red1;
        public Vector3 blue;
        public Vector3 blue1;
        public Vector3 green;
        public Vector3 green1;
        public Vector3 purple;
        public Vector3 purple1;
        public Vector3 orange;
        public Vector3 orange1;
    }
}
