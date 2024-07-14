namespace PetConnect.Domain.Common;

/// <summary>
/// Информация об ошибке при работе с доменной моделью.
/// </summary>
/// <param name="Code"> Код ошибки. </param>
/// <param name="Message"> Сообщение о причинах. </param>
public record Error(string Code, string Message);


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
        public static Error ValueIsInvalid(string name, string? reason = null)
        {
            reason = reason == null ? string.Empty : $" - \"{reason}\"";
            return new("value.is.invalid", $"Невалидное значение поля \"{name}\"{reason}");
        }

        /// <summary>
        /// Ошибка "Обязательное поле".
        /// </summary>
        public static Error ValueIsRequired(string name) =>
            new("value.is.required", $"Поле \"{name}\" обязательное");

        /// <summary>
        /// Ошибка "Неверная длина".
        /// </summary>
        /// <param name="name"> Название поля с неверной длиной. </param>
        public static Error InvalidLength(string? name = null)
        {
            name = name == null ? "" : $" для поля \"{name}\"";
            return new("record.not.found", $"Неверная длина{name}");
        }
    }
}