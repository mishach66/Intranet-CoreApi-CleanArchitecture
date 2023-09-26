using Microsoft.AspNetCore.Http;

namespace Core.Application.DTO
{
    public class FileDTO
    {
        public IFormFile? File { get; set; }
        public string? UploadedFileUrl { get; set; }
        //public bool? UploadIsSuccess { get; set; } = false;
        public bool? UploadIsSuccess { get; set; }
        public string? UniqueId { get; set; }
    }
}
