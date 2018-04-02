using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KnightsAndWarlocks
{
    class Program
    {
        public static void CombatMenu(Player player, Npc npc)
        {
            //Console.Clear();
            //Game choices & current healths
            GameFunctions.PrintEnemyLog();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"\n{player._name}: {player.Health}hp");
            Console.WriteLine($"Kills: {GameFunctions.killCounter}\n");
            Console.WriteLine("Option 1: Attack");
            Console.WriteLine($"Option 2: {player.HealItemsType} ({player.HealItems} left!)");
            Console.WriteLine($"Option 3: Special Attack ({player.SpecialMoves} left!)");
            Console.WriteLine($"\n{npc.NpcRace} {npc.NpcClass}: {npc.Health}hp\n");
            Console.WriteLine("--------------------------------------------------");
            GameFunctions.PrintPlayerLog();
        }

        public static void NpcTimer(Player player, Npc npc)
        {
            var timer = new Timer((e) =>
            {
                if (player.Health > 0 && npc.Health > 0)
                {
                    Console.Clear();
                    npc.NpcChoice(player);
                    CombatMenu(player, npc);
                }
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
        }

        public static void Main()
        {
            /*Instatiate both player and enemy. ChooseClass is called when 
            creating player object to decide which inherited member to assign.*/
            Npc enemyNpc1 = new Npc();
            Player firstPlayer = Player.ChooseClass();

            if (firstPlayer.Health > 0) NpcTimer(firstPlayer, enemyNpc1);

            while (GameFunctions.gameOn)
            {
                if (firstPlayer.Health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"The {enemyNpc1.NpcRace} {enemyNpc1.NpcClass} has killed you. You got {GameFunctions.killCounter} kills! Type 'Exit' or 'Restart'.");
                    string exitText = Console.ReadLine();
                    GameFunctions.Outcome(exitText, firstPlayer, enemyNpc1);
                }
                else if (enemyNpc1.Health <= 0)
                {
                    GameFunctions.AddToEnemyLog($"{enemyNpc1.NpcRace} {enemyNpc1.NpcClass} died!");
                    enemyNpc1.DropItem(firstPlayer);
                    GameFunctions.NewEnemy(enemyNpc1);
                }
                else
                {
                    CombatMenu(firstPlayer, enemyNpc1);
                    firstPlayer.PlayerChoice(enemyNpc1);
                }
            }
        }
    }
}
