using Microsoft.AspNetCore.Mvc;
using MyShop.Server.Repositories.Interface;
using MyShop.Server.Repository.Exeptions;
using MyShop.Server.Repository.Models;
using MyShop.Server.Repository.Server.Services;

namespace MyShop.Server.Repository.Server.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountServices _accountService;
    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
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