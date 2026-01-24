using CleanArch.Application.DataBase.Category.Commands.CreateCategory;
using CleanArch.Application.DataBase.Category.Queries.GetAllCategories;
using CleanArch.Application.Exceptions;
using CleanArch.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CategoryController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCategoryModel model,
            [FromServices] ICreateCategoryCommand createCategoryCommand,
            [FromServices] IValidator<CreateCategoryModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createCategoryCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllCategoriesQuery getAllCategoriesQuery)
        {
            var data = await getAllCategoriesQuery.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
