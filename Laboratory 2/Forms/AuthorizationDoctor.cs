using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationDoctor : MaterialForm, IForm
    {
        public const string docSubPath = @"C:\\DataBase\DocData\";

        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();

        public void ShowForm()
        {
            this.Show();
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
                        await fileOperations.NeedToCloseToOpenDoctor(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Doctor");
                        form.ShowForm();
                        this.Close();
                    }
                    else return;
                }
                else
                {
                    await dataHelper.OnPlaceDoctorCreation(context, newDoctor, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Doctor");
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
                var newDoctor = new EDoctor(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExDoctor = Repository<EDoctor>
                    .GetRepo(context)
                    .GetFirst(doctor => doctor.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExDoctor != null) && (preExDoctor.FirstName == FirstNameTxtBox.Text) && (preExDoctor.SecondName == SecondNameTxtBox.Text)
                    && (preExDoctor.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExDoctor.SecondName + " " + preExDoctor.FirstName + " managed to sing in!");
                    await fileOperations.NeedToCloseToOpenDoctor(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Doctor");
                    form.ShowForm();
                    this.Close();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await dataHelper.OnPlaceDoctorCreation(context, newDoctor, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Doctor");
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
