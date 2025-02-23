using FluentValidation;
using SignalR.DtoLayer.BookingDtos;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!").MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karekter veri girişi yapınız.").MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 kareter veri girişi yapınız."); ;
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!").EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 kareter veri girişi yapınız.");
        }
    }
}
