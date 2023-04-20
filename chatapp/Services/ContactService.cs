using chatapp.Data;
using chatapp.Dtos;
using chatapp.Repositories;

namespace chatapp.Services
{
    public class ContactService
    {
        private readonly ContactRepository _repository;

        public ContactService(ContactRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Guid> ContactCreate(ContactModelState contactMS)
        {
            Contact contact = new Contact();
            contact.first_name = contactMS.first_name;
            contact.last_name = contactMS.last_name;
            contact.username = contactMS.username;
            contact.email = contactMS.email;

            return await _repository.ContactCreate(contact);
        }

        public async Task<Contact> ContactGetById(Guid id)
        {
            return await _repository.ContactGetById(id);
        }

        public async Task<bool> ContactUpdate(Contact contact)
        {
            return await _repository.ContactUpdate(contact);
        }

        public async Task<bool> ContactDeleteById(Guid id)
        {
            return await _repository.ContactDeleteById(id);
        }
    }
}
