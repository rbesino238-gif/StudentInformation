using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace StudentInformation
{
    internal class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
        private SqlDataAdapter sqlDataAdapter;

        public DataTable dataTable;
        public BindingSource bindingSource;

        private string connectionString;
        public string _FirstName, _MiddleName, _LastName, _Genderl, _Program;
        public int _Age;
    }
}
