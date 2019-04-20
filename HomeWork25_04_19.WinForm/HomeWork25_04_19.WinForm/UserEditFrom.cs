using HomeWork25_04_19.DataAccess;
using HomeWork25_04_19.Models;
using HomeWork25_04_19.Sevices;
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
        User changedUser = new User();

        public UserEditFrom(User user)
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Login", "Login");
            dataGridView1.Columns.Add("Password", "Password");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("PhoneNumber", "PhoneNumber");
            dataGridView1.Columns.Add("IsAdmin", "IsAdmin");

            dataGridView1.Rows.Add(user.Id, user.Login, user.Password, user.Address, user.PhoneNumber, user.IsAdmin);

            changedUser.Id = user.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var firstRow = dataGridView1.Rows[Constants.FIRST_ELEMENT];

            using(TableDataService<User> dataService = new TableDataService<User>())
            {

                try
                {
                    changedUser.Address = firstRow.Cells["Address"].Value.ToString();

                    if(CheckData.IsLoginCorrect(firstRow.Cells["Login"].Value.ToString()))
                    {
                        changedUser.Login = firstRow.Cells["Login"].Value.ToString();
                    }

                    if(CheckData.IsPasswordCorrect(firstRow.Cells["Password"].Value.ToString()))
                    {
                        changedUser.Password = firstRow.Cells["Password"].Value.ToString();
                    }

                    if(CheckData.IsPhoneNumberCorrect(firstRow.Cells["PhoneNumber"].Value.ToString()))
                    {
                        changedUser.PhoneNumber = firstRow.Cells["PhoneNumber"].Value.ToString();
                    }

                    if (CheckData.IsAdminCorrect(firstRow.Cells["IsAdmin"].Value.ToString()))
                    {
                        changedUser.IsAdmin = (bool)firstRow.Cells["IsAdmin"].Value;
                    }

                    dataService.DeleteById(changedUser.Id);
                    dataService.Add(changedUser);
                    this.Close();
                }
                catch(ArgumentException exception)
                {
                    MessageBox.Show(this, exception.Message);
                }
            }
        }
    }
}
