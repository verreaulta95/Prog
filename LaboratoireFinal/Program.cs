using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinSession19
{
    
    class Program
    {
        static public Timer timer;
        static public Serpent Joueur1;
        static public Serpent ennemi1;
        static public Serpent ennemi2;
        static public Serpent ennemi3;
        static public bool isPlayerMoving;
        static public bool isEnnemi1Moving;
        static public long time;
        static public int pointage;
        static public int timeup;
        static public bool direction;


        public struct Serpent
        {
            //Position en X et Y
            public int posX;
            public int posY;
            public int oldPosX;
            public int oldPosY;
            public char symbol;
            public int speed;

            public Serpent(int _posX, int _posY, char _symbol) : this()
            {
                //Position du joueur en X et Y ainsi que le symbole
                posX = _posX;
                posY = _posY;

                oldPosX = 0;
                oldPosY = 0;

                symbol = _symbol;
                speed = 1;

            }
        }

        static void Main(string[] args)
        {
            // Changer couleur des lignes exterieurs et interieurs
            // Indiquer le score(Nombre de points manger) +/ voir static pointage pour reutilisation
            // Fin de partie si joueur a tout manger les points +/ les fantomes sont juste une difficulte ou bien ils disparaissent quand on les mange

            int ChoixMenu = 0;
            int ChoixCouleur = 0;
            bool Menu = true;

            while (Menu == true)
            {
                //Menu Principal
                Console.WriteLine("");
                Console.WriteLine("Bienvenue sur Pacman. Choisiser une option.");
                Console.WriteLine("1 Commencer partie.");
                Console.WriteLine("2 Choisir la couleur du HuD.");
                Console.WriteLine("3. Information sur le jeu");

                ChoixMenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                
                switch (ChoixMenu)
                {
                    case 1:
                        Menu = false; break;                   
                    case 2: //Choix Couleur
                        Console.WriteLine("Choisiser une couleur");
                        Console.WriteLine("1.Vert");
                        Console.WriteLine("2.Rouge");
                        Console.WriteLine("3.Bleu");
                        ChoixCouleur = Convert.ToInt32(Console.ReadLine());
                        switch (ChoixCouleur)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Clear();
                                break;

                            case 2:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                break;

                            case 3:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Clear();
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Le but du jeux est très simple. Vous diriger Pacman. votre but est de manger tous les point sur la map. Vous dever éviter de vous faire toucher par les ennemis, car si il vous touche," +
                            " la partie est terminer. Les plus gros points sont des power-up qui permettent de tuer les phantoms.");
                        break;
                    default: Console.WriteLine("Choisi une option valide ou ont refait le programme avec des Go To >:("); break;

                }

            }

            char PacMan = 'C';
            char fantome1 = 'P';
            char fantome2 = 'B';
            char fantome3 = 'i';
            //Rajouter les variables char fantome2 et fantome3  pour les autres            

            char cerise = 'O';
            bool finJeu = false;

            //Position depart en (X,Y) ainsi que le symbole
            Joueur1 = new Serpent(1, 1, PacMan);
            ennemi1 = new Serpent(14, 12, fantome1);
            ennemi2 = new Serpent(13, 12, fantome2);
            ennemi3 = new Serpent(15, 12, fantome3);
            // 13,12 et 15,12 pour les deux autres fantomes
            direction = false;
            pointage = 0;
            Console.CursorVisible = false;

            Timer timer = new Timer(UpdateTime, null, 0, 100);
            isEnnemi1Moving = false;
            isPlayerMoving = false;

            int largeur = 29;
            int hauteur = 31;

            //Console.WriteLine(pointage);
            Console.SetWindowSize(hauteur,largeur+3);
            char[,] tabPacMan = new char[,]
            {
                { '_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_'},
                { '|',' ','.','.','.','.','.','.','.','.','.','.','.','|',' ','|','.','.','.','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','|','_','_','_','|','.','|','_','_','|','.','|',' ','|','.','|','_','_','|','.','|','_','_','_','|','.','|'},
                { '|',cerise,'|',' ',' ',' ','|','.','|',' ',' ','|','.','|',' ','|','.','|',' ',' ','|','.','|',' ',' ',' ','|',cerise,'|'},
                { '|','.','|','_','_','_','|','.','|','_','_','|','.','|','_','|','.','|','_','_','|','.','|','_','_','_','|','.','|'},
                { '|','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','|','_','_','_','|','.','|','_','|','.','|','_','_','_','|','.','|','_','|','.','|','_','_','_','|','.','|'},
                { '|','.','.','.','.','.','.','.','|',' ','|','.','|',' ',' ',' ','|','.','|',' ','|','.','.','.','.','.','.','.','|'},
                { '|','_','_','_','_','_','_','.','|',' ','|','.','|',' ',' ',' ','|','.','|',' ','|','.','_','_','_','_','_','_','|'},
                { '|',' ',' ',' ',' ',' ','|','.','|',' ','|','.','|','_','_','_','|','.','|',' ','|','.','|',' ',' ',' ',' ',' ','|'},
                { '|',' ',' ',' ',' ',' ','|','.','|',' ','|','.','.','.','.','.','.','.','|',' ','|','.','|',' ',' ',' ',' ',' ','|'},
                { '|',' ',' ',' ',' ',' ','|','.','|',' ','|','.','|','-',' ','-','|','.','|',' ','|','.','|',' ',' ',' ',' ',' ','|'},
                { '|',' ',' ',' ',' ',' ','|','.','|',' ','|','.','|',' ',' ',' ','|','.','|',' ','|','.','|',' ',' ',' ',' ',' ','|'},
                { '|','_','_','_','_','_','|','.','|','_','|','.','|','_','_','_','|','.','|','_','|','.','|','_','_','_','_','_','|'},
                { '/','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','/'},
                { '|','_','_','_','_','_','_','.','_','_','_','.','_','_','_','_','_','.','_','_','_','.','_','_','_','_','_','_','|'},
                { '|',' ',' ',' ',' ',' ','|','.','|',' ','|','.','|',' ',' ',' ','|','.','|',' ','|','.','|',' ',' ',' ',' ',' ','|'},
                { '|',' ',' ',' ',' ',' ','|','.','|',' ','|','.','|',' ',' ',' ','|','.','|',' ','|','.','|',' ',' ',' ',' ',' ','|'},
                { '|','_','_','_','_','_','|','.','|','_','|','.','|','_','_','_','|','.','|','_','|','.','|','_','_','_','_','_','|'},
                { '|','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','|'},
                { '|','.','_','_','_','_','_','.','_','_','_','_','_','.','_','_','_','.','_','_','_','.','_','_','_','_','_','.','|'},
                { '|','.','|',' ',' ',' ','|','.','|',' ',' ',' ','|','.','|',' ','|','.','|',' ','|','.','|',' ',' ',' ','|','.','|'},
                { '|','.','|','_','_',' ','|','.','|','_','_','_','|','.','|','_','|','.','|','_','|','.','|',' ','_','_','|','.','|'},
                { '|',cerise,'.','.','|',' ','|','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','|',' ','|','.','.',cerise,'|'},
                { '|','_','_','.','|',' ','|','.','_','_','_','_','.','_','_','_','_','.','_','_','_','.','|',' ','|','.','_','_','|'},
                { '|','_','|','.','|','_','|','.','|',' ',' ','|','.','|',' ',' ','|','.','|',' ','|','.','|','_','|','.','|','_','|'},
                { '|','.','.','.','.','.','.','.','|',' ',' ','|','.','|',' ',' ','|','.','|',' ','|','.','.','.','.','.','.','.','|'},
                { '|','.','_','_','_','_','_','_','|',' ',' ','|','.','|',' ',' ','|','.','|',' ','|','_','_','_','_','_','_','.','|'},
                { '|','.','|','_','_','_','_','_','_','_','_','|','.','|','_','_','|','.','|','_','_','_','_','_','_','_','|','.','|'},
                { '|','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','|'},
                { '|','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','|'}
            };

            //cree le tableau
            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    Console.Write(tabPacMan[y, x]);
                }
                Console.WriteLine("");
            }
            InitialiseGame(Joueur1, ennemi1);
            

            while (finJeu == false)
            {
                Joueur1.oldPosX = Joueur1.posX;
                Joueur1.oldPosY = Joueur1.posY;

                ennemi1.oldPosX = ennemi1.posX;
                ennemi1.oldPosY = ennemi1.posY;

                UpdateInput();
                //Update(ref tabPacMan);                


                if (isPlayerMoving || isEnnemi1Moving)
                {
                    // PARTIE JOUEUR

                    if (tabPacMan[Joueur1.posY, Joueur1.posX] == '/')
                    {
                        
                        Joueur1.posX = Joueur1.oldPosX;
                        Joueur1.posY = Joueur1.oldPosY;
                        ClearJoueur(Joueur1);
                        Console.SetCursorPosition(15, 2);
                        DrawPerso(Joueur1);
                    }
                    else if (tabPacMan[Joueur1.posY, Joueur1.posX] == ' ' || tabPacMan[Joueur1.posY, Joueur1.posX] == '.')
                    {
                        //Change la position de joueur1 et fantome1

                        if (tabPacMan[Joueur1.posY, Joueur1.posX] == '.')
                            pointage++;


                        ClearJoueur(Joueur1);
                        tabPacMan[Joueur1.posY, Joueur1.posX] = ' ';
                        Console.SetCursorPosition(0, 0);
                        DrawPerso(Joueur1);

                        eatingTime(Joueur1, ennemi1, ref tabPacMan,ref cerise);

                        isEnnemi1Moving = false;

                    }
                    else if (tabPacMan[Joueur1.posY, Joueur1.posX] == '|' || tabPacMan[Joueur1.posY, Joueur1.posX] == '_')
                    {
                        Joueur1.posX = Joueur1.oldPosX;
                        Joueur1.posY = Joueur1.oldPosY;
                        
                        //finJeu = true;
                    }


                    // PARTIE IA
                   

                    ClearEnnemy(ennemi1);
                    DrawEnnemy(ennemi1);
                    DrawEnnemy(ennemi2);
                    DrawEnnemy(ennemi3);
                    isPlayerMoving = false;


                }

                if (pointage > 286)
                {
                    finJeu = true;
                    Console.SetWindowSize(85,20);
                    Console.Clear();
                    Console.ReadKey();
                }
                    

            }


            if (finJeu == true)
            {
                Console.WriteLine("Merci d'avoir essayer notre petit jeu de pac-man :)");
                Console.ReadKey();
            }


        }

        static void highScore()
        {
            
        }

        static void eatingTime(Serpent Joueur1,Serpent ennemi1,ref char[,] tabPacMan,ref char cerise)
        {
            bool manger = false;
            if(manger = false && tabPacMan[Joueur1.posY, Joueur1.posX] == cerise)
            {
                //fonctionne pas 
                manger = true;
                if (timeup <= 200) // 1000 = 1sec
                {
                    if (tabPacMan[Joueur1.posY, Joueur1.posX] == tabPacMan[ennemi1.posY, ennemi1.posX])
                    {
                        Console.SetCursorPosition(14, 12);
                        DrawEnnemy(ennemi1);
                    }
                }                
                else
                {
                    time = 0;
                    manger = false;
                }
            }
            
            
        }

        static void UpdateEnnemi(ref char[,] tabPacMan)
        {
            
            ennemi1.posY -= 1 * ennemi1.speed;
            int x = 29;

            if(tabPacMan[ennemi1.posY, ennemi1.posX] == '_' || tabPacMan[ennemi1.posY, ennemi1.posX] == '|' || tabPacMan[ennemi1.posY, ennemi1.posX] == x)
            {
                ennemi1.posX = ennemi1.oldPosX;
                ennemi1.posY = ennemi1.oldPosY;
                ennemi1.posX += 1 * ennemi1.speed;
                direction = true;
            }
            else
            {

                direction = false;
            }
            

                /*ClearEnnemy(ennemi1);
                ennemi1.posX = ennemi1.oldPosX;
                ennemi1.posY = ennemi1.oldPosY + 2;*/

                //Console.SetWindowSize(85,20);
                //Console.Clear();
                //finJeu = true;
            

            isEnnemi1Moving = true;            
        }

        static void UpdateTime(object o)
        {
            time += 100;
        }

        static void Update(ref char[,] tabPacMan)
        {
            //Si temps = 1000 alors 1000 equivaut a 1 sec(1000 milliseconde = 1 seconde)
            timeup = 0;
            if (time > 1000)
            {
                UpdateEnnemi(ref tabPacMan);
                time = 0;
                timeup++;
            }
        }

        static void InitialiseGame(Serpent Joueur1,Serpent ennemi1)
        {
            Console.SetCursorPosition(0, 0);            
            DrawPerso(Joueur1);
            DrawEnnemy(ennemi1);
            //Dois rajouter autres fonctionc draw ennemy pour les autres fantomes
        }

        // Permet de placer le symbole du joueur ou ennemy dans le tableau/map
        static void DrawPerso(Serpent Joueur1)
        {
            Console.SetCursorPosition(Joueur1.posX, Joueur1.posY);
            Console.Write(Joueur1.symbol);

        }

        static void DrawEnnemy(Serpent ennemi1)
        {
            Console.SetCursorPosition(ennemi1.posX, ennemi1.posY);
            Console.Write(ennemi1.symbol);
        }

        //Enleve le symbole et remplace par un espace l'ancienne position de joueur ou ennemy
        static void ClearJoueur(Serpent Joueur1)
        {
            Console.SetCursorPosition(Joueur1.oldPosX, Joueur1.oldPosY);
            Console.Write(" ");
        }

        static void ClearEnnemy(Serpent ennemi1)
        {
            Console.SetCursorPosition(ennemi1.oldPosX, ennemi1.oldPosY);
            Console.Write(" ");
        }

        //Update les touches lorsqu'elles sont appeles et indique si joueur1 a bouger +/ autrement le(les) fantomes ne bougeront pas
        static void UpdateInput()
        {
            while (Console.KeyAvailable)
            {

                Joueur1.oldPosX = Joueur1.posX;
                Joueur1.oldPosY = Joueur1.posY;

                ConsoleKey Input = Console.ReadKey(true).Key;               

                if (Input == ConsoleKey.W || Input == ConsoleKey.UpArrow)
                {
                    Joueur1.posY -= Joueur1.speed * 1;
                }
                else if (Input == ConsoleKey.S || Input == ConsoleKey.DownArrow)
                {
                    Joueur1.posY += Joueur1.speed * 1;
                }
                else if (Input == ConsoleKey.A || Input == ConsoleKey.LeftArrow)
                {
                    Joueur1.posX -= Joueur1.speed * 1;
                }
                else if (Input == ConsoleKey.D || Input == ConsoleKey.RightArrow)
                {
                    Joueur1.posX += Joueur1.speed * 1;
                }
                isPlayerMoving = true;
                
            }
        }






    }
}
