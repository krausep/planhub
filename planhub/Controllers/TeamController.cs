using Kledex.Queries;
using Microsoft.AspNetCore.Mvc;
using PlanHub.ReadModels.Teams;
using System;
using System.Threading.Tasks;

namespace PlanHub.WebApi.Controllers
{
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IQueryHandlerAsync<GetTeamQuery, GetTeamReadModel> _teamQueryHandlerAsync;

        public TeamController(IQueryHandlerAsync<GetTeamQuery, GetTeamReadModel> teamQueryHandlerAsync)
        {
            _teamQueryHandlerAsync = teamQueryHandlerAsync;
        }

        [HttpGet]
        [Route("/api/team/{teamId}")]
        public async Task<IActionResult> GetTeam(Guid teamId)
        {
            var result = await _teamQueryHandlerAsync.HandleAsync(new GetTeamQuery(teamId));
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/team/{teamId}/add")]
        public async Task<IActionResult> AddTeamMemberToTeam(Guid teamId, string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
