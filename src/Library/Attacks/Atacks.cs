namespace DefaultNamespace
{
    public class Attack
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Attack(string name, int damage)
        {
            this.Name = name.ToLower();
            this.Damage = damage;
        }
    }
}
