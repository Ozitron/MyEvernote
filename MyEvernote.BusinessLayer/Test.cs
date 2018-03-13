using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class Test
    {
        public Test()
        {
            DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
            db.Database.CreateIfNotExists(); // Creates db if it's not exists
        }
        

    }
}
