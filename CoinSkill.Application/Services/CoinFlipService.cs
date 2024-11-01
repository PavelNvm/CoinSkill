using CoinSkill.Core.Interfaces.Repositories;
using CoinSkill.Core.Interfaces.Services;
using CoinSkill.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoinSkill.Application.Services
{
    public class CoinFlipService : ICoinFlipService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICoinFlipRepository _coinFlipRepository;
        public CoinFlipService(IUsersRepository usersRepository,
        ICoinFlipRepository coinFlipRepository)
        {
            _usersRepository = usersRepository;
            _coinFlipRepository = coinFlipRepository;
        }


        public async Task<(CoinFlip, bool)> FlipMyltipleCoins(Guid userID)
        {
            int streak = 0;
            bool moreThan50 = true;
            (CoinFlip, bool) result;
            while(moreThan50)
            {
                if(RandomNumberGenerator.GetInt32(100)+1>50)
                {                    
                    streak++;
                }
                else 
                { 
                    moreThan50 = false;
                }
            }
            result = await _coinFlipRepository.FlipACoinAndRecordIfNecessary(userID,streak);
            if(result.Item2)
            {
                await _usersRepository.AddNewFlip(result.Item1);
            }
            return result;
        }
        public async Task<List<CoinFlip>> GetLeaderboard(int quantity)
        {
            return await _coinFlipRepository.GetLeaderboard(quantity);
        }
    }
}
