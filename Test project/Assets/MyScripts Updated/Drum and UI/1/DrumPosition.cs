using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumPosition : MonoBehaviour
{
   
    public Transform Parent;
    public float rayon;
    public float hauteur;
    public GameObject PointRepère;
    

    private int angle;
    
    public void InitPos(int nb)
    {

       
        switch (nb)
        {
            case 0:
                angle = 90;
                break;
            case 1:
                angle = 110;
                angle += 10 * (int)(2.0f - rayon);
                break;
            case 2:
                angle = 70;
                angle -= 10 * (int)(2.0f - rayon);
                break;
            case 3:
                angle = 130;
                angle += 20 * (int)(2.0f - rayon);
                break;
            case 4:
                angle = 50;
                angle -= 20 * (int)(2.0f - rayon);
                break;

        }

        this.transform.position = PointRepère.transform.position + rayon * (Mathf.Cos(angle * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(angle * Mathf.Deg2Rad) * PointRepère.transform.forward) + new Vector3(0, Parent.position.y - PointRepère.transform.position.y, 0);
        this.transform.eulerAngles -= new Vector3(0, angle - (90 * (int)(2.0f - rayon)), 0);
    }

    public void ChangePos(float pos)
    {
       
        this.transform.position = PointRepère.transform.position + rayon * (Mathf.Cos((pos + 1.0f) * Mathf.PI + (angle - 90) * Mathf.Deg2Rad) * PointRepère.transform.right - Mathf.Sin((pos + 1.0f) * Mathf.PI + (angle - 90) * Mathf.Deg2Rad) * PointRepère.transform.forward) + new Vector3(0, Parent.position.y - PointRepère.transform.position.y, 0);
        this.transform.eulerAngles = new Vector3(-75, (pos + 1.0f) * Mathf.PI * Mathf.Rad2Deg + (angle - (90 * (int)(2.0f - rayon))), 90);
    }

    public void SetPos(int pos)
    {
        switch (pos)
        {
            case 2: //right
                this.transform.position = PointRepère.transform.position + rayon*(Mathf.Cos(pos * 2 * Mathf.PI + (angle - (90 * (int)(2.0f - rayon))) * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + (angle - (90 * (int)(2.0f - rayon))) * Mathf.Deg2Rad) * PointRepère.transform.forward);
                this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
                this.transform.eulerAngles = new Vector3(-75, pos * 2 * Mathf.PI * Mathf.Rad2Deg - (angle - (90 * (int)(2.0f - rayon))), 90);
                break;
            case 0: //left
                this.transform.position = PointRepère.transform.position + rayon *(Mathf.Cos(pos * 2 * Mathf.PI + (angle + (90 * (int)(2.0f - rayon))) * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + (angle + (90 * (int)(2.0f - rayon))) * Mathf.Deg2Rad) * PointRepère.transform.forward);
                this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
                this.transform.eulerAngles = new Vector3(-75, pos * 2 * Mathf.PI * Mathf.Rad2Deg - (angle + (90 * (int)(2.0f - rayon))), 90);
                break;
            case 1: //center
                this.transform.position = PointRepère.transform.position + rayon * (Mathf.Cos(pos * 2 * Mathf.PI + angle * Mathf.Deg2Rad) * PointRepère.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + angle * Mathf.Deg2Rad) * PointRepère.transform.forward);
                this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
                this.transform.eulerAngles = new Vector3(-75, pos * 2 * Mathf.PI * Mathf.Rad2Deg - angle, 90);
                break;
        }
    }
}
