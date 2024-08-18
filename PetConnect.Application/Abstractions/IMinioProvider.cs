using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;

namespace PetConnect.Abstractions;

/// <summary>
/// 
/// </summary>
public interface IMinioProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="fileName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result<string, Error>> UploadPhotoAsync(Stream stream, string fileName, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result<string, Error>> RemovePhotoAsync(string fileName, CancellationToken cancellationToken);
}