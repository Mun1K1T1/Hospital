using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class CleaningWorkerForm : MaterialForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();
        public CleaningWorkerForm()
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

        //public async Task<string> CleaningTaskTextAcquire()
        //{
        //    string workerFullName = CleaningWorkerNameTbx.Text;
        //    string[] workerNameElements = workerFullName.Split(' ');
        //    string workerFirstName = workerNameElements[0];
        //    string workerSecondName = workerNameElements[1];
        //    using (var context = new DBApplicationContext())
        //    {
        //        var query = from cleaningTask in context.CleaningServiceTasks
        //                    where cleaningTask.AssignedCleaningServiceWorker.ToString() == Patient_Key.Text
        //                    select new { cleaningTask.CleaningTask };
        //        var result = await query.FirstOrDefaultAsync();
        //        return result?.CleaningTask;
        //    }
        //}

        public void AddItemsCleaningTasksListview(ListBox listBox)
        {
            try
            {
                string workerKey = Worker_Key.Text;
                var context = new DBApplicationContext();
                var query = from task in context.CleaningServiceTasks
                            where task.AssignedCleaningServiceWorker == workerKey
                            select task;
                foreach (var task in query)
                {
                    listBox.Items.Add(ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private async void CleaningWorkerForm_Load(object sender, EventArgs e)
        {
            try
            {
                CleaningWorkerNameTbx.Text = await fileOperations.ReadTempJson();
                dataHelper.AddCleaningWorkerKeyToTheForm(CleaningWorkerNameTbx, Worker_Key);
                fileOperations.ClearTempDir();
                AddItemsCleaningTasksListview(CleaningTaskslistBox);
                //string treatmentText = 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }
    }
}
