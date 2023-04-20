using chatapp.Dto;
using chatapp.Repositories;

namespace chatapp.Services
{
    public class GroupMemberService
    {
        private readonly GroupMemberRepository _repository;

        public GroupMemberService(GroupMemberRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Guid> GroupMemberCreate(GroupMember grpMb)
        {
            return await _repository.GroupMemberCreate(grpMb);
        }

        public async Task<GroupMember> GroupMemberGetById(Guid id)
        {
            return await _repository.GroupMemberGetById(id);
        }

        public async Task<bool> GroupMemberUpdate(GroupMember grpMb)
        {
            return await _repository.GroupMemberUpdate(grpMb);
        }

        public async Task<bool> GroupMemberDeleteById(Guid id)
        {
            return await _repository.GroupMemberDeleteById(id);
        }
    }
}
