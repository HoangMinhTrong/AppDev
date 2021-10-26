using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev.Models
{
    public class AssignTraineeToCourse
    {
        public int Id { get; set; }

        public string TraineeId { get; set; }

        [ForeignKey("TraineeId")]
        public Trainee Trainee { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime CreateAt { get; set; }

        public AssignTraineeToCourse()
        {
            CreateAt = DateTime.Now;
        }
    }
}
