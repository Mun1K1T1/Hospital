using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratory_2.Data.Models.Data
{
    public class ECleaningServiceManager : EPerson
    {
        public ECleaningServiceManager(int id, string firstName, string secondName) : base(id, firstName, secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
        }
    }
}
