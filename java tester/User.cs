using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkpaideytikoLogismiko
{
    public class User
    {
        private int userId;
        private string firstname;
        private string lastname;
        private string username;


        public User(int id, string fn,string ln, string un)
        {
            userId = id;
            firstname = fn;
            lastname = ln;
            username = un;
        }


        public int getUserId()
        {
            return userId;
        }

        public string getFirstname()
        {
            return firstname;
        }

        public string geLastname()
        {
            return lastname;
        }

        public string getUsername()
        {
            return username;
        }
    }
}
