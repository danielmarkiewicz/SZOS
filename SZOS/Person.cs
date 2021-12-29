using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    abstract class Person
    {
        protected string name;
        protected string surname;
        protected string addres;
        protected string sex;

        public string Sex
        {
            get => sex;
            set
            {
                if (value == "M")
                {
                    sex = value;
                }
                else if (value == "K")
                {
                    sex = value;
                }
            }
        }
        public string Addres
        {
            get => addres;
            set
            {
                if (value != null)
                {
                    addres = value;
                }
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (value != null && value.Length < 40)
                {
                    name = value;
                }
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                if (value != null && value.Length < 50)
                {
                    surname = value;
                }
            }
        }

        public Person()
        {

        }
        public Person(string name, string surname, string addres, string sex)
        {
            name = this.name;
            surname = this.surname;
            addres = this.addres;
            sex = this.sex;
        }

        public abstract string TypeOfPerson();
        
    }
}
