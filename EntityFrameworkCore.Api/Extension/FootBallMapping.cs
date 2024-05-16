using AutoMapper;
using EntityFrameworkCore.Api.DTO;
using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.Response;

namespace EntityFrameworkCore.Api.Extension;

public class FootBallMapping : Profile
{
    public FootBallMapping()
    {
        CreateMap<LeagueDto, League>();
        CreateMap<League,LeagueList>();
        CreateMap<League,LeagueDetails>();
    }
}
