using chatapp.Data;
using chatapp.Dto;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class GroupMemberRepository
    {
        private readonly Entities dbContext;

        public GroupMemberRepository(Entities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> GroupMemberCreate(GroupMember grpMb)
        {
            try
            {
                await dbContext.groupMembers.AddAsync(grpMb);
                await dbContext.SaveChangesAsync();
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
                return await dbContext.groupMembers.Where(u => u.group_member_id == id).FirstAsync();
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
                dbContext.groupMembers.Update(grpMb);
                await dbContext.SaveChangesAsync();
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
                var grpMb = await dbContext.groupMembers.Where(u => u.group_member_id == id).FirstAsync();
                dbContext.groupMembers.Remove(grpMb);
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
