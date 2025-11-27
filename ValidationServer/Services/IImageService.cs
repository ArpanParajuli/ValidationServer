namespace ValidationServer.Services
{
    public interface IImageService
    {
        Task<string> SaveStudentImageAsync(IFormFile imageFile);
    }
}
