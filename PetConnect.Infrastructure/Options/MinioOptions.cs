namespace PetConnect.Infrastructure.Options;

/// <summary>
/// Конфигурация для s3 хранилища minio.
/// </summary>
public class MinioOptions
{
    /// <summary>
    /// Название секции параметров в appsettings.json
    /// </summary>
    public static string Minio => nameof(Minio);

    /// <summary>
    /// Путь до хранилища.
    /// </summary>
    public string Endpoint { get; init; } = string.Empty;

    /// <summary>
    /// Логин.
    /// </summary>
    public string AccessKey { get; init; } = string.Empty;

    /// <summary>
    /// Пароль.
    /// </summary>
    public string SecretKey{ get; init; } = string.Empty;
}
