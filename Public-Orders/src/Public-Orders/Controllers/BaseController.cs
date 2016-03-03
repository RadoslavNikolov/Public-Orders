namespace PublicOrders.Controllers
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Data.UnitOfWork;
    using Infrastructure;
    using Microsoft.AspNet.Mvc;

    public class BaseController : Controller
    {

        public BaseController(IPublicOrdersData data)
        {
            this.PublicOrdersData = data;
            this.UserProfile = new User();
        }

        public IPublicOrdersData PublicOrdersData { get; private set; }

        public User UserProfile { get; set; }     

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