using Laboratory_2.Models;
using Laboratory_2.Repositories.FormFactory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2.Repositories
{
    internal class FileOperations : IForm
    {
        public const string directPath = @"C:\\DataBase";
        public const string docSubPath = @"C:\\DataBase\DocData\";
        public const string nurseSubPath = @"C:\\DataBase\NurseData\";
        public const string patientSubPath = @"C:\\DataBase\PatientData\";
        public const string cleaningWorkerSubPath = @"C:\\DataBase\CleaningWorkerData\";
        public const string cleaningManagerSubPath = @"C:\\DataBase\CleaningManagerData\";
        public const string treatSubPath = @"C:\\DataBase\TreatmentData\";
        public const string tempSubPath = @"C:\\DataBase\TempData\";
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void ShowForm()
        {

        }

        public async Task DataBaseCreation()
        {
            await Task.Run(() =>
            {
                var database = new DirectoryInfo(directPath);
                if (!database.Exists)
                {
                    database.Create();
                }
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public async Task DatabaseSubfolders()
        {
            await Task.Run(() =>
            {
                var docdata = new DirectoryInfo(docSubPath);
                if (!docdata.Exists) docdata.Create();
            });

            await Task.Run(() =>
            {
                var nursedata = new DirectoryInfo(nurseSubPath);
                if (!nursedata.Exists) nursedata.Create();
            });

            await Task.Run(() =>
            {
                var patientdata = new DirectoryInfo(patientSubPath);
                if (!patientdata.Exists) patientdata.Create();
            });

            await Task.Run(() =>
            {
                var cleaningWorkerdata = new DirectoryInfo(cleaningWorkerSubPath);
                if (!cleaningWorkerdata.Exists) cleaningWorkerdata.Create();
            });

            await Task.Run(() =>
            {
                var cleaningManagerdata = new DirectoryInfo(cleaningManagerSubPath);
                if (!cleaningManagerdata.Exists) cleaningManagerdata.Create();
            });

            await Task.Run(() =>
            {
                var treatmentdata = new DirectoryInfo(treatSubPath);
                if (!treatmentdata.Exists) treatmentdata.Create();
            });

            await Task.Run(() =>
            {
                var tempData = new DirectoryInfo(tempSubPath);
                if (!tempData.Exists) tempData.Create();
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public async Task DocTempFileCreation(string id, string firstName, string secondName)
        {
            try
            {
                var user = new Doctor(id, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        public async Task NurTempFileCreation(string id, string firstName, string secondName)
        {
            try
            {
                var user = new Nurse(id, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        public async Task PatTempFileCreation(string id, string firstName, string secondName)
        {
            try
            {
                var user = new Patient(id, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        public async Task CleaningWorkerTempFileCreation(string id, string firstName, string secondName)
        {
            try
            {
                var user = new Person(id, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        public async Task CleaningManagerTempFileCreation(string id, string firstName, string secondName)
        {
            try
            {
                var user = new Person(id, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public async Task NeedToCloseToOpenPatient(TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            await PatTempFileCreation(Id.Text, FirstName.Text, SecondName.Text);
        }

        public async Task NeedToCloseToOpenDoctor(TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            await DocTempFileCreation(Id.Text, FirstName.Text, SecondName.Text);
        }

        public async Task NeedToCloseToOpenNurse(TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            await NurTempFileCreation(Id.Text, FirstName.Text, SecondName.Text);
        }

        public async Task NeedToCloseToOpenCleaningWorker(TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            await CleaningWorkerTempFileCreation(Id.Text, FirstName.Text, SecondName.Text);
        }

        public async Task NeedToCloseToOpenCleaningManager(TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            await CleaningManagerTempFileCreation(Id.Text, FirstName.Text, SecondName.Text);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public async Task<string> ReadTempJson()
        {
            try
            {
                string[] tempFiles = Directory.GetFiles(tempSubPath);
                string tempfilePath = tempFiles[0];
                using (var file = new StreamReader(tempfilePath))
                {
                    string tempFileContent = await file.ReadToEndAsync();
                    dynamic jsonObj = JObject.Parse(tempFileContent);
                    return jsonObj.FirstName + " " + jsonObj.SecondName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't read tempfile - " + ex);
                return null;
            }
        }

        public string ReadTempJsonId()
        {
            try
            {
                string[] tempFiles = Directory.GetFiles(tempSubPath);
                string tempfilePath = tempFiles[0];
                var file = new StreamReader(tempfilePath);
                string tempFileContent = file.ReadToEnd();
                file.Close();
                dynamic jsonObj = JObject.Parse(tempFileContent);
                return jsonObj.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't read tempfile - " + ex);
                return null;
            }
        }

        public void ClearTempDir()
        {
            try
            {
                var tempDir = new DirectoryInfo(tempSubPath);
                var gottenFiles = tempDir.GetFiles();
                foreach (var file in gottenFiles)
                {
                    file.Delete();
                    MessageBox.Show("Temp is cleared!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred - " + ex);
            }
        }
    }
}
