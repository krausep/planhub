﻿using Kledex.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanHub.ReadModels.Okrs;
using PlanHub.ReadModels.Okrs.ReadModels;
using System;
using System.Threading.Tasks;

namespace PlanHub.WebApi.Controllers
{
    [ApiController]
    public class OkrController : ControllerBase
    {
        private readonly ILogger<OkrController> _logger;
        private readonly IQueryHandlerAsync<GetOkrsForTeamQuery, GetOkrsForTeamReadModel> _okrQueryHandler;

        public OkrController(ILogger<OkrController> logger, IQueryHandlerAsync<GetOkrsForTeamQuery, GetOkrsForTeamReadModel> okrQueryHandler)
        {
            _logger = logger;
            _okrQueryHandler = okrQueryHandler;
        }

        [HttpGet("api/okrs/team/{teamId}")]
        public async Task<IActionResult> GetOkrsForTeam(Guid teamId)
        {
            _logger.LogDebug($"Handling GET request for teamId {teamId}");
            var results = await _okrQueryHandler.HandleAsync(new GetOkrsForTeamQuery(teamId));

            return Ok(results);
        }
    }
}
