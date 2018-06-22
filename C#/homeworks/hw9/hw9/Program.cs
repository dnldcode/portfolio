using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw9
{
	class Program
	{
		static void Main(string[] args)
		{
			Student s1 = new Student("Фамилия 1", "Имя 1", 18, "мужской");
			Student s2 = new Student("Фамилия 2", "Имя 2", 18, "мужской");
			Student s3 = new Student("Фамилия 3", "Имя 3", 18, "мужской");
			Student s4 = new Student("Фамилия 4", "Имя 4", 18, "мужской");
			Student s5 = new Student("Фамилия 5", "Имя 5", 18, "мужской");
			Student s6 = new Student("Фамилия 6", "Имя 6", 18, "мужской");
			Student s7 = new Student("Фамилия 7", "Имя 7", 18, "мужской");
			Student s8 = new Student("Фамилия 8", "Имя 8", 18, "мужской");
			Student s9 = new Student("Фамилия 9", "Имя 9", 18, "мужской");
			Student s10 = new Student("Фамилия 10", "Имя 10", 18, "мужской");

			Group gr = new Group();
			try
			{
				gr.addStudent(s1);
				gr.addStudent(s2);
				gr.addStudent(s3);
				gr.addStudent(s4);
				gr.addStudent(s5);
				gr.addStudent(s6);
				gr.addStudent(s7);
				gr.addStudent(s8);
				gr.addStudent(s9);
				gr.addStudent(s10);
				gr.addStudent(s10);
			}
			catch (GroupOverflowException fe)
			{
				Console.WriteLine(" Ошибка : {0}", fe.Message);
			}
			//gr.showStudents();
			//Console.WriteLine("--------");
			gr.deleteStudent(0);
			gr.deleteStudent(0);
			gr.deleteStudent(0);
			gr.deleteStudent(0);
			gr.deleteStudent(0);
			//gr.showStudents();

			Group test = (Group)gr.Clone();
			test.showStudents();
		}
	}
	class Student : ICloneable
	{
		private String surname;
		public String Surname
		{
			get
			{
				return this.surname;
			}
			set
			{
				this.surname = value;
			}
		}
		private String name;
		public String Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}
		private int age;
		public int Age
		{
			get
			{
				return this.age;
			}
			set
			{
				if (value < 0)
					value *= -1;
				this.age = value;
			}
		}
		private String sex;
		public String Sex
		{
			get
			{
				return this.sex;
			}
			set
			{
				this.sex = value;
			}
		}
		public Student(String surname = "Unknown", String name = "Unknown", int age = 0, String sex = "Unknown")
		{
			this.Surname = surname;
			this.Name = name;
			this.Age = age;
			this.Sex = sex;
		}
		public override String ToString()
		{
			return String.Format(" Фамилия - {0}, имя - {1}\n Возраст - {2}, пол - {3}\n", Surname, Name, Age, Sex);
		}
		public object Clone()
		{
			Student copy = (Student)this.MemberwiseClone();
			copy.Surname = (String)this.Surname.Clone();
			copy.Name = (String)this.Name.Clone();
			copy.Sex = (String)this.Sex.Clone();
			return copy;
		}
	}
	class Group : ICloneable
	{
		private Student[] students = new Student[10];
		private int count = 0;
		public Student this[int i]
		{
			get
			{
				return this.students[i];
			}
			set
			{
				this.students[i] = value;
			}
		}
		public void addStudent(Student s)
		{
			if (count == 10)
				throw new GroupOverflowException(" Группа заполнена, добавление невозможно.");
			students[count] = s;
			count++;
		}
		public void deleteStudent(int index)
		{
			if(index < 0 || index >= count)
			{
				Console.WriteLine(" Полученого индекса не существует");
				return;
			}
			Student temp = new Student();
			for (int i = index; i < count - 1; i++)
			{
				temp = students[i + 1];
				students[i + 1] = students[i];
				students[i] = temp;
			}
			students[count-- - 1] = null;
		}
		public void showStudents()
		{
			int q = 0;
			foreach(Student s in students)
			{
				if (students[q] == null)
					Console.WriteLine(" Студент {0} : Место свободно\n", q++ + 1);
				else
					Console.WriteLine(" Студент {0} : {1}", q + 1, students[q++]);
			}
		}
		public object Clone()
		{
			Group copy = (Group)this.MemberwiseClone();
			for (int i = 0; i < count; i++)
			{
				copy.students[i] = (Student)this.students[i].Clone();
			}
			return copy;
		}
	}
	class GroupOverflowException : FormatException
	{
		public GroupOverflowException(string message) : base(message) { }
	}
}