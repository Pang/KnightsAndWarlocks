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
        public static bool gameOn = false;

        public static short killCounter = 0;
        public static void KillCountsZero() => killCounter = 0;

        public static double RndNextDouble() => _random.NextDouble();
        public static short RndNext(int a, int b) => (short)_random.Next(a, b);




        public static void NewEnemy(Npc player)
        {
            player.NpcEnemyClass();
            player.NpcEnemyRace();
            killCounter++;
            short increaseHealth = (short)(killCounter * 20);
            short newHealth = (short)(100 + increaseHealth);
            player.Health = newHealth;
        }

        public static void Outcome(string _exitText, Player player1, Npc player2)
        {
            if (_exitText.ToLower() == "exit") gameOn = false;
            else if (_exitText.ToLower() == "restart")
            {
                player1.HealItems = 9;
                player1.Health = 100;
                player2.Health = 100;
                player2.NpcEnemyClass();
                player2.NpcEnemyRace();
                KillCountsZero();
            }
            else Console.Clear();
        }
    }
}
