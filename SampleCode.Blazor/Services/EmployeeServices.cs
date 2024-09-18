using SampleCode.Blazor.Interfaces;
using SampleCode.Blazor.Model;

namespace SampleCode.Blazor.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>();

        public EmployeeServices()
        {
            // Seed data
            _employees.Add(new Employee { Id = 1, FirstName = "John", LastName = "Doe", Position = "Developer" });
            _employees.Add(new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Position = "Designer" });
        }

        public Task<List<Employee>> GetEmployeesAsync()
        {
            return Task.FromResult(_employees);
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(employee);
        }

        public Task AddEmployeeAsync(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Position = employee.Position;
            }
            return Task.CompletedTask;
        }

        public Task DeleteEmployeeAsync(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return Task.CompletedTask;
        }
    }
}
