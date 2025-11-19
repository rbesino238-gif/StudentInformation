using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



    
        public class ClubRegistrationQuery
        {
            private SqlConnection sqlConnect;
            private SqlCommand sqlCommand;
            private SqlDataAdapter sqlAdapter;
            private SqlDataReader sqlReader;

            public DataTable dataTable;
            public BindingSource bindingSource;

            private string connectionString;

            public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
            public int _Age;

            public ClubRegistrationQuery()
            {


                connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=ClubDB_RusselNielBesino;Integrated Security=True;Encrypt=False;
TrustServerCertificate=True;userid=soriano.j;password=12345";
                sqlConnect = new SqlConnection(connectionString);
                dataTable = new DataTable();
                bindingSource = new BindingSource();

            }

            public bool DisplayList()
            {
                string ViewClubMembers =
                    "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers";

                sqlAdapter = new SqlDataAdapter(ViewClubMembers, sqlConnect);

                dataTable.Clear();
                sqlAdapter.Fill(dataTable);
                bindingSource.DataSource = dataTable;

                return true;
            }


            public bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName,
                string LastName, int Age, string Gender, string Program)
            {
                sqlCommand = new SqlCommand(
                    "INSERT INTO ClubMembers VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)",
                    sqlConnect);

                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;
                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
                sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
                sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
                sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
                sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

                sqlConnect.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
                return true;
            }


            public bool UpdateMember(long StudentID, string FirstName, string MiddleName,
                string LastName, int Age, string Gender, string Program)
            {
                sqlCommand = new SqlCommand(
                    "UPDATE ClubMembers SET FirstName=@FirstName, MiddleName=@MiddleName, " +
                    "LastName=@LastName, Age=@Age, Gender=@Gender, Program=@Program WHERE StudentID=@StudentID",
                    sqlConnect);

                sqlCommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID;
                sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
                sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
                sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
                sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
                sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

                sqlConnect.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                return true;
            }
        }
    

    private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
