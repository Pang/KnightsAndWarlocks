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
        public static void Main()
        {
            /*Instatiate both player and enemy. ChooseClass is called when 
            creating player object to decide which inherited member to assign.*/
            Npc enemyNpc1 = new Npc();
            Player firstPlayer = Player.ChooseClass();

            if (firstPlayer.Health > 0) enemyNpc1.NpcTimer(firstPlayer);

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
                    //Game choices & current healths
                    Console.WriteLine("\nOption 1: Attack");
                    Console.WriteLine($"Option 2: Heal({firstPlayer.HealItems} {firstPlayer.HealItemsType} left!)");
                    Console.WriteLine($"\n{firstPlayer._name}: {firstPlayer.Health}hp");
                    Console.WriteLine($"{enemyNpc1.NpcRace} {enemyNpc1.NpcClass}: {enemyNpc1.Health}hp");
                    Console.WriteLine($"\nKills: {GameFunctions.killCounter}");
                    firstPlayer.PlayerChoice(enemyNpc1);
                }
            }
        }
    }
}
