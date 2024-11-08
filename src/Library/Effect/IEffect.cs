using Library;

public interface IEffect
{  
    public Pokemon Pokemon { get; set; }

    // Actualiza el estado del efecto en cada turno
    void UpdateEffect(Pokemon target);

    // Elimina el efecto del Pokémon, restaurando cualquier cambio
    void RemoveEffect(Pokemon target);

    // Indica si el efecto ha expirado, útil para saber cuándo eliminarlo
    bool IsExpired { get; }
    
}