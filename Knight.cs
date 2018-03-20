using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsAndWarlocks
{
    class Knight : Player
    {
        public override string PlayerClass { get; protected set; } = "Knight";
        public override string HealItemsType { get; protected set; } = "Bandage(s)";
        public override string _name { get; protected set; }
        protected override double _accuracyP { get; } = 0.90;

        public override void GiveDmg(Npc name)
        {
            if (IsSuccessful())
            {
                ushort dmg = GameFunctions.RndNext(17, 24);
                name.health -= dmg;

                if (name.health < 0) name.health = 0;
                else Console.WriteLine($"{_name} lunges ferociously for {dmg} damage.");
            }
            else Console.WriteLine($"{_name} missed!");
        }
    }
}
