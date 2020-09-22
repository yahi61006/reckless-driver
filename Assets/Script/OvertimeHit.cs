using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertimeHit : MonoBehaviour
{
    public Gamecontroller gc;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        gc.isgameover = true;
        gc.isgamestart = false;
    }
}
