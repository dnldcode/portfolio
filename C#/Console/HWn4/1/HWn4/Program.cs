using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HWn4
{
	class Program
	{
		static void Main(string[] args)
		{
			Student s1 = new Student("Holishevskyi", "Serhii", 17, "Noname", "N3");
			s1.showInfo();
		}
	}
	class Human
	{
		protected string surname, name;
		protected short age;
		public string Surname
		{
			set
			{
				surname = value;
			}
			get
			{
				return this.surname;
			}
		}
		public string Name
		{
			set
			{
				this.name = value;
			}
			get
			{
				return this.name;
			}
		}
		public short Age
		{
			set
			{
				if (age < 0)
					age *= -1;
				this.age = value;
			}
			get
			{
				return this.age;
			}
		}
		public Human(string surname = "", string name = "", short age = 0)
		{
			this.Surname = surname;
			this.Name = name;
			this.Age = age;
		}
		public void showInfo()
		{
			Console.WriteLine(" Surname : {0} |  name : {1} |  age : {2:D3}", this.Surname, this.Name, this.Age);
		}
	}
	class Student : Human
	{
		protected string university, faculty;
		public string University
		{
			set
			{
				university = value;
			}
			get
			{
				return this.university;
			}
		}
		public string Faculty
		{
			set
			{
				faculty = value;
			}
			get
			{
				return faculty;
			}
		}
		public Student(string surname = "", string name = "", short age = 0, string university = "", string faculty = "") : base(surname, name, age)
		{
			University = university;
			Faculty = faculty;
		}
		public new void showInfo()
		{
			Console.WriteLine(" Surname : {0} |  name : {1} |  age : {2} |  university : {3} |  faculty : {4}", this.Surname, this.Name, this.Age, this.University, this.Faculty);
		}
	}
}
