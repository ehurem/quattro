using Microsoft.EntityFrameworkCore;
using Quattro.Persistence.Abstractions;

namespace Quattro.Persistence.EF
{
    public class QuattroUnitOfWork : UnitOfWork, IQuattroUnitOfWork
    {
        public QuattroUnitOfWork(DbContext context) : base(context)
        {
        }
    }
}
