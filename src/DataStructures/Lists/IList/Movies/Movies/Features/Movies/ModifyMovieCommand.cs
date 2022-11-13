using System;
using Mediator;
using Movies.Features.Movies.Models;

namespace Movies.Features;

public record ModifyMovieCommand(Movie movie): IRequest<Movie>;

