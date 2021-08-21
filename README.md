# Projeto .NET "BANCO DIO"

## Origem

O projeto segue os aprendizados visto nas aulas sobre .NET da Digital Innovation One (DIO). Devo muito ao instrutor da DIO Eliézer Zarpelão, que me guiou até o código ser funcional, além de deixar aberto novas possibilidades de incremento.

## Objetivo da aplicação

A aplicação é do tipo console e simula operações financeiras simples. As funções implementadas são:

* Listagem de contas cadastradas no "banco"
* Transferência entre contas
* Depósito
* Saque
* Cadastro de contas

Além disso, há o uso de cores (caso o terminal suportar) em vermelho para indicar algumas mensagens de erro.

O pacote [Figgle](https://www.nuget.org/packages/Figgle/) foi utilizado para exibir uma espécie de logo do "Banco DIO", porém note que isso só acontece ao iniciar o programa (há uma variável de controle).

Por fim, fiz algumas validações na entrada de dados do usuário para não quebrar a aplicação ao lançar um erro. A vantagem é: melhor experiência do usuário.


## Limitações

O projeto é simples e não faz uso de banco de dados ou inserção de dados em arquivos. Portanto, os dados criados não são persistentes.

## Para rodar o projeto

Para executar, é necessário o SDK .NET. O seguinte comando executado no terminal iniciará a aplicação: 

```
dotnet run
```

Certifique-se de executar o comando dentro do diretório base que contém um arquivo com a extensão `.csproj`
