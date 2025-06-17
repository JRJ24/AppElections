using AutoMapper;
using Sadvo.Application.DTOs.Candidatos;
using Sadvo.Application.DTOs.Citizens;
using Sadvo.Application.DTOs.Election;
using Sadvo.Application.DTOs.ElectivePositions;
using Sadvo.Application.DTOs.PartyPolitical;
using Sadvo.Application.DTOs.PoliticalLeader;
using Sadvo.Application.DTOs.Roles;
using Sadvo.Application.DTOs.RolUsers;
using Sadvo.Application.DTOs.Users;
using Sadvo.Application.DTOs.Votes;
using Sadvo.Domain.Entities.Configuration;
using Sadvo.Domain.Entities.Elections;
using Sadvo.Domain.Entities.ElectionsVotes;
using Sadvo.Domain.Entities.ElectionsVotes.Citizen;
using Sadvo.Domain.Entities.Security;

namespace Sadvo.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            // Users Mapping
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<Users, SaveUsersDTO>().ReverseMap();
            CreateMap<Users, UpdateUsersDTO>().ReverseMap();
            CreateMap<Users, DeleteUsersDTO>().ReverseMap();
            CreateMap<Users, LoginDTO>().ReverseMap();

            // Candidatos Mappings
            CreateMap<Candidatos, CandidatosDTO>().ReverseMap();
            CreateMap<Candidatos, SaveCandidatosDTO>().ReverseMap();
            CreateMap<Candidatos, UpdateCandidatosDTO>().ReverseMap();
            CreateMap<Candidatos, DeleteCandidatosDTO>().ReverseMap();

            // PartyPolitical Mappings
            CreateMap<PartyPolitical, PartyPoliticalDTO>().ReverseMap();
            CreateMap<PartyPolitical, SavePartyPoliticalDTO>().ReverseMap();
            CreateMap<PartyPolitical, UpdatePartyPoliticalDTO>().ReverseMap();
            CreateMap<PartyPolitical, DeletePartyPoliticalDTO>().ReverseMap();

            // Citizens Mappings
            CreateMap<Citizens, CitizensDTO>().ReverseMap();
            CreateMap<Citizens, SaveCitizensDTO>().ReverseMap();
            CreateMap<Citizens, UpdateCitizensDTO>().ReverseMap();
            CreateMap<Citizens, DeleteCitizensDTO>().ReverseMap();

            //Election
            CreateMap<Election, ElectionDTO>().ReverseMap();
            CreateMap<Election, SaveElectionDTO>().ReverseMap();
            CreateMap<Election, UpdateElectionDTO>().ReverseMap();
            CreateMap<Election, DeleteElectionDTO>().ReverseMap();

            //ElectivePositions Mappings
            CreateMap<ElectivePositions, ElectivePositionsDTO>().ReverseMap();
            CreateMap<ElectivePositions, SaveElectivePositionsDTO>().ReverseMap();
            CreateMap<ElectivePositions, UpdateElectivePositionsDTO>().ReverseMap();
            CreateMap<ElectivePositions, DeleteElectivePositionsDTO>().ReverseMap();

            //PoliticalLeader Mappings
            CreateMap<PoliticalLeader, PoliticalLeaderDTO>().ReverseMap();
            CreateMap<PoliticalLeader, SavePoliticalLeaderDTO>().ReverseMap();
            CreateMap<PoliticalLeader, UpdatePoliticalLeaderDTO>().ReverseMap();
            CreateMap<PoliticalLeader, DeletePoliticalLeaderDTO>().ReverseMap();

            //RolUsers
            CreateMap<RolUsers, RolUsersDTO>().ReverseMap();
            CreateMap<RolUsers, SaveRolUsersDTO>().ReverseMap();
            CreateMap<RolUsers, UpdateRolUsersDTO>().ReverseMap();
            CreateMap<RolUsers, DeleteRolUsersDTO>().ReverseMap();

            //Roles
            CreateMap<Roles, RolesDTO>().ReverseMap();
            CreateMap<Roles, SaveRolesDTO>().ReverseMap();
            CreateMap<Roles, UpdateRolesDTO>().ReverseMap();
            CreateMap<Roles, DeleteRolesDTO>().ReverseMap();

            //Votes
            CreateMap<Votes, VotesDTO>().ReverseMap();
            CreateMap<Votes, SaveVotesDTO>().ReverseMap();
        }

    }
}
