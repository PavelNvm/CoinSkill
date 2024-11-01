using CoinSkill.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.Core.Interfaces.Services
{
    public interface ICoinFlipService
    {
        Task<(CoinFlip, bool)> FlipMyltipleCoins(Guid userID);
        Task<List<CoinFlip>> GetLeaderboard(int quantity);
    }
}
