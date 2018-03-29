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
            //Game choices & current healths
            Console.WriteLine("\nOption 1: Attack");
            Console.WriteLine($"Option 2: Heal({player.HealItems} {player.HealItemsType} left!)");
            Console.WriteLine($"\n{player._name}: {player.Health}hp");
            Console.WriteLine($"{npc.NpcRace} {npc.NpcClass}: {npc.Health}hp");
            Console.WriteLine($"\nKills: {GameFunctions.killCounter}");
        }

        public static void NpcTimer(Player player, Npc npc)
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(1.500);

            var timer = new Timer((e) =>
            {
                if (player.Health > 0)
                {
                    Console.Clear();
                    npc.NpcChoice(player);
                    CombatMenu(player, npc);
                }
            }, null, startTimeSpan, periodTimeSpan);
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
                    Console.WriteLine($"You killed the {enemyNpc1.NpcRace} {enemyNpc1.NpcClass}!");
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
