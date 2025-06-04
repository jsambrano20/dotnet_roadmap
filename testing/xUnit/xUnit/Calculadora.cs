namespace xUnit_Project;

public class Calculadora
{
    public int Somar(int a, int b) => a + b;

    public int Subtrair(int a, int b) => a - b;

    public int Multiplicar(int a, int b) => a * b;

    public double Dividir(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("Divisão por zero não é permitida.");
        return (double)a / b;
    }

    public int Fatorial(int n)
    {
        if (n < 0) throw new ArgumentException("Fatorial não é definido para números negativos.");
        if (n == 0) return 1;
        return n * Fatorial(n - 1);
    }
}
