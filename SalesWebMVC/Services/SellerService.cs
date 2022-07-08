﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;
namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;
        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.Include(obj => obj.Department).ToListAsync();
        }
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
          await  _context.SaveChangesAsync();
        }
        public async Task<Seller> FindbyIdAsync(int Id)
        {
            return await _context.Seller.Include(obj=>obj.Department).FirstOrDefaultAsync(obj=>obj.Id==Id);
        }
        public async Task RemoveAsync(int Id)
        {
            try 
            {
                var seller = await _context.Seller.FindAsync(Id);
                _context.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
           
        }
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyExeception(e.Message);
            }
            
        }
    }
}
