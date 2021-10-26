using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev.Models
{
    public class AssignTrainerToCourse
    {
        public int Id { get; set; }

        public string TrainerId { get; set; }
        
        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime CreateAt { get; set; }

        public AssignTrainerToCourse()
        {
            CreateAt = DateTime.Now;
        }
    }
}
