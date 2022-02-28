using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanHangAPI.Data;
using BanHangAPI.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace BanHangAPI.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly MyDBContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentsController(MyDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documents.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,FileName,ContentType,FileSize")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,FileName,ContentType,FileSize")] Document document)
        {
            if (id != document.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }

        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult> Upload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var rootPath = Path.Combine(_environment.ContentRootPath, "Resources", "Documents");
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

            foreach(var file in files)
            {
                var filePath = Path.Combine(rootPath, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    var document = new Document
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        FileSize = file.Length
                    };

                    await file.CopyToAsync(stream);

                    _context.Documents.Add(document);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(new { count = files.Count, size });
        }

        [HttpPost]
        [Route("download/{id}")]
        public async Task<ActionResult> Download(int id)
        {
            var provider = new FileExtensionContentTypeProvider();
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            var file = Path.Combine(_environment.ContentRootPath, "Resources", "Documents", document.FileName);

            string contentType;
            if(!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";

            }
            else
            {
                return NotFound();
            }
            byte[] fileBytes;
            if (System.IO.File.Exists(file))
            {
                fileBytes = System.IO.File.ReadAllBytes(file);
            }
            else
            {
                return NotFound();
            }
            return File(fileBytes, contentType, document.FileName);
        }
    }
}
