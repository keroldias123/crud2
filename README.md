# CRUD com ASP.NET MVC e MySQL

Este projeto é um exemplo de aplicação **ASP.NET MVC** utilizando um **CRUD (Create, Read, Update, Delete)** completo para gerenciamento de uma entidade `Pessoa`. Ele está integrado com um banco de dados **MySQL** e utiliza o **Entity Framework Core** para a manipulação de dados.

## Funcionalidades

- **Cadastrar Pessoa:** Permite criar uma nova pessoa com nome e idade.
- **Editar Pessoa:** Permite editar as informações de uma pessoa existente.
- **Excluir Pessoa:** Permite excluir uma pessoa do banco de dados.
- **Listar Pessoas:** Exibe todas as pessoas cadastradas.

## Tecnologias Utilizadas

- **ASP.NET Core MVC** - Framework utilizado para desenvolver a aplicação web.
- **Entity Framework Core** - Para interagir com o banco de dados.
- **MySQL** - Banco de dados utilizado para armazenar as informações.
- **Bootstrap** - Para o layout e design dos modais e páginas.

## Estrutura do Projeto

O projeto é dividido da seguinte forma:

- **Controllers**: Contém a lógica para manipular as requisições e interagir com os modelos.
- **Models**: Contém as classes que representam os dados no banco.
- **Views**: Contém as páginas HTML que o usuário interage.
- **Data**: Contém o contexto do banco de dados (conexão com o MySQL).

### **Controllers:**

- **PessoaApiHelper.cs**: Controlador responsável por manipular as ações de **Create**, **Edit** e **Delete** das pessoas. As ações utilizam métodos HTTP padrão (`POST`, `PUT`, `DELETE`) para interagir com o banco de dados.

### **Models:**

- **PessoaModel.cs**: Modelo que representa os dados de uma pessoa no banco de dados. Contém as propriedades **Id**, **Nome**, e **Idade**.

### **Views:**

- **Pessoa**: A página principal onde os dados de pessoas são listados e as opções para **Cadastrar**, **Editar** e **Excluir** estão disponíveis via modais.

## Como Rodar o Projeto

### 1. Clonar o Repositório

Primeiro, clone este repositório para o seu ambiente local:

```bash
git clone https://github.com/keroldias123/crud2.git
cd crud2
