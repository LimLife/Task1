using Entity.Common;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly DBData _context;
        public Repository(DBData context)
        {
            _context = context;
        }
        public async Task AddCompany(List<Company> companies)
        {
            await _context.Companies.AddRangeAsync(companies);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Employee>?> GetAllEmployeeCompany(int idCompany)
        {
            var result = await (from company in _context.Companies.AsNoTracking()
                                where company.Id == idCompany
                                from store in company.Stores
                                from employee in store.Employees
                                select employee).ToListAsync();
            return result;
        }
        public async Task<Employee?> GetEmployeeById(int idEmployee)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(id => id.Id == idEmployee);
        }
        public async Task<List<Company>?> GetAllCompanies()
        {
            return await _context.Companies.AsNoTracking().ToListAsync();
        }
        public async Task<Company?> GetCompany(int idCompany)
        {
            return await _context.Companies.AsNoTracking().FirstOrDefaultAsync(company => company.Id == idCompany);
        }
        public async Task<List<StoreOrder>?> StoreOrder(int idCompany)
        {
            var result = await (from company in _context.Companies.AsNoTracking()
                                where company.Id == idCompany
                                from store in company.Stores
                                from order in store.Orders
                                select new StoreOrder
                                {
                                    City =store.City,
                                    OrderDate = store.Orders.Select(time=>time.OrderDate).ToArray(),
                                }).ToListAsync();
            return result = result.Select((storeOrder, index) => { storeOrder.Id = index; return storeOrder; }).ToList();       
        }
        public async Task<List<OrderEmployee>?> OrderEmployee(int idCompany)
        {
            var result = await (from company in _context.Companies.AsNoTracking()
                                where company.Id == idCompany
                                from store in company.Stores
                                from employee in store.Employees
                                select new OrderEmployee
                                {
                                    FullName = employee.FirstName + " " + employee.LastName,
                                    Invoice = employee.Order.Select(o => o.InvoiceNumber).ToArray()
                                }).ToListAsync();
           return result.Select((orderemployee, index) => {orderemployee.Id = index; return orderemployee;}).ToList();
        }
        public async Task<bool> IsEmptyDataBase()
        {
            return await _context.Companies.AsNoTracking().AnyAsync();
        }
    }
};


