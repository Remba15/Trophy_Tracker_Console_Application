using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophy_Tracker_Console_Application.Models
{
    internal class Player : Identity
    {

        public string? Username { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Region { get; set; }

        public override string ToString()
        {
            return "Username: " + this.Username + " | Region: " + this.Region + " | Date registered: " + this.RegistrationDate.Value.ToString("dd.MM.yyyy");
        }

    }
}
