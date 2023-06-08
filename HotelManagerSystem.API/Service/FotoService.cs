using System.Security.Cryptography;

namespace HotelManagerSystem.API.Service
{
    public class FotoService
    {
        private readonly IWebHostEnvironment environment;
        private readonly ILogger<FotoService> logger;

        public FotoService(IWebHostEnvironment environment, ILogger<FotoService> logger)
        {
            this.environment = environment;
            this.logger = logger;
        }

        public async Task<string> SaveFotoAsync(string folder, string encodedContent, string fileName)
        {
            if (string.IsNullOrEmpty(encodedContent))
                throw new Exception("File has no content");

            var directory = Path.Combine(environment.WebRootPath, folder);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            try
            {
                var fileBytes = Convert.FromBase64String(encodedContent);
                var fileHash = string.Empty;

                using (var md5 = MD5.Create())
                {
                    byte[] hash = md5.ComputeHash(fileBytes);
                    fileHash = BitConverter.ToString(hash).Replace("-", "").ToLower();
                }

                var extensionIndex = fileName.LastIndexOf('.');
                var fileNameWithHash = fileName.Insert(extensionIndex, fileHash);

                var filePath = Path.Combine(directory, fileNameWithHash);

                if (File.Exists(filePath))
                    throw new Exception("File already exists");

                await File.WriteAllBytesAsync(filePath, fileBytes);

                return fileNameWithHash;
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                throw;
            }
        }

        public void DeleteFoto(string folder, string fileName)
        {
            var directory = Path.Combine(environment.WebRootPath, folder);
            var filePath = Path.Combine(directory, fileName);

            try
            {
                File.Delete(filePath);
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                throw;
            }
        }

        public async Task<string> AddFotoAsync(string folder, string encodedContent, string fileName)
        {
            try
            {
                var savedFileName = await SaveFotoAsync(folder, encodedContent, fileName);
                return savedFileName;
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
