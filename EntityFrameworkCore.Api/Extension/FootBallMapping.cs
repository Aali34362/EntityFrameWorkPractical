using AutoMapper;
using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.Response;

namespace EntityFrameworkCore.Api.Extension;

public class FootBallMapping : Profile
{
    public FootBallMapping()
    {
        CreateMap<League,LeagueList>();
        CreateMap<League,LeagueDetails>();
    }
}
