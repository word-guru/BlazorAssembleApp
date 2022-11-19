using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Server.Repository.Exeptions;
using MyShop.WebApi.Repositories.Interface;
using MyShop.WebApi.Services;

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
        catch (ExclusionOfEmailRegistration)
        {
            
            return BadRequest(new
            {
                Message = "Такой Email уже зарегистрирован"
            });
        }
    }

    [HttpPost("delete_account")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        await _accountRepository.DeleteById(id);
        return Ok();
    }
}