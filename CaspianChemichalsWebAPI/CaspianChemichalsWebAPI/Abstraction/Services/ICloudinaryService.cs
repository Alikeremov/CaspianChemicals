namespace CaspianChemichalsWebAPI.Abstraction.Services
{
    public interface ICloudinaryService
    {
        Task<string> FileCreateAsync(IFormFile file);
        Task<bool> FileDeleteAsync(string filename);
    }
}
