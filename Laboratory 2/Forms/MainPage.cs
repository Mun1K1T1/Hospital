using Laboratory_2.Forms;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace Laboratory_2
{
    public partial class MainPage : MaterialForm, IForm
    {
        private readonly IFileOperations _fileOperations;

        //------------------------------------------------------------------------------------------

        public void ShowForm()
        {
            this.Show();
        }

        public MainPage(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));

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

        public MainPage()
        {
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await _fileOperations.DataBaseCreation();
            await _fileOperations.DataBaseSubFolders();
        }

        private void PatientBtn_Click(object sender, EventArgs e)
        {
            IForm form = FormFactory.CreateForm("AuthPatient");
            form.ShowForm();
        }

        private void DoctorBtn_Click(object sender, EventArgs e)
        {
            IForm form = FormFactory.CreateForm("AuthDoctor");
            form.ShowForm();
        }

        private void NurseBtn_Click(object sender, EventArgs e)
        {
            IForm form = FormFactory.CreateForm("AuthNurse");
            form.ShowForm();
        }

        private void CleaningWorkerBtn_Click(object sender, EventArgs e)
        {
            IForm form = FormFactory.CreateForm("AuthCleanWorker");
            form.ShowForm();
        }

        private void CleaningManagerBtn_Click(object sender, EventArgs e)
        {
            IForm form = FormFactory.CreateForm("AuthCleanManager");
            form.ShowForm();
        }
    }
}
