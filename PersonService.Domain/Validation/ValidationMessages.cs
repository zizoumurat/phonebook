namespace PersonService.Domain.Validation
{
    public class ValidationMessages
    {
        public const string FirstNameRequired = "Kişi Adı Boş Bırakılamaz";
        public const string LastNameRequired = "Kişi Soyadı Boş Bırakılamaz";
        public const string CompanyNameRequired = "Firma Adı Boş Bırakılamaz";
        public const string EmailRequired = "E-mail Boş Bırakılamaz";
        public const string InvalidEmail = "Geçersiz E-mail Adresi";
        public const string PhoneNumberRequired = "Telefon Numarası Boş Bırakılamaz";
        public const string LocationRequired = "Konum Boş Bırakılamaz";
    }
}
