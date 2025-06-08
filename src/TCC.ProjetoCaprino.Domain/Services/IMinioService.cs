﻿namespace TCC.ProjetoCaprino.Domain.Services
{
	public interface IMinioService
	{
		Task<string> EnsureBucketExistsAsync(string name);
		Task<string> UploadImageAsync(string imageBase64);
		Task<string?> GetObjectUrlAsync(string bucketName, string objectName);

	}
}
