/*
 * Expeneses API
 *
 * API providing data for expeneses new project|
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: tomerk@kkl.org.il
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using amitalTest.Attributes;
using amitalTest.Models;
using amitalTest.Repositories;

namespace amitalTest.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class TodoApiController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoApiController(ITodoRepository repository)
        {
            _repository = repository;
        }
        /// <summaryITodoRepository
        /// Add task
        /// </summary>
        /// <param name="itemTodo"></param>
        /// <response code="200">successful operation</response>
        /// <response code="400">If any data is incorrect</response>
        /// <response code="500">If any server Error</response>
        [HttpPost]
        [Route("/task")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("AddTask")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ItemTodo>), description: "successful operation")]
        public virtual async Task<IActionResult> AddTask([FromBody]ItemTodo? itemTodo)
        {
            return Ok(await _repository.AddTask(itemTodo));
        }

        /// <summary>
        /// get all task by userId
        /// </summary>
        /// <param name="userId">a user id</param>
        /// <response code="200">OK</response>
        /// <response code="400">If any data is incorrect</response>
        /// <response code="500">If any server Error</response>
        [HttpGet]
        [Route("/task/GetSumOfTask/{userId}")]
        [ValidateModelState]
        [SwaggerOperation("GetSumOfTaskByUserId")]
        [SwaggerResponse(statusCode: 200, type: typeof(int), description: "OK")]
        public virtual async Task<IActionResult> GetSumOfTaskByUserId([FromRoute (Name = "userId")][Required]int userId)
        {

            return Ok(await _repository.GetSumOfTaskByUserId(userId));
        }

        /// <summary>
        /// Get list of task
        /// </summary>
        /// <remarks>get the list of all task on the system</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">If any data is incorrect</response>
        /// <response code="500">If any server Error</response>
        [HttpGet]
        [Route("/task")]
        [ValidateModelState]
        [SwaggerOperation("GetTaskList")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ItemTodo>), description: "successful operation")]
        public virtual async Task<IActionResult> GetTaskList()
        {
            return Ok(await _repository.GetTaskList());
        }
    }
}