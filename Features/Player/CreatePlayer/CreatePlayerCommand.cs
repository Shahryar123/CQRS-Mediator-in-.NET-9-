using MediatR;

namespace CQRS_and_Mediator.Features.Player.CreatePlayer
{
    //public class CreatePlayerCommand :IRequest<int>
    //{
    //    public string Name { get; set; }
        
    //    public int Level { get; set; }
    //}

    public record CreatePlayerCommand(string Name, int Level) : IRequest<int>
    {
        // The record type automatically provides the necessary properties and constructor.
        // No need to define them explicitly.
    }
}
