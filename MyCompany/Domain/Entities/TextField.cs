using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Name (title)")]
        public override string Title { get; set; } = "Informational Page";

        [Display(Name = "Long description")]
        public override string Text { get; set; } = "The Content is filled by administrator";

    }
}
