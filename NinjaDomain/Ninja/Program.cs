using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodeModelFromDB;

namespace Ninja
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Stop initialization process
            Database.SetInitializer(new NullDatabaseInitializer<HackathonEDM>());

            //Insert();
            //InsertRange();
            //GetStuff();
            //GetStuff();
            GetStuffAndUpdate();
            Console.ReadKey();
        }

        private static void Insert()
        {
            var user1 = new User {Email = "entity@qaworks.com", Name = "Entity 1", Surname = "QAWorks"};
            var user2 = new User {Email = "entity@qaworks.com", Name = "Entity 2", Surname = "QAWorks"};

            using (var context = new HackathonEDM())
            {
                context.Database.Log = Console.WriteLine;
                context.Users.Add(user1);
                context.Users.Add(user2);
                var id = context.SaveChanges();
                Console.WriteLine(id);
            }
        }

        private static void InsertRange()
        {
            var user1 = new User {Email = "entity@qaworks.com", Name = "Range 1", Surname = "QAWorks"};
            var user2 = new User {Email = "entity@qaworks.com", Name = "Range 2", Surname = "QAWorks"};

            using (var context = new HackathonEDM())
            {
                context.Database.Log = Console.WriteLine;
                context.Users.AddRange(new List<User> {user1, user2});
                var id = context.SaveChanges();
                Console.WriteLine(id);
            }
        }

        private static void GetStuff()
        {
            using (var context = new HackathonEDM())
            {
                //context.Database.Log = Console.WriteLine;

                var users = context.Users.ToList();
                var user = users.
                    FirstOrDefault(x => x.Name == "Entity");

                //foreach (var user in enumerable)
                //{
                if (user != null) Console.WriteLine(user.Name + " " + user.Surname);
                //}
            }
        }

        private static void GetStuffAndUpdate()
        {
            using (var context = new HackathonEDM())
            {
                context.Database.Log = Console.WriteLine;
                var user = context.Users.FirstOrDefault();

                // Make the update
                if (user != null)
                {
                    user.Name = "Updated User " + DateTime.Now.Ticks;
                    Console.WriteLine(user.Name + " " + user.Surname);
                }

                context.SaveChanges();
            }
        }
    }
}