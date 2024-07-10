using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPosition2 : MonoBehaviour
{
    private Vector3 PosC;
    private Vector3 PosD;
    private Vector3 PosG;
    
    void Start()
    {
        PosC = this.transform.position;
        PosD = this.transform.position + new Vector3(-1, 0, 0);
        PosG = this.transform.position + new Vector3(1,0,0);
    }

    public void ChangePos(float pos)
    {
        this.transform.position = PosG - new Vector3(2*pos,0,0);
    }

    public void SetPos(int pos)
    {
        switch (pos)
        {
            case 1:
                this.transform.position = PosD;
                break;
            case 2:
                this.transform.position = PosG;
                break;
            default:
                this.transform.position = PosC;
                break;
        }
    }
}
