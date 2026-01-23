using CleanArch.Application.DataBase.WorkTask.Commands.CreateWorkTask;
using CleanArch.Application.DataBase.WorkTask.Commands.UpdateWorkTask;
using CleanArch.Application.DataBase.WorkTask.Queries.GetAllWorkTasks;
using CleanArch.Application.Exceptions;
using CleanArch.Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class WorkTaskController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateWorkTaskModel model,
            [FromServices] ICreateWorkTaskCommand createWorkTaskCommand,
            [FromServices] IValidator<CreateWorkTaskModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createWorkTaskCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateWorkTaskModel model,
            [FromServices] IUpdateWorkTaskCommand updateCustomerCommand,
            [FromServices] IValidator<UpdateWorkTaskModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllWorkTasksQuery getAllWorkTasksQuery)
        {
            var data = await getAllWorkTasksQuery.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
