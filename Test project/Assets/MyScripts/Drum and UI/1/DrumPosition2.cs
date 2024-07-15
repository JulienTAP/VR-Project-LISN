using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPosition2 : MonoBehaviour
{
    private Vector3 PosC;
    public float hauteur;
    public float rayon;
    public GameObject PointRepère;

    private int angle;

    
    
    public void InitPos(int nb)
    {
        
        /*PosC = this.transform.position;*/
        switch (nb)
        {
            case 1:
                angle = 90;
                break;
            case 2:
                angle = 110;
                angle += 10 * (int)(2.0f - rayon);
                break;
            case 3:
                angle = 70;
                angle -= 10 * (int)(2.0f - rayon);
                break;
            case 4:
                angle = 130;
                angle += 20 * (int)(2.0f - rayon);
                break;
            case 5:
                angle = 50;
                angle -= 20 * (int)(2.0f - rayon);
                break;

        }
        
        this.transform.position = PointRepère.transform.position + rayon * (Mathf.Cos(angle * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(angle * Mathf.Deg2Rad) * PointRepère.transform.forward) + new Vector3(0, hauteur, 0);

    }

    public void ChangePos(float pos/*, Vector3 direction*/)
    {
        /*this.transform.position = PosC + direction * 2 *(pos > 0.5f ? pos - 0.5f : pos - 0.5f);*/
        this.transform.position = PointRepère.transform.position + rayon*(Mathf.Cos((pos+1.0f)* Mathf.PI + (angle-90) * Mathf.Deg2Rad) * PointRepère.transform.right - Mathf.Sin((pos + 1.0f) * Mathf.PI + (angle-90) * Mathf.Deg2Rad) * PointRepère.transform.forward) + new Vector3(0, hauteur, 0);
    }

    public void SetPos(int pos)
    {
        switch (pos)
        {
            case 1:
                this.transform.position = PointRepère.transform.position + rayon*(Mathf.Cos(pos * 2 * Mathf.PI + (angle - 90) * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + (angle -90) * Mathf.Deg2Rad) * PointRepère.transform.forward) + new Vector3(0, hauteur, 0);
                break;
            case 2:
                this.transform.position = PointRepère.transform.position + rayon *(Mathf.Cos(pos * 2 * Mathf.PI + (angle + 90) * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + (angle + 90) * Mathf.Deg2Rad) * PointRepère.transform.forward) + new Vector3(0, hauteur, 0);
                break;
            default:
                this.transform.position = PointRepère.transform.position + rayon * (Mathf.Cos(pos * 2 * Mathf.PI + angle * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + angle * Mathf.Deg2Rad) * PointRepère.transform.forward) + new Vector3(0, hauteur, 0);
                break;
        }
    }
}
