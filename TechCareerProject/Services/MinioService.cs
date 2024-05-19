﻿using Minio;
using Minio.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Minio.DataModel.Args;

public class MinioService
{
    private readonly IMinioClient _minioClient;
    private readonly string _bucketName;
    private readonly string _endpoint;

    public MinioService(IConfiguration configuration)
    {
        _endpoint = configuration["Minio:Endpoint"];
        var accessKey = configuration["Minio:AccessKey"];
        var secretKey = configuration["Minio:SecretKey"];
        _bucketName = configuration["Minio:BucketName"];

        _minioClient = new MinioClient()
            .WithEndpoint(_endpoint)
            .WithCredentials(accessKey, secretKey)
            .Build();
    }

    public async Task UploadFileAsync(string objectName, Stream data, long size, string contentType)
    {
        try
        {
            bool found = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucketName));
            if (!found)
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
            }

            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(objectName)
                .WithStreamData(data)
                .WithObjectSize(size)
                .WithContentType(contentType));
        }
        catch (MinioException e)
        {
            Console.WriteLine($"[MinioService] {e.Message}");
            throw;
        }
    }

    public string GetFileUrl(string objectName)
    {
        return $"http://{_endpoint}/{_bucketName}/{objectName}";
    }
}
