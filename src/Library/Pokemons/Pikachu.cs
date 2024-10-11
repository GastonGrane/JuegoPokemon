using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Pikachu : IPokemon
    {
        public string Name { get; set; }
        public Element Element { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
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

        public void Attack(IPokemon target, string attackName)
        {
            attackName = attackName.ToLower();
            if (!attacks.Countains(attack))
            {
                return;
            }

            posicion = attacks.index(attack);
            defender = target.Element;
            attacker = this.Element;

            double multiplier = Calculate.Advantage(attacker, defender);
            int damage = (int)(attack[posicion].Damage * multiplier);

            target.Health -= damage;
            if (target.Health < 0)
            {
                target.Health = 0;
            }
        }
    }
}
