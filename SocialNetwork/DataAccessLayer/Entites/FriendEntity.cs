using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data_Access_Layer.Entites
{
    public class FriendEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int friend_id { get; set; }
    }
}
