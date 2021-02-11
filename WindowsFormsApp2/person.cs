using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class person : IComparable<person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public string Info
        {
            get 
            {
                return $"{Name} {SurName}, ID: {Id} ";
            }
        }

        public int CompareTo(person other)
        {
            //throw new NotImplementedException();


            return this.Id.CompareTo(other.Id);
        }
    }
}
