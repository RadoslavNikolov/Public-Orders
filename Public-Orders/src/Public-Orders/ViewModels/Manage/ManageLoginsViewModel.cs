﻿namespace PublicOrders.ViewModels.Manage
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Http.Authentication;
    using Microsoft.AspNet.Identity;

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
