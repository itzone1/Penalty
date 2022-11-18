using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;
using Penalty.Penalty.Classes.Entities.Matches;
using Penalty.Penalty.Classes.Entities.MatchResults;
using Penalty.Penalty.Classes.RootEntities;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using Penalty.Penalty.Classes.RootEntities.Teams;
using Penalty.Penalty.Indexes.Clubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Penalty.Penalty.ODDSApiMatches.Services
{
    public class ODDSApiDomainService : IODDSApiDoaminService
    {
        private readonly IRepository<Match, Guid> _Matchrepository;
        private readonly IRepository<GeneralSettings, Guid> _generalSettingsRepository;
        private readonly IRepository<Team, Guid> _teamRepository;
        private readonly IRepository<MatchResult, Guid> _MatchResultrepository;
        private readonly IRepository<League, Guid> _Leaguesrepository;

        public ODDSApiDomainService(IRepository<Match, Guid> matchrepository, IRepository<MatchResult, Guid> matchResultrepository, IRepository<GeneralSettings, Guid> generalSettingsRepository, IRepository<Team, Guid> teamRepository, IRepository<League, Guid> leaguesrepository)
        {
            _Matchrepository = matchrepository;
            _MatchResultrepository = matchResultrepository;
            _generalSettingsRepository = generalSettingsRepository;
            _teamRepository = teamRepository;
            _Leaguesrepository = leaguesrepository;
        }

        public async Task GetAll()
        {
            try
            {
                    var generalSettings = _generalSettingsRepository.GetAll().FirstOrDefault();
                    List<string> Sportnames = _Leaguesrepository.GetAll().Select(x => x.LeagueApiKey).ToList();
                    var teams = _teamRepository.GetAll();
                    var leagues = _Leaguesrepository.GetAll();
                    var matchReses = _MatchResultrepository.GetAll();
                    List<ODDSMatch> oDDSMatch = new List<ODDSMatch>();
                    foreach (var leagueKey in Sportnames)
                    {
                        string SportName = leagueKey;
                        using (var _httpClient = new HttpClient())
                        {

                            var res = await _httpClient.GetAsync("https://api.the-odds-api.com" + "/v4/sports/" + SportName + "/scores/?apiKey=" + generalSettings.ApiKey + "&daysFrom=3&dateFormat=iso");
                            var JsonResponse = await res.Content.ReadAsStringAsync();
                            oDDSMatch = JsonSerializer.Deserialize<List<ODDSMatch>>(JsonResponse);


                        };
                        foreach (var oddsMatch in oDDSMatch)
                        {
                            var resExist = matchReses.Where(x => x.MatchId == Guid.Parse(oddsMatch.Id)).Count()>0;
                            var match = new Match()
                            {
                                Id = Guid.Parse(oddsMatch.Id),
                                Name = oddsMatch.HomeTeam + " - " + oddsMatch.AwayTeam,
                                AwayTeam = teams.FirstOrDefault(x => x.Name == oddsMatch.AwayTeam),
                                HomeTeam = teams.FirstOrDefault(x => x.Name == oddsMatch.HomeTeam),
                                League = leagues.FirstOrDefault(x => x.LeagueApiKey == SportName),
                                ODD = generalSettings.DefaultODD,
                                ExpectedEndingTime = oddsMatch.CommenceTime.AddMinutes(105),
                                MatchDate = oddsMatch.CommenceTime,
                                StartingTime = oddsMatch.CommenceTime,
                                MatchStatus = oddsMatch.Completed ? Enums.MatchStatus.Finished : oddsMatch.CommenceTime < DateTime.Now ? Enums.MatchStatus.Pending : Enums.MatchStatus.NotStarted,
                            };
                            _Matchrepository.InsertOrUpdate(match);
                            if (match.MatchStatus == Enums.MatchStatus.Finished && !resExist)
                            {
                                var matchRes = new MatchResult()
                                {
                                    AwayTeamScore = oddsMatch.Scores.FirstOrDefault(x => x.TeamName == oddsMatch.AwayTeam).TeamScore,
                                    HomeTeamScore = oddsMatch.Scores.FirstOrDefault(x => x.TeamName == oddsMatch.HomeTeam).TeamScore,
                                    Match = match,
                                };
                                _MatchResultrepository.Insert(matchRes);
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }
    }
}
