﻿using chatapp.Dtos;
using chatapp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Services
{
    public class GroupMemberService
    {
        private readonly GroupMemberRepository _repository;

        public GroupMemberService(GroupMemberRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Guid> GroupMemberCreate(GroupMemberModelState grpMbMS)
        {
            GroupMember grpMb = new GroupMember();
            grpMb.contact_id = grpMbMS.contact_id;
            grpMb.conversation_id = grpMbMS.conversation_id;
            grpMb.joined_datetime = DateTime.UtcNow;
            return await _repository.GroupMemberCreate(grpMb);
        }

        public async Task<GroupMember> GroupMemberGetById(Guid id)
        {
            return await _repository.GroupMemberGetById(id);
        }

        public async Task<GroupMember> GroupMemberGetByCoversationIdAndContactId(Guid conv_id, Guid contact_id)
        {
            return await _repository.GroupMemberGetByCoversationIdAndContactId(conv_id, contact_id);
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
