using Kledex.Queries;
using Microsoft.AspNetCore.Mvc;
using PlanHub.ReadModels.Teams;
using System.Threading.Tasks;

namespace PlanHub.WebApi.Controllers
{
    [ApiController]
    [Route("/api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly IQueryHandlerAsync<GetTeamsQuery, GetTeamsReadModel> _teamsQueryHandler;
        public TeamsController(IQueryHandlerAsync<GetTeamsQuery, GetTeamsReadModel> teamsQueryHandler)
        {
            _teamsQueryHandler = teamsQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var results = await _teamsQueryHandler.HandleAsync(new GetTeamsQuery());

            return Ok(results);
        }
    }
}
