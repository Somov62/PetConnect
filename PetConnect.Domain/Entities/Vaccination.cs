using PetConnect.Domain.Common;

namespace PetConnect.Domain.Entities;

/// <summary>
/// Информация о вакцине какого-то животного.
/// </summary>
public class Vaccination : Entity
{
    /// <summary>
    /// Пустой конструктор для DbContext.
    /// </summary>
    private Vaccination() { }


    /// <summary>
    /// Основной конструктор.
    /// </summary>
    public Vaccination(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; private set; } = null!;
    
    /// <summary>
    /// Дата вакцинации.
    /// </summary>
    public DateTime Date { get; private set; }
}