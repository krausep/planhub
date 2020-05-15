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
        private readonly ITeamMemberRepository _teamMemberRepository;
        public AddNewTeamMemberService(ITeamRepository teamRepository, ITeamMemberRepository teamMemberRepository)
        {
            _teamRepository = teamRepository;
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task AddTeamMemberToTeam(Guid teamId, Guid teamMemberId)
        {
            var teamMember = await _teamMemberRepository.GetTeamMemberAsync(teamMemberId);

            if(teamMember.TeamId == teamId)
            {
                throw new DomainValidationException($"Team member {teamMemberId} already belongs to this team.");
            }

            var team = await _teamRepository.GetByTeamId(teamId);
            teamMember.ChangeTeam(teamId);
            await _teamMemberRepository.UpdateAsync(teamMember);
        }
    }
}
