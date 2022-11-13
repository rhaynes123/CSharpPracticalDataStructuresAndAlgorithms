using Mediator;
using Movies.Data;

namespace Movies.Features.Movies
{
    public class CreateMovieCommandHandler : INotificationHandler<CreateMovieCommand>
    {
        private readonly MovieDbContext _context;
        public CreateMovieCommandHandler(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async ValueTask Handle(CreateMovieCommand notification, CancellationToken cancellationToken)
        {
            await _context.Movies.AddAsync(notification.movie, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

