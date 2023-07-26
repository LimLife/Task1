using Entity.Common;

namespace Application.Interfaces
{
    public interface IRepository
    {
        public Task<List<Company>?> GetAllCompanies();
        public Task<Company?> GetCompany(int idCompany);
        public Task<List<StoreOrder>?> StoreOrder(int idCompany);
        public Task<List<Employee>?> GetAllEmployeeCompany(int idComapny);
        public Task<List<OrderEmployee>?> OrderEmployee(int idCompany);
        public Task AddCompany(List<Company> companies);
        public Task<Employee?> GetEmployeeById(int idEmployee);
        public Task<bool> IsEmptyDataBase();
    }
}
