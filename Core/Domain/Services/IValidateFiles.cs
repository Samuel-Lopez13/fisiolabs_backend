using Microsoft.AspNetCore.Http;

namespace Core.Domain.Services;

public interface IValidateFiles
{
    public void ValidateRaw(IFormFile raw);
    
    public void ValidateImages(IFormFile image);
    
    public void ValidateVideo(IFormFile video);
}