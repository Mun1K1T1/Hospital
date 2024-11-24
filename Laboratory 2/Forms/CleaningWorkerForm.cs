using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class CleaningWorkerForm : MaterialForm, IForm
    {
        private readonly IFileOperations _fileOperations;
        private readonly DataHelper _dataHelper;
        private readonly DBApplicationContext _dbContext;

        public void ShowForm()
        {
            Show();
        }

        public CleaningWorkerForm(IFileOperations fileOperations, DataHelper dataHelper, DBApplicationContext dbContext)
        {
            _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));
            _dataHelper = dataHelper ?? throw new ArgumentNullException(nameof(dataHelper));

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
                var query = from task in _dbContext.CleaningServiceTasks
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
                CleaningWorkerNameTbx.Text = await _fileOperations.ReadTempJson();
                _dataHelper.AddCleaningWorkerKeyToTheForm(CleaningWorkerNameTbx, Worker_Key);
                await _fileOperations.ClearTempDir();
                AddItemsCleaningTasksListview(CleaningTaskslistBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }
    }
}
