using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomerManagement
{
    public partial class Form1 : Form
    {
        CustomerDAO customerDao = new CustomerDAO();
       

        public Form1()
        {    
            InitializeComponent();

            DeptComboBox.Items.Add("CSE");
            DeptComboBox.Items.Add("IPE");
            DeptComboBox.Items.Add("ME");
            DeptComboBox.Items.Add("EEE");

            loadCustomners();
        }

        private void loadCustomners()
        {
            CustomInfo.DataSource =customerDao.GetCustomers().Tables[0];
        }

        private void createCustomer()
        {
            int id = Convert.ToInt32(IDBox.Text);
            string name = NameBox.Text;
            int age = Convert.ToInt32(AgeBox.Text);
            string dept = DeptComboBox.Text;

            customerDao.CreateCustomer(new CustomerDTO(id,name,age,dept));

            loadCustomners();
        }

        private void deleteCustomer()
        {
            customerDao.DeleteCustomer(Convert.ToInt32(IDBox.Text));

            loadCustomners();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeptComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createCustomer();
        }

        private void CustomInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (CustomInfo.SelectedRows.Count == 1)
            {
                int idx = CustomInfo.SelectedRows[0].Index;

                IDBox.Text = CustomInfo.Rows[idx].Cells[0].Value.ToString();
                NameBox.Text = CustomInfo.Rows[idx].Cells[1].Value.ToString();
                AgeBox.Text = CustomInfo.Rows[idx].Cells[2].Value.ToString();
                DeptComboBox.Text = CustomInfo.Rows[idx].Cells[3].Value.ToString();

            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            deleteCustomer();
        }
    }


}
