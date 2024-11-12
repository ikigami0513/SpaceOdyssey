using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceOdyssey
{
    internal class Game
    {
        public Screen screen;
        public Player player;
        public Spaceship spaceship;
        public Planet Galaxy;
        public Planet CurrentPlanet;
        public int DayCounter = 1;
        public bool IsRunning = true;
        public int DistanceTarget;
        public int DistanceTraveled;
        public bool AsteroidChain = false;

        public Game() 
        {
            screen = new Screen();

            Console.Write("Votre nom >>> ");
            string? name = Console.ReadLine();

            if (name != null)
            {
                player = new Player(name);
            }
            else
            {
                player = new Player(Settings.DEFAULT_NAME);
            }

            Random rnd = new();
            DistanceTarget = rnd.Next(Settings.MIN_TARGET_DISTANCE, Settings.MAX_TARGET_DISTANCE);
            DistanceTraveled = 0;

            spaceship = new Spaceship();
            Galaxy = new Planet();
            CurrentPlanet = Galaxy;
        }

        public void Run()
        {
            while (IsRunning) // Game Loop
            {
                Draw();
                string action = GetAction();
                TreatAction(action);
                IsGameOver();
                IsWin();
                RandomEvent();
                DayCounter++;
            }
        }

        private void TreatAction(string action)
        {
            switch (action)
            {
                case "0":
                    IsRunning = false;
                    Console.WriteLine($"Bye {player.Name} !");
                    break;
                case "1":  // Avancer normalement
                    spaceship.Fuel -= Settings.TRAVEL_FUEL_CONSUMPTION;
                    spaceship.Usury -= Settings.TRAVEL_USURY_CONSUMPTION;
                    player.Food -= Settings.FOOD_CONSUMPTION;
                    player.Water -= Settings.WATER_CONSUMPTION;
                    DistanceTraveled += Settings.DISTANCE_TRAVEL;
                    break;
                case "2":  // Avancer vitesse Lumière
                    spaceship.Fuel -= Settings.LIGHT_FUEL_CONSUMPTION;
                    spaceship.Usury -= Settings.LIGHT_USURY_CONSUMPTION;
                    player.Food -= Settings.FOOD_CONSUMPTION;
                    player.Water -= Settings.WATER_CONSUMPTION;
                    DistanceTraveled += Settings.DISTANCE_LIGHT;
                    break;
                case "3":  // Atterir sur une planète
                    TravelToPlanet();
                    // Et oui Jammy, Atterir sur une planète consomme des ressources du pilote
                    // Plus sérieusement, cela permet de rendre plus dangereux l'atterrisage sur une planète si cette
                    // dernière ne possède pas de ressource.
                    // Cela force le joueur a réfléchir si c'est une bonne idée d'atterir sur une planète ou pas
                    player.Food -= Settings.FOOD_CONSUMPTION;
                    player.Water -= Settings.WATER_CONSUMPTION;
                    break;
                default:
                    Draw();
                    Console.Write($"Commande {action} inconnue >>> ");
                    GetAction();
                    break;
            }
        }

        private void IsGameOver()
        {
            if (
                player.Food <= 0 ||
                player.Water <= 0 ||
                spaceship.Fuel <= 0 ||
                spaceship.Usury <= 0
            )
            {
                DrawGameOverScreen();
                Console.WriteLine("Ressources manquantes, vous ne pouvez pas continuer votre voyage.");
                IsRunning = false;
            }
        }

        private void IsWin()
        {
            if (DistanceTraveled >= DistanceTarget)
            {
                DrawCongratultionsScreen();
                Console.WriteLine("Vous êtes arrivés à destination !");
                IsRunning = false;
            }
        }

        private void RandomEvent()
        {
            // Passage dans une chaine d'astéroïde
            Random rng = new Random();
            double AsteroidProbability = rng.NextDouble();
            if (AsteroidProbability <= Settings.ASTEROID_CHAIN_PROBABILITY)
            {
                AsteroidChain = true;
                spaceship.Usury -= Settings.ASTEROID_DAMAGE;
            }
            else
            {
                AsteroidChain = false;
            }
        }

        private string GetAction()
        {
            Console.Write($"{player.Name} >>> Commande >>> ");
            // On utilise la récursivité pour être sur d'obtenir un choix valable au bout d'un moment
            string? action = Console.ReadLine();
            if (!String.IsNullOrEmpty(action))
            {
                return action;
            }
            else
            {
                Draw(); // On redessine l'écran à chaque appel récursive pour s'assurer que la zone de saisie de texte soit toujours au même niveau
                return GetAction();
            }
        }

        private void Draw()
        {
            screen.ResetScreen();
            screen.AddElements($"Tableau de bord (Jour {DayCounter})", 2, 1);
            if (AsteroidChain)
            {
                screen.AddElements("ATTENTION : Vous êtes passés dans une chaîne d'asteroïdes.", 2, 2);
            }
            screen.AddElements(player.Name, 2, 3);
            screen.AddElements(Assets.Character, 2, 5);
            screen.AddElements(DisplayInformation(), 75, 5);
            screen.AddElements(DisplayMenu(), 75, 20);
            screen.AddElements("########## Carte du monde ##########", 130, 6);
            DisplayGalaxyMap(130, 7);
            screen.Show();
        }

        private String DisplayInformation()
        {
            return String.Format(
                Assets.Informations, 
                DistanceTarget, DistanceTraveled, 
                player.Food, player.Water, 
                spaceship.Fuel, spaceship.Usury
            );
        }

        private String DisplayMenu()
        {
            return String.Format(
                Assets.Menu, 
                Settings.TRAVEL_FUEL_CONSUMPTION.ToString(), Settings.TRAVEL_USURY_CONSUMPTION.ToString(), Settings.DISTANCE_TRAVEL,
                Settings.LIGHT_FUEL_CONSUMPTION.ToString(), Settings.LIGHT_USURY_CONSUMPTION.ToString(), Settings.DISTANCE_LIGHT
            );
        }

        private void DisplayGalaxyMap(int x, int y)
        {
            Galaxy.Display(screen, x, y, CurrentPlanet);
        }

        private void DrawGameOverScreen()
        {
            screen.ResetScreen();
            screen.AddElements(
                Assets.GameOver, 
                (Settings.SCREEN_WIDTH - (Assets.GameOver.Length / 6)) / 2 , 
                (Settings.SCREEN_HEIGHT - 6) / 2
            );
            screen.Show();
        }

        private void DrawCongratultionsScreen()
        {
            screen.ResetScreen();
            screen.AddElements(
                Assets.Congratulations,
                (Settings.SCREEN_WIDTH - (Assets.Congratulations.Length / 6)) / 2,
                (Settings.SCREEN_HEIGHT - 6) / 2
            );
            screen.Show();
        }

        private void TravelToPlanet()
        {
            Planet[] planets = new Planet[CurrentPlanet.Children.Length];
            Console.Write("Planètes atteignables : ");
            for (int i = 0; i < planets.Length; i++)
            {
                planets[i] = CurrentPlanet.Children[i];
                Console.Write($"({i}) {planets[i].Name}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Sur quelle planète voulez-vous aller ?");
            string? planet_index = Console.ReadLine();
            if (String.IsNullOrEmpty(planet_index)) {
                TravelToPlanet();
            }
            else
            {
                bool success = int.TryParse(planet_index, out int index);
                if (success)
                {
                    CurrentPlanet = planets[index];
                    player.Food += CurrentPlanet.FoodQuantity;
                    player.Water += CurrentPlanet.WaterQuantity;
                    spaceship.Fuel += CurrentPlanet.FuelQuantity;
                    spaceship.Usury += CurrentPlanet.UsuryQuantity;
                }
                else
                {
                    TravelToPlanet();
                }
            }
        }
    }
}
