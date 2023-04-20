using chatapp.Data;
using chatapp.Dto;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class MessageRepository
    {
        private readonly Entities _dbContext;

        public MessageRepository(Entities dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Guid> MessageCreate(Message msg)
        {
            try
            {
                await _dbContext.messages.AddAsync(msg);
                await _dbContext.SaveChangesAsync();
                var id_return = await _dbContext.messages.Select(u => u.message_id).LastAsync();
                return id_return;
            }
            catch (Exception ex)
            {
                return Guid.Empty;
            }
        }

        public async Task<Message> MessageGetById(Guid id)
        {
            try
            {
                return await _dbContext.messages.Where(u => u.message_id == id).FirstAsync();
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
                _dbContext.messages.Update(msg);
                await _dbContext.SaveChangesAsync();
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
                var msg = await _dbContext.messages.Where(u => u.message_id == id).FirstAsync();
                _dbContext.messages.Remove(msg);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
