using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophy_Tracker_Console_Application.Models
{
    internal class Game : Identity
    {

        public string? Title { get; set; }
        public string? Developer { get; set; }
        public List<string>? Platforms { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var platform in this.Platforms)
            {
                if (platform == this.Platforms.LastOrDefault())
                {
                    stringBuilder.Append(platform);
                }
                else
                {
                    stringBuilder.Append(platform + ", ");
                }
            }
            return this.Title + " - Developed by " + this.Developer + " for " + stringBuilder;
        }

    }
}
