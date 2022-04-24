﻿using EntitiyLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("En az 2 karakter girişi yapın.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("50 karakterden fazla değer girmeyin.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Hakkında kısmını boş bırakmayın.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Unvan kısmını boş bırakmayın.");

        }
    }
}
