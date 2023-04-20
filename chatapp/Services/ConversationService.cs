using chatapp.Dtos;
using chatapp.Repositories;

namespace chatapp.Services
{
    public class ConversationService
    {
        private readonly ConversationRepository _repository;

        public ConversationService(ConversationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> ConversationCreate(ConversationModelState convMS)
        {
            Conversation conv = new Conversation();
            conv.conversation_name = convMS.conversation_name;
            conv.isGroup = convMS.isGroup;

            return await _repository.ConversationCreate(conv);
        }

        public async Task<Conversation> ConversationGetById(Guid id)
        {
            return await _repository.ConversationGetById(id);
        }

        public async Task<bool> ConversationUpdate(Conversation conv)
        {
            return await _repository.ConversationUpdate(conv);
        }

        public async Task<bool> ConversationDeleteById(Guid id)
        {
            return await _repository.ConversationDeleteById(id);
        }
    }
}
