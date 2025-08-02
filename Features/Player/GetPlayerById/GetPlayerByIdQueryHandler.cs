using CQRS_and_Mediator.Data;
using MediatR;

namespace CQRS_and_Mediator.Features.Player.GetPlayerById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Entities.Player>
    {
        private readonly VideoGameAppDBContext _context;
        public GetPlayerByIdQueryHandler(VideoGameAppDBContext context)
        {
            _context = context;
        }
        public async Task<Entities.Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the player by ID from the database
            var player = await _context.Players.FindAsync(request.Id);
            return player;
        }
    }
}
