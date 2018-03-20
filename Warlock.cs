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
        public override string HealItemsType { get; protected set; } = "Potion(s)";
        public override string _name { get; protected set; }
        protected override double _accuracyP { get; } = 0.80;

        public override void GiveDmg(Npc name)
        {
            if (IsSuccessful())
            {
                short dmg = GameFunctions.RndNext(10, 17);
                name.Health -= dmg;
                Health += (short)(dmg / 10);

                if (name.Health < 0) name.Health = 0;
                else Console.WriteLine($"{_name} damages {name.NpcRace} for {dmg} health and steals {dmg / 10} health");
            }
            else Console.WriteLine($"{_name} missed!");
        }
    }
}
