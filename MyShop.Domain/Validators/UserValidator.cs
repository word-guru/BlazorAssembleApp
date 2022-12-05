using FluentValidation;
using MyShop.HttpModels;
using MyShop.HttpModels.Requests;

namespace MyShop.Domain.Validators;

public class UserValidator : AbstractValidator<RegisterRequest>
{
    public UserValidator()
    {
        RuleFor(account => account.Name)
            .NotNull().WithMessage("Заполните поле Name")
            .MinimumLength(3).WithMessage("Имя должно быть более 2-х символов");
        RuleFor(account => account.Email)
            .NotNull().WithMessage("Заполните поле Email")
            .EmailAddress().WithMessage("Некоректный ввод Email");
        RuleFor(account => account.Password)
            .NotNull().WithMessage("Заполните поле Password")
            .MinimumLength(6).WithMessage("Пароль должен быть неменьше 6 символов");
    }
}