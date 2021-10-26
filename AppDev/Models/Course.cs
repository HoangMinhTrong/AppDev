using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // NOT NUT: Một Course được sinh ra thì luôn tồn tại Category ID
        public int CategoryId { get; set; } 
        public Category Category { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
