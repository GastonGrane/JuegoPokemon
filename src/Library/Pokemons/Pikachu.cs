using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Pikachu : IPokemon
    {
        public string Name { get; set; }
        public Element Element { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public List<Attack> Attacks { get; set; }

        public Pikachu()
        {
            this.Name = "Pikachu";
            this.Element = Element.Electric;
            this.Health = 100;
            this.MaxHealth = 100;
            this.Attacks = new List<Attack>()
            {
                new Attack("Trueno", 50)
            };
        }

        public void AttackToPokemon(Attack attackName, IPokemon target)
        {
            Element defender = target.Element;
            Element attacker = this.Element;
            
            if (Attacks.Contains(attackName))
            {
                double multiplier = Calculate.Advantage(attacker, defender);
                double damage = (attackName.Damage * multiplier);
                target.Health -= damage;
                if (target.Health < 0)
                {
                    target.Health = 0;
                }
            }
        }
    }
}
