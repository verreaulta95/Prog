using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2019
{
    
    class Program
    {
        //Generateur nombre
        static Random generateurNombre = new Random();       
        public struct Commandant
        {
            public Vaisseau[] tabVaisseau;

            public Commandant(string _nomCommandantVaisseau):this()
            {
                tabVaisseau = new Vaisseau[20];


                for (int i = 0; i < tabVaisseau.Length; i++)
                {

                    int rarete = generateurNombre.Next(1, 101);

                    if (rarete >= 1 && rarete <= 60)
                    {
                        tabVaisseau[i] = new Vaisseau(generateurNombre.Next(10, 25), generateurNombre.Next(100, 150), 2000);
                    }
                    else if (rarete >= 61 && rarete <= 90)
                    {
                        tabVaisseau[i] = new Vaisseau(generateurNombre.Next(23, 50), generateurNombre.Next(140, 250), 4500);
                    }
                    else if(rarete >= 91 && rarete <= 99)
                    {
                        tabVaisseau[i] = new Vaisseau(generateurNombre.Next(65, 75), generateurNombre.Next(200, 600), 8000);
                    }
                    else if(rarete >= 100 )
                    {
                        tabVaisseau[i] = new Vaisseau(generateurNombre.Next(90,110), generateurNombre.Next(550, 2000), 20000);
                    }
                    
                }
            }

        }
  
        public struct Vaisseau
        {           
            public int attaqueVaisseau;
            public int vieVaisseau;
            public int prixVaisseau;


            public Vaisseau(int _attaqueVaisseau, int _vieVaisseau, int _prixVaisseau) : this()
            {                

                attaqueVaisseau = _attaqueVaisseau;
                vieVaisseau = _vieVaisseau;
                prixVaisseau = _prixVaisseau;
            }
                
        }
        static void AfficherMenu()
        {
            Console.WriteLine(" 1 - Afficher les vaisseaux avec toutes les caracteristiques");
            Console.WriteLine(" 2 - Verifier si un vaisseau legendaire existe");
            Console.WriteLine(" 3 - Trouver le vaisseau avec le plus d'attaque");
            Console.WriteLine(" 4 - Afficher la moyenne des prix des vaisseaux");
            Console.WriteLine(" 5 - Quitter le programme");
        }
        static void AfficherCaracteristique(ref Vaisseau[] tabVaisseau)
        {
            bool sortieTableauVaisseau = false;
            int position = 0;

            

            for(int i=0; i < tabVaisseau.Length; i++)
            {
                Console.WriteLine(" Vaisseau " + (i + 1) + " Attaque : " + tabVaisseau[i].attaqueVaisseau + " vie : " + tabVaisseau[i].vieVaisseau + " Prix : " + tabVaisseau[i].prixVaisseau);
                Console.ReadKey();
                

            }

        }

        static void AfficherSiLegendaireExiste(ref Vaisseau[] tabVaisseau)
        {
            int cpt = 0;
            bool vaisseauLegendaire = false;

            while(cpt < tabVaisseau.Length && vaisseauLegendaire == false)
            {
                if (tabVaisseau[cpt].attaqueVaisseau >= 90)
                    vaisseauLegendaire = true;
                else
                    cpt++;
                    
            }

            if(vaisseauLegendaire == true)
                Console.WriteLine(" Nous avons trouver un tel vaisseau !");
            else
                Console.WriteLine(" Helas, cette merveille n'est point disponible ... ");

            Console.ReadKey();

        }
        static void AfficherPlusAttaque(ref Vaisseau[] tabVaisseau)
        {
            int attaqueSuperieur = 0;
            int positionVaisseau = 0;

            for(int i =0; i< tabVaisseau.Length; i++)
            {
                if(tabVaisseau[i].attaqueVaisseau > attaqueSuperieur)
                {
                    attaqueSuperieur = tabVaisseau[i].attaqueVaisseau;
                    positionVaisseau = i;
                }
            }

            Console.WriteLine(" Voici le vaisseau ayant le plus d'attaque : " + tabVaisseau[positionVaisseau].attaqueVaisseau + " ainsi que sa position " + positionVaisseau);
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherMoyennePrix(ref Vaisseau[] tabVaisseau)
        {
            int accumulateurPrix = 0;
            int moyenne = 0;

            for(int i =0; i < tabVaisseau.Length; i++)
            {
                accumulateurPrix += tabVaisseau[i].prixVaisseau;
            }
            moyenne = accumulateurPrix / tabVaisseau.Length;

            Console.WriteLine(" Voici la moyenne des prix des vaisseaux : " + moyenne);
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            

            string nomCommandantVaisseau = "";
            bool finProgramme = false;
            Console.WriteLine("Bonjour Commandant ... Attendez, quel est votre nom !?");
            nomCommandantVaisseau = Convert.ToString(Console.ReadLine());

            Commandant commandantVaisseau = new Commandant(nomCommandantVaisseau);

            while(finProgramme == false)
            {
                Console.Clear();

                AfficherMenu();
                int choixmenu = Convert.ToInt32(Console.ReadLine());


                switch (choixmenu)
                {
                    case 1: AfficherCaracteristique(ref commandantVaisseau.tabVaisseau); break;
                    case 2: AfficherSiLegendaireExiste(ref commandantVaisseau.tabVaisseau); break;
                    case 3: AfficherPlusAttaque(ref commandantVaisseau.tabVaisseau);  break;
                    case 4: AfficherMoyennePrix(ref commandantVaisseau.tabVaisseau);  break;
                    case 5: finProgramme = true; break;
                    default: Console.WriteLine("Prenez une option dans les choix proposer"); break; 
                }
            }

            Console.ReadKey();

        }
    }
}
