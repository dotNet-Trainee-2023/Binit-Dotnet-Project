using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public abstract class Media
    {
        public string title { get; set; } = string.Empty;
        public int year { get; set; }

        public Media()
        {

        }
        public Media(string title, int year)
        {
            this.title = title;
            this.year = year;
        }

        public abstract void DisplayInfo();
    }
}
