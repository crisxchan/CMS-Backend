using CMS.Models;
using Newtonsoft.Json;

namespace CMS.Services
{
    public class JsonContactsRepo : IContactsRepo
    {
        private readonly IConfiguration _configuration;

        private List<Contact> Contacts { get; set; }
        
        public JsonContactsRepo(IConfiguration configuration)
        {
            _configuration = configuration;

            var json = File.ReadAllText(_configuration["ContactsDbFileName"]);
            Contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        }

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void DeleteContact(Guid id)
        {
            var contactToDelete = GetContact(id);

            Contacts.Remove(contactToDelete);
        }

        public Contact GetContact(Guid id)
        {
            var contact = Contacts.FirstOrDefault(contact => contact.Id == id);

            return contact;
        }

        public IEnumerable<Contact> GetContacts()
        {
            var contacts = Contacts.ToList();

            return contacts;
        }

        public void Save()
        {
            string updatedContacts = JsonConvert.SerializeObject(Contacts, Formatting.Indented);
            File.WriteAllText(_configuration["ContactsDbFileName"], updatedContacts);
        }
    }
}
