using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour
{
  
    
    


    public void CreateText()
    {


        //Check for Flip/Unflip
        string[] config = File.ReadAllLines(Application.dataPath + "/Logs/UserConfig/Config.txt");

  

        //File for Training

        string directoryPathTraining = Application.dataPath + "/Logs/ShuffleList/Training";

        if (!Directory.Exists(directoryPathTraining))
        {
            Directory.CreateDirectory(Application.dataPath + "/Logs/ShuffleList/Training");
        }


        DirectoryInfo dirTrain = new DirectoryInfo(Application.dataPath + "/Logs/ShuffleList/Training");
        
        string user = config[4];

        string txtDocumentNameTrain = dirTrain + "/Log_User_" + user + ".txt";
        if (File.Exists(txtDocumentNameTrain))
        {
            Console.WriteLine("The file already exists!");

        }

        File.WriteAllText(txtDocumentNameTrain, "Training session" + "\n\n" + "Logs for User" + user +  "\n\n");
        File.AppendAllText(txtDocumentNameTrain, "Name: " + config[0]  +  "\n\n");
        File.AppendAllText(txtDocumentNameTrain, "Surname: " + config[1]  +  "\n\n");
        File.AppendAllText(txtDocumentNameTrain, "Age: " + config[2]  + "\n\n");
        File.AppendAllText(txtDocumentNameTrain, "Sex: " + config[3]  + "\n\n");
        File.AppendAllText(txtDocumentNameTrain, "Login date: " + System.DateTime.Now + "\n\n");
  



        File.WriteAllText(Application.dataPath + "/Logs/Recording_" + user + ".txt", "");






        //File for Testing
        string directoryPathTesting = Application.dataPath + "/Logs/ShuffleList/Testing";

        if (!Directory.Exists(directoryPathTesting))
        {
            Directory.CreateDirectory( Application.dataPath + "/Logs/ShuffleList/Testing");
        }


        DirectoryInfo dirTest = new DirectoryInfo( Application.dataPath + "/Logs/ShuffleList/Testing");
        
        //FileInfo[] filesTest = dirTest.GetFiles();
        //int userTest = filesTest.Length;

        string txtDocumentNameTest = dirTest + "/Log_User_" + user + ".txt";
        if (File.Exists(txtDocumentNameTest))
        {
            Console.WriteLine("The file already exists!");

        }

        File.WriteAllText(txtDocumentNameTest, "Testing session" + "\n\n"+ "Logs for User" + user + "\n\n");
        File.AppendAllText(txtDocumentNameTest, "Login date: " + System.DateTime.Now + "\n\n");
        File.AppendAllText(txtDocumentNameTest, "Name: " + config[0] +  "\n\n");
        File.AppendAllText(txtDocumentNameTest, "Surname: " + config[1] +  "\n\n");
        File.AppendAllText(txtDocumentNameTest, "Age: " + config[2]  +  "\n\n");
        File.AppendAllText(txtDocumentNameTest, "Sex: " + config[3]  +  "\n\n");


    }
    
    // Start is called before the first frame update
    void Awake()
    {

        CreateText();
        
       
        
    }


}
