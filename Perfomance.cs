    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTheatre
{
    public class Performance
    {
        public Performance()
        {

        }
        public string Name { get; private set; }
        public string Author { get; set; }
        public string Genre { get; private set; }
        public int Year { get; private set; }
        public Performance(string name, string author, string genre, int year)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }

            Name = name;

            if (author == null)
            {
                throw new ArgumentNullException("Author cannot be null");
            }

            Author = author;

            if (genre == null)
            {
                throw new ArgumentNullException("Genre cannot be null");
            }

            Genre = genre;

            if (year == 0)
            {
                throw new ArgumentNullException("Year cannot be null");
            }

            Year = year;
        }
        public override bool Equals(object obj)
        {
            if (obj is Performance && obj != null)
            {
                Performance performance = (Performance)obj;
                return Name == performance.Name && Author == performance.Author && Genre == performance.Genre && Year == performance.Year;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString() => $"Name:{Name,-20} Author:{Author,-25} Genre:{Genre,-10} Published in:{Year,-5}";
    }
}

