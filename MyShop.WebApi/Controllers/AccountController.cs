using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Domain.Services;
using MyShop.Models;

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
    public async Task<ActionResult<Account>> Register(Account account) //[FromBody]
    {
        try
        {
            return await _accountService.Register(account);
        }
        catch (EmailAlreadyExistException ex)
        {
            return BadRequest(new
            {
                ex.Message,
                account.Email
            });
        }
    }

    [HttpPost("delete_account")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        await _accountRepository.DeleteById(id);
        return Ok();
    }
    
    [HttpGet("authorization")]
    public async Task<ActionResult<Account>> Authorization(Account account)
    {
        try
        {
            return account;
        }
        catch (Exception)
        {
            return Unauthorized();
        }
    }
}