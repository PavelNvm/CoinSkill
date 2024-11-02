using CoinSkill.Core.Interfaces.Repositories;
using CoinSkill.Core.Models;
using CoinSkill.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.DataAccess.Repositories
{    
    public class CoinFlipRepository : ICoinFlipRepository
    {
        private readonly CoinSkillDbContext _context;

        public CoinFlipRepository(CoinSkillDbContext context)
        {
            _context = context;
        }
        public async Task<(CoinFlip, bool)> FlipACoinAndRecordIfNecessary(Guid userId, int streak)
        {
            var coinFlipEntity = await _context.CoinFlips.
                OrderByDescending(o=>o.Date).
                AsNoTracking().
                FirstOrDefaultAsync(o=>o.UserId== userId);
            if (coinFlipEntity!=null&&coinFlipEntity.Date == DateOnly.FromDateTime(DateTime.Now))
            {
                return (CoinFlip.Create(coinFlipEntity.Id, coinFlipEntity.UserId, coinFlipEntity.Date, coinFlipEntity.Streak), false);
            }
            else
            {
                coinFlipEntity = new CoinFlipEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Streak = streak,
                    Date = DateOnly.FromDateTime(DateTime.Now)
                };
                await _context.CoinFlips.AddAsync(coinFlipEntity);
                _context.SaveChanges();
                return (CoinFlip.Create(coinFlipEntity.Id, coinFlipEntity.UserId, coinFlipEntity.Date, coinFlipEntity.Streak), true);
            }
        }

        public async Task<List<CoinFlip>> GetLeaderboard(int quantity)
        {
            var leaderboardEntities = await _context.CoinFlips
                .AsNoTracking()
                .OrderByDescending(o => o.Streak)
                .Take(quantity)                
                .ToListAsync();
            
            var leaderboard = leaderboardEntities.Select(o=> CoinFlip.Create(o.Id,o.UserId,o.Date,o.Streak)).DistinctBy(o => o.UserId).ToList();
            return leaderboard;
        }
    }
}
