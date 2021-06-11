using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Experimentation.AspNetCore.Example
{
    [Route("contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IExperimentGroupChecker _experimentGroupChecker;

        public ContactsController(IExperimentGroupChecker experimentGroupChecker)
        {
            _experimentGroupChecker = experimentGroupChecker;
        }

        [HttpGet]
        public ActionResult<GetContactsResponseModel> Get()
        {
            return Ok(new GetContactsResponseModel
            {
                Contacts = new List<Contact>
                {
                    new Contact
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test"
                    }
                },
                Message = _experimentGroupChecker.IsInGroup("A") ? "Group A" : "Not in Group A"
            });
        }
    }

    public class GetContactsResponseModel
    {
        public List<Contact> Contacts { get; set; }
        public string Message { get; set; }
    }

    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
