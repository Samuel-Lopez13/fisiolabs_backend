using Microsoft.AspNetCore.Http;

namespace Core.Domain.Services;

public interface IUploadFile
{
    public string UploadRaw(IFormFile raw, string titulo);
    
    public string UploadImages(string image, string titulo);
    
    public string UploadVideo(IFormFile video, string titulo);
}