using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelierPendu_19
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] tabPendu = { "allo", "programmation","informatique","anime","roblox","musique","peyruis","intro","interface","nintendo"};
            int[] tabNbLettre = new int[26];
            string mot = "";
            mot = tabPendu[0]; //Remplacer 0 par genererMotRandom
            int valeurLettre = 0;         
            int erreur = 0;
            bool finPartie = false;

            Random generateurMot = new Random();
            int genererMotRandom = generateurMot.Next(0, 9);

            Console.WriteLine(mot);

            char[] tabLettre = new char[mot.Length];
            
            for(int i =0; i < tabLettre.Length; i++)
            {
                //Affiche le mot en _ _ _ _ _ _ _ 
                tabLettre[i] = '_';
                Console.Write(tabLettre[i] + " ");                                
            }

            Console.WriteLine("");
            Console.WriteLine("Veuillez entrez une lettre");
            char lettre = Convert.ToChar(Console.ReadLine());            
            

            for (int i=0; i<tabNbLettre.Length; i++)
            {
                valeurLettre = (int)(lettre - 97);
                
            }
            Console.WriteLine(lettre);
            for (int i =0; i < mot.Length; i++)
            {

                if(lettre == mot[i])
                {
                    lettre = mot[valeurLettre];
                    Console.Write(tabLettre[i] + " ");

                }
                else
                {
                    Console.WriteLine("Mauvaise lettre");                    
                }
                
                
            }


            Console.ReadKey();
        }
    }
}
