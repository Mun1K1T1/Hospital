using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationDoctor : MaterialForm
    {
        public const string docSubPath = @"C:\\DataBase\DocData\";

        readonly FileOperations fileOperations = new FileOperations();

        public async Task CloseAndOpen()
        {
            await fileOperations.DocTempFileCreation(FirstNameTxtBox.Text, SecondNameTxtBox.Text);
            Close();
            var doctorForm = new DoctorForm();
            doctorForm.ShowDialog();
        }

        public async Task OnPlaceDoctorCreation(DBApplicationContext dBApplicationContext, EDoctor newEDoctor)
        {
            try
            {
                Repository<EDoctor>
                    .GetRepo(dBApplicationContext)
                    .Create(newEDoctor);
                MessageBox.Show("Success!");

                await CloseAndOpen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.ToString());
                return;
            }
        }

        public AuthorizationDoctor()
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

        private void DoctorAuthorization_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
                Hide();
                MainPage.form1Main.Show();
        }

        private async void SignBtn_Click(object sender, EventArgs e)
        {
            //    JSON PART
            //fileOperations.DoctorRegistrationFileCreation(docSubPath, IdTxtBox.Text, FirstNameTxtBox.Text, SecondNameTxtBox.Text);
            try
            {
                var context = new DBApplicationContext();
                var newDoctor = new EDoctor(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExDoctor = Repository<EDoctor>
                    .GetRepo(context)
                    .GetFirst(doctor => doctor.Id == newDoctor.Id);
                if (preExDoctor != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such doctor already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExDoctor = Repository<EDoctor>
                            .GetRepo(context)
                            .GetFirst(doctor => doctor.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExDoctor.SecondName + " " + newPreExDoctor.FirstName + " managed to sing in!");
                        await CloseAndOpen();
                    }
                    else return;
                }
                else
                {
                    await OnPlaceDoctorCreation(context, newDoctor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }

        private async void LogBtn_Click(object sender, EventArgs e)
        {
            //fileOperations.CheckFileForExsistence(docSubPath, IdTxtBox.Text, FirstNameTxtBox.Text, SecondNameTxtBox.Text);
            //if (fileOperations.CheckIfGetToGo() == true)
            //{
            //    
            //}
            try
            {
                var context = new DBApplicationContext();
                var newDoctor = new EDoctor(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExDoctor = Repository<EDoctor>
                    .GetRepo(context)
                    .GetFirst(doctor => doctor.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExDoctor != null) && (preExDoctor.FirstName == FirstNameTxtBox.Text) && (preExDoctor.SecondName == SecondNameTxtBox.Text)
                    && (preExDoctor.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExDoctor.SecondName + " " + preExDoctor.FirstName + " managed to sing in!");
                    await CloseAndOpen();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await OnPlaceDoctorCreation(context, newDoctor);
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
