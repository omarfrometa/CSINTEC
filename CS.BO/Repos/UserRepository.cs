using CS.BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.BO.Repos
{
    public class UserRepository
    {
        ApplicationContext context;

        private List<User> _users;
        private int _nextId = 1;

        public UserRepository()
        {
            _users = new List<User>();        
        }

        public void Create(User user)
        { 
            using(var context = new ApplicationContext())
            {
                context.User.Add(user);
                context.SaveChanges();  
            }
        }

        public User GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.User.FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<User> GetAlls()
        { 
           using (var context = new ApplicationContext())
            {
                return context.User.ToList();
            }
        }

        public void Update(User user)
        {
            var userExist = GetById(user.Id);
            if (userExist != null)
            {
                userExist.UserName = user.UserName;
                userExist.Email = user.Email;
                userExist.CreatedDate = DateTime.Now;
            }
        }

        public void Delete(int id)
        {
            var userExist = GetById(id);
            if (userExist != null)
            {
               _users.Remove(userExist);
            }
        }
    }
}
