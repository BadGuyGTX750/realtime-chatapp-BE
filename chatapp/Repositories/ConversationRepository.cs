﻿using chatapp.Data;
using chatapp.Dto;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class ConversationRepository
    {
        private readonly Entities _dbContext;

        public ConversationRepository(Entities dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> ConversationCreate(Conversation conv)
        {
            try
            {
                await _dbContext.conversations.AddAsync(conv);
                await _dbContext.SaveChangesAsync();
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
                return await _dbContext.conversations.Where(u => u.conversation_id == id).FirstAsync();
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
                _dbContext.conversations.Update(conv);
                await _dbContext.SaveChangesAsync();
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
                var conv = await _dbContext.conversations.Where(u => u.conversation_id == id).FirstAsync();
                _dbContext.conversations.Remove(conv);
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