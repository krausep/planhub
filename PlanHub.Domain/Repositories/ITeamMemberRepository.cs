using PlanHub.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanHub.Domain.Repositories
{
    public interface ITeamMemberRepository
    {
        Task<TeamMember> GetTeamMember(Guid teamMemberId);

        Task<List<TeamMember>> GetTeamMembersByTeamId(Guid teamId);
    }
}
