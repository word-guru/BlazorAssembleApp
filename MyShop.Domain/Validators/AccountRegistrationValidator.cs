using FluentValidation;
using MyShop.Models;

namespace MyShop.Domain.Validators;

public class AccountRegistrationValidator : AbstractValidator<User>
{
    public AccountRegistrationValidator()
    {
        RuleFor(account => account.Name)
            .NotNull().WithMessage("Заполните поле Name")
            .MinimumLength(3).WithMessage("Имя должно быть более 2-х символов")
            .MaximumLength(16).WithMessage("Имя должно содержать менее 16 символов");
        RuleFor(account => account.Email)
            .NotNull().WithMessage("Заполните поле Email")
            .EmailAddress().WithMessage("Некоректный ввод Email");
        RuleFor(account => account.Password)
            .NotNull().WithMessage("Заполните поле Password")
            .MinimumLength(6).WithMessage("Пароль должен быть неменьше 6 символов");
    }
}