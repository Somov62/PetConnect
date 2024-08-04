using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using System.Text.Json.Serialization;

namespace PetConnect.Domain.ValueObjects;

/// <summary>
/// Группа ссылок на сторонние ресурсы, соцсети для волонтера.
/// </summary>
public class SocialMedias
{
    [JsonConstructor]
    private SocialMedias() { }

    private SocialMedias(
       string telegram,
       string vk,
       string whatsApp,
       IEnumerable<SocialMedia> others)
    {
        Telegram = telegram;
        VK = vk;
        WhatsApp = whatsApp;
        Others = others.ToList();
    }

    /// <summary>
    /// Ссылка на телеграмм.
    /// </summary>
    public string Telegram { get; private set; } = null!;

    /// <summary>
    /// Ссылка на вконтакте.
    /// </summary>
    public string VK { get; private set; } = null!;

    /// <summary>
    /// Ссылка на ватсап.
    /// </summary>
    public string WhatsApp { get; private set; } = null!;

    /// <summary>
    /// Ссылка на сторонние соцсети (возможно, личный сайт).
    /// </summary>
    public IReadOnlyList<SocialMedia> Others { get; private set; } = [];

    /// <summary>
    /// Создать группу ссылок.
    /// </summary>
    /// <param name="telegram"> ссылка на телеграмм.       </param>
    /// <param name="vk">       ссылка на вконтакте.       </param>
    /// <param name="whatsApp"> ссылка на ватсап.          </param>
    /// <param name="others">   ссылка на сторонние сайты. </param>
    public static Result<SocialMedias, Error> Create(
        string telegram,
        string vk,
        string whatsApp,
        IEnumerable<SocialMedia> others)
    {
        // валидировать в целом пока нечего.
        return new SocialMedias(telegram, vk, whatsApp, others ?? []);
    }
}


/// <summary>
/// Ссылка на сторонний ресурс (например, личный сайт).
/// </summary>
public class SocialMedia
{
    [JsonConstructor]
    private SocialMedia() { }

    private SocialMedia(string link, string title)
    {
        Link = link;
        Title = title;
    }

    /// <summary>
    /// Ссылка.
    /// </summary>
    public string Link { get; private set; } = null!;

    /// <summary>
    /// Заголовок для ссылки.
    /// </summary>   
    public string Title { get; private set; } = null!;

    /// <summary>
    /// Создает ссылку на сторонний ресурс.
    /// </summary>
    public static Result<SocialMedia, Error> Create(string link, string title)
    {
        Result<string, Error> e;

        if ((e = StringHelper.HasPayload(ref link, maxLength: Constraints.LONG_TITLE_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref title, maxLength: Constraints.LONG_TITLE_LENGTH))
            .IsFailure) return e.Error;

        return new SocialMedia(link, title);
    }
}
