using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Server.Date.Repository.Interface;

namespace MyShop.Server.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(Account account) //[FromBody]
    {
        //if (ModelState.IsValid) 
          //  return ValidationProblem(new ValidationProblemDetails(ModelState));
          account.Id = Guid.NewGuid();
        _accountRepository.Add(account);
        return Ok();
    }
}