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
        public int health { get; set; } = 100;
        protected virtual double _accuracyP { get; }
        public virtual int HealItems { get; set; } = 9;
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

        public virtual void GiveDmg(Npc name)
        {
            //Check player accuracy 'IsSuccessful' method is true.
            if (IsSuccessful())
            {
                int dmg = GameFunctions.RndNext(11, 17);
                name.health -= dmg;

                //clamp health to not go below 0
                if (name.health < 0) name.health = 0;
                else Console.WriteLine($"{Name} lunges ferociously for {dmg} damage.");
            }
            else Console.WriteLine($"{Name} missed!");
        }

        public void HealSelf()
        {
            int heal = GameFunctions.RndNext(65, 75);
            int newHealth = health + heal;

            //Clamp health to not go above 100
            if (newHealth > 100) newHealth = 100;

            //Swap placeholder health(newHealth) back into int health variable
            health = newHealth;
            Console.WriteLine($"{Name} bandaged for {heal} health.");
            HealItems--;
        }
    }
}
