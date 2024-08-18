using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;
using PetConnect.Abstractions;
using PetConnect.Domain.Common;

namespace PetConnect.Infrastructure.Tools;

/// <summary>
/// 
/// </summary>
public class MinioProvider(IMinioClient minio, ILogger<MinioProvider> logger) : IMinioProvider
{
    private const string PHOTOS_BUCKET_NAME = "images";

    public async Task<Result<string, Error>> UploadPhotoAsync(
        Stream stream,
        string fileName,
        CancellationToken cancellationToken)
    {
        var access = await CheckBucketAccess(PHOTOS_BUCKET_NAME, cancellationToken);
        if (!access)
            return Errors.Database.SaveFailure("нет доступа к хранилищу изображений.");

        try
        {
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(PHOTOS_BUCKET_NAME)
                .WithStreamData(stream)
                .WithObjectSize(stream.Length)
                .WithObject(fileName);

            var putObjectResponse = await minio.PutObjectAsync(putObjectArgs, cancellationToken);

            return putObjectResponse.ObjectName;
        }
        catch
        {
            return Errors.Database.SaveFailure(fileName);
        }
    }

    public async Task<Result<string, Error>> RemovePhotoAsync(
        string fileName,
        CancellationToken cancellationToken)
    {
        var access = await CheckBucketAccess(PHOTOS_BUCKET_NAME, cancellationToken);
        if (!access)
            return Errors.Database.SaveFailure("нет доступа к хранилищу изображений.");

        try
        {
            var removeObjectArgs = new RemoveObjectArgs()
                .WithBucket(PHOTOS_BUCKET_NAME)
                .WithObject(fileName);

            await minio.RemoveObjectAsync(removeObjectArgs, cancellationToken);

            return fileName;
        }
        catch
        {
            return Errors.Database.SaveFailure(fileName);
        }
    }

    private async Task<bool> CheckBucketAccess(string bucketName, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bucketName);

        try
        {
            var bucketExistsArgs = new BucketExistsArgs()
                    .WithBucket(bucketName);

            if (!await minio.BucketExistsAsync(bucketExistsArgs, cancellationToken))
            {
                var makeBucketArgs = new MakeBucketArgs()
                .WithBucket(bucketName);

                await minio.MakeBucketAsync(makeBucketArgs, cancellationToken);
            }
            return true;
        }
        catch
        {
            logger.LogError("Не удалось создать minio bucket \"{bucketName}\"", bucketName);
            return false;
        }
    }
}
