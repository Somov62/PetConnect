namespace PetConnect.Domain.Entities;

/// <summary>
/// Информация о вакцине какого-то животного.
/// </summary>
public class Vaccination
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
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Дата вакцинации.
    /// </summary>
    public DateTime Date { get; private set; }
}