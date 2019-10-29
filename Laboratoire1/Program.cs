using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWorldGit
{
    class Program
    {

        static void AfficherMenu()
        {
            bool intro = false; //condition pour quitter boucle intro

            while (intro == false)
            {

                Console.WriteLine("  Ceci est l'introduction à l'univers de Dr.Stone.");
                Console.WriteLine("  Vous avez la possibilité de passer l'introduction.");
                Console.WriteLine("\n  Voulez-vous passer l'intro ? \n");
                Console.WriteLine(" 1 - Pour voir intro , 2 - Pour la passer ");

                int passerIntro = 0;
                passerIntro = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (passerIntro == 1)
                {
                    Console.WriteLine(" \n Dr. Stone est un manga/anime scientifique/fantasy. \n ");
                    Console.WriteLine("  L'histoire tourne autour de Senku, un apprenti scientifique. Et l'humanite a ete petrifier par un mysterieux laser ... (Ainsi que les oiseaux...) ");
                    Console.WriteLine("  3700 ans ont passer et Senku, le personnage principal, sort de sa coquille de roche.  ");
                    Console.WriteLine("  Scientifique dans l'ame, il tentera de reconstruire la science en construisant son propre royaume scientifique.  ");
                    Console.WriteLine("  Cependant, il aura un obstacle a surmonter ... ou plutot quelqu'un. Et il se nomme Tsukasa Shishio. ");
                    Console.WriteLine("  Tsukasa était reconnu pour etre le plus fort des lycéens. Il possede une force hors du commun et s'adapte tres rapidement.");
                    Console.WriteLine(" \n - Fin de l'introduction. \n ");
                    intro = true;
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (passerIntro == 2)
                {
                    Console.WriteLine("Vous avez decide de passer l'introduction.");
                    intro = true;
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Vous DEVEZ appuyer sur 1 ou 2. Sinon vous recommencerez.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static int RecolteFood()
        {
            int compteurRecolteSurvie = 100;
            int RecolteSurvie = 0;


            while (RecolteSurvie < 100)
            {
                Random generateurRecolte = new Random();
                int Recolte = generateurRecolte.Next(3, 8);

                Console.WriteLine(" Vous trouver : " + Recolte + " de nourriture. ");
                compteurRecolteSurvie = compteurRecolteSurvie - Recolte;
                Console.WriteLine(" Il vous reste : " + compteurRecolteSurvie);
                RecolteSurvie = RecolteSurvie + Recolte;
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Ce sera suffisant. \n Vous avez donc : " + RecolteSurvie + " de nourriture. \n ");
            Console.WriteLine("Vous en profitez donc pour construire votre cabane durant ce temps de recolte.");
            Console.WriteLine(" - Nourriture : Acquis !");
            Console.WriteLine(" - Cabane : Acquis !");
            Console.ReadKey();
            Console.Clear();


            return RecolteSurvie;
        }
        static void Main(string[] args)
        {

            // 1 - Introduction en boucle 

            AfficherMenu();
            bool finDeJeu = false;

            while (finDeJeu == false)
            {

                // 2 - Debut de l<aventure.

                Console.WriteLine(" Senku se reveille apres 3700 ans. Comment il le sait? Il a compter les secondes pendant 3700 ans ...");
                Console.WriteLine(" Il se promene et vois que a nature a repris son droit mais, il doit survivre. Ainsi debute son aventure.");
                Console.WriteLine(" Il doit etablir un abri et trouver de la nourriture. Mais il aimerait explorer davantage avant.");
                Console.WriteLine(" Par quoi Senku devra commencer ? ");
                Console.WriteLine(" 1 - Abri et nourriture , 2 - Explorer ? ");

                int survie = 0;
                bool charbon = false;

                survie = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                while (survie != 1 || survie != 2)
                {
                    if (survie == 1)
                    {

                        Console.WriteLine(" Senku se promene pendant un moment, regarde ce qui l'entoure et au bout d'un moment, il trouve un endroit convenable.");
                        Console.WriteLine(" Maintenant, il faut de la nourriture. Vous partez recolter tout ce que vous pouvez.");
                        Console.WriteLine(" Il vous faudra un certain temps avant d'en avoir assez. (100) ");
                        Console.ReadKey();
                        Console.Clear();
                        RecolteFood();
                        break;

                    }
                    else if (survie == 2)
                    {

                        Console.WriteLine("Senku se perd dans la foret et trouve une grotte !");
                        Console.WriteLine("Mais vous voyez au loin un terrain parfait pour vous etablir.");
                        Console.WriteLine(" 1 - Explorer , 2 - Passer votre chemin ");

                        int explorer = 0;
                        explorer = Convert.ToInt32(Console.ReadLine());

                        while (explorer != 1 || explorer != 2)
                        {
                            if (explorer == 1)
                            {
                                Console.WriteLine(" Vous sentez la peur monter en vous. Mais votre curiosité etait plus grande.");
                                Console.WriteLine(" Vous trouver une mine de charbon.");
                                Console.WriteLine(" - Mine de Charbon : Trouver !");
                                Console.ReadKey();
                                Console.Clear();
                                charbon = true;
                                break;
                            }
                            else if (explorer == 2)
                            {
                                Console.WriteLine(" Vous repartez et trouver un endroit convenable pour vous etablir. \n Et vous en profiter pour recolter tout ce que vous trouver.");
                                Console.WriteLine(" - Abri : Fabrique !");
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Vous DEVEZ choisir une option valable.");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            Console.WriteLine(" 1 - Explorer , 2 - Passer votre chemin ");
                            explorer = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.WriteLine(" Cependant, vous devez trouver de la nourriture pour survivre !");
                        RecolteFood();
                        break;
                    }
                }

                //3 - Main d<oeuvre        

                Console.WriteLine(" Apres plus d<un mois, Senku est parvenu a trouver et tester une methode pour la dépétrification sur des oiseaux !");
                Console.WriteLine(" Senku fais le meme processus sur Taiju, votre meilleur ami! Et cela fonctionne ! ");
                Console.WriteLine(" - Taiju : Depetrifier !");
                Console.ReadKey();
                Console.Clear();


                Console.WriteLine(" Mais, il vous faut de la main d'oeuvre pour le royaume de la science et ce n<est pas les statues de pierres qui manquent !");
                Console.WriteLine(" Et par miracle, Yuzuhira se trouve parmi elles ! ");
                Console.WriteLine(" Taiju vous supplie de la choisir (  *Il a penser qu'a elle pendant 3700 ans, il es fou amoureux d'elle* ) ");
                Console.WriteLine(" 1 - Prendre Yuzuhira , 2 - En prendre une autre ");

                bool yuzuhira = false;
                int choisirMainoeuvre = 0;
                choisirMainoeuvre = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                while (choisirMainoeuvre != 1 || choisirMainoeuvre != 2)
                {
                    if (choisirMainoeuvre == 1)
                    {
                        Console.WriteLine(" Vous avez choisi Yuzuhira ! Vous etes a present 3. ");
                        Console.WriteLine(" * Ses competences pourrait etre utiles plus tard. * ");
                        Console.WriteLine(" - Yuzuhira : Dépétrifier !");
                        yuzuhira = true;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (choisirMainoeuvre == 2)
                    {
                        Console.WriteLine("Taiju reconnait une statue dans le lot et vous le depetrifier ! ");
                        Console.WriteLine(" - Inconnu : Dépétrifier ! ");
                        Console.WriteLine(" - Inocnnu : Gen Asagiri !");
                        Console.WriteLine("Il s'agit de Gen Asagiri, un garcon de votre age. Il est ce qu'on appel un mentaliste. ");
                        Console.WriteLine(" \n Senku lui explique la situation et son but ... Mais il n'est pas interesser a rejoindre le royaume de la science et part de son cote ! \n ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vous DEVEZ choisir une option valable pour faire progresser l<histoire.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    Console.WriteLine(" 1 - Prendre Yuzuhira , 2 - En prendre une autre ");
                    choisirMainoeuvre = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }

                Console.WriteLine(" Comme vous avez encore besoin de main d'oeuvre et qu'il vous reste assez de potion alors vous dépétrifier une mysterieuse statue .. ");
                Console.WriteLine(" - Inconnu : Dépétrifier !");
                Console.WriteLine(" - Inconnu : Tsukasa Shisio !");
                Console.ReadKey();
                Console.Clear();

                //4 - Defier Tsukasa (fin 1) 
                Console.WriteLine("A peine revenu a lui qu'il comprend l'ampleur de la situation. Mais il ne partage pas la vision de Senku.");
                Console.WriteLine("Notre scientifique se trouve face a un ennemi redoutable et rien ne peut empecher sa soif d'apprendre plus.");
                Console.WriteLine("Vous aurez deux choix : Le rallier a votre cause ou le défier.");
                Console.WriteLine(" 1 - Le défier ou 2 - Tenter de le rallier a votre cause");

                int defiTsukasa = 0;
                defiTsukasa = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int TsukasaSc1 = 0;

                Random generateurNb = new Random();
                TsukasaSc1 = generateurNb.Next(1, 101);

                while (defiTsukasa != 1 || defiTsukasa != 2)
                {
                    if (defiTsukasa == 1)
                    {
                        if (TsukasaSc1 >= 1 && TsukasaSc1 <= 10)
                        {
                            Console.WriteLine("Vous n'avez pas de chance. Il vous a eu.");
                            Console.WriteLine("Ceci marque la fin de votre aventure.");
                            finDeJeu = true;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Vous etes chanceux, il vous laisse pour reflechir .. Mais il reviendra");
                            Console.WriteLine("Et vous n'aller pas rester les bras croise car il ne semble pas etre de confiance pour le royaume ..");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                    else if (defiTsukasa == 2)
                    {
                        Console.WriteLine("Vous avez tenter de le rallier mais ... sans succes. Il est trop fier pour ne pas etre le chef et vous quitte.");
                        Console.WriteLine("Vous ne lui faites pas confiance donc vous n<aller pas rester sans rien faire , au cas ou ..");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas appuyer sur la bonne touche.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    Console.WriteLine(" 1 - Le défier ou 2 - Tenter de le rallier a votre cause");
                    defiTsukasa = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                }

                if (finDeJeu == true)
                {
                    break;
                }

                // 5 - Mont Hage / Gunpowder = FIN

                Console.WriteLine(" Pour fabriquer de la poudre a canon, vous devez reunir 3 ingredients : ");
                Console.WriteLine(" 1 - Charbon, 2 - Nitrate de potassium , 3 - Souffre ");
                Console.WriteLine("Ce sont les 3 ingredients a reunir pour creer de la poudre a canon ! ");
                Console.ReadKey();
                Console.Clear();

                bool gunpowder = false; // Fabrication poudre a canon + piege Tsukasa + fin atlernatives multiples(Generateur)
                bool village = false;   // Rejoint le village et Tsukasa ne peut rien faire face au village

                if (charbon == true)
                {
                    Console.WriteLine("Vous retourner a la grotte chercher du charbon ! ");
                    Console.WriteLine(" - Ingredient obtenu : Charbon !");
                    Console.WriteLine(" Il ne vous reste que le Nitrate et le Souffre !");
                    gunpowder = true;
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Pour le charbon, Senku connait l'emplacement du Mont hage, celebre pour ses reserves de charbon.");
                    Console.WriteLine("En chemin, vous apercevez une etrange fumee s'élever au ciel mais vous etes pourtant les seuls ...");
                    Console.WriteLine(" 1 - Mont Hage , 2 - Aller voir le signal");

                    int kohaku = 0;
                    kohaku = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    while (kohaku != 1 || kohaku != 2)
                    {
                        if (kohaku == 1)
                        {
                            Console.WriteLine("Vous continuer donc votre route vers la montagne.");
                            Console.WriteLine(" Charbon : Acquis !");
                            gunpowder = true; // Fin poudre a canon
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (kohaku == 2)
                        {
                            Console.WriteLine("Senku et les autres vont voir la raison de ce feu.");
                            Console.WriteLine("Une fois rendu sur les lieux, vous faites la rencontre de Kohaku.");
                            Console.WriteLine("Apres connaissance, vous apprenez l<existence d<un village ou personne n'a jamais ete petrifier !");
                            Console.WriteLine("Kohaku, fascine par votre savoir scientifique, accepte de vous aider contre Tsukasa.");
                            Console.WriteLine("Vous allez donc a ce fameux village ..");
                            village = true;  // Fin village
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Vous avez appuyer sur une mauvaise touche.");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        Console.WriteLine(" 1 - Mont Hage , 2 - Aller voir le signal");
                        kohaku = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                    }
                }

                // 6 -  Partie Gunpowder/Village + fin 

                // Partie Gunpowder + fin multiples
                if (gunpowder == true)
                {
                    Console.WriteLine("Il vous reste le Nitrate de Potassium et le Souffre.");
                    Console.WriteLine("Le Japon regorge de sources thermales, qui contiennent du souffre. Donc, vous devrez vous rendre aux sources thermales.");
                    Console.WriteLine("Et la potion pour dépétrifier les humains contient comme ingredient principale le Nitrate de Potassium.");
                    Console.WriteLine(" Ingredient obtenu : Nitrate de Potassium !");
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine("Vous allez donc en direction de la source thermale la plus proche.");
                    Console.WriteLine("Sur le chemin, des tigres sauvages vous attaquent et vous navez pas encore de poudre a canon pour vous defendre !");
                    Console.WriteLine(" 1 - S<enfuir de chaque cote , 2 - Fuir tous ensemble ");

                    int escape = 0;
                    escape = Convert.ToInt32(Console.ReadLine());

                    while (escape != 1 || escape != 2) // chance de ne pas survivre = fin de partie
                    {
                        if (escape == 1)
                        {
                            Console.WriteLine(" Les tigres ont eu raison de vous parce que vous avez paniquer..");
                            Console.WriteLine("Ceci marque la fin de votre aventure ... ");
                            finDeJeu = true;
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }
                        else if (escape == 2)
                        {
                            Console.WriteLine("Grace a votre ingenuosite, vous avez reussi a vous enfuir ! ");
                            Console.WriteLine("Vous continuer donc votre chemin et arrivez aux sources thermales.");
                            Console.WriteLine(" Tant qu'a etre aux sources thermales, vous en profitez pour y rester un petit moment .. ");
                            Console.WriteLine(" - Ingredient obtenu : Souffre ! ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Les tigres vous ont manger et ceci marque la fin de votre aventure..");
                            Console.ReadKey();
                            finDeJeu = true;
                            Console.Clear();
                        }

                        Console.WriteLine(" 1 - S'enfuir de chaque cote , 2 - Fuir tous ensemble ");
                        escape = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                    }
                    if (finDeJeu == true)
                    {
                        break;
                    }

                    Console.WriteLine(" Vous avez tout les ingredients necessaires afin de fabriquer de la poudre a canon !");  // generateur fail explosion = fin de partie
                    Console.ReadKey();
                    Console.Clear();

                    if (yuzuhira == true)
                    {
                        Console.WriteLine("Comme vous avez choisi Yuzuhira, ses competences vous seront utiles.");
                        Console.WriteLine(" * Faisant partie du Club de couture de son ecole, Yuzuhira est parfaite pour ce travail ! * ");

                        int fabricationGunpowderYuzu = 0;

                        Random generateurYuzu = new Random();
                        fabricationGunpowderYuzu = generateurYuzu.Next(1, 101);

                        if (fabricationGunpowderYuzu <= 80)  // 80 % de reussite
                        {
                            Console.WriteLine("Vous avez reussi a fabriquer de la poudre a canon sans tout faire sauté !");
                            Console.WriteLine(" - Poudre a canon : Acquis ! ");
                            Console.WriteLine("Vous retourner donc a votre campement pour poser des pieges et attendre son retour ...");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else
                        {
                            Console.WriteLine("Malgre ses competences, la poudre a canon a explose et vous emporte avec le souffle !");
                            Console.WriteLine("Ceci marque la fin de votre aventure et du royaume de la science..");
                            Console.ReadKey();
                            Console.Clear();
                            finDeJeu = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Etant seul avec Taiju, vous tenter de fabriquer la poudre a canon par vous-meme ..");
                        Console.WriteLine("Ce n<est pas la meilleur des idees mais vous n'avez pas le choix ");
                        Console.ReadKey();
                        Console.Clear();

                        int taijuExplosion = 0;

                        Random explosionGunpowderGenerateur = new Random();
                        taijuExplosion = explosionGunpowderGenerateur.Next(1, 101);  // 30 % de reussite

                        if (taijuExplosion <= 30)
                        {
                            Console.WriteLine(" Vous etes chanceux, Taiju a moderer sa force et ne vous a pas fait saute avec une explosion hasardeuse !");
                            Console.WriteLine("Vous avez reussi a fabriquer de la poudre a canon !");
                            Console.WriteLine(" - Poudre a canon : Obtenu !");
                            Console.WriteLine(" * Vous revenez donc a votre campement pour cacher des pieges un peu partout .. *");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else if (taijuExplosion >= 31)
                        {
                            Console.WriteLine(" Taiju y est aller un peu trop fort et Boom !");
                            Console.WriteLine(" Ceci marque la fin de votre aventure et du royaume de la Science ... ");
                            finDeJeu = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                    if (finDeJeu == true)
                    {
                        break;
                    }
                    // 7 - Confrontation finale 
                    Console.WriteLine(" Le moment tant attendu est arrive ... Tsukasa a fais son retour au campement !");

                    int confrontationTsukasa = 0;
                    Random confrontationGenerateur = new Random();
                    confrontationTsukasa = confrontationGenerateur.Next(1, 101);

                    if (confrontationTsukasa <= 50)
                    {
                        Console.WriteLine("Vous avez reussi a triompher de Tsukasa ! Avec cette puissance, il ne viendra plus vous embeter !");
                        Console.ReadKey();
                        Console.Clear();
                        finDeJeu = true;
                    }
                    else
                    {
                        Console.WriteLine("Vous ne faites pas le poids face a lui ..");
                        Console.WriteLine(" Il vous oblige donc a rejoindre SA tribut ..");
                        Console.ReadKey();
                        Console.Clear();
                        finDeJeu = true;
                    }
                }


                // Partie  Village + fin
                if (village == true)
                {
                    Console.WriteLine("Vous arrivez donc au fameux village. Un village qui ne ressemble en rien a la civilisation du 21e Siecle !");
                    Console.WriteLine("Vous devez gagner leur confiance ... Mais comment  ^ ");
                    Console.WriteLine(" 1 - Raconter leur histoire , 2 - Depetrifier un oiseau");

                    int decisionVillage = 0;
                    bool villageContreTsukasa = false;
                    decisionVillage = Convert.ToInt32(Console.ReadLine());

                    while (decisionVillage != 1 || decisionVillage != 2)
                    {
                        if (decisionVillage == 1)
                        {
                            Console.WriteLine("Senku leur raconte son histoire, la situation du monde actuel et Tsukasa ..");

                            int sauverSenku = 0;
                            Random sauverRoyaume = new Random();
                            sauverSenku = sauverRoyaume.Next(1, 101);

                            if (sauverSenku <= 50)
                            {
                                Console.WriteLine("Le village s<est reuni et accepte de vous preter main forte contre Tsukasa!");
                                Console.WriteLine(" Et Tsukasa, ayant suivi le signale lui aussi, arrive au village ..");
                                villageContreTsukasa = true;
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Le village craint de ne pouvoir vous aider ..");
                                Console.WriteLine(" Et Tsukasa, ayant suivi le signale lui aussi, arrive au village ..");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        }
                        else if (decisionVillage == 2)
                        {
                            Console.WriteLine("Le village est impresionne par votre savoir ! Tout le monde est fascine et vous regarde avec admiration !");
                            Console.WriteLine("La decision est unanime ! Ils vont vous aider contre Tsukasa!");
                            Console.WriteLine(" A peine la decision prise que Tsukasa, ayant suivi le signale lui aussi, arrive au village ..");
                            villageContreTsukasa = true;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Vous avez appuyer sur une mauvaise touche .. ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        Console.WriteLine(" 1 - Raconter leur histoire , 2 - Laisser faire Kohaku");
                        decisionVillage = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }

                    // 7 - Confrontation finale 
                    if (villageContreTsukasa == true)
                    {
                        Console.WriteLine("Le village est pret a se defendre contre Tsukasa !");
                        Console.WriteLine(" Tsukasa reconnait que meme lui ne pourrait venir a bout d<un village a lui seul.");
                        Console.WriteLine(" Tsukasa reconnait sa defaite a contre-coeur ...");
                        finDeJeu = true;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine(" Senku reconnais quil ne fais pas le poid face a tsukasa ...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }

            //Message de fin de partie

            if (finDeJeu == true)
            {
                Console.WriteLine(" Bravo ! Tu es arriver a la fin jeu !");
                Console.WriteLine(" - Etat du jeu : Terminer");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine(" Vous avez echouer a faire revivre le royaume de la science ...");
                Console.WriteLine(" - Etat du jeu : Terminer");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
