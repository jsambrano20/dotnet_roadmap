using aspnetcore_basics.Interface;

namespace aspnetcore_basics.Service
{
    public class SaudacaoService : ISaudacaoService
    {
        public string ObterMensagem() => "Olá via Injeção de Dependência!";
    }
}
