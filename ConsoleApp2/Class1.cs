using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Class1
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Major { get; set; }
        Class1() { }
       public Class1(int id,string name,string major) {
            Id = id ;
            Name = name;
            Major= major;
        }
        Class1(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return "Student Id " + this.Id + " Student name " + this.Name + " Student Major " + this.Major;
        }

    }
}
