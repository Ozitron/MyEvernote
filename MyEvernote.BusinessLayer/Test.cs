using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class Test
    {
        // creates fake data, use it just once
        //public Test()
        //{
        //    DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
        //    db.Categories.ToList(); 
        //}
        
        // repository pattern 
        public Test()
        {
            Repository<Category> repo = new Repository<Category>();
            List<Category> categories = repo.List();
        }

    }
}
