using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Permet de d�finir les fonctions utiles au d�placement des instruments.

public class DrumPosition : MonoBehaviour
{
    
    public Transform Parent; // Gameobject qui d�finir sa position verticale (Y).
    public float rayon; // Le rayon � laquelle les instruments se trouvent autour de soi. (Modifiable dans l'inspecteur).
    public GameObject PointRep�re; // le Point de rep�re pour la rotation des instruments (le point de t�l�portation.

    private int angle; // L'angle que poss�de l'instrument dans le cercle de centre le point de rep�re (l'axe X est le 0).
    
    //Fonction qui permet d'Initialis� la position des Instruments, m�me ceux masqu�s.
    public void InitPos(int nb)
    {

        int AngleOffeset = 10 * (int)(2.0f - rayon); // Un offest qui permet aux instruments de ne pas se chevaucher si le rayon diminue.
        
        // Un swicth pour l'angle de d�part en fonction du num�ro de l'intrument (Du module).
        switch (nb)
        {
            case 0:
                angle = 90;
                break;
            case 1:
                angle = 110 + AngleOffeset;
                break;
            case 2:
                angle = 70 - AngleOffeset;
                break;
            case 3:
                angle = 120 + 2 * AngleOffeset;
                break;
            case 4:
                angle = 60 - 2 * AngleOffeset;
                break;
        }

        // D�place l'instrument sur le cercle de centre le point de rep�re, de l'angle qui lui est donn� et de du rayon selectionn�.
        this.transform.position = PointRep�re.transform.position + rayon * (Mathf.Cos(angle * Mathf.Deg2Rad) * PointRep�re.transform.right + Mathf.Sin(angle * Mathf.Deg2Rad) * PointRep�re.transform.forward);
        // Ajuste la hauteure de l'instrument en fonction de son parent.
        this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
        // Tourne l'objet de mani�re a ce qu'il soit toujours en face de l'utilisateur, pour que l'inclinaison soit conserv� dans le bon sens.
        this.transform.eulerAngles -= new Vector3(0, angle-90, 0);

    }

    // Permet de d�placer l'instrument d'une valeure flotante (rotation de 0 RAD � Pi RAD) autour du m�me cercle.
    public void ChangePos(float pos) //  0 <= pos <= 1 
    {
        // D�place l'instrument en fonction de la valeure flotante dans le demi cercle en face de l'utilisateur.
        this.transform.position = PointRep�re.transform.position + rayon*(Mathf.Cos((pos+1.0f)* Mathf.PI - (angle - 90) * Mathf.Deg2Rad) * PointRep�re.transform.right - Mathf.Sin((pos + 1.0f) * Mathf.PI - (angle - 90) * Mathf.Deg2Rad) * PointRep�re.transform.forward);
        // Ajuste la hauteure de l'instrument en fonction de son parent.
        this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
        // Tourne l'objet de mani�re a ce qu'il soit toujours en face de l'utilisateur, pour que l'inclinaison soit conserv� dans le bon sens.
        this.transform.eulerAngles =  new Vector3(-75, (pos + 1.0f) * Mathf.PI * Mathf.Rad2Deg  - (angle-90), 90);
    }

    // permet de d�placer l'instrument entre 3 positions : Gauche (Pi) , Centre (Pi/2) , Droite (0).
    public void SetPos(int pos)
    {
        //switch en fonction du code que l'on envoie.
        switch (pos)
        {
            case 2: //right
                //Deplace, ajuste et tourne, de la m�me mani�re que pr�c�dement.
                this.transform.position = PointRep�re.transform.position + rayon*(Mathf.Cos(pos * 2 * Mathf.PI + (angle - 90) * Mathf.Deg2Rad) * PointRep�re.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + (angle - 90) * Mathf.Deg2Rad) * PointRep�re.transform.forward);
                this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
                this.transform.eulerAngles = new Vector3(-75, pos * 2 * Mathf.PI * Mathf.Rad2Deg - (angle - 90), 90);
                break;
            case 0: //left
                //Deplace, ajuste et tourne, de la m�me mani�re que pr�c�dement.
                this.transform.position = PointRep�re.transform.position + rayon *(Mathf.Cos(pos * 2 * Mathf.PI + (angle + 90) * Mathf.Deg2Rad) * PointRep�re.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + (angle + 90) * Mathf.Deg2Rad) * PointRep�re.transform.forward);
                this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
                this.transform.eulerAngles = new Vector3(-75, pos * 2 * Mathf.PI * Mathf.Rad2Deg - (angle + 90), 90);
                break;
            case 1: //center
                //Deplace, ajuste et tourne, de la m�me mani�re que pr�c�dement.
                this.transform.position = PointRep�re.transform.position + rayon * (Mathf.Cos(pos * 2 * Mathf.PI + angle * Mathf.Deg2Rad) * PointRep�re.transform.right + Mathf.Sin(pos * 2 * Mathf.PI + angle * Mathf.Deg2Rad) * PointRep�re.transform.forward);
                this.transform.position = new Vector3(this.transform.position.x, Parent.position.y, this.transform.position.z);
                this.transform.eulerAngles = new Vector3(-75, pos * 2 * Mathf.PI * Mathf.Rad2Deg - angle, 90);
                break;
        }
    }
}
