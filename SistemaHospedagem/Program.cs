using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

try
{
    // Teste 1: Reserva normal (5 dias)
    Console.WriteLine("=== TESTE 1: Reserva de 5 dias ===");

    // Cria os modelos de hóspedes e cadastra na lista de hóspedes
    List<Pessoa> hospedes = new List<Pessoa>();

    Pessoa p1 = new Pessoa(nome: "Ozzy", sobrenome: "Osbourne");
    Pessoa p2 = new Pessoa(nome: "Sharon", sobrenome: "Osbourne");

    hospedes.Add(p1);
    hospedes.Add(p2);

    // Cria a suíte
    Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

    // Cria uma nova reserva, passando a suíte e os hóspedes
    Reserva reserva = new Reserva(diasReservados: 5);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    // Exibe a quantidade de hóspedes e o valor da diária
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor diária: R$ {reserva.CalcularValorDiaria():F2}");
    Console.WriteLine($"Lista de hóspedes:");
    foreach (var hospede in reserva.Hospedes)
    {
        Console.WriteLine($"- {hospede.NomeCompleto}");
    }

    Console.WriteLine("\n=== TESTE 2: Reserva com desconto (15 dias) ===");

    // Teste 2: Reserva com desconto (15 dias)
    Reserva reservaComDesconto = new Reserva(diasReservados: 15);
    reservaComDesconto.CadastrarSuite(suite);
    reservaComDesconto.CadastrarHospedes(hospedes);

    Console.WriteLine($"Hóspedes: {reservaComDesconto.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor sem desconto: R$ {15 * 30:F2}");
    Console.WriteLine($"Valor com desconto (10%): R$ {reservaComDesconto.CalcularValorDiaria():F2}");

    Console.WriteLine("\n=== TESTE 3: Tentativa de exceder capacidade ===");

    // Teste 3: Tentativa de exceder a capacidade da suíte
    List<Pessoa> muitosHospedes = new List<Pessoa>
    {
        new Pessoa("Steven", "Tyller"),
        new Pessoa("Slash", "Hudson"),
        new Pessoa("Jimmy", "Page") // 3 hóspedes para suíte de capacidade 2
    };

    Reserva reservaExcedida = new Reserva(diasReservados: 7);
    reservaExcedida.CadastrarSuite(suite);
    reservaExcedida.CadastrarHospedes(muitosHospedes); // Isso deve gerar exceção
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Erro capturado: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro inesperado: {ex.Message}");
}