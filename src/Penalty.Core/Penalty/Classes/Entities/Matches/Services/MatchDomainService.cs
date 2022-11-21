using Abp.Configuration.Startup;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.RootEntities;
using Penalty.Penalty.InvitedUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.Matches.Services
{
    public class MatchDomainService : IMatchDomainService
    {
        private readonly IRepository<Match, Guid> _repository;

        public MatchDomainService(IRepository<Match, Guid> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public IList<Match> GetAll()
        {
            CheckEndings();
            return _repository.GetAllIncluding(x => x.League, x => x.HomeTeam.Country, x => x.AwayTeam.Club).ToList();
        }

        public IList<Match> GetAllFinishedMatches()
        {
            CheckEndings();
            return _repository.GetAllIncluding(x => x.League, x => x.HomeTeam.Country, x => x.AwayTeam.Club).Where(x => x.MatchStatus == Enums.MatchStatus.Finished).ToList();
        }

        public async Task<IList<Match>> GetAllMatchesAsync()
        {
            await CheckEndings();
            return await _repository.GetAllListAsync();
        }

        public IList<Match> GetAllNotStartedMatches()
        {
            CheckEndings();
            return _repository.GetAllIncluding(x => x.League, x => x.HomeTeam.Country, x => x.AwayTeam.Club).Where(x=> x.MatchStatus == Enums.MatchStatus.NotStarted).ToList();
        }

        public IList<Match> GetAllPendingMatches()
        {
            CheckEndings();
            return _repository.GetAllIncluding(x => x.League, x => x.HomeTeam.Country, x => x.AwayTeam.Club).Where(x => x.MatchStatus == Enums.MatchStatus.Pending).ToList();
        }

        public async Task<Match> GetbyId(Guid id)
        {
            CheckEndings();
            return _repository.GetAllIncluding(x => x.League, x => x.HomeTeam.Country, x => x.AwayTeam.Club).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Match> Insert(Match match)
        {
            return await _repository.InsertAsync(match);
        }

        public async Task<Match> Update(Match match)
        {
            return await _repository.InsertOrUpdateAsync(match);
        }

        public async Task<bool> CheckEndings()
        {
          var matches = _repository.GetAllIncluding(x => x.League, x => x.HomeTeam.Country, x => x.AwayTeam.Club).Where(x => x.MatchStatus == Enums.MatchStatus.NotStarted).ToList();
            foreach(var match in matches)
            {
                if(match.StartingTime < DateTime.Now)
                {
                    match.MatchStatus = Enums.MatchStatus.Pending;
                    await _repository.UpdateAsync(match);
                }
            }
            return true;
        }
     
    }
}
