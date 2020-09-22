using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;



public class MainGame : MonoBehaviour
{
    public GameObject[] game=new GameObject[40];
    GameObject[] tmp=new GameObject[40];
    public Gamecontroller gc;
    public int stage=0,stageAmount = 40;
    public List<string> timeList = new List<string>();
    public string playername;

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        GameRepeat();
    }

    void GameStart()
    {
        if(!tmp[stage])
        {
            tmp[stage]=Instantiate(game[stage]);
            gc=GameObject.Find("Game0(Clone)").GetComponentInChildren<Gamecontroller>();
        }
    }

    void DifferentStage()
    {
        if(!tmp[stage])
        {
            tmp[stage]=Instantiate(game[stage]);
            gc=GameObject.Find("Game"+stage.ToString()+"(Clone)").GetComponentInChildren<Gamecontroller>();
            if(stage!= stageAmount/2)
            {
                gc.isgamestart=true;
                gc.StartBtn.gameObject.SetActive(false);
                gc.PlayerName.gameObject.SetActive(false);
                gc.Description.gameObject.SetActive(false);
            }
            else
            {
                gc.PlayerName.gameObject.SetActive(false);
            }
        }
    }
    
    void GameOver()
    {
        if(gc.isgameover&&stage!=stageAmount)
        {
            if (stage == 0) playername = gc.getPlayerName();
            Debug.Log("Player:"+ gc.getPlayerName()+ "\tNo."+stage.ToString()+"\ttime ="+gc.getTime().ToString());
            timeList.Add(gc.getTime().ToString());
            Destroy(tmp[stage]);
            stage+=1;
            if (stage == stageAmount)
            {
                Debug.Log(playername + "start write");
                CsvWriter();
            }
            else
            {
                DifferentStage();
            }
        }  
    }

    void GameRepeat()
    {
        GameOver();
    }

    
    void CsvWriter()
    {
        Debug.Log("csv write start");
        try
        {
            FileInfo fi = new FileInfo("data.csv");
            string data="";
            if (!fi.Directory.Exists)
            {
                Debug.Log("file creating");
                fi.Directory.Create();
                data += "id,game1,game2,game3,game3,game4,game5,game6,game7,game8,game9,game10,game11," +
               "game12,game13,game14,game15,game16,game17,game18,game19,game20,game21,game22,game23,game24,game25," +
               "game26,game27,game28,game29,game30,game31,game32,game33,game34,game35,game36,game37,game38,game39,game40";
            }

            FileStream fs = new FileStream("data.csv", System.IO.FileMode.Append, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            
            data +=playername+",";
            for(int i = 0; i < stageAmount; i++)
            {
               Debug.Log(timeList[i]);
               data += timeList[i] + ",";
            }
 
            Debug.Log("writing data ="+data);
            sw.WriteLine(data);
            sw.Close();
            fs.Close();
        } catch (Exception e)
        {
            Debug.Log(e+"csv write fail");
            return;
        }
    }

}
