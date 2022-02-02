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
    public class LanguageRepository : ILanguageRepository
    {
        public async Task<List<Language>> GetAllLanguages()
        {
            using (var db = new DataContext())
            {
                return await db.Languages.ToListAsync();
            }
        }
        public async Task<Language> GetLanguageById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Languages.FindAsync(id);
            }
        }
        public async Task<Language> GetLanguageByShortCode(string shortCode)
        {
            using (var db = new DataContext())
            {
                return await db.Languages.FirstOrDefaultAsync(w => w.ShortCode.ToLower() == shortCode.ToLower());
            }
        }
        public async Task<Language> CreateLanguage(Language language)
        {
            using (var db = new DataContext())
            {
                db.Languages.Add(language);
                await db.SaveChangesAsync();
                return language;
            }
        }
        public async Task<Language> UpdateLanguage(Language language)
        {
            using (var db = new DataContext())
            {
                db.Languages.Update(language);
                await db.SaveChangesAsync();
                return language;
            }
        }
        public async Task DeleteLanguage(int id)
        {
            using (var db = new DataContext())
            {
                var deletelanguage = await GetLanguageById(id);
                db.Languages.Remove(deletelanguage);
                await db.SaveChangesAsync();
            }
        }

    }
}
