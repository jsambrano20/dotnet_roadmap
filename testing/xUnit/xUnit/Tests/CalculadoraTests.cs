using Xunit;

namespace xUnit_Project.Tests;

public class CalculadoraTests
{
    private readonly Calculadora _calc = new();

    [Fact]
    public void Somar_DeveRetornarSomaCorreta()
    {
        var resultado = _calc.Somar(3, 5);
        Assert.Equal(8, resultado);
    }

    [Theory]
    [InlineData(10, 4, 6)]
    [InlineData(5, 5, 0)]
    [InlineData(0, 7, -7)]
    public void Subtrair_DeveRetornarResultadoCorreto(int a, int b, int esperado)
    {
        var resultado = _calc.Subtrair(a, b);
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(0, 5, 0)]
    public void Multiplicar_DeveRetornarProdutoCorreto(int a, int b, int esperado)
    {
        var resultado = _calc.Multiplicar(a, b);
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Dividir_DeveLancarExcecaoSeDivisorZero()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(9, 3, 3)]
    public void Dividir_DeveRetornarQuocienteCorreto(int a, int b, double esperado)
    {
        var resultado = _calc.Dividir(a, b);
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Fatorial_DeveRetornar1ParaZero()
    {
        var resultado = _calc.Fatorial(0);
        Assert.Equal(1, resultado);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(3, 6)]
    [InlineData(5, 120)]
    public void Fatorial_DeveRetornarValorCorreto(int n, int esperado)
    {
        var resultado = _calc.Fatorial(n);
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void Fatorial_DeveLancarErroParaValorNegativo()
    {
        Assert.Throws<ArgumentException>(() => _calc.Fatorial(-3));
    }
}
