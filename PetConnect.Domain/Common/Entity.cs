namespace PetConnect.Domain.Common;

public abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; private set; } = Guid.Empty;


    public static bool operator == (Entity left, Entity right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return true;

        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

    public bool Equals(Entity? other)
    {
        return Id == other?.Id; 
    }

    public override bool Equals(object obj)
    {
        if (!ReferenceEquals(this, obj)) 
            return false;

        if (GetType() != obj.GetType()) 
            return false;
        
        return Id == ((Entity)obj).Id;
    }

    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }
}
