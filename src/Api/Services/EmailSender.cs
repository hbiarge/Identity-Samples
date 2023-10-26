using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;

namespace Api.Services
{
    public class EmailSender : IEmailSender<IdentityUser>
    {
        private readonly IHostEnvironment _env;
        private readonly UrlEncoder _encoder;

        public EmailSender(IHostEnvironment env, UrlEncoder encoder)
        {
            _env = env;
            _encoder = encoder;
        }

        public Task SendConfirmationLinkAsync(IdentityUser user, string email, string confirmationLink)
        {
            var fileName = Path.Combine(_env.ContentRootPath, "Data", "ConfirmEmailLinks.txt");
            
            File.AppendAllLines(fileName, new[] { $"{email} - {_encoder.Encode(confirmationLink)}" });

            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(IdentityUser user, string email, string resetCode)
        {
            var fileName = Path.Combine(_env.ContentRootPath, "Data", "PasswordRestCodes.txt");

            File.AppendAllLines(fileName, new[] { $"{email} - {resetCode}" });

            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(IdentityUser user, string email, string resetLink)
        {
            var fileName = Path.Combine(_env.ContentRootPath, "Data", "PasswordRestLinks.txt");

            File.AppendAllLines(fileName, new[] { $"{email} - {resetLink}" });

            return Task.CompletedTask;  
        }
    }
}
