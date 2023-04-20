using chatapp.Data;
using chatapp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class ContactRepository
    {
        private readonly Entities _dbContext;

        public ContactRepository(Entities dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Guid> ContactCreate(Contact contact)
        {
            try
            {
                await _dbContext.contacts.AddAsync(contact);
                await _dbContext.SaveChangesAsync();
                var id_return = await _dbContext.contacts.Select(u => u.contact_id).LastAsync();
                return id_return;
            }
            catch (Exception ex)
            {
                return Guid.Empty;
            }
        }

        public async Task<Contact> ContactGetById(Guid id)
        {
            try
            {
                return await _dbContext.contacts.Where(u => u.contact_id == id).FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ContactUpdate(Contact contact)
        {
            try
            {
                _dbContext.contacts.Update(contact);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ContactDeleteById(Guid id)
        {
            try
            {
                var contact = await _dbContext.contacts.Where(u => u.contact_id == id).FirstAsync();
                _dbContext.contacts.Remove(contact);
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
