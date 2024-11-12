using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceOdyssey
{
    internal class Settings
    {
        public const int MAX_TREE_GENERATION = 3;
        public const int MIN_NODE_CHILDREN = 2;
        public const int MAX_NODE_CHILDREN = 4;

        public const int MIN_SYLLABLES_PLANET_COUNT = 2;
        public const int MAX_SYLLABLES_PLANET_COUNT = 4;

        public static readonly string[] PLANET_SYLLABLES =
        [
            "ba", "ra", "xan", "or", "na", "ka", "tor", "lun", "yth", "vel",
            "zur", "re", "ven", "tha", "zan", "sol", "lex", "pyr", "gro", "val",
            "mir", "qui", "nar", "thi", "vor", "nu", "ter", "za", "kry", "fra",
            "vil", "ran", "do", "kas", "zel", "dar", "vin", "ol", "xal", "nim",
            "ix", "kor", "fin", "lar", "vo", "sil", "ren", "drak", "nol", "ri",
            "pra", "ast", "xen", "shor", "van", "qui", "zar", "kis", "tra", "myn",
            "zil", "rol", "quon", "syn", "gar", "fur", "vor", "plo", "je", "tis",
            "mol", "ska", "lun", "tri", "zor", "val", "nex", "jor", "ven", "eth",
            "ax", "kry", "mel", "san", "bor", "nis", "var", "dor", "lex", "vul",
            "zur", "gla", "cen", "thal", "dor", "tir", "rex", "jyl", "fal", "slo"
        ];

        public const int SCREEN_WIDTH = 175;
        public const int SCREEN_HEIGHT = 65;

        public const int MIN_TARGET_DISTANCE = 200;
        public const int MAX_TARGET_DISTANCE = 400;

        public const int INIT_FOOD = 50;
        public const int INIT_WATER = 70;
        public const int INIT_FUEL = 100;
        public const int INIT_USURY = 100;

        public const int FOOD_CONSUMPTION = 4;
        public const int WATER_CONSUMPTION = 7;

        public const int DISTANCE_TRAVEL = 30;
        public const int DISTANCE_LIGHT = 55;

        public const int TRAVEL_FUEL_CONSUMPTION = 10;
        public const int TRAVEL_USURY_CONSUMPTION = 5;
        public const int LIGHT_FUEL_CONSUMPTION = 20;
        public const int LIGHT_USURY_CONSUMPTION = 8;

        public const string DEFAULT_NAME = "Actarus";

        public const double RESOURCE_PROBABILITY = 0.6;
        public const int MIN_FOOD_QUANTITY = 5;
        public const int MAX_FOOD_QUANTITY = 10;
        public const int MIN_WATER_QUANTITY = 4;
        public const int MAX_WATER_QUANTITY = 12;
        public const int MIN_FUEL_QUANTITY = 17;
        public const int MAX_FUEL_QUANTITY = 21;
        public const int MIN_USURY_QUANTITY = 5;
        public const int MAX_USURY_QUANTITY = 15;

        public const double ASTEROID_CHAIN_PROBABILITY = 0.15;
        public const int ASTEROID_DAMAGE = 40; // Valeur qu'on retire à l'usure du vaisseau si ce dernier se prend un astéroide
    }
}
