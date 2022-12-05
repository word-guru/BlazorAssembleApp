using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Entites;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Domain.Services;
using MyShop.Domain.Services.Interfaces;
using MyShop.HttpModels;
using MyShop.HttpModels.Requests;
using MyShop.HttpModels.Responses;

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
            return new LogInResponse { Id = account.Id, Token = token };
        }
        catch (EmailUnregisteredException)
        {
            return BadRequest(new {Message = "Такой Email не зарегестрирован"});
        }
        catch (IncorrectPasswordException)
        {
            return BadRequest(new {Message = "Пароль не совпадает"});
        }

    }
    [Authorize]
    [HttpGet("get_info")]
    public async Task<ActionResult<AccountInfoResponse>> GetAccountInfo()
    {
        var strId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var guid = Guid.Parse(strId);
        var account = await _accountRepository.GetById(guid);
        return new AccountInfoResponse(guid, account.Name, account.Email);
    }
    
}