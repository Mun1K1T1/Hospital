using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class CleaningManagerForm : MaterialForm, IForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();

        public void ShowForm()
        {
            this.Show();
        }

        public CleaningManagerForm()
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

        private async void CleaningManagerForm_Load(object sender, EventArgs e)
        {
            try
            {
                CleaningManagerNameTbx.Text = await fileOperations.ReadTempJson();
                dataHelper.AddCleaningManagerKeyToTheForm(CleaningManagerNameTbx, CleaningManager_Key);
                fileOperations.ClearTempDir();
                dataHelper.AddItemsCleaningWorkersListview(WorkersListBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }
    }
}
