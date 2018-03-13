using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernote.Entities;

namespace MyEvernote.DataAccessLayer
{
    // works on db create
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Adding admin user.
            EvernoteUser admin = new EvernoteUser()
            {
                Name = "Ozan",
                Surname = "Kömürcü",
                Email = "ozankomurcu@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "okomurcu",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUserName = "okomurcu"
            };

            //Addsin standart user.
            EvernoteUser standartUser = new EvernoteUser()
            {
                Name = "Ozan2",
                Surname = "Kömürcü2",
                Email = "ozankomurcu2@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "okomurcu2",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(15),
                ModifiedUserName = "okomurcu"
            };

            context.EvernoteUsers.Add(standartUser);
            context.EvernoteUsers.Add(admin);

            for (int i = 0; i < 10; i++)
            {
                EvernoteUser user = new EvernoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUserName = $"user{i}"
                };

                context.EvernoteUsers.Add(user);
            }

            context.SaveChanges();

            // User list for creating data
            List<EvernoteUser> userlist = context.EvernoteUsers.ToList();

            // adding fake categories
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUserName = "okomurcu"
                };

                context.Categories.Add(cat);

                for (int k = 0; k < FakeData.NumberData.GetNumber(7, 15); k++)
                {
                    

                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(10, 35)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 10),
                        Owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)],
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUserName = (k % 3 == 0) ? admin.Username : standartUser.Username
                    };

                    cat.Notes.Add(note);


                    // Adding fake comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(0, 7); j++)
                    {
                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = (j % 3 == 0) ? admin : standartUser,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUserName = (j % 3 == 0) ? admin.Username : standartUser.Username
                        };

                        note.Comments.Add(comment);
                    }

                    //Adding fake likes
                    for (int m = 0; m < 4; m++)
                    {
                        Liked liked = new Liked()
                        {
                            LikedUser = userlist[m]
                        };

                        note.Likes.Add(liked);
                    }
                }
            }


            context.SaveChanges();
        }
    }
}
