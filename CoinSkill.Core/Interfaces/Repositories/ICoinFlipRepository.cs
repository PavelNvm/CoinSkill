using CoinSkill.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.Core.Interfaces.Repositories
{
    public interface ICoinFlipRepository
    {
        Task<(CoinFlip, bool)> FlipACoinAndRecordIfNecessary(Guid userId,int streak);
        Task<List<CoinFlip>> GetLeaderboard(int quantity);
    }
}
