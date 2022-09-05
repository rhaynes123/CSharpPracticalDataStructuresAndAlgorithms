using System;
using MediatR;
using Movies.Features.Models;

namespace Movies.Features;

public record ModifyMovieCommand(Movie movie): IRequest<Movie>;

