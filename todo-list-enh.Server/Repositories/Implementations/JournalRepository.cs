﻿using Microsoft.EntityFrameworkCore;
using System;
using todo_list_enh.Server.Data;
using todo_list_enh.Server.Models.Domain;
using todo_list_enh.Server.Repositories.Interfaces;

namespace todo_list_enh.Server.Repositories.Implementations
{
    public class JournalRepository : Repository<Journal>, IJournalRepository
    {
        private readonly ETLDbContext _dbContext;
        public JournalRepository(ETLDbContext dbContext) : base(dbContext) { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Journal>> GetJournalsByUserIdAsync(int userId)
        {
            return await _dbContext.Journals
                .Where(j => j.UserId == userId)
                .ToListAsync();
        }

        public async Task<Journal?> GetJournalWithRecordsAsync(int journalId)
        {
            return await _dbContext.Journals
                .Include(j => j.JournalRecords)
                .FirstOrDefaultAsync(j => j.Id == journalId);
        }
    }

}
