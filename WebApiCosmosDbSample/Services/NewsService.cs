using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCosmosDbSample.Data;
using WebApiCosmosDbSample.Data.Entities;

namespace WebApiCosmosDbSample.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationContext _context;

        public NewsService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<News> AddNewsAsync(string body, string photoUrl)
        {
            var news = new News
            {
                Body = body,
                PhotoUrl = photoUrl
            };

            await _context.News.AddAsync(news);
            var success = await _context.SaveChangesAsync();
            if(success == 1)
            {
                return news;
            }

            return null;
        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            var news = await _context.News.ToListAsync();
            if (news != null)
                return news;
            return null;
        }

        public async Task<News> GetNewsByIdAsync(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
                return news;
            return null;
        }
    }
}
