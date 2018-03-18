using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsAndWarlocks
{
    static class GameFunctions
    {
        private static Random _random = new Random();
        public static bool gameOn = true;
        public static int turnCounter = 0;
        public static int killCounter = 0;

        public static void TurnCountsZero() => turnCounter = 0;
        public static void KillCountsZero() => killCounter = 0;

        public static double RndNextDouble() => _random.NextDouble();
        public static int RndNext(int a, int b) => _random.Next(a, b);

        public static void NewEnemy(Npc player)
        {
            player.NpcEnemyClass();
            player.NpcEnemyRace();
            killCounter++;
            int increaseHealth = killCounter * 20;
            int newHealth = 100 + increaseHealth;
            player.health = newHealth;
        }

        public static void Outcome(string _exitText, Player player1, Npc player2)
        {
            if (_exitText.ToLower() == "exit")
            {
                gameOn = false;
            }
            else if (_exitText.ToLower() == "restart")
            {
                player1.HealItems = 9;
                player1.health = 100;
                player2.health = 100;
                player2.NpcEnemyClass();
                player2.NpcEnemyRace();
                TurnCountsZero();
                KillCountsZero();
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
