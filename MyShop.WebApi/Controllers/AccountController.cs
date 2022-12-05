using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Domain.Services;
using MyShop.Domain.Services.Interfaces;
using MyShop.Models;
using MyShop.Models.Requests;
using MyShop.Models.Responses;

namespace MyShop.WebApi.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountServices _accountService;
    public AccountController(
        IAccountRepository accountRepository,
        IAccountServices accountService
        )
    {
        _accountRepository = accountRepository;
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<Account>> Register(RegisterRequest model) //[FromBody]
    {
        try
        {
            return await _accountService.Register(model.Email,model.Name,model.Password);
        }
        catch (EmailAlreadyExistException ex)
        {
            return BadRequest(new
            {
                ex.Message,
                model.Email
            });
        }
    }

    [HttpPost("delete_account")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        await _accountRepository.DeleteById(id);
        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<LogInResponse>> LogIn(LogInRequest request)
    {
        
        try
        {
            var (account, token) = await _accountService.LogIn(request.Email, request.Password);
            return new LogInResponse { AccountIn = account, Token = token };
        }
        catch (EmailUnregisteredException)
        {
            return new LogInResponse();
        }
        catch (IncorrectPasswordException)
        {
            return new LogInResponse();
        }

    }    
    
}