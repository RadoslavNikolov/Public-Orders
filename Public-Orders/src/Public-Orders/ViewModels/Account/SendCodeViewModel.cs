﻿namespace PublicOrders.ViewModels.Account
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Mvc.Rendering;

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
