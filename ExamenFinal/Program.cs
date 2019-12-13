using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen3_2019
{
    class Program
    {
        static Random generateurNb = new Random();
        public struct Alliage
        {
            public string nom;
            public int resistance;
            public int pointFusion;
            public int poids;
            public int conductivite;

            public Alliage(string _nom, int _resistance, int _pointFusion, int _poids, int _conductivite) : this()
            {
                nom = _nom;
                resistance = _resistance;
                pointFusion = _pointFusion;
                poids = _poids;
                conductivite = _conductivite;

            }

        }
       
        static void Main(string[] args)
        {

            Alliage[] tabMetaux = new Alliage[4];

            // Nom + Resistance + PointFusion + Poids + Conductivite

            tabMetaux[0] = new Alliage("Fer",7,9,4,3);
            tabMetaux[1] = new Alliage("Cuivre", 4, 8, 8, 2);
            tabMetaux[2] = new Alliage("Plomb", 1, 3, 7, 2);
            tabMetaux[3] = new Alliage("Zinc", 2, 5, 3, 6);

            bool finMenu = false;            

            while(finMenu == false)
            {
                AfficherMenu();

                int choix = 0;
                choix = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choix)
                {
                    case 1: AfficherMeilleurResistance(ref tabMetaux); break;
                    case 2: AfficherHighscore(ref tabMetaux); break;
                    case 3: AfficherConductivite(ref tabMetaux);  break;
                    case 4: AfficherFusionMetaux(ref tabMetaux); break;
                    case 5: finMenu = true; break;
                    default: Console.WriteLine("Vous devez choisir une option valable, re-essayer!"); break;
                }
            }

            //test
            Console.WriteLine(tabMetaux[0].nom + " Resistance : " + tabMetaux[0].resistance);
            Console.ReadKey();
        }


        static void AfficherMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1 - Connaitre le metal avec la meilleure resistance");
            Console.WriteLine("2 - Connaitre le metal avec le meilleur score");
            Console.WriteLine("3 - Savoir si un metal avec une conductivite superieur a 6 existe");
            Console.WriteLine("4 - Creer un nouvel alliage");
            Console.WriteLine("5 - Quitter");
            Console.WriteLine("");            

        }


        static void AfficherMeilleurResistance(ref Alliage[] tabMetaux)
        {
            int meilleur = 0;
            string nom = "";
            int position = 0;

            for (int i = 0; i < tabMetaux.Length; i++)
            {
                if (tabMetaux[i].resistance < meilleur)
                {
                    meilleur = tabMetaux[i].resistance;
                    nom = tabMetaux[i].nom;
                    position = i;
                }
            }

            Console.WriteLine(tabMetaux[position].nom + " avec une resistance de : " + tabMetaux[position].resistance);
        }


        static void AfficherHighscore(ref Alliage[] tabMetaux)
        {
            int meilleur = 0;
            string nom = "";
            int position = 0;

            int fer = (tabMetaux[0].resistance + tabMetaux[0].poids + tabMetaux[0].pointFusion + tabMetaux[0].conductivite) / 4;
            int cuivre = (tabMetaux[1].resistance + tabMetaux[1].poids + tabMetaux[1].pointFusion + tabMetaux[1].conductivite) / 4;
            int plomb = (tabMetaux[2].resistance + tabMetaux[2].poids + tabMetaux[2].pointFusion + tabMetaux[2].conductivite) / 4;
            int zinc = (tabMetaux[3].resistance + tabMetaux[3].poids + tabMetaux[3].pointFusion + tabMetaux[3].conductivite) / 4;

            int[] tabHigh = new int[4];
            tabHigh[0] = fer;
            tabHigh[1] = cuivre;
            tabHigh[2] = plomb;
            tabHigh[3] = zinc;

            for (int i = 0; i < tabMetaux.Length; i++)
            {
                if(tabHigh[i] > meilleur)
                {
                    meilleur = tabHigh[i];
                    position = i;
                }
            }

           switch(position)
           {
                case 0: nom = "fer"; break;
                case 1: nom = "cuivre"; break;
                case 2: nom = "plomb"; break;
                case 3: nom = "zinc"; break;

           }

            Console.WriteLine("Le metal : " + nom + " a obtenu la meilleur cote : " + meilleur);
        }

        static void AfficherConductivite(ref Alliage[] tabMetaux)
        {
            bool trouver = false;
            int cpt = 0;
            int conductivite = 6;

            while(trouver == false && cpt < 4)
            {
                if(tabMetaux[cpt].conductivite > conductivite)
                {
                    trouver = true;
                }
                else
                {
                    cpt++;
                }
            }

            if (trouver == true)
            {
                Console.WriteLine("Le metal avec une conductivite de 6 ou plus est : " + tabMetaux[cpt]);
            }
            else
            {
                Console.WriteLine("Un metal avec une conductivite de " + conductivite + " existe pas");
            }

        }


        static void AfficherFusionMetaux(ref Alliage[] tabMetaux)
        {

            int choixMetal1 = 0;
            int choixMetal2 = 0;
            string nom1 = "";
            string nom2 = "";
            bool choixCorrecte = false;

            Console.WriteLine("Voici les metaux a votre disposition : ");
            Console.WriteLine("Vous devez en choisir 2 parmi ceux-ci");
            Console.WriteLine("");

            for(int i = 0; i < tabMetaux.Length; i++)
            {
                Console.WriteLine((i+1) + " - " + tabMetaux[i].nom);
            }

            Console.ReadKey();
            Console.Clear ();

            Console.WriteLine("Pour choisir, prenez un nombre entre 1 et 4");
            Console.WriteLine("");
            Console.WriteLine("Entrez votre nombre pour le premier");
            choixMetal1 =  Convert.ToInt32(Console.ReadLine()) - 1 ;
            Console.WriteLine("Entrez votre nombre pour le second");
            choixMetal2 =  Convert.ToInt32(Console.ReadLine()) - 1;

            //Verification si 2 nombres sont pareil +/ autrement refais choisir le 2ime
            while (choixCorrecte == false)
            {
                if(choixMetal1 > 3)
                {
                    choixMetal1 = 1 + Convert.ToInt32(Console.ReadLine());
                }
                if (choixMetal1 == choixMetal2)
                {
                    Console.WriteLine("Reessayer !! Un seul metal unique par choix ");
                    choixMetal1 = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    choixCorrecte = true;
                }
            }

            //Prise de nom pour le metal
            switch (choixMetal1)
            {
                case 0: nom1 = "fer"; break;
                case 1: nom1 = "cuivre"; break;
                case 2: nom1 = "plomb"; break;
                case 3: nom1 = "zinc"; break;
            }
            switch (choixMetal2)
            {
                case 0: nom2 = "fer"; break;
                case 1: nom2 = "cuivre"; break;
                case 2: nom2 = "plomb"; break;
                case 3: nom2 = "zinc"; break;

            }

            int concentration1 = 0;
            int concentration2 = 0;

            Console.Clear();
            Console.WriteLine("Vous devez choisir le pourcentage de chaque metaux");
            Console.WriteLine("Vous devez prendre un nombre ENTIER entre 1 et 100");
            Console.WriteLine("(Penser a garder de la place pour le second)");
            Console.WriteLine("");

            bool concentrationCorrecte = false;
            int concentrationMax = 100;

            //Choix concentration
            Console.WriteLine("Pourcentage pour : " + nom1);
            concentration1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pourcentage pour : " + nom2);
            concentration2 = Convert.ToInt32(Console.ReadLine());

            while ((concentration1 > 95 || concentration2 > concentration1)  && concentrationCorrecte == false)
            {          
                if (concentration1 > 95 )
                {
                    Console.WriteLine("Pourcentage pour : " + nom1);
                    Console.WriteLine("Reduisez votre concentration ! MAX = 95");
                    concentration1 = Convert.ToInt32(Console.ReadLine());
                }

                concentrationMax = concentrationMax - concentration1;

                if(concentration2 > concentrationMax)
                {
                    Console.WriteLine("Reduisez votre concentration ! MAX = 95 et le 2ime dois pas depasser 5 !");
                    Console.WriteLine("Pourcentage pour : " + nom2);
                    concentration2 = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    concentrationCorrecte = true;
                    Console.WriteLine("Votre concentration semble correcte ! ");
                }
            }

            //Derniere etape +/ faire melange et sortir nom + stats
            Console.WriteLine("Veuillez patientez pendant que le proccessus s'effectue ! ");

            double pointage = 0;
            string cote = "";
            int nouvelleResistance = (tabMetaux[choixMetal1].resistance * concentration1) + (tabMetaux[choixMetal2].resistance * concentration2);
            int nouveauPointFusion = (tabMetaux[choixMetal1].pointFusion * concentration1) + (tabMetaux[choixMetal2].pointFusion * concentration2);
            int nouveauPoid = (tabMetaux[choixMetal1].poids * concentration1) + (tabMetaux[choixMetal2].poids * concentration2);
            int nouvelleConductivite = (tabMetaux[choixMetal1].conductivite * concentration1) + (tabMetaux[choixMetal2].conductivite * concentration2);

            pointage = Math.Abs(nouvelleResistance - 5) + Math.Abs(nouveauPointFusion - 5) + Math.Abs(nouveauPoid - 5) + Math.Abs(nouvelleConductivite - 5);

            if(pointage > 7)
            {
                cote = "Faible";
            }
            else if(pointage > 3.5 && pointage <= 7)
            {
                cote = "Moyen";
            }
            else if(pointage <= 3.5 && pointage <= 1)
            {
                cote = "Bon";
            }
            else
            {
                cote = "PARFAIT";
            }



            //Permet de trouver le premier mot
            int positionPremierEspace = nom1.IndexOf(' ');
            string premierMot = nom1.Substring(0, positionPremierEspace);

            //Permet de trouver le 2ime mot
            int positionDeuxiemeEspace = nom2.IndexOf(' ');
            string secondMot = nom2.Substring(0, positionPremierEspace);

            string newAlliance = "";

            if(concentration1 > concentration2)
            {
                newAlliance = nom1 + secondMot;
            }
            else
            {
                newAlliance = nom2 + premierMot;
            }

            Console.WriteLine(" Voici votre nouvelle alliage : " + newAlliance  + " avec une resistance de  : " + pointage + " de type : " + cote); 

            Console.ReadKey();
        }

    }
}
