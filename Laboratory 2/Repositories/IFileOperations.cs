using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2.Repositories
{
    public interface IFileOperations
    {
        Task NeedToCloseToOpenPatient(TextBox Id, TextBox FirstName, TextBox SecondName, Form This);
        // Define other methods as per original `FileOperations`
        Task NeedToCloseToOpenDoctor(TextBox Id, TextBox FirstName, TextBox SecondName, Form This);
        Task NeedToCloseToOpenNurse(TextBox Id, TextBox FirstName, TextBox SecondName, Form This);
        Task NeedToCloseToOpenCleaningWorker(TextBox Id, TextBox FirstName, TextBox SecondName, Form This);
        Task NeedToCloseToOpenCleaningManager(TextBox Id, TextBox FirstName, TextBox SecondName, Form This);
        Task ReadTempJsonId();
        Task <string> ReadTempJson();
        Task DataBaseCreation();
        Task DataBaseSubFolders();
        Task ClearTempDir();
    }
}
