using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PetConnect.Infrastructure.Conventions;

/// <summary>
/// Ef-core конвертер для защиты базы данных от значения DateTimeOffset с ненулевым смещением.
/// Подробнее <see cref="https://github.com/npgsql/npgsql/issues/4176"/>
/// </summary>
internal class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetConverter() : base( d => d.ToUniversalTime(), d => d.ToUniversalTime()) { }
}