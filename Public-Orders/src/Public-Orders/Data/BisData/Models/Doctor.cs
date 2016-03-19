using System.Collections.Generic;

namespace PublicOrders.Data.BisData.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Doctor
    {
        public Doctor()
        {
            Examination = new HashSet<Examination>();
        }

        public int Id { get; set; }

        [Display(Name = "Doctor first name")]
        public string FirstName { get; set; }

        [Display(Name = "Doctor last name")]
        public string LastName { get; set; }

        [Display(Name = "Doctor second name")]
        public string SecondName { get; set; }

        [Display(Name = "Doctor speciality")]
        public string Speciality { get; set; }

        [Display(Name = "Doctor UIN")]
        public string UIN { get; set; }

        public virtual ICollection<Examination> Examination { get; set; }
    }
}
