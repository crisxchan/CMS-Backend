using AutoMapper;
using CMS.DTOs;
using CMS.Models;
using CMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepo _repository;
        private readonly IMapper _mapper;

        public ContactsController(IContactsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ContactReadDto>> GetContacts()
        {
            var contacts = _repository.GetContacts();

            return Ok(_mapper.Map<IEnumerable<ContactReadDto>>(contacts));
        }
        
        [HttpGet("{id}", Name = "GetContactById")]
        public ActionResult<ContactReadDto> GetContactById(Guid id)
        {
            var contact = _repository.GetContact(id);

            return Ok(_mapper.Map<ContactReadDto>(contact));
        }

        [HttpPost]
        public ActionResult<ContactReadDto> Post(ContactCreateDto contactCreateDto)
        {
            var contactModel = _mapper.Map<Contact>(contactCreateDto);

            _repository.AddContact(contactModel);
            _repository.Save();

            var contactReadDto = _mapper.Map<ContactReadDto>(contactModel);

            return CreatedAtRoute(nameof(GetContactById), new { Id = contactReadDto.Id }, contactReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _repository.DeleteContact(id);
            _repository.Save();

            return NoContent();
        }
    }
}
