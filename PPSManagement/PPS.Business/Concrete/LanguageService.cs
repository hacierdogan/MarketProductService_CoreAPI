using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.DataAccess.Concrete;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class LanguageService : ILanguageService
    {
        private ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<List<Language>> GelAllLanguages()
        {
            return await _languageRepository.GetAllLanguages();
        }
        public async Task<Language> GetLanguageByShortCode(string shortCode)
        {
            return await _languageRepository.GetLanguageByShortCode(shortCode);
        }
        public async Task<Language> GetLanguageById(int id)
        {
            return await _languageRepository.GetLanguageById(id);
        }
        public async Task<Language> CreateLanguage(Language language)
        {
            return await _languageRepository.CreateLanguage(language);
        }
        public async Task<Language> UpdateLanguage(Language language)
        {
            return await _languageRepository.UpdateLanguage(language);
        }
        public async Task DeleteLanguage(int id)
        {
            //var language = await _languageRepository.GetLanguageById(id);
            //if (language != null)
            //{
                await _languageRepository.DeleteLanguage(id);
            //}
            //throw new Exception("Bu Id'ye ait kayıt bulunamadı.");
        }
    }
}
