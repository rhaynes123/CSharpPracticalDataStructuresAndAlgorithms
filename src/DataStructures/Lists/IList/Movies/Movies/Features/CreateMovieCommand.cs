using System;
using Mediator;
using Movies.Features.Models;

namespace Movies.Features;

public sealed record CreateMovieCommand(Movie movie): INotification;

