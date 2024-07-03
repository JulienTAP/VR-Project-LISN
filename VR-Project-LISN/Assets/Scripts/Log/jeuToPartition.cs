using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System;
using UnityEngine;


public class jeuToPartition : MonoBehaviour
{

    public string path; // le chemin du fichier de partition.
    public string[] Instrument = new string[] { "Xylophone", "Batterie" }; //les deux instruments possibles.
    public DateTime date; // la date de l'enregistrement de la partition.
    public string nom; // Le nom de la personne.
    public string prenom; // Le prénom de la personne.
    public int scène; // le numéro de la scène (0 ou 1) -> Xylophone ou Batterie.

    public bool side; //le coté à travailler (gauche/droite).
    public bool[] mains = new bool[] { false, false }; // gauche/droite. ( les mains que le patient utilise)
    public int nbTouches; // ne nombres de modules que l'instrument utilise.

    TextWriter tw;
    public jeuToPartition(DateTime date, string nom, string prenom, int scène, bool side, bool[] mains, int nbTouches)
    {
        this.date = date;
        this.nom = nom;
        this.prenom = prenom;
        this.scène = scène;
        this.side = side;
        this.mains = mains;
        this.nbTouches = nbTouches;
    }


    public void InitDoc()
    {

        path = "E:/Code/LISN/musique/Partition.txt"; // A compléter
        if (!File.Exists(path))
        {
            
            tw = new StreamWriter(path);
            tw.WriteLine("Rapport d'activité du jeu de : " + this.nom);
            tw.WriteLine(this.date);
            tw.WriteLine("Instrument utilisé : " + Instrument[this.scène]); //Xylophone, batterie.
            tw.WriteLine("---");
            
        }
        else if (File.Exists(path))
        {
            Console.Write("Le fichier existe déjà");
        }

    }

    public void InitSettings()
    {
        tw.WriteLine("Paramètres de la partition : ");
        tw.WriteLine("Côté à travailler : " + this.side?"Droite":"Gauche");
        tw.WriteLine("Nombre de mains : " + this.mains[1]?(this.mains[0]?"Les deux mains":"La main droite"):"La main gauche");
        tw.WriteLine("Nombre de touches : " + this.nbTouches);
        tw.WriteLine("---");
        
    }

    public void WriteNote(/*Note note*/ string note, float time /*(en secondes)*/ ) // A completer avec la class Note ou pas en fonction de l'implémentation de wwise.
    {
        tw.WriteLine(note + "       " + time); 
    }

}

//Pour teester le code

namespace programe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            jeuToPartition jeu = new jeuToPartition(DateTime.Now, "Dupont", "Jean", 0, true, new bool[] { true, false }, 5);
            jeu.InitDoc();
            jeu.InitSettings();
            jeu.WriteNote("Do", 0.5f);
            jeu.tw.Close(); // A verifier
        }
    }
}