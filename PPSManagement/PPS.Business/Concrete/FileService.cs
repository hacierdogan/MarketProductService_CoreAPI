using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class FileService : IFileService
    {
        protected IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<List<File>> GetAllFile()
        {
            return await _fileRepository.GetAllFile();
        }
        public async Task<List<File>> GetFileByBrandId(int id)
        {
            return await _fileRepository.GetFileByBrandId(id);
        }
        public async Task<List<File>> GetFileByCategoryId(int id)
        {
            return await _fileRepository.GetFileByCategoryId(id);
        }
        public async Task<File> GetFileById(int id)
        {
            return await _fileRepository.GetFileById(id);
        }
        public async Task<List<File>> GetFileByProductId(int id)
        {
            return await _fileRepository.GetFileByProductId(id);
        }
        public async Task<File> CreateFile(File file)
        {
            return await _fileRepository.CreateFile(file);
        }
        public async Task<File> UpdateFile(File file)
        {
            return await _fileRepository.UpdateFile(file);
        }
        public async Task DeleteFile(int id)
        {
            await _fileRepository.DeleteFile(id);
        }
    }
}
