// Copyright (c) Russlan Akiev. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityBase.Shared.InputModels.Login
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using ServiceBase.Mvc.ModelBinding;

    public class LoginInputModel
    {
        [EmailAddress]
        [StringLength(254)]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [ModelBinder(BinderType = typeof(TrimStringModelBinder))]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember login")]
        public bool RememberLogin { get; set; }

        [StringLength(2000)]
        public string ReturnUrl { get; set; }
    }
}