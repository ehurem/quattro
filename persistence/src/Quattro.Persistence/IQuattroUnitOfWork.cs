using Quattro.Domain.Entities;
using Quattro.Persistence.Abstractions;

namespace Quattro.Persistence
{
    public interface IQuattroUnitOfWork : IUnitOfWork
    {
        IDataRepository<Employee> EmployeeRepository { get; }
        IDataRepository<Role> RoleRepository { get; }
        IDataRepository<Scope> ScopeRepository { get; }
        IDataRepository<Status> StatusRepository { get; }
        IDataRepository<TimeClock> TimeClockRepository { get; }
        IDataRepository<User> UserRepository { get; }
    }
}
