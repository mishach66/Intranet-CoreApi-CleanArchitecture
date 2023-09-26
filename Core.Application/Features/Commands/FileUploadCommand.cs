using Core.Application.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Features.Commands
{
    public class FileUploadCommand : IRequest<FileDTO>
    {
        public FileDTO FileForUpoad { get; set; }
    }

    public class FileUploadCommandHandler : IRequestHandler<FileUploadCommand, FileDTO>
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FileUploadCommandHandler(IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor) 
        {
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<FileDTO> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            var filename = "";
            var httpReq = _httpContextAccessor.HttpContext.Request;
            try
            {
                var requestfile = request.FileForUpoad.File;
                if (requestfile != null) 
                {
                    var filenamewithoutextension = Path.GetFileNameWithoutExtension(requestfile.FileName);
                    string fileextension = Path.GetExtension(requestfile.FileName);
                    filename = filenamewithoutextension + "-" + DateTime.Now.Ticks.ToString() + fileextension;
                }
                else
                {
                    filename = "!blank.png";
                }

                var filepath = _hostEnvironment.WebRootPath + "\\Upload\\Files";
                //var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");
                //var filepath = Path.Combine(Directory.GetDirectoryRoot("D:\\"), "Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var filenamewithpath = Path.Combine(filepath, filename);
                //var filenamewithpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                //var filenamewithpath = Path.Combine(Directory.GetDirectoryRoot("D:\\"), "Files", filename);

                string Imageurl = "";
                string hosturl = $"{httpReq.Scheme}://{httpReq.Host}{httpReq.PathBase}";

                if (requestfile != null)
                {
                    using (var stream = new FileStream(filenamewithpath, FileMode.Create))
                    {
                        await requestfile.CopyToAsync(stream);
                        request.FileForUpoad.UploadIsSuccess = true;
                    }
                }

                request.FileForUpoad.UploadedFileUrl = hosturl + "/Upload/Files/" + filename;
            }
            catch (Exception ex) 
            {
                request.FileForUpoad.UploadIsSuccess = false;
            }
            
            return request.FileForUpoad;
        }
    }
}
