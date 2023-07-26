using Application.Entities;
using Application.Interfaces;
using Entity.Common;

namespace Application.Services
{
    public class AddData
    {
        private readonly IRepository _repository;
        private readonly StateCapital _state;
        private readonly RandomCompanyData _companyData;
        private readonly RandomEmployeeData _employeeData;
        private readonly Random _random;


        private readonly int _companies = 10;
        private readonly int _store = 5;
        private readonly int _employees = 1;
        private readonly int _order = 1;
        public AddData(IRepository repository)
        {
            _random = new Random();
            _repository = repository;
            _state = new StateCapital();
            _companyData = new RandomCompanyData();
            _employeeData = new RandomEmployeeData();
        }

        public void AddDataToBD()
        {
            var list = new List<Company>();
            for (int i = 0; i < _companies; i++)
            {
                var company = _companyData.GetRandomCompany();
                company.Stores = new();

                for (int j = 0; j < _store; j++)
                {
                    var store = new Store
                    {
                        City = _state.GetRandomCity(),
                        Employees = new List<Employee>(),
                        Orders = new List<Order>(),
                        Company = company,
                    };


                    List<Order> orders = new();
                    for (int k = 0; k < _order; k++)
                    {
                        var order = new Order
                        {
                            OrderDate = new DateTime(_random.Next(1950, 2023), _random.Next(1, 12), _random.Next(1, 28)),
                            InvoiceNumber = _random.Next(10000, 99999),
                        };
                        orders.Add(order);
                    }
                    List<Employee> employees = new();

                    for (int k = 0; k < _employees; k++)
                    {
                        var employee = _employeeData.GetRandomEmployee();
                        employee.Order = new()
                        {
                            orders[k]
                        };
                        employee.Store = store;
                        employees.Add(employee);
                    }

                    store.Employees.AddRange(employees);
                    store.Orders.AddRange(orders);
                    company.Stores.Add(store);
                }
                list.Add(company);
            }
            _repository.AddCompany(list);
        }
    }
}

