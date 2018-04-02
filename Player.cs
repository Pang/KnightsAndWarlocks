using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsAndWarlocks
{
    abstract class Player
    {
        private string Name { get => _name; set => Name = value; }
        public virtual string _name { get; protected set; }
        public short Health { get; set; } = 100;
        protected virtual double _accuracyP { get; }
        public virtual short HealItems { get; set; } = 9;
        public virtual short SpecialMoves { get; set; } = 3;
        public virtual string HealItemsType { get; protected set; }
        public virtual string PlayerClass { get; protected set; }

        //creates a new success chance value every turn.
        public bool IsSuccessful() => GameFunctions.RndNextDouble() < _accuracyP;

        //Constructor to set name into encapsulated 'Name' property when instantiated.
        public Player()
        {
            Console.WriteLine($"Please enter a name for your {PlayerClass}:");
            _name = PlayerClass + " " + Console.ReadLine();
        }

        public static Player ChooseClass()
        {
            Player firstPlayer = null;
            Console.WriteLine("Type in the class you want to play: (Knight or Warlock)");

            while (firstPlayer == null)
            {
                string classChoice = Console.ReadLine();
                switch (classChoice.ToUpper())
                {
                    case "KNIGHT":
                        firstPlayer = new Knight();
                        break;
                    case "WARLOCK":
                        firstPlayer = new Warlock();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Not a valid class, please enter 'Knight' or 'Warlock'");
                        break;
                }
            }
            GameFunctions.gameOn = true;
            return firstPlayer;
        }

        public virtual void PlayerChoice(Npc target)
        {
            try
            {
                //Checks that user input a number
                string playerOp = Console.ReadLine();
                int playerOption = int.Parse(playerOp);

                switch (playerOption)
                {
                    case 1:
                        Console.Clear();
                        GiveDmg(target);
                        break;
                    case 2:
                        if (HealItems > 0)
                        {
                            Console.Clear();
                            HealSelf();
                        }
                        else
                        {
                            Console.Clear();
                            GameFunctions.AddToCombatLog($"No {HealItemsType} left!");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        SpecialMove(target);
                        break;
                    default:
                        Console.Clear();
                        GameFunctions.AddToCombatLog("Can't find that option.");
                        break;
                }
            }
            catch
            {
                //Catches if input is non-numeric
                Console.Clear();
                GameFunctions.AddToCombatLog("Please enter a valid option");
            }
        }

        ////////////////////////////////////////////////////////
        /* All methods below are default for the Knight class */
        ////////////////////////////////////////////////////////

        public virtual void GiveDmg(Npc name)
        {
            //Check player accuracy 'IsSuccessful' method is true.
            if (IsSuccessful())
            {
                short dmg = GameFunctions.RndNext(17, 24);
                name.Health -= dmg;

                //clamp health to not go below 0
                if (name.Health < 0) name.Health = 0;
                else
                {
                    GameFunctions.AddToCombatLog($"{_name} lunges ferociously for {dmg} damage.");
                }
            }
            else
            {
                GameFunctions.AddToCombatLog($"{_name} missed!");
            }
        }

        public virtual void HealSelf()
        {
            short heal = GameFunctions.RndNext(65, 75);
            short newHealth = (short)(Health + heal);

            //Clamp health to not go above 100
            if (newHealth > 100) newHealth = 100;

            //Swap placeholder health(newHealth) back into int health variable
            if (Health > 0)
            {
                Health = newHealth;
                GameFunctions.AddToCombatLog($"{Name} bandaged for {heal} health.");
                HealItems--;
            }
            else
            {
                Health = 0;
            }
        }

        public virtual void SpecialMove(Npc name)
        {
            if (SpecialMoves > 0)
            {
                short dmg = GameFunctions.RndNext(100, 200);
                GameFunctions.AddToCombatLog($"You charge fiercly, slicing down at the {name.NpcRace} for {dmg} damage!");
                name.Health -= dmg;
                SpecialMoves--;
            }
            else
            {
                GameFunctions.AddToCombatLog("You're out of special moves!");
            }
        }
    }
}
