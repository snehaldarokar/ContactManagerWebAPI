using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerWebAPI
{
    public interface IContacts
    {
        IEnumerable<ContactDataAccess.Contact> GetContacts();
    }
}
