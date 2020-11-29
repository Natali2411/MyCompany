using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Fill the service name")]
        [Display(Name = "Name (title)")]
        public override string Title { get; set; }

        [Display(Name = "Short description")]
        public override string Subtitle { get; set; }

        [Display(Name = "Long description")]
        public override string Text { get; set; }
    }
}
