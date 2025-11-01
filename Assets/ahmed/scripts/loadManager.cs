using System;
using System.IO;
using UnityEditor;
using UnityEngine;
[Serializable]
public class loadManager : MonoBehaviour
{
    // public List<GameObject> interacableItems = new List<GameObject>();



    public GameObject colorOrbs_prefab;
    //  public  GameObject colorOrbs;
    public GameObject player;
    //public CheckPoint lastCheck;

    public float saveTime;

    private void Start()
    {
        // saveTime = Time.time;
        try
        {


            saving.realLoad(GameObject.Find("color orbs"), colorOrbs_prefab, player);

        }
        catch (Exception e)
        {
            Debug.Log("file error");
            Controler.newSave = true;

        }
    }

    public void savee(string checkName)
    {
        float ti = Time.timeSinceLevelLoad - saveTime;
        //  Debug.Log(ti);
        Debug.Log("timeeeee" + ti);
        saveTime = Time.timeSinceLevelLoad;
        saving.realSave(GameObject.Find("color orbs"), player, checkName, ti);

    }

   

   
    public static void load(GameObject colorOrbs_prefab)
    {
        pp obj = new pp();
        Debug.Log("reading started from saves.txt");

        obj = JsonUtility.FromJson<pp>(File.ReadAllText(saving.GetSaveFilePath("saves.txt")));

        Debug.Log("reading completed from saves.txt");
        GameObject x = Instantiate(colorOrbs_prefab);
        x.name = "color orbs";
        Controler.newSave = obj.newSave;
        ColorManager.CollectedColors.Clear();
        ColorManager.newCollectedColors.Clear();
        //  ColorManager.lighte.color = Color.black;//some bug in this area
        for (int i = 0; i < 7; i++)
        {
            if (!obj.child.Exists(item => item == i))
            {
                ColorManager.newColor(x.transform.GetChild(7 - i - 1).GetComponent<SpriteRenderer>().color);
                Debug.Log("added " + x.transform.GetChild(7 - i - 1).GetComponent<SpriteRenderer>().color);
                Destroy(x.transform.GetChild(7 - i - 1).gameObject);

            }

        }
        Debug.Log(obj.newSave);


    }

}

[Serializable]
class Player_Data
{
    public GameObject parent;
    public int childNumber;






}


