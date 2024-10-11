using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Bulbasaur : IPokemon
    {
        public string Name { get; set; }
        public Element Element { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public List<Attack> Attacks { get; set; }

        public Bulbasaur()
        {
            this.Name = "Bulbasaur";
            this.Element = Element.Fire;
            this.Health = 100;
            this.MaxHealth = 100;
            this.Attacks = new List<Attack>()
            {
                new Attack("Drenadora", 50)
            };
        }


    }
}