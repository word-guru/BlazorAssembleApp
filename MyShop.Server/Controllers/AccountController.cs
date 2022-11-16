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
       Account? existedAccount = await _accountRepository
           .FindByEmail(account.Email);
       
       if (existedAccount is not null)
       {
           return BadRequest(new {Message = "Такой email уже существует"});
         
       }
       
       await _accountRepository.Add(account);

       return Ok();
    }

    [HttpPost("delete_account")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        await _accountRepository.DeleteById(id);
        return Ok();
    }
}