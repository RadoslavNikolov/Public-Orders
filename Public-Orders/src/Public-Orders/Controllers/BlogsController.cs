namespace PublicOrders.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.AppData.Models;
    using Data.AppData.UnitOfWork;
    using Microsoft.AspNet.Authorization;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Data.Entity;

    [Authorize]
    [RequireHttps]
    public class BlogsController : BaseController
    {

        public BlogsController(IPublicOrdersData data)
            : base(data)
        {
        }

        // GET: Blogs
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(this.PublicOrdersData.Blogs.All().ToListAsync());
        }

        // GET: Blogs/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Task<Blog> blog = this.PublicOrdersData.Blogs.All().SingleAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (this.ModelState.IsValid)
            {
                this.PublicOrdersData.Blogs.Add(blog);
                this.PublicOrdersData.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.View(blog);
        }

        // GET: Blogs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Task<Blog> blog = this.PublicOrdersData.Blogs.All().SingleAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                this.PublicOrdersData.Blogs.Update(blog);
                this.PublicOrdersData.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Task<Blog> blog = this.PublicOrdersData.Blogs.All().SingleAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Task<Blog> blog = this.PublicOrdersData.Blogs.All().SingleAsync(m => m.BlogId == id);
            this.PublicOrdersData.Blogs.Remove(blog);
            this.PublicOrdersData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
