using Mediator;
using Microsoft.Extensions.Caching.Distributed;
using Movies.Data;
using Movies.Data.Settings;
using Movies.Features.Movies.Extensions;
using Movies.Features.Movies.Models;

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

