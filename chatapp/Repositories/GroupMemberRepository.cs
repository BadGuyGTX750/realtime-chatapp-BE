﻿using chatapp.Data;
using chatapp.Dto;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class GroupMemberRepository
    {
        private readonly Entities _dbContext;

        public GroupMemberRepository(Entities dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> GroupMemberCreate(GroupMember grpMb)
        {
            try
            {
                await _dbContext.groupMembers.AddAsync(grpMb);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<GroupMember> GroupMemberGetById(Guid id)
        {
            try
            {
                return await _dbContext.groupMembers.Where(u => u.group_member_id == id).FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> GroupMemberUpdate(GroupMember grpMb)
        {
            try
            {
                _dbContext.groupMembers.Update(grpMb);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> GroupMemberDeleteById(Guid id)
        {
            try
            {
                var grpMb = await _dbContext.groupMembers.Where(u => u.group_member_id == id).FirstAsync();
                _dbContext.groupMembers.Remove(grpMb);
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