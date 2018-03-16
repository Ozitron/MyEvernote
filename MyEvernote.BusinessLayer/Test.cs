using MyEvernote.DataAccessLayer.EntityFramework;
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
        Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        Repository<Category> repo_category = new Repository<Category>();
        Repository<Comment> repo_comment = new Repository<Comment>();
        Repository<Note> repo_note = new Repository<Note>();

        // creates fake data, use it just once
        //public Test()
        //{
        //    DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
        //    db.Categories.ToList(); 
        //}

        // repository pattern 
        public Test()
        {
            List<Category> categories = repo_category.List();
            //List<Category> categories_filtered = repo_category.List(x => x.Id > 5);
        }

        //insert test
        public void InsertTest()
        {
            int result = repo_user.Insert(new EvernoteUser()
            {
                Name = "Testy",
                Surname = "Tester",
                Email = "ozankomurcutest@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "testusr",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUserName = "testusr"
            });
        }

        public void UpdateTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "testusr");

            if(user != null)
            {
                user.Username = "testx";
                repo_user.Update(user);
            }
        }

        public void DeleteTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "testx");

            if(user != null)
            {
                repo_user.Delete(user);
            }
        }

        public void CommentTest()
        {
            EvernoteUser user = repo_user.Find(x => x.Id == 1);
            Note note = repo_note.Find(x => x.Id == 3);
            
            Comment comment = new Comment()
            {
                Text = "Test comment.",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUserName = "testyman",
                Note = note,
                Owner = user
            };

            repo_comment.Insert(comment);
        }
    }
}
