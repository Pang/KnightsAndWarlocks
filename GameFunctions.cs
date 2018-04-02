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

        public static void Outcome(string _exitText, Player player1, Npc player2)
        {
            if (_exitText.ToLower() == "exit") gameOn = false;
            else if (_exitText.ToLower() == "restart")
            {
                player1.HealItems = 9;
                player1.SpecialMoves = 3;
                player1.Health = 100;
                player2.Health = 100;
                player2.NpcEnemyClass();
                player2.NpcEnemyRace();
                KillCountsZero();
            }
            else
            {
                Console.Clear();
            }
        }

        static Queue<string> combatLog = new Queue<string>();
        static Queue<string> enemyCombatLog = new Queue<string>();

        public static void AddToCombatLog(string stringy)
        {
            //adds string arg to combatLog Queue
            combatLog.Enqueue(stringy);
            //removes first entry once log exceeds 5
            if (combatLog.Count > 5) combatLog.Dequeue();
        }

        public static void AddToEnemyLog(string stringy)
        {
            enemyCombatLog.Enqueue(stringy);
            if (enemyCombatLog.Count > 3) enemyCombatLog.Dequeue();
        }

        public static void PrintPlayerLog()
        {
            //creates new array and copies the queue list to it
            string[] array = new string[combatLog.Count];
            combatLog.CopyTo(array, 0);

            //display combat log
            Console.WriteLine("COMBAT LOG:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void PrintEnemyLog()
        {
            string[] array = new string[enemyCombatLog.Count];
            enemyCombatLog.CopyTo(array, 0);

            Console.WriteLine("ENEMY LOG:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void NewEnemy(Npc player)
        {
            player.NpcEnemyClass();
            player.NpcEnemyRace();
            killCounter++;
            short increaseHealth = (short)(killCounter * 20);
            short newHealth = (short)(100 + increaseHealth);
            player.Health = newHealth;
        }


    }
}
