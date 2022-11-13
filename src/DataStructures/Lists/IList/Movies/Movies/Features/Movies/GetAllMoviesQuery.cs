using System;
using Mediator;
using Movies.Features.Movies.Models;

namespace Movies.Features
{
    public sealed record GetAllMoviesQuery() : IQuery<IQueryable<Movie>>;
}

