using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRed : MonoBehaviour
{
    Transform tran;
    public float Matcolor, Matcnt;
    // Start is called before the first frame update
    void Start()
    {
        tran = this.transform;
        Matcolor = Matcnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Matcnt > 1.5)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
            Matcolor = 1;
        }
        if (Matcnt >= 1.8)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            Matcolor = 2;
        }
        
        Matcnt += Time.deltaTime;
    }
}