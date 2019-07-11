using Microsoft.EntityFrameworkCore;
using Quattro.Domain.Entities;
using Quattro.Persistence.Abstractions;

namespace Quattro.Persistence.EF
{
    public class QuattroUnitOfWork : UnitOfWork, IQuattroUnitOfWork
    {
        private IDataRepository<Employee> _employeeRepository;
        private IDataRepository<Role> _roleRepository;
        private IDataRepository<Scope> _scopeRepository;
        private IDataRepository<Status> _statusRepository;
        private IDataRepository<TimeClock> _timeClockRepository;
        private IDataRepository<User> _userRepository;

        public QuattroUnitOfWork(DbContext context) : base(context)
        {
        }

        public IDataRepository<Employee> EmployeeRepository => _employeeRepository ?? (_employeeRepository = new DataRepository<Employee>(Context));

        public IDataRepository<Role> RoleRepository => _roleRepository ?? (_roleRepository = new DataRepository<Role>(Context));

        public IDataRepository<Scope> ScopeRepository => _scopeRepository ?? (_scopeRepository = new DataRepository<Scope>(Context));

        public IDataRepository<Status> StatusRepository => _statusRepository ?? (_statusRepository = new DataRepository<Status>(Context));

        public IDataRepository<TimeClock> TimeClockRepository => _timeClockRepository ?? (_timeClockRepository = new DataRepository<TimeClock>(Context));

        public IDataRepository<User> UserRepository => _userRepository ?? (_userRepository = new DataRepository<User>(Context));
    }
}
