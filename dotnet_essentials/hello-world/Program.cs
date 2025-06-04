using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Saída no console
        Console.WriteLine("Olá, .NET!");

        // ----------------------------
        // 🧮 Variáveis e Tipos Primitivos
        // ----------------------------

        int numero = 10;
        double preco = 9.99;
        bool ativo = true;
        char letra = 'A';
        string nome = "João";

        Console.WriteLine($"Número: {numero}, Preço: {preco}, Ativo: {ativo}, Letra: {letra}, Nome: {nome}");

        // ----------------------------
        // 🧮 Constantes
        // ----------------------------

        const double PI = 3.1415;
        Console.WriteLine($"Valor de PI: {PI}");

        // ----------------------------
        // 🧾 Operações matemáticas
        // ----------------------------

        int soma = numero + 5;
        double divisao = preco / 2;
        Console.WriteLine($"Soma: {soma}, Divisão: {divisao}");

        // ----------------------------
        // 🔁 Estruturas de controle
        // ----------------------------

        if (numero > 5)
        {
            Console.WriteLine("Número é maior que 5");
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Contador: {i}");
        }

        // ----------------------------
        // 📦 Listas
        // ----------------------------

        List<string> frutas = new List<string> { "Maçã", "Banana", "Laranja" };
        frutas.Add("Abacaxi");

        foreach (var fruta in frutas)
        {
            Console.WriteLine($"Fruta: {fruta}");
        }

        // ----------------------------
        // 📌 Arrays
        // ----------------------------

        int[] numeros = { 1, 2, 3, 4 };
        Console.WriteLine($"Primeiro número: {numeros[0]}");

        // ----------------------------
        // 🔧 Métodos
        // ----------------------------

        Saudacao("Maria");

        // ----------------------------
        // 🧱 Classes e Objetos
        // ----------------------------

        Pessoa p = new Pessoa("Carlos", 30);
        p.Apresentar();
    }

    static void Saudacao(string nome)
    {
        Console.WriteLine($"Olá, {nome}!");
    }
}

class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public void Apresentar()
    {
        Console.WriteLine($"Meu nome é {Nome} e tenho {Idade} anos.");
    }
}
