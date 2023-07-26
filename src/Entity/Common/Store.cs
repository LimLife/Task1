namespace Entity.Common
{
    public class Store
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public string City { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Order> Orders { get; set; }

    }
}
