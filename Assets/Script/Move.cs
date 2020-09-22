using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform tran;
    public float Timecnt, speed, move_x, move_z;
    public int FlagTag;
    // Start is called before the first frame update
    void Start()
    {
        tran = this.transform;
        speed = 0.45f;
        Timecnt = move_x = move_z = 0;
        FlagTag = 10;
    }

    // Update is called once per frame
    void Update()
    {
        move_x = 0;
        move_z = 15 * Time.deltaTime;
        if (FlagTag != 0 && Timecnt > 1)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move_x -= speed;
                FlagTag--;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                move_x += speed;
                FlagTag--;
            }
        }
        this.tran.position += new Vector3(move_x, 0, move_z);
        Timecnt += Time.deltaTime;
    }
}
