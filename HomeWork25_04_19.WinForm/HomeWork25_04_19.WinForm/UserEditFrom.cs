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
    public partial class UserEditFrom : Form
    {
        private int userIndex;

        public UserEditFrom(User user, int index)
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Login", "Login");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("PhoneNumber", "PhoneNumber");
            dataGridView1.Columns.Add("IsAdmin", "IsAdmin");

            dataGridView1.Rows.Add(user.Id, user.Login, user.Password, user.Address, user.PhoneNumber, user.IsAdmin);

            userIndex = index;
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            using(TableDataService<User> dataService = new TableDataService<User>())
            {
                var dataSet = new DataSet("ShopDb");
                var dataAdapter = dataService.GetDataAdapter();

                dataAdapter.Fill(dataSet, "Users");

                var usersTable = dataSet.Tables["Users"];

                var row = usersTable.Rows[userIndex];
                try
                {
                    row.BeginEdit();
                    if(Checker.CheckLogin(dataGridView1[1, 0].Value.ToString()))
                        row["Login"] = dataGridView1[1, 0].Value;
                    row["Password"] = dataGridView1[2, 0].Value;
                    row["Address"] = dataGridView1[3, 0].Value;
                    row["PhoneNumber"] = dataGridView1[4, 0].Value;
                    row["IsAdmin"] = dataGridView1[5, 0].Value;
                    row.EndEdit();
                }
                catch (ArgumentException exception)
                {
                    row.CancelEdit();
                }

                dataAdapter.Update(dataSet, "Users");
            }
            this.Close();
        }
    }
}
