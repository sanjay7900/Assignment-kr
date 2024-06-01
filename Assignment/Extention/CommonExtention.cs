namespace Assignment.Extention
{
    public static class CommonExtention
    {

        public static async Task<string> SaveToFileAsync(this IFormFile formFile, string rootPath="wwwroot", string subFolder="ProductImages")
        {
            if (formFile == null || formFile.Length == 0)
            {
                return null;
            }

            var directoryPath = Path.Combine(rootPath, subFolder);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
            var extension = Path.GetExtension(formFile.FileName);
            var newFileName = $"{fileName}_{Guid.NewGuid()}{extension}";

            var filePath = Path.Combine(directoryPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            // Return the relative path
            return Path.Combine(subFolder, newFileName).Replace("\\", "/");
        }
    
    }
}
