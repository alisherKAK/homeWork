using HomeWork25_04_19.DataAccess;
using HomeWork25_04_19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork25_04_19.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Login", "Login");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("PhoneNumber", "PhoneNumber");
            dataGridView1.Columns.Add("IsAdmin", "IsAdmin");

            using (TableDataService<User> dataService = new TableDataService<User>())
            {
                var users = dataService.GetAll();

                for(int i = 0; i < users.Count; i++)
                {
                    listBox1.Items.Add(users[i].Login);
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            UserEditFrom userEditFrom;
            string selectedItem = listBox1.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                dataGridView1.Rows.Clear();

                using (TableDataService<User> dataService = new TableDataService<User>())
                {
                    var users = dataService.GetAll();

                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].Login == selectedItem)
                        {
                            userEditFrom = new UserEditFrom(users[i]);

                            if (userEditFrom.ShowDialog(this) == DialogResult.Cancel)
                            {
                                AdminFilter();
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm();
            if(userAddForm.ShowDialog(this) == DialogResult.Cancel)
            {
                AdminFilter();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = listBox1.SelectedIndex;

            if (selectedItemIndex >= 0)
            {
                using (TableDataService<User> dataService = new TableDataService<User>())
                {
                    var dataSet = new DataSet("ShopDb");
                    var dataAdapter = dataService.GetDataAdapter();

                    dataAdapter.Fill(dataSet, "Users");

                    var usersTable = dataSet.Tables["Users"];

                    var row = usersTable.Rows[selectedItemIndex];
                    row.BeginEdit();
                    row.Delete();
                    row.EndEdit();

                    dataAdapter.Update(dataSet, "Users");

                    listBox1.Items.RemoveAt(selectedItemIndex);
                    dataGridView1.Rows.Clear();
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            string selectedItem = listBox1.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                dataGridView1.Rows.Clear();

                using (TableDataService<User> dataService = new TableDataService<User>())
                {
                    var users = dataService.GetAll();

                    for(int i = 0; i < users.Count; i++)
                    {
                        if(users[i].Login == selectedItem)
                        {
                            dataGridView1.Rows.Add(users[i].Id, users[i].Login, users[i].Password.ToString().GetHashCode(), users[i].Address, users[i].PhoneNumber, users[i].IsAdmin);
                        }
                    }
                }
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            AdminFilter();
        }

        private void AdminFilter()
        {
            if (checkBox1.Checked)
            {
                listBox1.Items.Clear();

                using (TableDataService<User> dataService = new TableDataService<User>())
                {
                    var users = dataService.GetAll();

                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].IsAdmin)
                        {
                            listBox1.Items.Add(users[i].Login);
                        }
                    }
                }
            }
            else
            {
                listBox1.Items.Clear();

                using (TableDataService<User> dataService = new TableDataService<User>())
                {
                    var users = dataService.GetAll();

                    for (int i = 0; i < users.Count; i++)
                    {
                        listBox1.Items.Add(users[i].Login);
                    }
                }
            }
        }
    }
}
