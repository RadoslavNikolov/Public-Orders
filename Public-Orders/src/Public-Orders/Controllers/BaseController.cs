namespace PublicOrders.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data.AppData.Models;
    using Data.AppData.UnitOfWork;
    using Data.BisData;
    using Infrastructure;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Data.Entity;

    public class BaseController : Controller
    {
        public BaseController(IPublicOrdersData data)
        {
            this.PublicOrdersData = data;
        }

        public IPublicOrdersData PublicOrdersData { get; private set; }

        [FromServices]
        public BisDbContext BisDbContext { get; set; }

        public Task<User> UserProfileAsync
        {
            get
            {
                var user = this.PublicOrdersData.Users.All().FirstOrDefaultAsync(u => u.Id == this.HttpContext.User.GetUserId());

                return user;
            }
        }

        public User UserProfile
        {
            get
            {
                var user = this.PublicOrdersData.Users.All().FirstOrDefault(u => u.Id == this.HttpContext.User.GetUserId());

                return user;
            }
        }

        protected bool IsAdmin()
        {
            return this.User.IsInRole(AppConfig.AdminRole);
        }

        protected ICollection<User> GetUsers(ICollection<string> usersId)
        {
            ICollection<User> users = new HashSet<User>();

            if (usersId != null)
            {
                foreach (string id in usersId)
                {
                    User wantedUser = this.PublicOrdersData.Users.Find(id);
                    if (wantedUser == null)
                    {
                        throw new NullReferenceException();
                    }

                    users.Add(wantedUser);
                }
            }

            return users;
        }
    }
}