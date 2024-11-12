/// Camel Game
/// Aventure textuel où le joueur traverse un désert à dos de chameau
/// objectif : parcourir une certaine distance en gérant ses ressources et en esquivant certains dangers
/// éléments clés:
///     - distance à parcourir
///     - ressources à gérer (eau pour joueur et chameau, nourriture, fatigue)
///     - actions possibles à chaque tour:
///         - avancer à vitesse normale
///         - avancer rapidement (+ de distance mais + de fatigue)
///         - se reposer (permet de récupérer de la fatigue mais consomme des ressources)
///         - chercher de l'eau et de la nourriture (chance de trouver des ressources mais risque de trouver des dangers)
///     - evénement aléatoire:
///         - tempête de sable
///         - rencontre avec des bandits
///         - oasis
///         - puit abandonné
///     - fin du jeu:
///         - victoire : parvenir à l'arrivée
///         - défaite : manque de ressources ou tomber sur un danger fatal
///         
/// Réinterprétation:
///     - le joueur est un pilote spatial, le chameau est un vaisseau spatial
///     - il décolle de sa planète d'origine alors que cette dernière est en train d'exploser suite à l'attaque de
///       de pillards
///     - les bandits que peut rencontrer le joueur sont les pillards de sa planète d'origine
///     - avancer à vitesse normale est le déplacement du vaisseau à vitesse de croisière
///     - avancer rapidement est le déplacement à vitesse lumière
///     - se reposer est une journée passée sur une planète pour faire le plein de carburant du vaisseau
///     - le joueur a comme ressources:
///         - nourriture
///         - eau
///     - le vaisseau a comme ressources:
///         - carburant (anti-matière) (équivalent de la nourriture et de l'eau du chameau)
///         - usure (équivalent de la fatigue)
///     - evenement aléatoire:
///         - tempête de sables => chaine d'astéroïdes
///         - oasis => planètes où se poser pour réparer le vaisseau et faire le plein de carburant
///         - rencontre avec des bandits => vaisseau des pillards de la planète d'origine
///         - puit abandonné => vaisseau spatial abandonné


/// To Do List
/// [x] classes Screen, Assets et Utils
/// [x] classes Player et Spaceship
/// [x] classes Game et Menu
/// [] intégration des mécaniques de Gameplay

namespace SpaceOdyssey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}
