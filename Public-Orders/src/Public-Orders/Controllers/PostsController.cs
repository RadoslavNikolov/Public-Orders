namespace PublicOrders.Controllers
{
    using System.Linq;
    using Data.AppData.Models;
    using Data.AppData.UnitOfWork;
    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.Data.Entity;

    public class PostsController : BaseController
    {
        public PostsController(IPublicOrdersData data)
            : base(data)
        {           
        }

        // GET: Posts
        public IActionResult Index()
        {
            var publicOrdersDbContext = this.PublicOrdersData.Posts.All().Include(p => p.Blog);
            return this.View(publicOrdersDbContext.ToList());
        }

        // GET: Posts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.HttpNotFound();
            }

            Post post = this.PublicOrdersData.Posts.All().Single(m => m.PostId == id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            this.ViewData["BlogId"] = new SelectList(this.PublicOrdersData.Blogs.All(), "BlogId", "Url");
            return this.View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (this.ModelState.IsValid)
            {
                this.PublicOrdersData.Posts.Add(post);
                this.PublicOrdersData.SaveChanges();
                return this.RedirectToAction("Index");
            }
            this.ViewData["BlogId"] = new SelectList(this.PublicOrdersData.Blogs.All(), "BlogId", "Url", post.BlogId);
            return this.View(post);
        }

        // GET: Posts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.HttpNotFound();
            }

            Post post = this.PublicOrdersData.Posts.All().Single(m => m.PostId == id);
            if (post == null)
            {
                return this.HttpNotFound();
            }
            this.ViewData["BlogId"] = new SelectList(this.PublicOrdersData.Blogs.All(), "BlogId", "Url", post.BlogId);
            return this.View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (this.ModelState.IsValid)
            {
                this.PublicOrdersData.Posts.Update(post);
                this.PublicOrdersData.SaveChanges();
                return this.RedirectToAction("Index");
            }
            this.ViewData["BlogId"] = new SelectList(this.PublicOrdersData.Blogs.All(), "BlogId", "Url", post.BlogId);
            return this.View(post);
        }

        // GET: Posts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.HttpNotFound();
            }

            Post post = this.PublicOrdersData.Posts.All().Single(m => m.PostId == id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Post post = this.PublicOrdersData.Posts.All().Single(m => m.PostId == id);
            this.PublicOrdersData.Posts.Remove(post);
            this.PublicOrdersData.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}
