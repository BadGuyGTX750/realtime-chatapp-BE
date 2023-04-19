using chatapp.Data;
using chatapp.Dto;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class ConversationRepository
    {
        private readonly Entities dbContext;

        public ConversationRepository(Entities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ConversationCreate(Conversation conv)
        {
            try
            {
                await dbContext.conversations.AddAsync(conv);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Conversation> ConversationGetById(Guid id)
        {
            try
            {
                return await dbContext.conversations.Where(u => u.conversation_id == id).FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ConversationUpdate(Conversation conv)
        {
            try
            {
                dbContext.conversations.Update(conv);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ConversationDeleteById(Guid id)
        {
            try
            {
                var conv = await dbContext.conversations.Where(u => u.conversation_id == id).FirstAsync();
                dbContext.conversations.Remove(conv);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
