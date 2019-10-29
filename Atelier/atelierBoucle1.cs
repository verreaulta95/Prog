using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelierBouche19_2
{
    class Program
    {
        public static void AfficherMenu()
        {
            Console.WriteLine("Voici vos options : ");
            Console.WriteLine(" 1 - Trouver le plus grand nombre");
            Console.WriteLine(" 2 - Trouver le plus petit nombre");
            Console.WriteLine(" 3 - Verifier si le nombre saisie existe");
            Console.WriteLine(" 4 - Faire la moyenne des nombres");
            Console.WriteLine(" 5 - Quitter le programme");
        }
        public static void AfficherPlusGrandNombre(ref int[] tabValeurAleatoire, ref int max)
        {
            //Permet de verifier quel est la plus grande valeur(max) ET si max est superieur a 9995
            for (int i = 0; i < tabValeurAleatoire.Length; i++)
            {
                if (max < tabValeurAleatoire[i])
                {
                    max = tabValeurAleatoire[i];  
                }
            }
            if (max > 9995)
            {
                Console.WriteLine("Il existe un nombre plus grand que 9995");
            }

            Console.WriteLine("Le plus grand nombre est " + max);
            Console.ReadKey();
            Console.Clear();
        }

        public static void AfficherPlusPetitNombre(ref int[] tabValeurAleatoire, ref int min)
        {
            //Permet de verifier si la variable min est la plus petite du tableau
            for (int i = 0; i < tabValeurAleatoire.Length; i++)
            {
                if (min > tabValeurAleatoire[i])
                {
                    min = tabValeurAleatoire[i];
                }
            }
            Console.WriteLine("Le plus petit nombre est " + min);
            Console.ReadKey();
            Console.Clear();
        }   
        
        public static void TrouverNombreTableau(ref int[] tabValeurAleatoire, ref bool nombreTrouver, ref int nombreSaisie, ref int nombreRevientPlusieursFois)
        {
            //Verifie si le nombre saisie existe dans le tableau + indice ET s'il se trouve + de 3 fois
            int cpt = 0;
            while (nombreTrouver == false && cpt < tabValeurAleatoire.Length)
            {
                if (nombreSaisie == tabValeurAleatoire[cpt])
                {
                    nombreRevientPlusieursFois++;
                    nombreTrouver = true;

                    Console.WriteLine("Le nombre : " + nombreSaisie + " existe et se trouve a l'indice : " + cpt);
                    if (nombreRevientPlusieursFois >= 3)
                        Console.WriteLine("Le nombre a ete trouver plus de trois fois.");
                }
                else
                {
                    cpt++;
                }
            }
            if (nombreTrouver == false)
            {
                Console.WriteLine("Le nombre : " + nombreSaisie + " n'existe pas dans le tableau");
            }
        }

        public static void TrouverMoyenne(ref int[] tabValeurAleatoire)
        {
            int moyenne = 0;
            int calculateur = 0;

            for (int i = 0; i < tabValeurAleatoire.Length; i++)
            {
                calculateur = calculateur + tabValeurAleatoire[i];
            }
            moyenne = calculateur / tabValeurAleatoire.Length;
            Console.WriteLine("La moyenne est de : " + moyenne);
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {            

            int choixMenu = 0;
            int max = 0;
            int min = 1000;
            int nombreRevientPlusieursFois = 0;
            bool nombreTrouver = false;
            int nombreSaisie = 0;

            //Creation Tableau + Generation nombre dans tableau
            int[] tabValeurAleatoire = new int[300];
            Random generateur = new Random();

            // Boucle qui met les nombres aleatoires dans le tableau
            for(int i = 0; i<tabValeurAleatoire.Length; i++)
            {
                tabValeurAleatoire[i] = generateur.Next(1, 10001);
            }

            /*Console.WriteLine(tabValeurAleatoire[10]);*/


            Console.WriteLine("Entrer un nombre");
            nombreSaisie = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ce nombre vous servira pour divers options.");
            Console.ReadKey();
            Console.Clear();

            while(choixMenu != 5)
            {
                AfficherMenu();
                choixMenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choixMenu)
                {
                    case 1: AfficherPlusGrandNombre(ref tabValeurAleatoire, ref max); break;
                    case 2: AfficherPlusPetitNombre(ref tabValeurAleatoire, ref min); break;
                    case 3: TrouverNombreTableau(ref tabValeurAleatoire, ref nombreTrouver, ref nombreSaisie, ref nombreRevientPlusieursFois); break;
                    case 4: TrouverMoyenne(ref tabValeurAleatoire); break;
                    case 5: break;
                }                
            }

            //fin

        }
    }
}
