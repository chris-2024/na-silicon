using Infrastructure.Entities;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories;

public class ContactFactory
{
    public static ContactEntity Create(Contact form)
    {

        try
        {
            var contact = new ContactEntity
            {
                Id = Guid.NewGuid().ToString(),
                Email = form.Email,
                FullName = form.FullName,
                Message = form.Message,
                Service = form.Service,
            };
            return contact;

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }
}
