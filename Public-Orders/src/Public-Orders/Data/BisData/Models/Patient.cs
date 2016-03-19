using System;
using System.Collections.Generic;

namespace PublicOrders.Data.BisData.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Patient
    {
        public Patient()
        {
            Examination = new HashSet<Examination>();
        }

        public int Id { get; set; }

        [Display(Name = "Patient address")]
        public string Address { get; set; }

        [Display(Name = "Patient age")]
        public short? Age { get; set; }

        [Display(Name = "Patient city")]
        public string City { get; set; }

        [Display(Name = "Patient EGN")]
        public string Egn { get; set; }

        [Display(Name = "Patient first name")]
        public string FirstName { get; set; }

        [Display(Name = "Patient last name")]
        public string LastName { get; set; }

        [Display(Name = "Patient second name")]
        public string SecondName { get; set; }

        public virtual ICollection<Examination> Examination { get; set; }
    }
}
