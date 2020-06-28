using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCosmosDbSample.Data.Entities;

namespace WebApiCosmosDbSample.Services
{
    public interface INewsService
    {
        Task<News> AddNewsAsync(string body, string photoUrl);
        Task<List<News>> GetAllNewsAsync();
        Task<News> GetNewsByIdAsync(Guid id);
    }
}
