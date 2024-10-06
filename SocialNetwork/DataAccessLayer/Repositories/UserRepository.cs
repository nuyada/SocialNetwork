using SocialNetwork.Data_Access_Layer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data_Access_Layer.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int Create(UserEntity userEntity)
        {
            return Execute(@"insert into users (firstname,lastname,password,email) 
                             values (:firstname,:lastname,:password,:email)", userEntity);
        }

        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("select * from users");
        }

        public UserEntity FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new { email_p = email });
        }

        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where id = :id_p", new { id_p = id });
        }

        public int Update(UserEntity userEntity)
        {
            return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password, email = :email,
                             photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id", userEntity);
        }

        public int DeleteById(int id)
        {
            return Execute("delete from users where id = :id_p", new { id_p = id });
        }
    }

    public interface IUserRepository
    {
        int Create(UserEntity userEntity);
        UserEntity FindByEmail(string email);
        IEnumerable<UserEntity> FindAll();
        UserEntity FindById(int id);
        int Update(UserEntity userEntity);
        int DeleteById(int id);
    }
}
