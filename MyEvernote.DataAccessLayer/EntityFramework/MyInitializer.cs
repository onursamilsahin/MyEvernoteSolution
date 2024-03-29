﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernote.Entities;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
   public  class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Adding Admin User
            EvernoteUser admin = new EvernoteUser()
            {

                Name = "Onur ",
                Surname = "Şahin",
                Email = "samilsahin4118@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "samilsahin",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "samilsahin"




            };
            //Adding Admin User
            EvernoteUser standartUser =new EvernoteUser()
            {

                Name = " Şamil",
                Surname = "Şahin",
                Email = "samilsahin4118@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "onursahin",
                Password = "654321",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "samilsahin"


            };

            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(standartUser);

            for (int i = 0; i < 8; i++)
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
                    ModifiedUsername = $"user{i}"

                };
                context.EvernoteUsers.Add(user);


            }
            context.SaveChanges();


            List<EvernoteUser> Userlist = context.EvernoteUsers.ToList();
            //Addding fake category
            for (int i = 0; i < 10; i++)
            {
                
                Category cat=new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    ModifiedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    ModifiedUsername = "onursamilsahin"

                };

                context.Categories.Add(cat);

                //Adding NOtes
                for (int k = 0; k < FakeData.NumberData.GetNumber(5,10); k++)
                {
                    EvernoteUser owner = Userlist[FakeData.NumberData.GetNumber(0, Userlist.Count - 1)];
                    Note note=new Note()
                    {

                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5,25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1,3)),
    
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1,9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),

                        ModifiedUsername = owner.Username,
                         

                    };

                    cat.Notes.Add(note );


                    //Adding Comments

                    for (int j = 0; j < FakeData.NumberData.GetNumber(3,5); j++)
                    {

                        EvernoteUser comment_owner = Userlist[FakeData.NumberData.GetNumber(0, Userlist.Count - 1)];

                        Comment comment=new Comment()
                        {

                            Text = FakeData.TextData.GetSentence(),
                            
                            Owner =comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username,



                        };
                        note.Comments.Add(comment);

                    }


                    //Adding fake likes
                     
                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        
                        Liked liked=new Liked()
                        {

                            LikedUser = Userlist[m]


                        };
                        note.Likes.Add(liked);

                    }



                    
                }


            }

            context.SaveChanges();


        }
    }
}
