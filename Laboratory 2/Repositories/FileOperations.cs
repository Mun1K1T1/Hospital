using Laboratory_2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2.Repositories
{
    internal class FileOperations
    {
        public const string directPath = @"C:\\DataBase";
        public const string docSubPath = @"C:\\DataBase\DocData\";
        public const string nurseSubPath = @"C:\\DataBase\NurseData\";
        public const string patientSubPath = @"C:\\DataBase\PatientData\";
        public const string treatSubPath = @"C:\\DataBase\TreatmentData\";
        public const string tempSubPath = @"C:\\DataBase\TempData\";
        //-----------------------------------------------------------------------------------------------------------------------------------

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

        public async Task PatTempFileCreation(string firstName, string secondName)
        {
            try
            {
                var user = new Patient(tempSubPath, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
                //File.WriteAllText(tempPath, jsonObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        public async Task DocTempFileCreation(string firstName, string secondName)
        {
            try
            {
                var user = new Doctor(tempSubPath, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
                //File.WriteAllText(tempPath, jsonObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        public async Task NurTempFileCreation(string firstName, string secondName)
        {
            try
            {
                var user = new Nurse(tempSubPath, firstName, secondName);
                string jsonObj = JsonConvert.SerializeObject(user);
                string tempPath = Path.Combine(tempSubPath, $"{firstName} {secondName}.json");
                using (var file = new StreamWriter(tempPath))
                {
                    await file.WriteAsync(jsonObj);
                }
                //File.WriteAllText(tempPath, jsonObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in creating a tempfile - " + ex);
            }
        }

        public async Task<string> ReadTempJson()
        {
            try
            {
                string[] tempFiles = Directory.GetFiles(tempSubPath);
                string tempfilePath = tempFiles[0];
                //string tempFileContent = File.ReadAllText(tempfilePath);
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

        public async Task ClearTempDir()
        {
            try
            {
                var tempDir = new DirectoryInfo(tempSubPath);
                //foreach (FileInfo file in tempDir.GetFiles())
                //{
                //    file.Delete();
                //}
                var deleteTasks = tempDir.GetFiles().Select(file => Task.Run(() => file.Delete())).ToArray();
                await Task.WhenAll(deleteTasks);

                MessageBox.Show("Temp is cleared!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred - " + ex);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------

        //public void PatientRegistrationFileCreation(string subpath, string id, string firstName, string secondName)
        //{
        //    try
        //    {
        //        var user = new Patient(id, firstName, secondName);
        //        string jsonObj = JsonConvert.SerializeObject(user);
        //        File.WriteAllText(Path.Combine(subpath, $"{firstName} {secondName}.json"), jsonObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Didn't secceed in filling a file - " + ex);
        //    }
        //}

        //public void DoctorRegistrationFileCreation(string subpath, string id, string firstName, string secondName)
        //{
        //    try
        //    {
        //        var user = new Doctor(id, firstName, secondName);
        //        string jsonObj = JsonConvert.SerializeObject(user);
        //        File.WriteAllText(Path.Combine(subpath, $"{firstName} {secondName}.json"), jsonObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Didn't secceed in filling a file - " + ex);
        //    }
        //}

        //public void NurseRegistrationFileCreation(string subpath, string id, string firstName, string secondName)
        //{
        //    try
        //    {
        //        var user = new Nurse(id, firstName, secondName);
        //        string jsonObj = JsonConvert.SerializeObject(user);
        //        File.WriteAllText(Path.Combine(subpath, $"{firstName} {secondName}.json"), jsonObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Didn't secceed in filling a file - " + ex);
        //    }
        //}
        //-----------------------------------------------------------------------------------------------------------------------------------
        public async Task<string> ReadJsonFromFile(string subpath, string firstName, string secondName)
        {
            string generalPath = subpath + firstName + " " + secondName + ".json";
            try
            {
                return await Task.Run(() => File.ReadAllText(generalPath));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read JSON file: " + ex);
                return null;
            }
        }
        public string GetUserId(string jsonContent)
        {
            try
            {
                dynamic jsonObj = JObject.Parse(jsonContent);
                return jsonObj.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get id from JSON: " + ex);
                return null;
            }
        }
        public async Task<string[]> GetUserTreatmentContent(string jsonContent)
        {
            try
            {
                dynamic jsonObj = JObject.Parse(jsonContent);
                JArray treatmentContentArray = await jsonObj.TreatmentContent;
                return treatmentContentArray.ToObject<string[]>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get id from JSON: " + ex);
                return null;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        public bool IdInput(int idToCheck, int userId)
        {
            bool access;
            if (idToCheck == userId)
            {
                access = true;
                MessageBox.Show("You successfully signed in!");
            }
            else
            {
                access = false;
                MessageBox.Show("Wrong id input");
            }

            return access;
        }

        public bool mainFuncBoolean;
        public async Task CheckFileForExsistence(string subpath, string id, string firstName, string secondName)
        {
            int ID = Convert.ToInt32(id);
            string generalPath = subpath + firstName + " " + secondName + ".json";
            string jsonContent = await ReadJsonFromFile(subpath, firstName, secondName);
            try
            {
                if (!File.Exists(generalPath))
                {
                    MessageBox.Show("You need to sign up at first!");
                    mainFuncBoolean = false;
                }

                int jsonId = Convert.ToInt32(GetUserId(jsonContent));

                bool idCheck = IdInput(jsonId, ID);
                if (idCheck == true)
                {

                    mainFuncBoolean = true;
                }
                if (idCheck == false)
                {

                    mainFuncBoolean = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't succeed - " + ex);
                mainFuncBoolean = false;
            }
        }

        public bool CheckIfGetToGo()
        {
            bool toGo = mainFuncBoolean;
            if (toGo == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public string[] FindPatientsFiles(string patAdress)
        {
            string[] patients = Directory.GetFiles(patAdress);
            return patients;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        string[] patientsNames;
        public string[] GetPatientsNames(string[] patientsPath)
        {
            patientsNames = patientsPath;
            for (int i = 0; i < patientsPath.Length; i++)
            {
                patientsPath[i] = Path.GetFileNameWithoutExtension(patientsPath[i]);
                patientsNames[i] = patientsPath[i];
            }

            return patientsNames;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        public void TreatmentFileCreation(string subpath, string patientFirstName, string patientSecondName, string[] textboxContent)
        {
            try
            {
                var treatment = new Treatment(patientFirstName, patientSecondName, textboxContent);
                string jsonObj = JsonConvert.SerializeObject(treatment);
                File.WriteAllText(Path.Combine(subpath, $"{patientFirstName} {patientSecondName}.json"), jsonObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't secceed in filling a file - " + ex);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        public async Task<string[]> FillTheTreatment(string subpath, string firstName, string secondName)
        {
            string jsonContent = await ReadJsonFromFile(subpath, firstName, secondName);
            return await GetUserTreatmentContent(jsonContent);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void DischargePatient(string patientSubPath, string treatmentSubPath, string firstName, string secondName)
        {
            string patientPath = patientSubPath + firstName + " " + secondName + ".json";
            string treatmentPath = treatmentSubPath + firstName + " " + secondName + ".json";

            if (File.Exists(patientPath))
            {
                File.Delete(patientPath);
                File.Delete(treatmentPath);
                MessageBox.Show("Patient has been successfully discharged!");
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public void PerformTreatment(string patientSubPath, string treatmentSubPath, string firstName, string secondName)
        {
            string patientFilePath = (patientSubPath + firstName + " " + secondName + ".json");
            File.Delete(patientFilePath);
            string theatmentFilePath = (treatmentSubPath + firstName + " " + secondName + ".json");
            File.Delete(theatmentFilePath);
            MessageBox.Show("Treatment has been successfully performed and pathient has been discharged!");
        }
    }
}
