using DataLayer.Repository;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        Accounting_DBEntities db = new Accounting_DBEntities();




        private GenericRepository<Customers> _customers;
        public GenericRepository<Customers> Customers
        {
            get
            {
                if(_customers == null)
                {
                    _customers = new GenericRepository<Customers>(db);
                }
                return _customers;
            }
        }

        private GenericRepository<Accounting> _accounting;
        public GenericRepository<Accounting> Accounting
        {
            get
            {
                if(_accounting == null)
                {
                    _accounting=new GenericRepository<Accounting>(db);
                }
                return _accounting;
            }
        }

        private GenericRepository<Login> _login;
        public GenericRepository<Login> Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new GenericRepository<Login>(db);
                }
                return _login;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();

        }
    }
}
