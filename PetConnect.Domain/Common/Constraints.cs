namespace PetConnect.Domain.Common;

/// <summary>
/// Базовые ограничения.
/// </summary>
public static class Constraints
{
    /// <summary>
    /// Длина короткого поля.
    /// </summary>
    public const int SHORT_TITLE_LENGTH = 100;

    /// <summary>
    /// Длина среднего поля.
    /// </summary>
    public const int MEDIUM_TITLE_LENGTH = 1000;

    /// <summary>
    /// Длина длинного поля.
    /// </summary>
    public const int LONG_TITLE_LENGTH = 5000;
}
