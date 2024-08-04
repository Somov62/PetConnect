using CSharpFunctionalExtensions;
using System.Runtime.CompilerServices;

namespace PetConnect.Domain.Common;

public static class StringHelper
{
    /// <summary>
    /// Обрезает пробелы с концов и проверяет строку на длину.
    /// </summary>
    /// <param name="content"> Входная строка. </param>
    /// <param name="fieldName"> Название поля, для создания ошибки. (генерируется автоматически) </param>
    /// <param name="isRequired"> Обязательное поле. </param>
    /// <param name="maxLength"> Максимальная длина. </param>
    /// <returns></returns>
    public static Result<string, Error> HasPayload(
        ref string content,
        // Получает название переменной, в которой передавался текст в аргумент content.
        [CallerArgumentExpression(nameof(content))] string fieldName = "",
        bool isRequired = true,
        int? maxLength = null)
    {
        content = content?.Trim()!;

        if (isRequired && string.IsNullOrEmpty(content))
            return Errors.General.ValueIsRequired(fieldName);

        if (maxLength is not null && content.Length > maxLength)
            return Errors.General.InvalidLength(fieldName);

        return content;
    }
}

