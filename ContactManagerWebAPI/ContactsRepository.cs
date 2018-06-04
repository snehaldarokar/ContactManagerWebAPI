using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactDataAccess;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ContactManagerWebAPI
{
    public class ContactsRepository : IContacts
    {
        //private DbSet<ContactDataAccess.Contact> contact;
        private ContactDBEntities db = new ContactDBEntities();
        public IEnumerable<ContactDataAccess.Contact> GetContacts()
        {
            return db.Contacts.AsEnumerable();
        }
    }
}