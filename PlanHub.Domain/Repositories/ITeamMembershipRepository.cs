using PlanHub.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanHub.Domain.Repositories
{
    public interface ITeamMembershipRepository
    {
        Task<List<TeamMembership>> GetTeamMembershipByTeamIdAsync(Guid teamId);

        Task<TeamMembership> GetTeamMembershipByTeamMemberId(Guid teamMemberId);
    }
}
