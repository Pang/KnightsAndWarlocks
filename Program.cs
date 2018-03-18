using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsAndWarlocks
{
    class Program
    {
        public static void Main()
        {
            //Instatiate both player and enemy. ChooseClass is called when creating player object to decide which inherited member to assign.
            Npc enemyNpc1 = new Npc();
            Player firstPlayer = GameFunctions.ChooseClass();

            while (GameFunctions.gameOn)
            {
                if (firstPlayer.Health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"The {enemyNpc1.NpcRace} {enemyNpc1.NpcClass} has killed you. You got {GameFunctions.killCounter} kills in {GameFunctions.turnCounter} turns! Type 'Exit' or 'Restart'.");
                    string exitText = Console.ReadLine();

                    GameFunctions.Outcome(exitText, firstPlayer, enemyNpc1);
                }
                else if (enemyNpc1.health <= 0)
                {
                    Console.WriteLine($"You killed the {enemyNpc1.NpcRace} {enemyNpc1.NpcClass}!");
                    GameFunctions.NewEnemy(enemyNpc1);
                }
                else
                {
                    //Game choices & current healths
                    Console.WriteLine("");
                    Console.WriteLine("Option 1: Attack");
                    Console.WriteLine($"Option 2: Heal({firstPlayer.HealItems} {firstPlayer.HealItemsType} left!)");
                    Console.WriteLine("");
                    Console.WriteLine($"{firstPlayer._name}: {firstPlayer.Health}hp");
                    Console.WriteLine($"{enemyNpc1.NpcRace} {enemyNpc1.NpcClass}: {enemyNpc1.health}hp");
                    Console.WriteLine("");
                    Console.WriteLine($"Turn: {GameFunctions.turnCounter}");
                    Console.WriteLine($"Kills: {GameFunctions.killCounter}");
                    GameFunctions.turnCounter++;

                    try
                    {
                        //Check user input corresponds with menu
                        string playerOp = Console.ReadLine();
                        int playerOption = int.Parse(playerOp);

                        switch (playerOption)
                        {
                            case 1:
                                Console.Clear();
                                firstPlayer.GiveDmg(enemyNpc1);
                                if (enemyNpc1.health > 0) enemyNpc1.NpcChoice(firstPlayer);

                                break;
                            case 2:
                                if (firstPlayer.HealItems > 0)
                                {
                                    Console.Clear();
                                    firstPlayer.HealSelf();
                                    enemyNpc1.NpcChoice(firstPlayer);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("No bandages left!");
                                    GameFunctions.turnCounter--;
                                }
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Can't find that option.");
                                GameFunctions.turnCounter--;
                                break;
                        }
                    }
                    catch
                    {
                        //Catches if input is non-numeric
                        Console.Clear();
                        Console.WriteLine("Please enter a valid option");
                        GameFunctions.turnCounter--;
                    }
                }
            }
        }
    }
}
