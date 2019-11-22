using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ex1
{
    class Program
    {
        

        static void AfficherMenu()
        {
            Console.WriteLine("");
            Console.WriteLine(" Voici vos options : ");
            Console.WriteLine("");
            Console.WriteLine(" 1 - Afficher le nombre de mots contenu dans la pharase");
            Console.WriteLine(" 2 - Afficher combien de fois chaque lettre apparait ");
            Console.WriteLine(" 3 - Afficher la lettre qui apparait le plus souvent");
            Console.WriteLine(" 4 - Encoder la phrase en utilisant une cle de +2 et l'afficher");
            Console.WriteLine(" 5 - Quitter le programme");
           
        }
        static void AfficherNbMotPhrase(ref int nbMotPhrase)
        {
            Console.WriteLine("Vous avez : " + nbMotPhrase + " mots dans votre phrase");
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherLettrePhrase(ref string maPhrase)
        {
           
            int[] tabLettreMultiple = new int[26];

            for (int i = 0; i < maPhrase.Length; i++)
            {
                int valeurIndiceLettre = 0;
                valeurIndiceLettre = (int)(maPhrase[i] - 97);

                if (valeurIndiceLettre >= 0 && valeurIndiceLettre < 26)
                {
                    tabLettreMultiple[valeurIndiceLettre]++;
                }
            }

            for (int j = 0; j < tabLettreMultiple.Length; j++)
            {
                char lettre = (char)(j + 97);
                Console.WriteLine("Vous avez " + tabLettreMultiple[j] + " " + lettre);

            }
            Console.ReadKey();
            Console.Clear();
        }

        static void AfficherLettreRevientSouvent(ref string maPhrase)
        {
            int[] tabLettreMultiple = new int[26];
            int max = 0;
            int position = 0;

            for (int i = 0; i < maPhrase.Length; i++)
            {
                int valeurIndiceLettre = 0;
                valeurIndiceLettre = (int)(maPhrase[i] - 97);

                if (valeurIndiceLettre >= 0 && valeurIndiceLettre < 26)
                {
                    tabLettreMultiple[valeurIndiceLettre]++;                    
                }                
            }


            for (int i = 0; i < tabLettreMultiple.Length; i++)
            {

                if (max < tabLettreMultiple[i])
                {
                    max = tabLettreMultiple[i];
                    position = i;
                    
                }

            }


            Console.WriteLine("Le mot qui revient le plus souvent est : " + max + " lettre : " + (char)(position + 97));
            Console.ReadKey();
            Console.Clear();

        }

        static void EncodagePhrase(ref string maPhrase)
        {
            string phraseDecode = "";


            for (int i = 0; i < maPhrase.Length; i++)
            {
                int valeurLettre = (int)maPhrase[i];
                phraseDecode += (char)(valeurLettre + 2);


            }
            Console.WriteLine("Voici votre phrase encode " + phraseDecode);
        }
        static void Main(string[] args)
        {

            //Choix de la phrase et affichage 
            Console.WriteLine("Veuillez entrer une phrase de votre choix ");
            string maPhrase = Console.ReadLine();        
            Console.WriteLine("Voici votre phrase : " + maPhrase);
        
            string[] tabPhrase = maPhrase.Split(' ');
            int nbMotPhrase = tabPhrase.Length;
            bool finDeProgramme = false;


            while (finDeProgramme == false)
            {
                //Affiche menu et prend le choix de l'utilisateur
                
                AfficherMenu();
                int choixUtilisateur = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choixUtilisateur)
                {
                    case 1: AfficherNbMotPhrase(ref nbMotPhrase); break;
                    case 2: AfficherLettrePhrase(ref maPhrase);  break;
                    case 3: AfficherLettreRevientSouvent(ref maPhrase);  break;
                    case 4: EncodagePhrase(ref maPhrase);  break;
                    case 5: finDeProgramme = true; break;
                }

            }

            //Fin Exercise 1 du Lab 3

        }
    }
}
