using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRight : MonoBehaviour
{
    Transform tran;
    public float time, move_x, move_z;
    // Start is called before the first frame update
    void Start()
    {
        tran = this.transform;
        time = move_x = move_z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        move_x = 0.05f;
        move_z = 0.1f;
        if (time >= 1.8 && time < 2.8)
        {
            this.tran.position += new Vector3(move_x, 0, move_z);
        }
        time += Time.deltaTime;
    }
}

