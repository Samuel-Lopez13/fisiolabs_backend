using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace Core.Features.Usuario.Command;

public class UploadFiles : IUploadFile
{
    private readonly IConvertToBase64 _convert;
    private readonly Account account;
    private readonly Cloudinary cloudinary;
    private readonly IValidateFiles _validateFiles;
    
    public UploadFiles(IConvertToBase64 convert, IValidateFiles validateFiles)
    {
        _convert = convert;
        _validateFiles = validateFiles;
        account = new Account(Environment.GetEnvironmentVariable("CLOUD_NAME"), Environment.GetEnvironmentVariable("API_KEY"), Environment.GetEnvironmentVariable("API_SECRET"));
        cloudinary = new Cloudinary(account);
    }

    public string UploadRaw(IFormFile raw, string titulo)
    {
        _validateFiles.ValidateRaw(raw);
        
        //tipo de formato que se subira
        RawUploadResult result = cloudinary.UploadLarge(new RawUploadParams
        {
            //Sube una imagen en base64 y lo desconvierte para subirla
            File = new FileDescription(Guid.NewGuid().ToString(), new MemoryStream(Convert.FromBase64String(_convert.ConvertBase64(raw)))),
            PublicId = titulo, 
            Folder = "Fisiolabs/Document"
        });
        
        return result.Url.ToString();
    }
    
    public string UploadImages(string image, string titulo)
    {
        //_validateFiles.ValidateImages(image);
        
        // Decodificar la cadena Base64 a bytes
        byte[] imageBytes = Convert.FromBase64String(image);
        
        //tipo de formato que se subira
        ImageUploadResult result = cloudinary.UploadLarge(new ImageUploadParams
        {
            //Sube una imagen en base64 y lo desconvierte para subirla
            File = new FileDescription(Guid.NewGuid().ToString(), new MemoryStream(Convert.FromBase64String(image))),
            PublicId = titulo,
            Folder = "Fisiolabs/Img"
        });

        return result.Url.ToString();
    }

    public string UploadVideo(IFormFile video, string titulo)
    {
        //tipo de formato que se subira
        VideoUploadResult result = cloudinary.UploadLarge(new VideoUploadParams
        {
            //Sube una imagen en base64 y lo desconvierte para subirla
            File = new FileDescription(Guid.NewGuid().ToString(), new MemoryStream(Convert.FromBase64String(_convert.ConvertBase64(video)))),
            PublicId = titulo,
            Folder = "Fisiolabs/Video"
        });
        
        return result.Url.ToString();
    }
}