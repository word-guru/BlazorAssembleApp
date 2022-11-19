﻿namespace MyShop.Server.Repository.Exeptions;

[Serializable]
public class ExclusionOfEmailRegistration : Exception
{

    public ExclusionOfEmailRegistration(string message = "Такой Email уже зарегистрирован")
        : base(message) { }
}