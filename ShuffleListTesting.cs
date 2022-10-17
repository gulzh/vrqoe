using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using UnityEngine;

public class ShuffleListTesting : MonoBehaviour
{


    public string[] filesList;

    // Start is called before the first frame update
    void OnEnable()
    {
        CreateList();
        //Meshes = Resources.LoadAll("Carlos_Testing/" + initialFramePc.Split('_')[0] + "/",typeof(GameObject)) as GameObject[];
    }


    public void CreateList()
    {
        string[] config = File.ReadAllLines( Application.dataPath + "/Logs/UserConfig/Config.txt");
        string user = config[4];

        string InitialFrameFolder = GameObject.Find("NonDestructibleObject").GetComponent<InitialFrameScript>().InitialFrame;
        string sourcePath = Application.dataPath + "/Resources/PointCloud/"+InitialFrameFolder+"/";
        DirectoryInfo m_Path = new DirectoryInfo(sourcePath);
        FileInfo[] files = m_Path.GetFiles("*.ply");
        string[] filesName = new string[files.Length];
        int i = 0;

        foreach (FileInfo file in files)
        {

            string fileName = file.Name.Replace(file.Extension, "");


            filesName[i] = (fileName);

            i++;
        }

        filesList = ReshuffleList(filesName);
        int p = 0;
        File.WriteAllText( Application.dataPath + "/Logs/ShuffleList/Testing/ShuffleList_" + user + ".txt", "");

        foreach (string element in this.filesList)
        {
            File.AppendAllText(Application.dataPath + "/Logs/ShuffleList/Testing/ShuffleList_" + user +".txt", this.filesList[p] + "\n");
            p++;
        }


    }
    private void Update()
    {
        

    }

    private string[] ReshuffleList(string[] texts)
    {
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
        return texts;
    }



}
