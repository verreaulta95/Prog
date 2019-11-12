using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelierConditionString
{
    class Program
    {

        static void AfficherMenu(ref int choixMenu)
        {
            Console.Clear();
            Console.WriteLine("Entrez un nombre pour effectuer une action parmi celles-ci : ");
            Console.WriteLine("");
            Console.WriteLine(" 1 - Permet d'afficher la longueur de la chaine de caracteres");
            Console.WriteLine(" 2 - Permet de determiner si la phrase contient le mot 'octopus' ");
            Console.WriteLine(" 3 - Permet de connaitre la position du premier 'e' ");
            Console.WriteLine(" 4 - Permet d'afficher une sous phrase");
            Console.WriteLine(" 5 - Transforme la chaine en majuscule et l'affiche ");
            Console.WriteLine(" 6 - Transforme la chaine en minuscule et l'affiche ");
            Console.WriteLine(" 7 - Ferme le programme ");

            choixMenu = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
        }

        
        static void Main(string[] args)
        {
           
            
            Console.WriteLine("- Entrez un mot ou une phrase ");
            Console.WriteLine("- Vous pourrez ensuite l'utilisez de plusieurs manieres differentes");
            string maPhrase = Convert.ToString(Console.ReadLine());
            Console.Clear();
            bool finDeProgramme = false;

            
            int positionLettreE = maPhrase.IndexOf('e') + 1;

            //Permet de trouver le dernier mot
            int positionDernierEspace = maPhrase.LastIndexOf(' ');
            string dernierMot = maPhrase.Substring(positionDernierEspace + 1);

            //Permet de trouver le premier mot
            int positionPremierEspace = maPhrase.IndexOf(' ');
            string premierMot = maPhrase.Substring(0, positionPremierEspace);

            while(finDeProgramme == false)
            {
                int choixMenu = 0;
                AfficherMenu(ref choixMenu);

                switch (choixMenu)
                {
                    case 1: Console.WriteLine("Votre mot/phrase contient " + maPhrase.Length + " caracteres "); break;
                    case 2:
                        if (maPhrase.Contains("octopus") == true)
                        {
                            Console.WriteLine("Votre phrase contient bien le mot 'octopus' ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Votre phrase ne contient pas le mot 'octopus' ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        if (positionLettreE == -1)
                        {
                            Console.WriteLine("Votre phrase ne contient pas de lettre 'e' ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("La lettre 'e' se trouve a la position " + positionLettreE);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Voici le premier mot de votre phrase " + premierMot);
                        Console.WriteLine("Voici le dernier mot de votre phrase " + dernierMot);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5: Console.WriteLine(maPhrase.ToUpper()); break;
                    case 6: Console.WriteLine(maPhrase.ToLower()); break;
                    case 7:  finDeProgramme = true; break;
                }
            }
            


            

        }
    }
}
