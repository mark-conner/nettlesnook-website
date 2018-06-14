using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nettlesnook.Data;
using Nettlesnook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ImageProcessor.Imaging.Formats;
using ImageProcessor;
using System.Drawing;

namespace Nettlesnook.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public BlogsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //GET: Blogs
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            // .Include inserted to allow Eager Loading of images into Blog.Images list
            return View(await _context.Blog.Include(x => x.Images).ToListAsync());
        }

        public async Task<IActionResult> List()
        {
            // .Include inserted to allow Eager Loading of images into Blog.Images list
            return View(await _context.Blog.Include(x => x.Images).ToListAsync());
        }

        // GET: Blogs/Details/Id?
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .Include(m => m.Images) //  .Include inserted to allow Eager Loading of images into Blog.Images list
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateTime,Title,Body,Archive,Images")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/Id?
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  .Include inserted to allow Eager Loading of images into Blog.Images list
            var blog = await _context.Blog.Include(m => m.Images).SingleOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/Id?
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateTime,Title,Body,Archive,Images")] Blog blog)
        {
            if (id != blog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Account/Dashboard");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/Id?
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.ID == id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return Redirect("/Account/Dashboard");
        }

        //Some code from Christopher Noto, with additions by me for existing file checking
        //POST: Blogs/ImageUpload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImages(IFormFile ImageFile, string NewFileName="")
        {
            string _NewFileName = NewFileName + ".jpg";
            string file = ImageFile.FileName;

            var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            FileInfo newFile = new FileInfo(Path.Combine(imagePath, _NewFileName)); //Used to check if file name already exists

            /*  This part not working yet.  This section is to resize and compress images for web viewing
            //Uses imageFactory class from http://imageprocessor.org/imageprocessor/imagefactory/
            //****Resize and and compress
            using (var imageFactory = new ImageFactory())
            using (var fileStream = new FileStream(path))
            {
                file.Value.Seek(0, SeekOrigin.Begin);

                imageFactory.FixGamma = false;
                imageFactory.Load(file.Value)
                            .Resize(new ResizeLayer(new Size(264, 176)))
                            .Format(new JpegFormat
                            {
                                Quality = 100
                            })
                            .Quality(100)
                            .Save(fileStream);
            }
            */


            ViewBag.Error = "";
            ViewBag.Success = "";
            if (!newFile.Exists)    //Check if file already exists on server
            { 
                if (ImageFile.Length > 0 && ImageFile.ContentType == "image/jpeg")  //Make sure file is a jpeg and and has conent
                {
                    var cType = ImageFile.ContentType;
                    using (var fileStream = new FileStream(Path.Combine(imagePath, _NewFileName), FileMode.Create)) //using is to close process completely when done
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }
                    ViewBag.Success = "FileUploaded!";
                }
                else
                {
                    ViewBag.Error = "Something went wrong! " + imagePath + " " + _NewFileName + " " + ImageFile.ContentType;
                }
            }
            else
            {
                ViewBag.Error = "File already exists!";
                return View();
            }
            
            return View();
        }

        //GET: Blogs/UploadImages
        public IActionResult UploadImages()
        {
            ViewBag.Error = "";
            ViewBag.Success = "";
            return View();
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.ID == id);
        }

        
    }
}
