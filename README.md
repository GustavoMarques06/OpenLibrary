# Open Library

O Open Library é uma API REST desenvolvida com intuito de gerenciar seus livros pessoais de forma simples.

Oferecendo um **CRUD** completo, permitindo:
- Cadastrar novos livros (**POST**)  
- Consultar livros por **ID** e por **título** (**GET**)
- Editar informações do livro selecionado (**PUT**)  
- Remover registros do livro (**DELETE**)  

Ela foi construida utilizando a arquitetura de **Service Pattern**, garantindo uma arquitetura bem estruturada, organizada e de fácil manutenção.

---
## Tecnologias utilizadas
### Back-end
- C#
- Asp.net Core 8
- entity framework core
- SQL Server
- Swagger 

---
## Instruções de instalação e execução
1- No Package Manager Console, execute: 
```bash
    Add-Migration Inicial
```
2- Para criar o banco de dados, execute:
```bash
    Update-Database
```
3- No terminal execute:
```bash
    dotnet run
```
