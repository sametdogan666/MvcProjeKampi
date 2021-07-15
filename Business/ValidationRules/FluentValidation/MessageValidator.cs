using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            //RuleFor(p => p.ReceiverMail).Must(Contains).WithMessage("Alıcı Mail Adresi @ işareti içermelidir");
            // RuleFor(p => p.SenderMail).Must(Contains).WithMessage("Gönderici Mail Adresi @ işareti içermelidir");
            RuleFor(p => p.ReceiverMail).EmailAddress().WithMessage("Alıcı Mail Adresini Doğru Formatta Giriniz");
            RuleFor(p => p.SenderMail).EmailAddress().WithMessage("Gönderici Mail Adresini Doğru Formatta Giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 Karakterden Fazla Değer Girişi Yapmayınız");
        }

        private bool Contains(string arg)
        {
            return arg.Contains("@");
        }
    }
}
