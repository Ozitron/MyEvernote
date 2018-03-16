using MyEvernote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    //using singleton pattern
    class RepositoryBase
    {
        private static DatabaseContext _db;
        private static object _lockSync = new object();

        // ctor is protected so cant do new
        protected RepositoryBase()
        {

        }

        public static DatabaseContext CreateContext()
        {
            if (_db == null)
            {
                lock (_lockSync) // to prevent thread errors
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContext();
                    }
                }
            }

            return _db;
        }
    }
}
