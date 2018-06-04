using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ContactDataAccess;


namespace ContactManagerWebAPI.Controllers
{
    public class ContactsController : ApiController
    {
        private IContacts _repository;
        List<Contact> contacts = new List<Contact>();
        public ContactsController() { }
        public ContactsController(IContacts contactRepository) 
        {
            _repository = contactRepository; 
        }


        private ContactDBEntities db = new ContactDBEntities();

        // GET api/Contacts
        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            _repository = new ContactsRepository();
            return _repository.GetContacts();
        }

        // GET api/Contacts/5
        [HttpGet]
        public HttpResponseMessage Contact(int id)
        {
            Contact contact = new Contact();
            using (ContactDBEntities entities = new ContactDBEntities())
            {
                contact = entities.Contacts.FirstOrDefault(e => e.Id == id);
            }
            if (contact != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact with id= " + id.ToString() + " not found");
            }
            
        }

        [HttpPut]
        // PUT api/Contacts/5
        public HttpResponseMessage PutContact(int id, Contact contact)
        {
            if (ModelState.IsValid && id == contact.Id)
            {
                try
                {
                    using (ContactDBEntities entities = new ContactDBEntities())
                    {
                        var contactEntity = entities.Contacts.FirstOrDefault(e => e.Id == id);

                        if (contactEntity == null)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact with id= " + id.ToString() + " not found");
                        }
                        else
                        {
                            contactEntity.FirstName = contact.FirstName;
                            contactEntity.LastName = contact.LastName;
                            contactEntity.Email = contact.Email;
                            contactEntity.PhoneNumber = contact.PhoneNumber;
                            contactEntity.Status = contact.Status;

                            entities.SaveChanges();
                            return Request.CreateResponse(HttpStatusCode.OK, contactEntity);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,ex);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        // POST api/Contacts
        public HttpResponseMessage PostContact([FromBody]Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (ContactDBEntities entities = new ContactDBEntities())
                    {
                        entities.Contacts.Add(contact);
                        entities.SaveChanges();
                    }

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contact);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = contact.Id }));
                    return response;
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Contacts/5
        public HttpResponseMessage DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Contacts.Remove(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contact);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}