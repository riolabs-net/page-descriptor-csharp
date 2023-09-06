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
    [ProducesResponseType(typeof(IEnumerable<User>), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
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
    [ProducesResponseType(typeof(User), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
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
    [ProducesResponseType(typeof(User), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
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
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
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
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
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
