using Laboratory_2.Forms;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace Laboratory_2
{
    public partial class MainPage : MaterialForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        public static MainPage form1Main = new MainPage();
        
        //------------------------------------------------------------------------------------------

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
        }

        private void DoctorBtn_Click(object sender, EventArgs e)
        {
            var authorizationDoctor = new AuthorizationDoctor();

            authorizationDoctor.Show();
        }

        private void NurseBtn_Click(object sender, EventArgs e)
        {
            var authorizationNurse = new AuthorizationNurse();

            authorizationNurse.Show();

        }

        private void CleaningWorkerBtn_Click(object sender, EventArgs e)
        {
            var authorizationCleanServWorker = new AuthorizationCleaningWorker();

            authorizationCleanServWorker.Show();
        }

        private void CleaningManagerBtn_Click(object sender, EventArgs e)
        {
            var authorizationCleanServManager = new AuthorizationCleaningManager();

            authorizationCleanServManager.Show();
        }
    }
}
