<h1 align="center"> Autenticação </h1>

<img src="https://img.shields.io/github/issues/Alunser/Autenticacao"/> <img src="https://img.shields.io/github/forks/Alunser/Autenticacao"/> <img src="https://img.shields.io/github/stars/Alunser/Autenticacao"/>

## Índice 
* [Descrição do Projeto](#descrição-do-projeto)
* [Status do Projeto](#status-do-projeto)
* [Aplicação](#aplicação)
  * [Critério de validação](#critério-de-validação)
  * [Funcionalidades](#funcionalidades)
  * [Demonstração da aplicação](#demonstração-da-aplicação)
* [Acesso ao Projeto](#acesso-ao-projeto)
* [Abrir e rodar o projeto](#abrir-e-rodar-o-projeto)
* [Técnicas e tecnologias utilizadas](#técnicas-e-tecnologias-utilizadas)
* [Autor](#autor)

## Descrição do projeto 
Projeto desenvolvido para validar a entrada de uma password.

## Status do Projeto
<img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>

## Aplicação
### Critério de validação
Uma senha é considerada válida quando a mesma atender as seguintes regras:

- Nove ou mais caracteres.
- Não possuir caracteres repetidos dentro do conjunto.
- Ao menos 1 dígito.
- Ao menos 1 letra minúscula.
- Ao menos 1 letra maiúscula.
- Ao menos 1 caractere especial.
- Os caracteres especiais aceitos são: ! @ # $ % ^ & * ( ) - +

Exemplo:  

```c#
IsValid("") // false  
IsValid("aa") // false  
IsValid("ab") // false  
IsValid("AAAbbbCc") // false  
IsValid("AbTp9!foo") // false  
IsValid("AbTp9!foA") // false
IsValid("AbTp9 fok") // false
IsValid("AbTp9!fok") // true
```

> **_Nota:_**  Espaços em branco não são considerados como caracteres válidos.

### Funcionalidades
- `Funcionalidade 1`: Realizar a validação de um password informado pelo usuário.

### Demonstração da aplicação
<div align="center">

![api](https://raw.githubusercontent.com/Alunser/Autenticacao/main/api.gif)

  </div>
  
## Acesso ao projeto

Você pode <a href="https://github.com/Alunser/Autenticacao">acessar o código fonte do projeto inicial</a> ou <a href="https://github.com/Alunser/Autenticacao/archive/refs/heads/main.zip">baixá-lo</a>.

## Abrir e rodar o projeto

Após baixar o projeto

- Abra a solution [`COP.Autenticacao.sln`] com Microsoft Visual Studio 2019.
- Na camada [`1 - Presentation`] defina o [`COP.Autenticacao.API`] como projeto de inicialização.
- Irá abrir o browser com a seguinte url: [`http://localhost:5000/index.html`], caso não abra, com a aplicação rodando copie e cole a url no browser.
- Informar no [`Authorize`] a seguinte chave de acesso: [`Basic M2U0MjgwZTMtNDYzMS00NGZiLWExMzMtMTA4NTE5NjEyYWZm`] para ter acesso a API.
- Executar o endPoint [`v1/login`].

## Técnicas e tecnologias utilizadas
As técnicas e tecnologias utilizadas pra isso são:

- `API RESTful`: interface de programação de aplicação para estabeler a comunicação. 
- `Extension functions`: adicionar comportamentos em outras classes para reutilizá-los.
- `Notification Pattern`: capturar as mensagens das validações de domínio.
- `CQRS Pattern`: separar a responsabilidade de escrita e leitura dos dados.
- `Clean Code`: filosofia de desenvolvimento que consiste em aplicar técnicas simples que facilitam a escrita e a leitura de um código.

## Autor

| [<img src="https://avatars.githubusercontent.com/u/10420762?v=4" width=115><br><sub>Al Unser Bueno de Albuquerque</sub>](https://github.com/alunser) | 
| :---: |
