using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Abstract
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllLanguages();
        Task<Language> GetLanguageById(int id);
        Task<Language> GetLanguageByShortCode(string shortCode);
        Task<Language> CreateLanguage(Language language);
        Task<Language> UpdateLanguage(Language language);
        Task DeleteLanguage(int id);

    }
}
