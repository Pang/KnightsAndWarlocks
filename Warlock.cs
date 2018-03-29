using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsAndWarlocks
{
    class Warlock : Player
    {
        public override string PlayerClass { get; protected set; } = "Warlock";
        public override string HealItemsType { get; protected set; } = "Health Potion";
        public override string _name { get; protected set; }
        protected override double _accuracyP { get; } = 0.80;
        public override short HealItems { get; set; } = 6;

        public override void GiveDmg(Npc name)
        {
            if (IsSuccessful())
            {
                short dmg = GameFunctions.RndNext(10, 17);
                name.Health -= dmg;
                Health += (short)(dmg / 10);

                if (name.Health < 0) name.Health = 0;
                else Console.WriteLine($"{_name} damages {name.NpcRace} for {dmg} health and steals {dmg / 10} health");

                if (Health > 100) Health = 100;
            }
            else Console.WriteLine($"{_name} missed!");
        }

        public override void HealSelf()
        {
            short heal = GameFunctions.RndNext(65, 75);
            short newHealth = (short)(Health + heal);

            if (newHealth > 100) newHealth = 100;

            if (Health > 0)
            {
                Health = newHealth;
                Console.WriteLine($"{_name} drank a potion for {heal} health.");
                HealItems--;
            }
            else Health = 0;
        }

        public override void SpecialMove(Npc name)
        {
            if (SpecialMoves > 0)
            {
                short dmg = GameFunctions.RndNext(200, 300);
                Console.WriteLine($"You summon a demon which crushes the {name.NpcRace} for {dmg} damage!");
                name.Health -= dmg;
                SpecialMoves--;
            }
            else Console.WriteLine("You're out of special moves!");
        }
    }
}
