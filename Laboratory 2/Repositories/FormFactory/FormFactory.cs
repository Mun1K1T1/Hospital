using Laboratory_2.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_2.Repositories.FormFactory
{
    internal class FormFactory
    {
        public static IForm CreateForm(string formType)
        {
            switch (formType)
            {
                case "MainPage":
                    return new MainPage();
                case "AuthDoctor":
                    return new AuthorizationDoctor();
                case "AuthNurse":
                    return new AuthorizationNurse();
                case "AuthPatient":
                    return new AuthorizationPatient();
                case "AuthCleanWorker":
                    return new AuthorizationCleaningWorker();
                case "AuthCleanManager":
                    return new AuthorizationCleaningManager();
                case "Doctor":
                    return new DoctorForm();
                case "Nurse":
                    return new NurseForm();
                case "Patient":
                    return new PatientForm();
                case "CleaningWorker":
                    return new CleaningWorkerForm();
                case "CleaningManager":
                    return new CleaningManagerForm();
                default:
                    throw new ArgumentException("Unknown form type");
            }
        }
    }
}
