using System;
using MediatR;
using Movies.Features.Models;

namespace Movies.Features
{
    public record GetAllMoviesQuery() : IRequest<IQueryable<Movie>>;
}

