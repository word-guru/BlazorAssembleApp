using FluentValidation;
using MyShop.HttpModels.Requests;

namespace MyShop.HttpModels.Validators;

public class UserLogInValidator : AbstractValidator<LogInRequest>
{
    public UserLogInValidator()
    {
        RuleFor(account => account.Email)
            .NotNull().WithMessage("Заполните поле Email")
            .EmailAddress().WithMessage("Некоректный Email");
        RuleFor(account => account.Password)
            .NotNull().WithMessage("Заполните поле Пароль")
            .MinimumLength(6).WithMessage("Пароль должен быть не меньше 6 символов");
    }
}