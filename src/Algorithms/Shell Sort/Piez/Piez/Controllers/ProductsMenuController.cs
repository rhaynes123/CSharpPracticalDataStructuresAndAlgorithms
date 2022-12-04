using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Piez.Features.Menu.Models;
using Piez.Features.Menu.Repositories;
using Piez.Features.Products.Entity;

namespace Piez.Controllers;
#region
/*
 * https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0
 * https://localhost:7059/swagger/index.html
 * https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
 * https://rehansaeed.com/migrating-to-entity-framework-core-seed-data/
 * https://garywoodfine.com/how-to-seed-your-ef-core-database/
 */
#endregion

[Route("[controller]")]
[ApiController]
public class ProductsMenuController : ControllerBase
{
    private readonly IProductMenuRepository _menuRepository;
    public ProductsMenuController(IProductMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Menu), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var menu = await _menuRepository.GetProductMenuAsync();

        return Ok(menu);
    }
}
