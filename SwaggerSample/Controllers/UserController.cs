using Microsoft.AspNetCore.Mvc;
using SwaggerSample.Core;
using SwaggerSample.Data;

namespace SwaggerSample.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/users
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        try
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest($"Errore: {ex.Message}");
        }
    }

    // GET: api/users/{id}
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        try
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("Utente non trovato");
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest($"Errore: {ex.Message}");
        }
    }

    // POST: api/users
    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return BadRequest("Dati utente non validi");
            }

            _userService.CreateUser(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return BadRequest($"Errore: {ex.Message}");
        }
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        try
        {
            if (user == null || id != user.Id)
            {
                return BadRequest("Dati utente non validi");
            }

            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound("Utente non trovato");
            }

            _userService.UpdateUser(user);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Errore: {ex.Message}");
        }
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound("Utente non trovato");
            }

            _userService.DeleteUser(id);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Errore: {ex.Message}");
        }
    }
}
