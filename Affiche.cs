using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTheatre
{
    public class Affiche 
    {
        public List<Performance> Performances { get; private set; }
        //public Affiche(Performance[] performances)
        //{
        //    Performances = new List<Performance>();
        //    foreach (Performance perf in performances)
        //    {
        //        Performances.Add(perf);
        //    }
        //}
        public Affiche(List<Performance> performances)
        {
            Performances = new List<Performance>();
            foreach (Performance perf in performances)
            {
                Performances.Add(perf);
            }
        }
        public void Add(Performance performance)
        {
            Performances.Add(performance);
        }
        public List<Performance> GetByAuthor(string author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("Author cannot be null");
            }
            List<Performance> performances = new List<Performance>();
            foreach (Performance perf in Performances)
            {
                if (perf.Author == author)
                {
                    performances.Add(perf);
                }
            }
            return performances;
        }
        public List<Performance> GetByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            List<Performance> temp = new List<Performance>();
            foreach (Performance perf in Performances)
            {
                if (perf.Name == name)
                {
                    temp.Add(perf);
                }
            }               
            return temp;
        }
        public List<Performance> GetByGenre(string genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException("Genre cannot be null");
            }
            List<Performance> temp = new List<Performance>();
            foreach (Performance perf in Performances)
            { 
                if (perf.Genre == genre)
                { 
                    temp.Add(perf); 
                } 
            }
            return temp;
        }
        public Performance this[int index]
        {
            get
            {
                return Performances[index];
            }
        }
    }
}
