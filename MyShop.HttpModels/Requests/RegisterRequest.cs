﻿using System.ComponentModel.DataAnnotations;

namespace MyShop.HttpModels.Requests;

public class RegisterRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}