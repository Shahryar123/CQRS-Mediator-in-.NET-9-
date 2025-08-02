using MediatR;

namespace CQRS_and_Mediator.Features.Player.GetPlayerById
{
    //public class GetPlayerByIdQuery : IRequest<Entities.Player>
    //{        
    //    public int Id { get; set; }
    //    public GetPlayerByIdQuery(int id)
    //    {
    //        Id = id;
    //    }
    //}

    public record GetPlayerByIdQuery(int Id) : IRequest<Entities.Player?>;
}
