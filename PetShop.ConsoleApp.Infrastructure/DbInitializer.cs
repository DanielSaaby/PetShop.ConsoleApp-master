using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Infrastructure
{
    public class DbInitializer
    {
        public static void SeedDB(PetAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var owner1 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Kenny",
                LastName = "Powers",
                Email = "kp@powers.dk",
                PhoneNumber = "28882291",
                Address = "Sunset Boulevard 666",


            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Daniel",
                LastName = "Rasmussen",
                Address = "Engdraget 4",
                Email = "dani2885@easv365.dk",
                PhoneNumber = "26294128",

            }).Entity;


            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Dino",
                Type = "Dog",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "Black",
                Owner = owner1,
                Price = 20
            }).Entity;


            var pet2 = ctx.Pets.Add(new Pet()
            {
                Name = "Dino",
                Type = "Dog",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "Black",
                Owner = owner2,
                Price = 20
            }).Entity;

            string password = "1234";
            byte[] passwordHashFrederik, passwordSaltFrederik, passwordHashKent, passwordSaltKent;
            CreatePasswordHash(password, out passwordHashFrederik, out passwordSaltFrederik);
            CreatePasswordHash(password, out passwordHashKent, out passwordSaltKent);
            /*
            var user1 = ctxUser.Users.Add(new User()
            {
                Username = "Frederik",
                PasswordHash = passwordHashFrederik,
                PasswordSalt = passwordSaltFrederik,
                IsAdmin = false 
            });

            var user2 = ctxUser.Users.Add(new User()
            {
                Username = "Kent",
                PasswordHash = passwordHashKent,
                PasswordSalt = passwordSaltKent,
                IsAdmin = true
            });



ctxUser.SaveChanges();
            */
      ctx.SaveChanges();      
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
