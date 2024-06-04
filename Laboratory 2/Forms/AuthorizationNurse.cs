using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationNurse : MaterialForm
    {

        public const string nurseSubPath = @"C:\\DataBase\NurseData\";

        readonly FileOperations fileOperations = new FileOperations();
        public AuthorizationNurse()
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

        public async Task CloseAndOpen()
        {
            await fileOperations.DocTempFileCreation(FirstNameTxtBox.Text, SecondNameTxtBox.Text);
            Close();
            var nurseForm = new NurseForm();
            nurseForm.ShowDialog();
        }

        public async Task OnPlaceDoctorCreation(DBApplicationContext dBApplicationContext, ENurse newENurse)
        {
            try
            {
                Repository<ENurse>
                    .GetRepo(dBApplicationContext)
                    .Create(newENurse);
                MessageBox.Show("Success!");

                await CloseAndOpen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.ToString());
                return;
            }
        }

        private void AuthorizationNurse_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
                Hide();
                MainPage.form1Main.Show();
        }

        private async void SignBtn_Click(object sender, EventArgs e)
        {                //fileOperations.PatientRegistrationFileCreation(nurseSubPath, IdTxtBox.Text, FirstNameTxtBox.Text, SecondNameTxtBox.Text);

            try
            {
                var context = new DBApplicationContext();
                var newNurse = new ENurse(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExNurse = Repository<ENurse>
                    .GetRepo(context)
                    .GetFirst(nurse => nurse.Id == newNurse.Id);
                if (preExNurse != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such nurse already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExNurse = Repository<ENurse>
                            .GetRepo(context)
                            .GetFirst(doctor => doctor.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExNurse.SecondName + " " + newPreExNurse.FirstName + " managed to sing in!");
                        await CloseAndOpen();
                    }
                    else return;
                }
                else
                {
                    await OnPlaceDoctorCreation(context, newNurse);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }

        private async void LogBtn_Click(object sender, EventArgs e)
        {                //fileOperations.CheckFileForExsistence(nurseSubPath, IdTxtBox.Text, FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                         //if (fileOperations.CheckIfGetToGo() == true)
                         //{
                         //    Hide();
                         //    var nurForm = new NurseForm();
                         //    nurForm.ShowDialog();
                         //}
            try
            {
                var context = new DBApplicationContext();
                var newNurse = new ENurse(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExNurse = Repository<ENurse>
                    .GetRepo(context)
                    .GetFirst(nurse => nurse.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExNurse != null) && (preExNurse.FirstName == FirstNameTxtBox.Text) && (preExNurse.SecondName == SecondNameTxtBox.Text)
                    && (preExNurse.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExNurse.SecondName + " " + preExNurse.FirstName + " managed to sing in!");
                    await CloseAndOpen();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await OnPlaceDoctorCreation(context, newNurse);
                    }
                    else return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }
    }
}
