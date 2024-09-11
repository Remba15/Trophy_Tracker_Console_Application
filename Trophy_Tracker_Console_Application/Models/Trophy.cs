using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophy_Tracker_Console_Application.Models
{
    internal class Trophy : Identity
    {

        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? GameID { get; set; }
        public string? Type { get; set; }

        public override string ToString()
        {
            return "Type: " + this.Type + "\nTitle"
        }
    }
}
