using PetConnect.Domain;

namespace PetConnect.API.Contracts;

/// <summary>
/// ДТО для запроса на создание поста.
/// </summary>
/// <param name="Name"> Имя. </param>
/// <param name="Breed"> Порода. </param>
/// <param name="Photo"> Фото. </param>
/// <param name="Description"> Описание. </param>
/// <param name="Address"> Адрес. </param>
/// <param name="Height"> Высота. </param>
/// <param name="Vaccine"> Наличие вакцин </param>
/// <param name="BirthDate"> День рождения. </param>
public record CreatePostRequest(
        string Name,
        string Breed,
        Weight Weight,
        string Photo,
        string Description,
        string Address,
        int Height,
        bool Vaccine,
        DateOnly BirthDate);
