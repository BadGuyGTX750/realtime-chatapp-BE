using chatapp.Dtos;
using chatapp.Repositories;

namespace chatapp.Services
{
    public class MessageService
    {
        private readonly MessageRepository _repository;

        public MessageService(MessageRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Guid> MessageCreate(MessageModelState msgMs)
        {
            Message msg = new Message();
            msg.conversation_id = msgMs.conversation_id;
            msg.from_email = msgMs.from_email;
            msg.message_text = msgMs.message_text;
            msg.sentAt = DateTime.UtcNow;

            return await _repository.MessageCreate(msg);
        }

        public async Task<Message> MessageGetById(Guid id)
        {
            return await _repository.MessageGetById(id);
        }

        public async Task<bool> MessageUpdate(Message msg)
        {
            return await _repository.MessageUpdate(msg);
        }

        public async Task<bool> MessageDeleteById(Guid id)
        {
            return await _repository.MessageDeleteById(id);
        }
    }
}
