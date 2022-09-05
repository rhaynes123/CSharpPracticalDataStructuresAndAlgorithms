using System;
using MediatR;
using Movies.Features.Models;

namespace Movies.Features;

public record CreateMovieCommand(Movie movie): IRequest<Movie>;

