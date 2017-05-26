using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement
{
    class CustomerDAO
    {   
        //public string connectionString= @"Data Source=.\\sqlexpress;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
        public string connectionString = @"Data Source=C:\Users\SUSMOY\Desktop\CustomerManagement\CustomerManagement\Database1.sdf";
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private DataSet dataSet;

        public CustomerDAO()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataSet GetCustomers()
        {
            sqlConnection.Open();
            string sqlQuery = "select * from Customer";
            sqlCommand= new SqlCommand(sqlQuery, sqlConnection);

            sqlAdapter = new SqlDataAdapter(sqlCommand);
            
            dataSet = new DataSet();

            sqlAdapter.Fill(dataSet);

            sqlConnection.Close();

            return dataSet;
          
        }

        public void CreateCustomer(CustomerDTO customeDTO)
        {

            sqlConnection.Open();
            string sqlQuery = " insert into customer values('" + customeDTO.ID +
                                                           "','" + customeDTO.NAME + 
                                                           "','" + customeDTO.AGE +
                                                           "','" + customeDTO.DEPT + "')";

            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
         

        }

        public void DeleteCustomer(int id)
        {
            sqlConnection.Open();
            string sqlQuery = " delete from customer where ID= " + id;

            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
           
        }
    }
}
