using Entity.Common;

namespace Application.Entities
{
    public class RandomEmployeeData
    {
        private readonly List<string> _firstName;
        private readonly List<string> _lastName;

        private readonly List<string> _title;
        private readonly List<string> _position;

        private readonly List<DateTime> _birthDay;

        private readonly Random _random;
        public RandomEmployeeData()
        {
            _random = new Random();
            _firstName = new List<string>() { "Alice", "Bob", "Charlie", "Dave" };
            _lastName = new List<string>() { "Smith", "Johnson", "Williams", "Brown" };
            _title = new List<string>() { "Mr.", "Mis." };
            _position = new List<string>() { "SEO", "Sales", "Marketing", "Operations", "Finance" };
            _birthDay = new List<DateTime>()
            {
                new DateTime(1994,10,22),
                new DateTime(2004,3,4),
                new DateTime(2022,12,11),
                new DateTime(1995,11,15),
                new DateTime(1979,6,16),
                new DateTime(1964,5,8),
                new DateTime(1999,1,20),
            };
        }

        public Employee GetRandomEmployee()
        {
            var Employe = new Employee()
            {
                BirthDate = _birthDay[_random.Next(_birthDay.Count)].ToString("MM/dd/yyyy"),
                FirstName = _firstName[_random.Next(_firstName.Count)],
                LastName = _lastName[_random.Next(_lastName.Count)],
                Position = _position[_random.Next(_position.Count)],
                Title = _title[_random.Next(_title.Count)],
            };
            return Employe;
        }



    }

}
