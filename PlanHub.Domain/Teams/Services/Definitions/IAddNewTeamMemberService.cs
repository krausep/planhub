using System;
using System.Threading.Tasks;

namespace PlanHub.Domain.Teams.Services.Definitions
{
    public interface IAddNewTeamMemberService
    {
        Task AddTeamMemberToTeam(Guid teamId, Guid teamMemberId);
    }
}
