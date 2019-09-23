using System;
using System.Collections.Generic;
using System.Text;

namespace Itea_Lesson3

{
    class Person : IModel
    {
        public Guid Id { get; set; }
        int Age { get; set; }
        string Name { get; set; }
        Guid CompanyId { get; set; }

        public Person(string name) {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Person(string name, Guid companyid)
        {
            Id = Guid.NewGuid();
            Name = name;
            CompanyId = companyid;
        }
        public Person(string name, int age, Guid companyid)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            CompanyId = companyid;
        }
        override public string ToString() {
            string text = "";
            if (Age!=0)  text = "Name: " + Name;
            else text = "Name: " + Name + "\tAge: " + Age;
            return text;
        }

        /* public string ToString(Guid companyid)
        {
            string text = "";
            if (Age != 0) text = "Name: " + Name +"\t Company: " +;
            else text = "Name: " + Name + "\tAge: " + Age;
            return text;
        }*/
    }

    class Company : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public List<Person> People { get; set; }
        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            People = new List<Person>();
        }
        public void AddPeople(string name, int age) {
            People.Add(new Person(name, age, Id));
        }
        public void AddPeople(string name) {
            People.Add(new Person(name, Id));
        }

    }
}
