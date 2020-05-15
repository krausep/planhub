using PlanHub.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanHub.Domain.Repositories
{
    public interface ITeamMemberRepository
    {
        Task<TeamMember> GetTeamMemberAsync(Guid teamMemberId);

        Task<List<TeamMember>> GetTeamMembersByTeamIdAsync(Guid teamId);

        Task UpdateAsync(TeamMember teamMember);
    }
}
