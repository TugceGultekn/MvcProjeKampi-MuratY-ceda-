﻿using EntitiyLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresinizi Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı boş geçemezsiniz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapın.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapın.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("20 karakterden fazla değer girmeyin.");
        }
    }
}
