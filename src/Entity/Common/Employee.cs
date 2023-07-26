namespace Entity.Common
{
    public class Employee
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int OrderId { get; set; }
        public List<Order> Order { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string BirthDate { get; set; }
        public string Position { get; set; }
    }
}
