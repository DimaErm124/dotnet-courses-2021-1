using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class MainForm : Form
    {
        private IList<User> _users;
        private BindingSource _usersSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditUser();

            if (form.ShowDialog() == DialogResult.OK)
            {                
                _users.Add(form.User);
            }
        }


    }

    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; }

        public User(int id, string firstName, string lastName, DateTime birthdate)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }
    }

    public class Reward
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Reward(int id, string title, string description = "")
        {
            ID = id;
            Title = title;
            Description = description;
        }
    }
}
