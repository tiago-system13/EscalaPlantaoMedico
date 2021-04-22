using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;

namespace EscalaPlantaoMedico.Data.Contexto
{
    public class ContextAsyncDbConnection : AsyncDbConnection
    {

        private CommonDbContext _context;

        public ContextAsyncDbConnection(CommonDbContext context): base(context.Database.GetDbConnection())
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override IDbTransaction BeginTransaction()
        {
            if (_context.IsDisposed)
            {
                return null;
            }

            _context.Database.BeginTransaction();
            return (_context.Database.CurrentTransaction as IInfrastructure<DbTransaction>).Instance;
        }

        public override IDbTransaction BeginTransaction(IsolationLevel il)
        {
            if (_context.IsDisposed)
            {
                return null;
            }

            _context.Database.BeginTransaction(il);
            return _context.Database.GetDbTransaction();
        }

        public override IDbTransaction Transaction
        {
            get
            {
                if (_context.IsDisposed)
                    return null;

                return _context.Database.GetDbTransaction();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!(_context?.IsDisposed ?? true))
                _context?.Dispose();

            _context = null;
        }


    }
}
