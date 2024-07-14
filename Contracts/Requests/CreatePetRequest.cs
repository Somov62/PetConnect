namespace Contracts.Requests;

/// <summary>
/// ДТО для запроса на создание животного.
/// </summary>
/// <param name="Nickname"> Имя животного. </param>
/// <param name="Description"> Описание. </param>
/// <param name="Breed"> Порода. </param>
/// <param name="Color"> Окрас. </param>
/// <param name="PeopleAttitude"> Отношение животного к людям. </param>
/// <param name="AnimalAttitude"> Отношение животного к другим животным. </param>
/// <param name="Health"> Информация о здоровье животного. </param>
/// <param name="Place"> Текущее место расположения. </param>
/// <param name="City"> Адрес (город) </param>
/// <param name="Street"> Адрес (улица) </param>
/// <param name="Building"> Адрес (дом/строение) </param>
/// <param name="Postcode"> Адрес (почтовый индекс) </param>
/// <param name="ContactNumber"> Телефон человека, который содержит животное на данный момент. </param>
/// <param name="VolunteerPhoneNumber"> Телефон ответственного за это животное волонтёра. </param>
/// <param name="Castration"> Кастрировано ли животное. </param>
/// <param name="OnlyOneInFamily"> Отметка о том, что данное животное должно быть единственным в семье. </param>
/// <param name="OnTreatment"> Отметка о том, что животное на данный момент находится на лечении. </param>
/// <param name="Height"> Рост в сантиметрах. </param>
/// <param name="Weight"> Вес в килограммах. </param>
/// <param name="BirthDate"> Дата рождения. </param>
public record CreatePetRequest(
        string Nickname,
        string Description,
        string Breed,
        string Color,
        string PeopleAttitude,
        string AnimalAttitude,
        string Health,
        string Place,
        string City, 
        string Street, 
        string Building, 
        string Postcode,
        string ContactNumber,
        string VolunteerPhoneNumber,
        bool Castration,
        bool OnlyOneInFamily,
        bool OnTreatment,
        int? Height,
        float Weight,
        DateTimeOffset BirthDate
    );




