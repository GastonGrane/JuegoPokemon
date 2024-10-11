using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Squirtle : IPokemon
    {
        public string Name { get; set; }
        public Element Element { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public List<Attack> Attacks { get; set; }

        public Squirtle()
        {
            this.Name = "Squirtle";
            this.Element = Element.Water;
            this.Health = 100;
            this.MaxHealth = 100;
            this.Attacks = new List<Attack>()
            {
                new Attack("Chorro de Agua", 50)
            };
        }
    }
}