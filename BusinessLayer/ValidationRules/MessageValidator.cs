using EntitiyLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriğini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter Girişi Yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En Fazla 100 Karakter Girişi Yapın");

        }
    }
}
