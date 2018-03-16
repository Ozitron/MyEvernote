using MyEvernote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    //using singleton pattern
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lockSync = new object();

        // ctor is protected so cant do new
        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (context == null)
            {
                lock (_lockSync) // to prevent thread errors
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }
        }
    }
}
