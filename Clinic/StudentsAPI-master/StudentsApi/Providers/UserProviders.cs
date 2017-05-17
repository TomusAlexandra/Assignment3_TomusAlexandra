using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace StudentsApi.Providers
{
    public class UserProviders
    {
        private DatabaseDB db = new DatabaseDB();

        public IList<User> GetUsers() {

            return db.Users.ToList();
         }

        public User GetById(int id) {

            User user = db.Users.Find(id);
            return user;
        }

        public void Add(User user) {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Edit(User user) {

            db.Entry(user).State = EntityState.Modified;
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Delete(int id) {

            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User GetByUsername(String username) {

            try {
                return db.Users.First(d => d.UserName.Equals(username));
            }
            catch(Exception e)
            {
                return null;
            }

        }

        public bool IsValid(String username, String pass) {

            try
            {
                var user = db.Users.First(d => d.UserName.Equals(username) && d.Password.Equals(pass));

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e) {
                return false;
            }

        }

      
    }
}