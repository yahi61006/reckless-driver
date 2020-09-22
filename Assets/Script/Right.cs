using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public Gamecontroller gc;
    public LightRed colorR;
    public LightGreen colorG;
    public float i=0;
    Transform tran;
    //public float Matcolor, Matcnt;
    // Start is called before the first frame update
    void Start()
    {
        tran = this.transform;
        //Matcolor = Matcnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if(colorG.Matcolor==1) i=1;
            if(colorR.Matcolor==2) i=2;
        }catch{
            return;
        }
    }

    private void OnTriggerEnter(Collider SportsVehicleBlack)
    {
        if (i == 0) {
            Debug.Log("Right Default");
            gc.isDefault=true;
        }
        else if (i == 1) Debug.Log("Right Correct");
        else if(i==2) {
            Debug.Log("Right Stop");
            gc.isRedHit=true;
        }
        gc.isgameover = true;
        gc.isgamestart = false;
    }
}