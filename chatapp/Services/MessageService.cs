using chatapp.Dto;
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

        public async Task<bool> MessageCreate(Message msg)
        {
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
