using CQRS_and_Mediator.Data;
using MediatR;

namespace CQRS_and_Mediator.Features.Player.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly VideoGameAppDBContext _context;
        public CreatePlayerCommandHandler(VideoGameAppDBContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Entities.Player
            {
                Name = request.Name,
                Level = request.Level
            };
            _context.Players.Add(player);
            await _context.SaveChangesAsync(cancellationToken);
            return player.Id; // Return the ID of the newly created player
        }
    }
    
}
