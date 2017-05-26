using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagement
{
    class CustomerDTO
    {
        private int id, age;
        private string name, dept;

        public CustomerDTO(int id, string name, int age, string dept)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.dept = dept;
        }

        public int ID 
        {
             get {return id ;}
             set {id = value ;}
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public int AGE
        {
            get { return age; }
            set { age = value; }
        }

        public string DEPT
        {
            get { return dept; }
            set { dept = value; }
        }
    }
}
