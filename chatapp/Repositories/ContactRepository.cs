using chatapp.Data;
using chatapp.Dto;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Repositories
{
    public class ContactRepository
    {
        private readonly Entities dbContext;

        public ContactRepository(Entities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ContactCreate(Contact contact)
        {
            try
            {
                await dbContext.contacts.AddAsync(contact);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Contact> ContactGetById(Guid id)
        {
            try
            {
                return await dbContext.contacts.Where(u => u.contact_id == id).FirstAsync();
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
                dbContext.contacts.Update(contact);
                await dbContext.SaveChangesAsync();
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
                var contact = await dbContext.contacts.Where(u => u.contact_id == id).FirstAsync();
                dbContext.contacts.Remove(contact);
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
