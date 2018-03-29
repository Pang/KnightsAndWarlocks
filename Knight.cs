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
        public override string HealItemsType { get; protected set; } = "Bandage";
        public override string _name { get; protected set; }
        protected override double _accuracyP { get; } = 0.90;

        
    }
}
