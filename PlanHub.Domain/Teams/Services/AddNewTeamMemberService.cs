using PlanHub.Domain.Exceptions;
using PlanHub.Domain.Repositories;
using PlanHub.Domain.Teams.Services.Definitions;
using System;
using System.Threading.Tasks;

namespace PlanHub.Domain.Teams.Services
{
    public class AddNewTeamMemberService : IAddNewTeamMemberService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamMembershipRepository _teamMembershipRepository;
        public AddNewTeamMemberService(ITeamRepository teamRepository, ITeamMembershipRepository teamMembershipRepository)
        {
            _teamRepository = teamRepository;
            _teamMembershipRepository = teamMembershipRepository;
        }

        public async Task AddTeamMemberToTeam(Guid teamId, Guid teamMemberId)
        {
            var existingTeamMembership = await _teamMembershipRepository.GetTeamMembershipByTeamMemberId(teamMemberId);
            if(existingTeamMembership != null)
            {
                throw new DomainValidationException($"Team member {teamMemberId} already belongs to a team.");
            }

            if(existingTeamMembership.TeamId == teamId)
            {
                throw new DomainValidationException($"Team member {teamMemberId} already belongs to this team.");
            }

            var team = await _teamRepository.GetByTeamId(teamId);
            team.AddNewTeamMember(teamMemberId);
            await _teamRepository.Update(team);
        }
    }
}
