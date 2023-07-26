namespace Entity.Common
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Store> Stores { get; set; }

    }
}
