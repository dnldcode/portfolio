using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace hw4._2form
{
	public partial class Form1 : Form
	{
		static Person person = new Person();
		static BinaryFormatter formatter = new BinaryFormatter();
		public Form1()
		{
			InitializeComponent();
			initComboBoxes();

			Deserialize();

			this.FormClosing += Form1_FormClosing;

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			using (FileStream fs = new FileStream("form.dat", FileMode.OpenOrCreate))
				formatter.Serialize(fs, person);
		}

		private void Deserialize()
		{
			using (FileStream fs = new FileStream("form.dat", FileMode.OpenOrCreate))
				person = (Person)formatter.Deserialize(fs);
			textBox1.Text = person.Surname;
			textBox2.Text = person.Name;
			if (person.Sex)
				radioButton1.Checked = true;
			else
				radioButton2.Checked = true;
			comboBox1.SelectedIndex = person.birthday.day;
			comboBox2.SelectedIndex = person.birthday.month;
			comboBox3.SelectedIndex = person.birthday.year;

			if (person.interests[0])
				checkBox1.Checked = true;
			if (person.interests[1])
				checkBox2.Checked = true;
			if (person.interests[2])
				checkBox3.Checked = true;
			if (person.interests[3])
				checkBox4.Checked = true;		
		}

		private void initComboBoxes()
		{
			for (int i = 1; i <= 31; i++)
				comboBox1.Items.Add(i.ToString());
			comboBox2.Items.Add("Январь");
			comboBox2.Items.Add("Февраль");
			comboBox2.Items.Add("Март");
			comboBox2.Items.Add("Апрель");
			comboBox2.Items.Add("Май");
			comboBox2.Items.Add("Июнь");
			comboBox2.Items.Add("Июль");
			comboBox2.Items.Add("Август");
			comboBox2.Items.Add("Сентябрь");
			comboBox2.Items.Add("Октябрь");
			comboBox2.Items.Add("Ноябрь");
			comboBox2.Items.Add("Декабрь");
			for (int i = 1960; i < 2000; i++)
				comboBox3.Items.Add(i.ToString());
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			person.Surname = textBox1.Text;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			person.Name = textBox2.Text;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			person.Sex = true;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			person.Sex = false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			person.birthday.day = comboBox1.SelectedIndex;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			person.birthday.month = comboBox2.SelectedIndex;
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			person.birthday.year = comboBox3.SelectedIndex;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				person.interests[0] = true;
			else
				person.interests[0] = false;
		}
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
				person.interests[1] = true;
			else
				person.interests[1] = false;
		}
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked)
				person.interests[2] = true;
			else
				person.interests[2] = false;
		}
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked)
				person.interests[3] = true;
			else
				person.interests[3] = false;
		}
	}
	[Serializable]
	class Person
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
		private bool sex;
		public bool Sex
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
		public birthday birthday;
		public List<bool> interests = new List<bool>(4);
		public Person()
		{
			for (int i = 0; i < 4; i++)
			{
				interests.Add(false);
			}
		}
	}
	[Serializable]
	struct birthday
	{
		public int day;
		public int month;
		public int year;
	}
}