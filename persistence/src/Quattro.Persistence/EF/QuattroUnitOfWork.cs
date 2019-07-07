using Microsoft.EntityFrameworkCore;
using Quattro.Persistence.Abstractions;

namespace Quattro.Persistence.EF
{
    public class QuattroUnitOfWork : UnitOfWork, IQuattroUnitOfWork
    {
        private IDataRepository<Entities.User> _userRepository;

        public IDataRepository<Entities.User> UserRepository => _userRepository ?? (_userRepository = new DataRepository<Entities.User>(Context));
        public QuattroUnitOfWork(DbContext context) : base(context)
        {
        }
    }
}
