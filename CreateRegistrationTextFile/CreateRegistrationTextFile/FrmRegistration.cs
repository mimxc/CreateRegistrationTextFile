using System.Collections;

namespace CreateRegistrationTextFile
{
    public partial class FrmRegistration : Form
    {

        private string StudentNo;
        
        private string Fullname;
        private string Program;
        private string Gender;
        private string Age;
        private string Birthday;
        private string ContactNo;
        public FrmRegistration()
        {
            InitializeComponent();
        }

        public void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{ "BS Information Technology",
                "BS Computer Science", "BS Information Systems", "BS in Accountancy",
                "BS in Hospitality Management", "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                comboProgram.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new string[] { "Male", "Female", "Prefer not to say" };

            for (int j  = 0; j < 3; j++)
            {
                comboGender.Items.Add(ListOfGender[j].ToString());
            }

        }

        public void btnRegister_Click(object sender, EventArgs e)
        {

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName;

            StudentNo = "Student No.: " + txtStudentNo.Text.ToString();
            Fullname = "Full Name: " + txtLastName.Text + ", " + txtFirstName.Text + ", " + txtMiddleInitial.Text;
            Program = "Program: " + comboProgram.Text;
            Gender = "Gender: " + comboGender.Text;
            Age = "Age: " + txtAge.Text.ToString();
            Birthday = "Birthday: " + dateBirthday.Value.ToString("yyyy-MM-dd");
            ContactNo = "Contact No.: " + txtContactNo.Text.ToString();
            fileName = txtStudentNo.Text.ToString() + ".txt";

            ArrayList ListOfInfo = new ArrayList();

            ListOfInfo.Add(StudentNo);
            ListOfInfo.Add(Fullname);
            ListOfInfo.Add(Program);
            ListOfInfo.Add(Gender);
            ListOfInfo.Add(Age);
            ListOfInfo.Add(Birthday);
            ListOfInfo.Add(ContactNo);

                using (StreamWriter outputfile = new StreamWriter(Path.Combine(docPath, fileName)))
                {
                    foreach (var Info in ListOfInfo) 
                    {
                        outputfile.WriteLine(Info);
                        Console.WriteLine(Info);
                    }
                }


            MessageBox.Show("File Saved!");

        }
    }
}
