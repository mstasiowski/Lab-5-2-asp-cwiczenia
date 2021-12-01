using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public class EFCRUDContactRepository : ICRUDContactRepository
    {
        private ApplicationDbContext context;

        public EFCRUDContactRepository(ApplicationDbContext context)
        {
            this.context = context;
        }



        public Contact Add(Contact contact)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Contact> entityEntry = context.Add(contact);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            context.Contacts.Remove(context.Contacts.Find(id));
            context.SaveChanges();

        }

        public List<Contact> FindAll()
        {
            return context.Contacts.ToList();
            
        }

        public Contact FindById(int id)
        {
            return context.Contacts.Find(id);
        }

        public Contact Update(Contact contact)
        {
           Contact orginal =  context.Contacts.Find(contact.Id);
            orginal.Email = contact.Email;
            orginal.Phone = contact.Phone;
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Contact> entityEntry = context.Contacts.Update(contact);
            context.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
