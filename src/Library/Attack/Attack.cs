namespace Library;

// TODO: Esto es una clase o una interfaz?
public class Attack
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Attack(string name, int damage)
    {
        // TODO: No me termina de convencer el nombre en lower, porque no es buen UX que el nombre siempre sea en minúscula, la idea sería usar algún id o algo
        this.Name = name.ToLower();
        this.Damage = damage;
    }
}
