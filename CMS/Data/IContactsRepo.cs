using CMS.Models;

namespace CMS.Services
{
    public interface IContactsRepo
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(Guid id);
        void AddContact(Contact contact);
        void DeleteContact(Guid id);
        void Save();
    }
}
