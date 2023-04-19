using chatapp.Data;
using chatapp.Dto;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class MessageRepository
    {
        private readonly Entities dbContext;

        public MessageRepository(Entities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> MessageCreate(Message msg)
        {
            try
            {
                await dbContext.messages.AddAsync(msg);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Message> MessageGetById(Guid id)
        {
            try
            {
                return await dbContext.messages.Where(u => u.message_id == id).FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> MessageUpdate(Message msg)
        {
            try
            {
                dbContext.messages.Update(msg);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> MessageDeleteById(Guid id)
        {
            try
            {
                var msg = await dbContext.messages.Where(u => u.message_id == id).FirstAsync();
                dbContext.messages.Remove(msg);
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
