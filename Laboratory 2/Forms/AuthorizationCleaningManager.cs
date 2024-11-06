using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class AuthorizationCleaningManager : MaterialForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();
        public AuthorizationCleaningManager()
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

        private void AuthorizationCleaningManager_Load(object sender, EventArgs e)
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
                var newCleaningManager = new ECleaningServiceManager(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningManager = Repository<ECleaningServiceManager>
                    .GetRepo(context)
                    .GetFirst(CleaningManager => CleaningManager.Id == newCleaningManager.Id);
                if (preExCleaningManager != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such Cleaning Manager already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExCleaningManager = Repository<ECleaningServiceManager>
                            .GetRepo(context)
                            .GetFirst(CleaningManager => CleaningManager.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExCleaningManager.SecondName + " " + preExCleaningManager.FirstName + " managed to sing in!");
                        await fileOperations.CloseAndOpenCleaningManager(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    }
                    else return;
                }
                else
                {
                    await dataHelper.OnPlaceCleaningManagerCreation(context, newCleaningManager, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
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
                var newCleaningManager = new ECleaningServiceManager(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningManager = Repository<ECleaningServiceManager>
                    .GetRepo(context)
                    .GetFirst(person => person.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExCleaningManager != null) && (preExCleaningManager.FirstName == FirstNameTxtBox.Text) && (preExCleaningManager.SecondName == SecondNameTxtBox.Text)
                    && (preExCleaningManager.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExCleaningManager.SecondName + " " + preExCleaningManager.FirstName + " managed to sing in!");
                    await fileOperations.CloseAndOpenCleaningManager(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such Cleaning Manager doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await dataHelper.OnPlaceCleaningManagerCreation(context, newCleaningManager, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
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
