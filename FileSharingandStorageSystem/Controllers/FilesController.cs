using FileSharingandStorageSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileSharingandStorageSystem.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileStorageService _fileStorageService;

        public FilesController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public IActionResult Index()
        {
            var files = _fileStorageService.GetAllFiles();
            return View(files);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "Please select a file to upload.";
                return RedirectToAction("Index");
            }

            await _fileStorageService.StoreFileAsync(file);
            TempData["Message"] = "File uploaded successfully.";
            return RedirectToAction("Index");
        }

        [HttpGet("download/{fileName}")]
        public IActionResult Download(string fileName)
        {
            var fileStream = _fileStorageService.GetFileStream(fileName);
            if (fileStream == null) return NotFound();

            return File(fileStream, "application/octet-stream", fileName);
        }
    }
}

