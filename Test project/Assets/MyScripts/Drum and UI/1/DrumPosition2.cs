using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPosition2 : MonoBehaviour
{
    private Vector3 PosC;
    
    public GameObject PointRepère;

    
    
    public void InitPos(int nb)
    {
        
        /*PosC = this.transform.position;*/
        switch (nb)
        {
            case 1:
                this.transform.position = PointRepère.transform.position + Mathf.Cos(90 * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(90 * Mathf.Deg2Rad) * PointRepère.transform.forward + new Vector3(0,0.5f,0);
                break;
            case 2:
                this.transform.position = PointRepère.transform.position + Mathf.Cos(110 * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(110 * Mathf.Deg2Rad) * PointRepère.transform.forward + new Vector3(0, 0.5f, 0);
                break;
            case 3:
                this.transform.position = PointRepère.transform.position + Mathf.Cos(70 * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(70 * Mathf.Deg2Rad) * PointRepère.transform.forward + new Vector3(0, 0.5f, 0);
                break;
            case 4:
                this.transform.position = PointRepère.transform.position + Mathf.Cos(130 * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(130 * Mathf.Deg2Rad) * PointRepère.transform.forward + new Vector3(0, 0.5f, 0);
                break;
            case 5:
                this.transform.position = PointRepère.transform.position + Mathf.Cos(50 * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(50 * Mathf.Deg2Rad) * PointRepère.transform.forward + new Vector3(0, 0.5f, 0);
                break;

        }

    }

    public void ChangePos(float pos/*, Vector3 direction*/)
    {
        /*this.transform.position = PosC + direction * 2 *(pos > 0.5f ? pos - 0.5f : pos - 0.5f);*/
        this.transform.position = Mathf.Cos(pos*2*Mathf.PI) * PointRepère.transform.right + Mathf.Sin(pos*2*Mathf.PI)* PointRepère.transform.forward;
    }

    public void SetPos(int pos, Vector3 direction)
    {
        switch (pos)
        {
            case 1:
                this.transform.position = PosC + direction;
                break;
            case 2:
                this.transform.position = PosC - direction;
                break;
            default:
                this.transform.position = this.PosC;
                break;
        }
    }
}
