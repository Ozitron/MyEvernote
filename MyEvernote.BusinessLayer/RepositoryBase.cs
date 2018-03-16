﻿using MyEvernote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    //using singleton pattern
    public class RepositoryBase
    {
        protected static DatabaseContext db;
        private static object _lockSync = new object();

        // ctor is protected so cant do new
        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (db == null)
            {
                lock (_lockSync) // to prevent thread errors
                {
                    if (db == null)
                    {
                        db = new DatabaseContext();
                    }
                }
            }
        }

    }
}