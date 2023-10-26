using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetIdentity_Default.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAuthenticationSchemeProvider _schemes;

        public IndexModel(ILogger<IndexModel> logger, IAuthenticationSchemeProvider schemes)
        {
            _logger = logger;
            _schemes = schemes;
        }

        public IEnumerable<AuthenticationScheme> Schemes { get; private set; }
        public IEnumerable<AuthenticationScheme> RequestHandlerSchemes { get; private set; }
        public AuthenticationScheme? DefaultAuthenticateScheme { get; private set; }
        public AuthenticationScheme? DefaultChallengeScheme { get; private set; }
        public AuthenticationScheme? DefaultForbidScheme { get; private set; }
        public AuthenticationScheme? DefaultSignInScheme { get; private set; }
        public AuthenticationScheme? DefaultSignOutScheme { get; private set; }

        public async Task OnGet()
        {
            Schemes = await _schemes.GetAllSchemesAsync();

            RequestHandlerSchemes = await _schemes.GetRequestHandlerSchemesAsync();

            DefaultAuthenticateScheme = await _schemes.GetDefaultAuthenticateSchemeAsync();
            DefaultChallengeScheme = await _schemes.GetDefaultChallengeSchemeAsync();
            DefaultForbidScheme = await _schemes.GetDefaultForbidSchemeAsync();
            DefaultSignInScheme = await _schemes.GetDefaultSignInSchemeAsync();
            DefaultSignOutScheme = await _schemes.GetDefaultSignOutSchemeAsync();
        }
    }
}
