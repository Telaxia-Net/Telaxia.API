using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Resources;

namespace texlaxia_backend.Telaxia.Controllers;

[Route("/api/v1/[controller]")]
public class UsersController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public UsersController(IUserService UserService, IMapper mapper)
    {
        _userService = UserService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveUserResource, User>(resource);

        var result = await _userService.SaveAsync(user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsyncData(int id, [FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveUserResource, User>(resource);

        var result = await _userService.UpdateAsync(id, user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }
}