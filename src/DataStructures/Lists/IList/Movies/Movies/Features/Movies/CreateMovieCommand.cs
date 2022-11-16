using System;
using Mediator;
using Movies.Features.Movies.Models;

namespace Movies.Features.Movies;

public sealed record CreateMovieCommand(Movie movie): ICachable;

