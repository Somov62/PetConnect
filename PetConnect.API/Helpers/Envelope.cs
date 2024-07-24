using PetConnect.Domain.Common;

namespace PetConnect.API.Helpers;

/// <summary>
/// Класс конверт, в котором сервер возвращает ответы на запросы.
/// Это нужно для того, чтобы структура ответа во всех случаях была одинаковой.
/// </summary>
public class Envelope
{
    /// <summary>
    /// Результат, полезная информация.
    /// </summary>
    public object? Result { get; }
    
    /// <summary>
    /// Список ошибок (если есть).
    /// </summary>
    public IEnumerable<Error>? Errors { get; }
    
    /// <summary>
    /// Дата и время ответа.
    /// </summary>
    public DateTime? TimeGenerated { get; }

    private Envelope(object? result, IEnumerable<Error>? errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.Now;
    }

    /// <summary>
    /// Конверт успешного запроса.
    /// </summary>
    public static Envelope Ok(object? result = null) => new (result, null);

    /// <summary>
    /// Конверт неудачного запроса (ошибка).
    /// </summary>
    public static Envelope Error(Error? error = null) => new(null, [error!]);

    /// <summary>
    /// Конверт неудачного запроса (несколько ошибок).
    /// </summary>
    public static Envelope Error(IEnumerable<Error> errors) => new(null, errors);
}
