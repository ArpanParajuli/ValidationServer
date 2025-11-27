using Microsoft.AspNetCore.Http;

namespace ValidationServer.Services
{
    public class ImageService : IImageService
    {
        private readonly string _studentFolderPath;

        public ImageService()
        {
            _studentFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "students");
        }

        public async Task<string> SaveStudentImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                throw new ArgumentException("Image file is required.");

            // Ensure folder exists
            if (!Directory.Exists(_studentFolderPath))
                Directory.CreateDirectory(_studentFolderPath);

            // Generate unique file
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(_studentFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/uploads/students/{fileName}";
        }
    }
}
