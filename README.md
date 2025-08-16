# Sistema de Hospedagem

Este projeto faz parte dos desafios práticos do Bootcamp WEX – End to End Engineering, uma iniciativa conjunta entre a WEX, empresa global de tecnologia financeira, e a plataforma de ensino DIO (Digital Innovation One). O objetivo é aplicar, na prática, conceitos de desenvolvimento de software por meio da construção de um sistema de hospedagem hoteleira.

🔗 **Exercício Original:** https://github.com/digitalinnovationone/trilha-net-explorando-desafio

**Proposta do Desafio:**
- Sistema de reservas com relacionamento entre hóspedes, suítes e reservas
- Cálculo automático de valores com desconto para estadias longas
- Validação de capacidade das suítes
- Controle de hóspedes por reserva

## Documentação - Sistema de Hospedagem Implementado

### Visão Geral
Sistema desenvolvido em C# .NET para gerenciamento de reservas hoteleiras com validação de capacidade, cálculo automático de valores e aplicação de descontos. O sistema implementa as funcionalidades propostas no desafio original (cadastro de hóspedes, suítes e reservas), além de melhorias adicionais como tratamento robusto de exceções, testes abrangentes e formatação profissional dos resultados.

## Estrutura das Classes

### Classe Pessoa
**Propriedades Públicas:**
- `string Nome`: Nome do hóspede
- `string Sobrenome`: Sobrenome do hóspede  
- `string NomeCompleto`: Propriedade calculada que retorna nome completo em maiúsculas

**Construtores:**
- `Pessoa()`: Construtor padrão
- `Pessoa(string nome)`: Construtor com nome
- `Pessoa(string nome, string sobrenome)`: Construtor completo

### Classe Suite
**Propriedades Públicas:**
- `string TipoSuite`: Tipo da suíte (Premium, Standard, etc.)
- `int Capacidade`: Número máximo de hóspedes
- `decimal ValorDiaria`: Valor da diária da suíte

**Construtores:**
- `Suite()`: Construtor padrão
- `Suite(string tipoSuite, int capacidade, decimal valorDiaria)`: Construtor completo

### Classe Reserva
**Propriedades Públicas:**
- `List<Pessoa> Hospedes`: Lista dos hóspedes da reserva
- `Suite Suite`: Suíte reservada
- `int DiasReservados`: Quantidade de dias da reserva

## Métodos Implementados

### 1. CadastrarHospedes(List<Pessoa> hospedes) - PÚBLICO
**Funcionalidade:** Registra os hóspedes na reserva com validação de capacidade.

**Fluxo de execução:**
- Verifica se capacidade da suíte comporta número de hóspedes
- Se válido: atribui lista à propriedade Hospedes
- Se inválido: lança InvalidOperationException com detalhes

**Validações:**
- ✅ Capacidade da suíte deve ser maior ou igual ao número de hóspedes
- ✅ Mensagem de erro detalhada com valores específicos

### 2. CadastrarSuite(Suite suite) - PÚBLICO
**Funcionalidade:** Registra a suíte na reserva.

**Características:**
- Atribui suíte à propriedade Suite
- Método auxiliar para completar dados da reserva

### 3. ObterQuantidadeHospedes() - PÚBLICO
**Funcionalidade:** Retorna a quantidade total de hóspedes da reserva.

**Características:**
- Utiliza propriedade Count da lista Hospedes
- Retorna valor inteiro
- **Retorno:** `int` - número de hóspedes

### 4. CalcularValorDiaria() - PÚBLICO
**Funcionalidade:** Calcula o valor total da estadia com aplicação automática de desconto.

**Fluxo de execução:**
- Calcula valor base: `DiasReservados × Suite.ValorDiaria`
- Verifica se reserva é ≥ 10 dias
- Aplica desconto de 10% quando aplicável
- Retorna valor final

**Cálculo:** `valorTotal = DiasReservados × ValorDiaria × (desconto ? 0.9 : 1.0)`

**Validações:**
- ✅ Desconto automático para reservas de 10+ dias
- ✅ Precisão decimal para valores monetários

## Menu Principal (Program.cs)

### Cenários de Teste Implementados:

**Teste 1: Reserva Normal (5 dias)**
- Suíte Premium, capacidade 2, R$ 30/dia
- 2 hóspedes, 5 dias
- Resultado: R$ 150,00 (sem desconto)

**Teste 2: Reserva com Desconto (15 dias)**
- Mesma configuração, 15 dias  
- Cálculo: 15 × 30 × 0.9 = R$ 405,00
- Desconto aplicado: 10%

**Teste 3: Validação de Capacidade**
- Tentativa: 3 hóspedes em suíte para 2
- Resultado: Exceção capturada e tratada

### Características:
- Testes automatizados com diferentes cenários
- Tratamento completo de exceções
- Formatação monetária brasileira (R$)
- Exibição detalhada de resultados

## Validações e Tratamentos de Erro

### Capacidade da Suíte:
- Verifica se `Suite.Capacidade >= hospedes.Count`
- Lança `InvalidOperationException` com mensagem detalhada
- Formato: "A capacidade da suíte (X) é menor que o número de hóspedes (Y)"

### Exemplos Válidos:
- ✅ Suíte para 2, com 1 hóspede
- ✅ Suíte para 4, com 4 hóspedes  
- ✅ Suíte para 3, com 2 hóspedes

### Exemplos Inválidos:
- ❌ Suíte para 2, com 3 hóspedes
- ❌ Suíte para 1, com 2 hóspedes

## Bibliotecas Utilizadas

**System.Collections.Generic:**
- `List<Pessoa>`: Armazenamento dos hóspedes

**System.Text:**
- `Encoding.UTF8`: Formatação de caracteres especiais

**System:**
- `InvalidOperationException`: Tratamento de erros de negócio
- `Console`: Interface com usuário

## Formatação de Dados

### Valores Monetários:
- Formato: R$ XX,XX
- Precisão: 2 casas decimais
- Uso: `{valor:F2}`

### Nomes:
- Sempre em maiúsculas via `NomeCompleto`
- Formato: "NOME SOBRENOME"

## Melhorias Implementadas

### Além dos Requisitos Básicos:
- Tratamento robusto de exceções com mensagens detalhadas
- Programa de testes com múltiplos cenários
- Formatação profissional dos resultados
- Demonstração prática de todas as funcionalidades
- Cálculo preciso com desconto automático
- Interface clara e informativa

### Experiência do Usuário:
- Mensagens claras sobre valores e descontos
- Lista detalhada de hóspedes
- Comparação entre valor com e sem desconto
- Tratamento elegante de erros
- Formatação monetária brasileira

---

**Bootcamp WEX - End to End Engineering - DIO**  
Desenvolvido por [Natalia Moraes](https://www.linkedin.com/in/moraesnatalia/)
