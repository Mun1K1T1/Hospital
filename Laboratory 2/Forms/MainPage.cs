using Laboratory_2.Forms;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace Laboratory_2
{
    public partial class MainPage : MaterialForm
    {
        public const string directPath = @"C:\\DataBase";
        public const string patientSubPath = @"C:\\DataBase\PatientData\";
        public const string docSubPath = @"C:\\DataBase\DocData\";
        public const string nurseSubPath = @"C:\\DataBase\NurseData\";
        public const string treatSubPath = @"C:\\DataBase\TreatmentData\";
        public const string tempSubPath = @"C:\\DataBase\TempData\";

        //------------------------------------------------------------------------------------------
        readonly FileOperations fileOperations = new FileOperations();
        //##########################################################################################
        public static MainPage form1Main = new MainPage();
        public MainPage()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
                );
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await fileOperations.DataBaseCreation();
            await fileOperations.DatabaseSubfolders();
        }

        private void PatientBtn_Click(object sender, EventArgs e)
        {
            var authorizationPatient = new AuthorizationPatient();

            authorizationPatient.Show();
            Hide();
        }

        private void DoctorBtn_Click(object sender, EventArgs e)
        {
            var authorizationDoctor = new AuthorizationDoctor();

            authorizationDoctor.Show();
            Hide();

        }

        private void NurseBtn_Click(object sender, EventArgs e)
        {
            var authorizationNurse = new AuthorizationNurse();

            authorizationNurse.Show();
            Hide();

        }
    }
}
