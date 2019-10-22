using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelierBoucle19_2
{
    class Program
    {
        public static void Niveau1()
        {
            int nombre = 0;
            Random generateurNombre = new Random();
            nombre = generateurNombre.Next(1, 101);

            Console.WriteLine(" Le jeu consiste a trouver le nombre.");
            Console.WriteLine(" Vous aurez donc a devinez un nombre entre 1 et 100");
            Console.WriteLine(" Une notification apparaitra lorsque vous serez a plus ou moins 5 de difference.");
            Console.WriteLine(" Entrez votre premier nombre");

            int nombreSaisie = 0;
            int indicateur1 = nombre + 5;
            int indicateur2 = nombre - 5;
            bool finDeNiveau = false;
            nombreSaisie = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(nombre);

            while (nombreSaisie != nombre && finDeNiveau == false)
            {

                Console.WriteLine(" Votre nombre n'est pas le bon! Reessayer");
                nombreSaisie = Convert.ToInt32(Console.ReadLine());

                if (nombreSaisie < indicateur1 && nombreSaisie > indicateur2)
                {
                    Console.WriteLine(" ** Notification : 5 de difference ** ");
                }

                if (nombreSaisie == nombre && finDeNiveau == false)
                {
                    Console.WriteLine(" Vous avez trouver le nombre : " + nombre);
                    finDeNiveau = true;
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            
        }
        public static void Niveau2()
        {
            int nombre = 0;
            Random generateurNombre = new Random();
            nombre = generateurNombre.Next(1, 1001);

            Console.WriteLine(" Le jeu consiste a trouver le nombre.");
            Console.WriteLine(" Vous aurez donc a devinez un nombre entre 1 et 1000");
            Console.WriteLine(" Une notification apparaitra lorsque vous serez a plus ou moins 5 de difference.");
            Console.WriteLine(" Entrez votre premier nombre");

            int nombreSaisie = 0;
            int indicateur1 = nombre + 5;
            int indicateur2 = nombre - 5;
            bool finDeNiveau = false;
            nombreSaisie = Convert.ToInt32(Console.ReadLine());

            while (nombreSaisie != nombre && finDeNiveau == false)
            {

                Console.WriteLine(" Votre nombre n'est pas le bon! Reessayer");
                nombreSaisie = Convert.ToInt32(Console.ReadLine());

                if (nombreSaisie < indicateur1 && nombreSaisie > indicateur2)
                {
                    Console.WriteLine(" ** Notification : 5 de difference ** ");
                }

                if (nombreSaisie == nombre && finDeNiveau == false)
                {
                    Console.WriteLine(" Vous avez trouver le nombre : " + nombre);
                    finDeNiveau = true;
                    Console.ReadKey();
                    Console.Clear();
                }

            }


        }
        public static void Niveau3()
        {
            int nombre = 0;
            Random generateurNombre = new Random();
            nombre = generateurNombre.Next(1, 10001);

            Console.WriteLine(" Le jeu consiste a trouver le nombre.");
            Console.WriteLine(" Vous aurez donc a devinez un nombre entre 1 et 10 000");
            Console.WriteLine(" Une notification apparaitra lorsque vous serez a plus ou moins 5 de difference.");
            Console.WriteLine(" Entrez votre premier nombre");

            int nombreSaisie = 0;
            int indicateur1 = nombre + 5;
            int indicateur2 = nombre - 5;
            bool finDeNiveau = false;
            nombreSaisie = Convert.ToInt32(Console.ReadLine());

            while (nombreSaisie != nombre && finDeNiveau == false)
            {

                Console.WriteLine(" Votre nombre n'est pas le bon! Reessayer");
                nombreSaisie = Convert.ToInt32(Console.ReadLine());

                if (nombreSaisie < indicateur1 && nombreSaisie > indicateur2)
                {
                    Console.WriteLine(" ** Notification : 5 de difference ** ");
                }

                if (nombreSaisie == nombre && finDeNiveau == false)
                {
                    Console.WriteLine(" Vous avez trouver le nombre : " + nombre);
                    finDeNiveau = true;
                    Console.ReadKey();
                    Console.Clear();
                }

            }



        }


        static void Main(string[] args)
        {

            
            int niveauChoisi = 0;
            bool finDeJeu = false;

            while(finDeJeu == false)
            {
                Console.WriteLine(" Le jeu consiste a trouver le nombre.");
                Console.WriteLine(" Le jeu dispose de trois niveaux : ");
                Console.WriteLine(" 1 - Niveau 1 : 1 et 100");
                Console.WriteLine(" 2 - Niveau 2 : 1 et 1000");
                Console.WriteLine(" 3 - Niveau 3 : 1 et 10 000");               
                Console.WriteLine(" 4 - Quitter le menu");

                niveauChoisi = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (niveauChoisi)
                {
                    case 1: Niveau1(); break;
                    case 2: Niveau2(); break;
                    case 3: Niveau3(); break;
                    case 4: finDeJeu = true; break;
                }
            }
            

        }
    }
}
