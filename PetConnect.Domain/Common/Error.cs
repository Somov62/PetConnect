namespace PetConnect.Domain.Common;

/// <summary>
/// Информация об ошибке при работе с доменной моделью.
/// </summary>
/// <param name="Code"> Код ошибки. </param>
/// <param name="Message"> Сообщение о причинах. </param>
/// <param name="InvalidField"> Название поля, которое не прошло валидацию. </param>
public record Error(string Code, string? Message, string? InvalidField = null)
{
    public string Serialize() => $"{Code}||{Message}||{InvalidField}";

    public static Error Deserialize(string error)
    {
        ArgumentNullException.ThrowIfNull(error);

        var parts = error.Split("||");
        if (parts.Length < 3)
            throw new($"Не удалось расшифровать ошибку: '{error}'");

        return new(parts[0], parts[1], parts[2]);
    }
}


/// <summary>
/// Заготовленные ошибки для доменной модели.
/// </summary>
public static class Errors
{
    /// <summary>
    /// Основные ошибки при работе с доменной моделью.
    /// </summary>
    public static class General
    {
        /// <summary>
        /// Ошибка "Запись не найдена".
        /// </summary>
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $"c идентификатором {id} ";
            return new("record.not.found", $"Запись {forId}не найдена");
        }

        /// <summary>
        /// Ошибка "Невалидное значение".
        /// </summary>
        public static Error ValueIsInvalid(string fieldName, string reason) => 
            new("value.is.invalid", reason, fieldName);

        /// <summary>
        /// Ошибка "Обязательное поле".
        /// </summary>
        public static Error ValueIsRequired(string fieldName) =>
            new("value.is.required", "Обязательное поле", fieldName);

        /// <summary>
        /// Ошибка "Неверная длина".
        /// </summary>
        public static Error InvalidLength(string? fieldName = null)
        {
            return new("length.is.invalid", "Неверная длина", fieldName);
        }
    }

    /// <summary>
    /// Ошибки при работе с базой данных.
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// Ошибка при сохранении в бд.
        /// </summary>
        /// <param name="name"> Название сущности, которую не удалось сохранить. </param>
        public static Error SaveFailure(string name) =>
            new("record.save.failure", $"Ошибка сохранения \"{name}\"");
    }
}