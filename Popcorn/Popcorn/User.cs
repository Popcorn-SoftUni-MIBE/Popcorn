using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    class User
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public User(string name, int score)
        {
            this.Name = name;
            this.Score = Score;
        }

        public static User ParseUser(string line)
        {
            string[] dataArr = line.Split();
            string name = dataArr[0];
            int score = int.Parse(dataArr[1]);
            return new User(name, score);
        }
        public override string ToString()
        {
            string user = this.Score + " " + this.Name;
            return user;

        }
    }
}
