using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2019_31
{
    class Program
    {
        static Random generateurNb = new Random();
        public struct Joueur
        {
            //Creer les variables
            public string nom;
            public int hp;
            public Carte[] tabCarte;
            
            
            public Joueur(string _nom, int _hp) : this()
            {
                //ajoute une valeur a une variable
                nom = _nom;
                tabCarte = new Carte[3];  // Main du joueur

                //Genere la main du joueur
                for(int i =0; i<tabCarte.Length; i++)
                {
                    tabCarte[i] = GenererCarte(); 
                }

            }
        }

        public enum Sorte { Coeur = 1, Carreaux = 2, Trefle = 3, Pique = 4 };


        public struct Carte
        {
            public Sorte sorteCarte; 
            public int valeurCarte;

            public Carte(Sorte _sorteCarte, int _valeurCarte) : this()
            {
                sorteCarte = _sorteCarte;
                valeurCarte = _valeurCarte;    
                
               
            }
        }

        static Carte GenererCarte()
        {
            //Tenter de faire en sorte qu'il y ait que des cartes uniques
            return new Carte( (Sorte) generateurNb.Next(1, 5), generateurNb.Next(1, 15) );
        }

        static void AfficherTableauJoueur1(Joueur monJoueur)
        {
            //Fonction qui affiche la main du joueur 
            Console.WriteLine("Carte 1 : " + monJoueur.tabCarte[0].valeurCarte + " de " + monJoueur.tabCarte[0].sorteCarte);
            Console.WriteLine("Carte 2 : " + monJoueur.tabCarte[1].valeurCarte + " de " + monJoueur.tabCarte[1].sorteCarte);
            Console.WriteLine("Carte 3 : " + monJoueur.tabCarte[2].valeurCarte + " de " + monJoueur.tabCarte[2].sorteCarte);
        }


        static void AfficherTableauIA(Joueur monOrdi)
        {
            Console.WriteLine("Carte 1 : " + monOrdi.tabCarte[0].valeurCarte + " de " + monOrdi.tabCarte[0].sorteCarte);
            Console.WriteLine("Carte 2 : " + monOrdi.tabCarte[1].valeurCarte + " de " + monOrdi.tabCarte[1].sorteCarte);
            Console.WriteLine("Carte 3 : " + monOrdi.tabCarte[2].valeurCarte + " de " + monOrdi.tabCarte[2].sorteCarte);
        }
        static void GenereCarteMilieu(Carte carteMilieu)
        {
            Console.WriteLine("Voici la carte du milieu : " + carteMilieu.valeurCarte + " de " + carteMilieu.sorteCarte);
        }
        
        static void Main(string[] args)
        {

            //Permet de choisir son nom
            string nomJoueur1 = "";
            Console.WriteLine("Joueur1, veuillez entrez votre nom");
            nomJoueur1 = Convert.ToString(Console.ReadLine());
            Console.Clear();


            //Ajout = Demander au joueur combien ils sont (DEFI)
            /*string nomJoueur2 = "";
            Console.WriteLine("Joueur2, veuillez entrez votre nom");
            nomJoueur2 = Convert.ToString(Console.ReadLine());
            Console.Clear();*/


            Carte carteMilieu = GenererCarte();
            Carte temp;


            //Cree le nom ET affiche les cartes du joueur 1 + Joueur 2 + ordi
            Joueur monJoueur = new Joueur(nomJoueur1, 3);
            /*Joueur monjoueur2 = new Joueur(nomJoueur2, 3);*/
            string IntelligenceArtificiel = "Intelligence Artificiel ";
            Joueur monOrdi = new Joueur(IntelligenceArtificiel, 3);                                    



            // Debut du jeu + Boucle tant que la game est pas fini
            bool endGame = false;

            while(endGame == false)
            {
                bool choixJoueur1Invalide = false;
                bool finDeTour = false;
                

                while (choixJoueur1Invalide == false && finDeTour == false)
                {
                    //Main du joueur
                    Console.WriteLine(nomJoueur1 + ", voici vos cartes :");
                    Console.WriteLine("");
                    AfficherTableauJoueur1(monJoueur);
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("Vous avez 3 options :");
                    Console.WriteLine(" 1 - Prendre une nouvelle carte");
                    Console.WriteLine(" 2 - Prendre la carte du milieu");
                    Console.WriteLine(" 3 - Cogner (+ de 21)");

                    Console.WriteLine("");
                    GenereCarteMilieu(carteMilieu);
                    Console.WriteLine("");                    

                    int choixJoueur1 = Convert.ToInt32(Console.ReadLine());
                    

                    if (choixJoueur1 == 1)
                    {
                        Console.WriteLine("Laquelle de vos cartes voulez-vous changer");
                        int changerCarteJoueur = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Voici votre nouvelle main : ");
                        Console.WriteLine("");
                        monJoueur.tabCarte[changerCarteJoueur - 1] = GenererCarte();
                        AfficherTableauJoueur1(monJoueur);
                        choixJoueur1Invalide = true;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (choixJoueur1 == 2)
                    {
                        Console.WriteLine("Laquelle de vos cartes voulez-vous changer");
                        int changerCarteJoueur = Convert.ToInt32(Console.ReadLine());

                        //Permet de changer l'une des cartes en main pour une autre
                        temp = monJoueur.tabCarte[changerCarteJoueur - 1];
                        monJoueur.tabCarte[changerCarteJoueur - 1] = carteMilieu;
                        carteMilieu = temp;

                        //Affiche la main du joueur et la carte du milieu
                        AfficherTableauJoueur1(monJoueur);
                        Console.WriteLine("");
                        GenereCarteMilieu(carteMilieu);
                        choixJoueur1Invalide = true;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (choixJoueur1 == 3)
                    {
                        if (monJoueur.tabCarte[0].valeurCarte + monJoueur.tabCarte[1].valeurCarte + monJoueur.tabCarte[2].valeurCarte >= 21 && finDeTour == false)
                        {
                            //Mettre la condition de fin et un tour restant
                            Console.WriteLine();
                            Console.WriteLine(" * IL RESTE UN TOUR * ");
                            finDeTour = true;
                            endGame = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Vous ne pouvez faire ca. Tenter une autre option.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                }

                //Rajouter le tour du joueur 2

                //Tour de l'IA

                Console.WriteLine(" Veuillez patientez, c'est maintenant au tour de l'IA");
                bool intelChangeCarte = false;


                //Effacer affichage avant remise
                AfficherTableauIA(monOrdi);
                Console.ReadKey();

                if (monOrdi.tabCarte[0].valeurCarte + monOrdi.tabCarte[1].valeurCarte + monOrdi.tabCarte[2].valeurCarte >= 21 && finDeTour == false)
                {
                    Console.WriteLine(" * IA VIENT DE COGNER ---- IL RESTE UN TOUR * ");
                    finDeTour = true;
                    endGame = true;
                }
                else
                {
                    int carteMin = 50;
                    //Boucle permettant de trouver la plus petite carte
                    for (int i = 0; i < monOrdi.tabCarte.Length; i++)
                    {
                        if (monOrdi.tabCarte[i].valeurCarte <= carteMin)
                            carteMin = monOrdi.tabCarte[i].valeurCarte;
                    }


                    if (monOrdi.tabCarte[0].valeurCarte == carteMin)
                    {
                        if (monOrdi.tabCarte[0].valeurCarte >= carteMilieu.valeurCarte)
                        {
                            monOrdi.tabCarte[0] = GenererCarte();
                            Console.WriteLine(" L'IA a choisi une nouvelle carte");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {

                            temp = monOrdi.tabCarte[0];
                            monOrdi.tabCarte[0] = carteMilieu;
                            carteMilieu = temp;
                            
                            
                            Console.WriteLine(" L'IA prend la carte du centre");
                            GenereCarteMilieu(carteMilieu);
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }
                    else if (monOrdi.tabCarte[1].valeurCarte == carteMin)
                    {
                        if (monOrdi.tabCarte[1].valeurCarte >= carteMilieu.valeurCarte)
                        {
                            monOrdi.tabCarte[1] = GenererCarte();
                            Console.WriteLine(" L'IA a choisi une nouvelle carte");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            temp = monOrdi.tabCarte[0];
                            monOrdi.tabCarte[0] = carteMilieu;
                            carteMilieu = temp;

                            GenereCarteMilieu(carteMilieu);
                            Console.WriteLine(" L'IA prend la carte du centre");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else if (monOrdi.tabCarte[2].valeurCarte == carteMin)
                    {
                        if (monOrdi.tabCarte[2].valeurCarte >= carteMilieu.valeurCarte)
                        {

                            monOrdi.tabCarte[2] = GenererCarte();
                            Console.WriteLine(" L'IA a choisi une nouvelle carte");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            temp = monOrdi.tabCarte[0];
                            monOrdi.tabCarte[0] = carteMilieu;
                            carteMilieu = temp;

                            GenereCarteMilieu(carteMilieu);
                            Console.WriteLine(" L'IA prend la carte du centre");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }


                }
            }
            
            


            //Calcul des points
            

            if(endGame == true)
            {
                
                Console.WriteLine("Veuillez patientez, le score est en phase de calcul");
                Console.WriteLine("");
                Console.WriteLine("");

                int pointageOrdi = monOrdi.tabCarte[0].valeurCarte + monOrdi.tabCarte[1].valeurCarte + monOrdi.tabCarte[2].valeurCarte;

                if (pointageOrdi > 31)                
                    pointageOrdi = 31;
                
                Console.WriteLine(" Pointage IA : " + pointageOrdi);
                int pointageJoueur1 = monJoueur.tabCarte[0].valeurCarte + monJoueur.tabCarte[1].valeurCarte + monJoueur.tabCarte[2].valeurCarte;
                Console.WriteLine(" Pointage Joueur : " + pointageJoueur1);
                Console.WriteLine("");
                Console.WriteLine("");

                if (pointageJoueur1 > pointageOrdi)
                {
                    Console.WriteLine("Le gagnant est : " + nomJoueur1);
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    
                    Console.WriteLine("Le gagnant est : " + IntelligenceArtificiel);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            


        }
    }
}
