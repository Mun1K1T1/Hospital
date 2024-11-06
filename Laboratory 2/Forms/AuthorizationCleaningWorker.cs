using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class AuthorizationCleaningWorker : MaterialForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();
        public AuthorizationCleaningWorker()
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

        private void AuthorizationCleaningWorker_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Hide();
            MainPage.form1Main.Show();
        }

        private async void SignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new DBApplicationContext();
                var newCleaningWorker = new ECleaningServiceWorker(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningWorker = Repository<ECleaningServiceWorker>
                    .GetRepo(context)
                    .GetFirst(CleaningWorker => CleaningWorker.Id == newCleaningWorker.Id);
                if (preExCleaningWorker != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such Cleaning Worker already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExCleaningWorker = Repository<ECleaningServiceWorker>
                            .GetRepo(context)
                            .GetFirst(CleaningWorker => CleaningWorker.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExCleaningWorker.SecondName + " " + preExCleaningWorker.FirstName + " managed to sing in!");
                        await fileOperations.CloseAndOpenCleaningWorker(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    }
                    else return;
                }
                else
                {
                    await dataHelper.OnPlaceCleaningWorkerCreation(context, newCleaningWorker, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }

        private async void LogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new DBApplicationContext();
                var newCleaningWorker = new ECleaningServiceWorker(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningWorker = Repository<ECleaningServiceWorker>
                    .GetRepo(context)
                    .GetFirst(person => person.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExCleaningWorker != null) && (preExCleaningWorker.FirstName == FirstNameTxtBox.Text) && (preExCleaningWorker.SecondName == SecondNameTxtBox.Text)
                    && (preExCleaningWorker.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExCleaningWorker.SecondName + " " + preExCleaningWorker.FirstName + " managed to sing in!");
                    await fileOperations.CloseAndOpenCleaningWorker(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such Cleaning Worker doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await dataHelper.OnPlaceCleaningWorkerCreation(context, newCleaningWorker, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
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
