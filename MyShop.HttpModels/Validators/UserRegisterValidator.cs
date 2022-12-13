using FluentValidation;
using MyShop.HttpModels.Requests;

namespace MyShop.HttpModels.Validators;

public class UserRegisterValidator : AbstractValidator<RegisterRequest>
{
    public UserRegisterValidator()
    {
        RuleFor(account => account.Name)
            .NotNull().WithMessage("Заполните поле Имя")
            .MinimumLength(3).WithMessage("Имя должно быть не меньше 3-х символов");
        RuleFor(account => account.Email)
            .NotNull().WithMessage("Заполните поле Email")
            .EmailAddress().WithMessage("Некоректный ввод Email");
        RuleFor(account => account.Password)
            .NotNull().WithMessage("Заполните поле Пароль")
            .MinimumLength(6).WithMessage("Пароль должен быть не меньше 6 символов");
    }
}