namespace PublicOrders.Data.AppData.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public string Egn { get; set; }

        public short Age { get; set; }
    }
}
