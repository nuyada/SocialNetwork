using SocialNetwork.Data_Access_Layer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data_Access_Layer.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public int Create(MessageEntity messageEntity)
        {
            return Execute(@"insert into messages(content, sender_id, recipient_id) 
                             values(:content,:sender_id,:recipient_id)", messageEntity);
        }

        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            return Query<MessageEntity>("select * from messages where sender_id = :sender_id", new { sender_id = senderId });
        }

        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            return Query<MessageEntity>("select * from messages where recipient_id = :recipient_id", new { recipient_id = recipientId });
        }

        public int DeleteById(int messageId)
        {
            return Execute("delete from messages where id = :id", new { id = messageId });
        }

    }

    public interface IMessageRepository
    {
        int Create(MessageEntity messageEntity);
        IEnumerable<MessageEntity> FindBySenderId(int senderId);
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
        int DeleteById(int messageId);
    }
}
