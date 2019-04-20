using System;
using System.Collections.Generic;
using System.Text;
using BookMyBrickDomain.Repository;
using System.Linq;
using System.Runtime.CompilerServices;
namespace BookMyBrickDomain.UserAccount
{


    public class AccountManagement
    {
        
        public bool UserLogging(UserCredentials details)
        {
           UserRepoContext _context = new UserRepoContext();

           String emailTobeChecked = details.email;
           String passwordTobeChecked = details.password;

           var uservalue = _context.User.FirstOrDefault(p => p.usermail == emailTobeChecked);

           if ((uservalue.usermail == emailTobeChecked) && (uservalue.password == passwordTobeChecked))
           {
               return true;
           }      
           else
           {
               return false;
           }
        }
    }
}
