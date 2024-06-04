namespace Laboratory_2.Data.Models.Data
{
    public class EPerson : EEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }


        protected EPerson(int id, string firstName, string secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
        }
    }
}
