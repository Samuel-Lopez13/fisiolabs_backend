using Core.Domain.Exceptions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace Core.Features.Usuario.Command;

public class ValidateFiles : IValidateFiles
{
    public void ValidateRaw(IFormFile raw)
    {
        //Recoge la extension del archivo
        string fileExtension = Path.GetExtension(raw.FileName).ToLower();
        
        //verifica si esta permitida
        string[] allowedExtensions = { ".pdf" };
        
        //Si es incorrecta mandara una excepcion
        if (!allowedExtensions.Contains(fileExtension)){
            throw new BadRequestException("No se acepta este tipo de formato");
        }
    }
    
    public void ValidateImages(IFormFile image)
    {
        //Recoge la extension del archivo
        string fileExtension = Path.GetExtension(image.FileName).ToLower();
        
        //verifica si esta permitida
        string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
        
        //Si es incorrecta mandara una excepcion
        if (!allowedExtensions.Contains(fileExtension)){
            throw new BadRequestException("No se acepta este tipo de formato");
        }
    }

    public void ValidateVideo(IFormFile video)
    {
        throw new NotImplementedException();
    }
}