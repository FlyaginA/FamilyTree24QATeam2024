using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.TestEntities
{
    /// <summary>
    /// Объект пользователя.
    /// используется при входе на ресурс.
    /// </summary>
    public class User
    {
        public User(List<string> userData = null)
        {
            if (userData != null && userData.Count != 5 )
            {
                throw new ArgumentException("Invalid argument: userData list should contain exactly 5 elements.");
            }

            this.Id = userData[0];
            this.Name = userData[1];
            this.Surname = userData[2];
            this.Login = userData[3];
            this.Password = userData[4];
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Id { get; } = null;
        public string Name { get; } = null;
        public string Surname { get; } = null;
    }
    

}