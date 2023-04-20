using chatapp.Data;
using chatapp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class GroupMemberRepository
    {
        private readonly Entities _dbContext;

        public GroupMemberRepository(Entities dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> GroupMemberCreate(GroupMember grpMb)
        {
            try
            {
                grpMb.group_member_id = Guid.NewGuid();
                await _dbContext.groupMembers.AddAsync(grpMb);
                await _dbContext.SaveChangesAsync();
                return grpMb.group_member_id;
            }
            catch (Exception ex)
            {
                return Guid.Empty;
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

        public async Task<GroupMember> GroupMemberGetByCoversationIdAndContactId(Guid conv_id, Guid contact_id)
        {
            try
            {
                return await _dbContext.groupMembers.Where(u => u.conversation_id == conv_id && u.contact_id == contact_id).FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<GroupMember>> GroupMemberGetByCoversationId(Guid conv_id)
        {
            try
            {
                return await _dbContext.groupMembers.Where(u => u.conversation_id == conv_id).ToListAsync();
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
