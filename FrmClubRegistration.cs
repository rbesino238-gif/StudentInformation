using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentInformation;
using System;
using System.Windows.Forms;

namespace StudentInformation
{




    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;

        private int ID = 0, Age, count = 0;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }

        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        private int RegistrationID()
        {
            count++;
            return count;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Get inputs from form textboxes
            ID = RegistrationID();
            StudentId = long.Parse(txtStudentID.Text);
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;
            Age = int.Parse(txtAge.Text);
            Gender = cbGender.Text;
            Program = cbProgram.Text;

            // Call Register Function
            clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);

            MessageBox.Show("Record Saved!");

            RefreshListOfClubMembers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            FrmUpdateMember frm = new FrmUpdateMember();
            frm.ShowDialog();
            RefreshListOfClubMembers();
        }
    }
}

