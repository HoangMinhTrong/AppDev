using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev.ViewModel
{
    public class TrainerViewModel
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Có thể tách thành các ViewModel khác nhau tuỳ mục đích sử dụng.
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
