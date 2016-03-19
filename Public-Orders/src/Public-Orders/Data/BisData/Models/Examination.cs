using System;
using System.Collections.Generic;

namespace PublicOrders.Data.BisData.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Examination
    {
        public int Id { get; set; }

        [Display(Name = "Examination date")]
        public DateTime Date { get; set; }

        [Display(Name = "Examination description")]
        public string Description { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
