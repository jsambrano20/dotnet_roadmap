using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;

namespace dotnet_security_api.Services
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
        ) : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Header 'Authorization' não encontrado."));

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                if (!authHeader.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
                    return Task.FromResult(AuthenticateResult.Fail("Esquema inválido. Esperado: Basic."));

                var encodedCredentials = authHeader.Parameter;
                if (string.IsNullOrWhiteSpace(encodedCredentials))
                    return Task.FromResult(AuthenticateResult.Fail("Credenciais não fornecidas."));

                byte[] credBytes;
                try
                {
                    credBytes = Convert.FromBase64String(encodedCredentials);
                }
                catch (FormatException)
                {
                    return Task.FromResult(AuthenticateResult.Fail("Credenciais malformadas (Base64 inválido)."));
                }

                var credentials = Encoding.UTF8.GetString(credBytes).Split(':', 2);
                if (credentials.Length != 2)
                    return Task.FromResult(AuthenticateResult.Fail("Formato de credenciais inválido. Esperado: usuário:senha"));

                var username = credentials[0];
                var password = credentials[1];

                if (username != "admin" || password != "123")
                    return Task.FromResult(AuthenticateResult.Fail("Usuário ou senha inválidos."));

                var claims = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao processar autenticação Basic.");
                return Task.FromResult(AuthenticateResult.Fail("Erro interno na autenticação."));
            }
        }
    }
}
