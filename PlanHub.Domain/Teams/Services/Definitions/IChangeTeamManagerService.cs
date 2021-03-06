﻿using System;
using System.Threading.Tasks;

namespace PlanHub.Domain.Teams.Services.Definitions
{
    public interface IChangeTeamManagerService
    {
        Task ChangeTeamManager(Team team, Guid newTeamManagerId);
    }
}
