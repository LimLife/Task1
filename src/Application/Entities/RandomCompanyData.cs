using Entity.Common;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace Application.Entities
{
    public class RandomCompanyData
    {
        private readonly StateCapital _state;

        private readonly List<string> _companyName;
        private readonly List<string> _phoneNumbers;
        private readonly List<string> _address;
        private readonly Random _random;
        public RandomCompanyData()
        {
            _random = new Random();
            _state = new StateCapital();

            _companyName = new List<string>()
            {
                "Cyber Inc", "Globex Corp", "Ambrella Corp", "Sticks and Branch","Tirex","Mr. Proper","The Beast Market","Little Market"
            };
            _phoneNumbers = new List<string>()
            {
                "(902) 680-9463", "(907) 966-3820", "(693) 707-7731", "(962) 567-0956", "(756) 763-5743", "(488) 743-6504", "(901) 388-2383"
            };
            _address = new List<string>()
            {
                "502 Fulton St.Petersburg VA 23803",
                "4 Eagle Lane Maumee, OH 43537",
                "24 Carson Ave.Lutherville Timonium, MD 21093",
                "68 Beech Drive Dorchester Center, MA 02124",
                "9542 White Ave.Dorchester, MA 02125",
                "413 South Cypress Dr.Sylvania, OH 43560"
            };

        }

        public Company GetRandomCompany()
        {
            var (state, city) = _state.GetRandomCitySate();
            var company = new Company()
            {
                CompanyName = _companyName[_random.Next(_companyName.Count)],
                Phone = _phoneNumbers[_random.Next(_phoneNumbers.Count)],
                Address = _address[_random.Next(_address.Count)],
                City = city,
                State = state,
            };
            return company;
        }
    }
}
