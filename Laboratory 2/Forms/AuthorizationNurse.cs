using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationNurse : MaterialForm, IForm
    {
        public const string nurseSubPath = @"C:\\DataBase\NurseData\";

        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();

        public void ShowForm()
        {
            this.Show();
        }

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

        private void AuthorizationNurse_Load(object sender, EventArgs e)
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
                        await fileOperations.NeedToCloseToOpenNurse(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Nurse");
                        form.ShowForm();
                        this.Close();
                    }
                    else return;
                }
                else
                {
                    await dataHelper.OnPlaceNurseCreation(context, newNurse, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Nurse");
                    form.ShowForm();
                    this.Close();
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
                var newNurse = new ENurse(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExNurse = Repository<ENurse>
                    .GetRepo(context)
                    .GetFirst(nurse => nurse.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExNurse != null) && (preExNurse.FirstName == FirstNameTxtBox.Text) && (preExNurse.SecondName == SecondNameTxtBox.Text)
                    && (preExNurse.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExNurse.SecondName + " " + preExNurse.FirstName + " managed to sing in!");
                    await fileOperations.NeedToCloseToOpenNurse(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Nurse");
                    form.ShowForm();
                    this.Close();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await dataHelper.OnPlaceNurseCreation(context, newNurse, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Nurse");
                        form.ShowForm();
                        this.Close();
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
