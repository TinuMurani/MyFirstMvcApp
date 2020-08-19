﻿using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Data;
using MyFirstMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Services
{
    public class ContactListService : IContactListService
    {
        private readonly MyFirstMvcAppDbContext _context;

        public ContactListService(MyFirstMvcAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ContactListEntry>> GetEntriesAsync()
        {
            return await _context.ContactListEntry.ToListAsync();
        }

        public async Task<ContactListEntry> GetByIdAsync(int id)
        {
            var contactListEntry = await _context.ContactListEntry
                                        .FirstOrDefaultAsync(x => x.Id == id);

            return contactListEntry;
        }
        public async Task<bool> CreateEntryAsync(ContactListEntry entry)
        {
            _context.Add(entry);

            var insertedRows = await _context.SaveChangesAsync();

            return insertedRows > 0;
        }
        
        public async Task<bool> UpdateEntryAsync(ContactListEntry entry)
        { 
            _context.Update(entry);

            int updateRows = await _context.SaveChangesAsync();

            return updateRows > 0;
        }

        public async Task<bool> DeleteEntryAsync(int id)
        {
            var contactListEntry = await _context.ContactListEntry.FindAsync(id);

            _context.ContactListEntry.Remove(contactListEntry);

            var deletedRows = await _context.SaveChangesAsync();

            return deletedRows > 0;
        }
    }
}
