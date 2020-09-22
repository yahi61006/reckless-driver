using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public Button StartBtn;
    public InputField PlayerName;
    public Text timer, over, Description;
    float temp;
    public bool isgameover = false, isgamestart = false,isDefault=false,isRedHit=false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isgamestart)
        {
            Time.timeScale = 1;
            StartBtn.gameObject.SetActive(false);
            PlayerName.gameObject.SetActive(false);
            Description.gameObject.SetActive(false);

            temp += Time.deltaTime;
            timer.text = "" + temp.ToString();
        }
        if (isgameover)
        {
            Time.timeScale = 0;
            over.gameObject.SetActive(isgameover);
        }
    }

    public float getTime()
    {
        if(temp>1.5f){
            if(isRedHit || isDefault){
                return temp+100;
                isRedHit=false;
                isDefault=false;
            }
        }
        return temp-1.5f;
    }

    public string getPlayerName()
    {
        return PlayerName.text;
    }

    public void StartBtnOnclick()
    {
        isgamestart = true;
    }
}
