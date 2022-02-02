using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface IFileService
    {
        Task<List<File>> GetAllFile();
        Task<File> GetFileById(int id);
        Task<List<File>> GetFileByCategoryId(int id);
        Task<List<File>> GetFileByBrandId(int id);
        Task<List<File>> GetFileByProductId(int id);
        Task<File> CreateFile(File file);
        Task<File> UpdateFile(File file);
        Task DeleteFile(int id);
    }
}
