using Microsoft.EntityFrameworkCore;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Concrete
{
    public class FileRepository : IFileRepository
    {
        public async Task<List<File>> GetAllFile()
        {
            using(var db=new DataContext())
            {
                return await db.Files.ToListAsync();
            }
        }
        public async Task<File> GetFileById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Files.FindAsync(id);
            }
        }
        public async Task<List<File>> GetFileByBrandId(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Files.Where(w => w.BrandId == id).ToListAsync();
            }
        }
        public async Task<List<File>> GetFileByCategoryId(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Files.Where(w => w.CategoryId == id).ToListAsync();
            }
        }
        public async Task<List<File>> GetFileByProductId(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Files.Where(w => w.BrandId == id).ToListAsync();
            }
        }
        public async Task<File> CreateFile(File file)
        {
            using (var db = new DataContext())
            {
                db.Files.Add(file);
                await db.SaveChangesAsync();
                return file;
            }
        }
        public async Task<File> UpdateFile(File file)
        {
            using (var db = new DataContext())
            {
                db.Files.Update(file);
                await db.SaveChangesAsync();
                return file;
            }
        }
        public async Task DeleteFile(int id)
        {
            using (var db = new DataContext())
            {
                var deleteFile = await GetFileById(id);
                db.Files.Remove(deleteFile);
                await db.SaveChangesAsync();
            }
        }

    }
}
