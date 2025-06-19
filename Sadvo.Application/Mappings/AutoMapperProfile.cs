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
using Sadvo.Application.ViewModels.Candidatos;
using Sadvo.Application.ViewModels.Citizens;
using Sadvo.Application.ViewModels.ElectivePositions;
using Sadvo.Application.ViewModels.PartyPolitical;
using Sadvo.Application.ViewModels.PoliticalLeader;
using Sadvo.Application.ViewModels.Roles;
using Sadvo.Application.ViewModels.RolUser;
using Sadvo.Application.ViewModels.Users;
using Sadvo.Application.ViewModels.Votes;
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

            CreateMap<UsersDTO, UsersViewModel>()
                .ForMember(dest => dest.fullName, opt => opt.MapFrom(src => $"{src.Name} {src.lastname}"))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.isActive ? "Activo" : "Inactivo"));

            CreateMap<SaveUsersDTO, CreateUserViewModel>().ReverseMap();
            CreateMap<UpdateUsersDTO, UpdateUserViewModel>().ReverseMap();
            CreateMap<DeleteUsersDTO, UserDeleteViewModel>().ReverseMap();
            CreateMap<LoginDTO, LoginUserViewModel>().ReverseMap();

            // Candidatos Mappings
            CreateMap<Candidatos, CandidatosDTO>().ReverseMap();
            CreateMap<Candidatos, SaveCandidatosDTO>().ReverseMap();
            CreateMap<Candidatos, UpdateCandidatosDTO>().ReverseMap();
            CreateMap<Candidatos, DeleteCandidatosDTO>().ReverseMap();

            CreateMap<CandidatosDTO, CandidatosViewModels>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.lastname}"))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.isActive ? "Activo" : "Inactivo"))
                .ForMember(dest => dest.Asociado, opt => opt.MapFrom(src => src.isAssocciate ? "Asociado" : "No Asociado"));

            CreateMap<SaveCandidatosDTO, CreateCandidatosViewModel>().ReverseMap();
            CreateMap<UpdateCandidatosDTO, UpdateCandidatosViewModel>().ReverseMap();
            CreateMap<DeleteCandidatosDTO, DeleteCandidatosViewModel>().ReverseMap();


            // PartyPolitical Mappings
            CreateMap<PartyPolitical, PartyPoliticalDTO>().ReverseMap();
            CreateMap<PartyPolitical, SavePartyPoliticalDTO>().ReverseMap();
            CreateMap<PartyPolitical, UpdatePartyPoliticalDTO>().ReverseMap();
            CreateMap<PartyPolitical, DeletePartyPoliticalDTO>().ReverseMap();

            CreateMap<PartyPoliticalDTO, PartyPoliticalViewModels>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.isActive ? "Activo" : "Inactivo"));

            CreateMap<SavePartyPoliticalDTO, CreatePartyPoliticalViewModel>().ReverseMap();
            CreateMap<UpdatePartyPoliticalDTO, UpdatePartyPoliticalViewModel>().ReverseMap();
            CreateMap<DeletePartyPoliticalDTO, DeletePartyPoliticalViewModel>().ReverseMap();

            // Citizens Mappings
            CreateMap<Citizens, CitizensDTO>().ReverseMap();
            CreateMap<Citizens, SaveCitizensDTO>().ReverseMap();
            CreateMap<Citizens, UpdateCitizensDTO>().ReverseMap();
            CreateMap<Citizens, DeleteCitizensDTO>().ReverseMap();

            CreateMap<CitizensDTO, CitizensViewModel>()
                .ForMember(dest => dest.isVoted, opt => opt.MapFrom(src => src.isVoted ? "Voto" : "NoVoto"))
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.isActive ? "Activo" : "Inactivo"));

            CreateMap<SaveCandidatosDTO, CreateCitizensViewModel>().ReverseMap();
            CreateMap<UpdateCitizensDTO,  UpdateCitizensViewModel>().ReverseMap();
            CreateMap<DeleteCitizensDTO, DeleteCitizensViewModel>().ReverseMap();

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

            CreateMap<ElectivePositionsDTO, ElectivePositionsViewModel>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.isActive ? "Activo" : "Inactivo"));

            CreateMap<SaveElectivePositionsDTO, CreateElectivePositionsViewModel>().ReverseMap();
            CreateMap<UpdateElectivePositionsDTO, UpdateElectivePositionsViewModel>().ReverseMap();
            CreateMap<DeleteElectivePositionsDTO, DeleteElectivePositionsViewModel>().ReverseMap();


            //PoliticalLeader Mappings
            CreateMap<PoliticalLeader, PoliticalLeaderDTO>().ReverseMap();
            CreateMap<PoliticalLeader, SavePoliticalLeaderDTO>().ReverseMap();
            CreateMap<PoliticalLeader, UpdatePoliticalLeaderDTO>().ReverseMap();
            CreateMap<PoliticalLeader, DeletePoliticalLeaderDTO>().ReverseMap();

            CreateMap<PoliticalLeaderDTO, PoliticalLeaderViewModel>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.isActive ? "Activo" : "Inactivo"));

            CreateMap<SavePoliticalLeaderDTO, CreatePoliticalLeaderViewModel>().ReverseMap();
            CreateMap<UpdatePoliticalLeaderDTO, UpdatePoliticalLeaderViewModel>().ReverseMap();
            CreateMap<DeletePoliticalLeaderDTO, DeletePoliticalLeaderViewModel>().ReverseMap();

            //RolUsers
            CreateMap<RolUsers, RolUsersDTO>().ReverseMap();
            CreateMap<RolUsers, SaveRolUsersDTO>().ReverseMap();
            CreateMap<RolUsers, UpdateRolUsersDTO>().ReverseMap();
            CreateMap<RolUsers, DeleteRolUsersDTO>().ReverseMap();

            CreateMap<RolUsersDTO, RolUserViewModel>()
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.isActive ? "Activo" : "Inactivo"));

            CreateMap<SaveRolUsersDTO, CreateRolUserViewModel>().ReverseMap();
            CreateMap<UpdateRolUsersDTO, UpdateRolUserViewModel>().ReverseMap();
            CreateMap<DeleteRolesDTO, DeleteRolUserViewModel>().ReverseMap();


            //Roles
            CreateMap<Roles, RolesDTO>().ReverseMap();
            CreateMap<Roles, SaveRolesDTO>().ReverseMap();
            CreateMap<Roles, UpdateRolesDTO>().ReverseMap();
            CreateMap<Roles, DeleteRolesDTO>().ReverseMap();

            //Votes
            CreateMap<Votes, VotesDTO>().ReverseMap();
            CreateMap<Votes, SaveVotesDTO>().ReverseMap();
            CreateMap<Votes, UpdateVotesDTO>().ReverseMap();
            CreateMap<Votes, InvalidVotesDTO>().ReverseMap();
            CreateMap<VotesDTO, VotesViewModel>().ReverseMap();
            CreateMap<SaveVotesViewModel, SaveVotesDTO>().ReverseMap();
        }

    }
}
