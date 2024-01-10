## 🌐 Sobre

Este é meu primeiro projeto feito em C# utilizando ASP.NET e Angular. O projeto consiste em um sistema para avaliação de lotes de materiais, seguindo critérios de qualidade que podem ser cadastrados para cada material específico.

Foram cerca de três dias seguidos de estudos para ficar por dentro das tecnologias utilizadas e construir uma API estável seguindo boas práticas de programação, além de adentrar o mundo do Angular, no qual utilizei TypeScript para realizar requisições para a API e fazer as conexões necessárias entre back-end e front-end.

Ainda há muito para aprender e isto é apenas o começo de uma nova jornada.

## 📚 Conteúdos
- [🌐 Sobre](#-sobre)
- [🛠️ Recomendações do projeto](#-Recomendacoes-do-projeto)
- [🖌️ Arquitetura](#-providers-and-models)
- [💡 Utilização](#-utilização)
- [🚥 Status](#-status)
- [📄 Referências](#-referências)

## 🛠️ Recomendacoes do projeto

Este projeto utiliza:
```sh
.NET 8.0
Angular CLI 17.0.9
Node 18.18.0
SQL Server 2022
```
Certifique-se de ter todos os componentes instalados em sua máquina para testar a aplicação da maneira mais fluída possível, lembre-se de atualizar e construir as bibliotecas assim que fizer clone do repositório. As instruções de instalação e utilização serão informadas na seção [💡Utilização](#-utilização).

## 🖌️ Arquitetura

Algumas informações foram passadas para a criação deste projeto, a partir delas, foi montada uma arquitetura em diagrama de classes UML e criados os relacionamentos das entidades.

IMAGENS AQUI

Como pode ser observado na Figura 1, teremos em nossa API a possibilidade de criar materiais, adicionar características de qualidade aos materiais e adicionar uma metodologia (visão) de qualidade para o material.

Posteriormente, os materiais podem ter seus lotes lançados. Para cada lote, o material poderá passar por testes de qualidade, onde será avaliado a qualidade do material de acordo com cada característica cadastrada, além de usar a metodologia especificada.

Cada material é independente, sendo assim, é possível cadastrar, remover e editar características específicas de cada material (ou sua metodologia) e com isso manter o controle de quais as melhores opções de qualidade para um determinado material.

Para a arquitetura do Front-End, utilizou-se a arquitetura padrão do Angular, composta por: Modules, Components, Templates e Services.

## 💡 Utilização
> [!Note]
<sup><strong>Está sendo implementada uma branch para utilização com o docker através de `docker compose -f "docker-compose.yml" up -d --build` mas ainda está em andamento!

1. Primeiro veja se você está com o .NET 8.0 e Angular CLI 17.0.9 instalado.

   - [Instalar Dotnet](https://dotnet.microsoft.com/pt-br/download)
   - [Instalar Angular CLI](https://angular.io/cli)

2. Clone o repositório do GitHub:

```bash
git clone https://github.com/athoskenew/batch-validation.git
```

3. Vá até o diretório do projeto:

```bash
cd batch-validation
```
4. Inicie a API:

```bash
cd api
```
```bash
dotnet restore
dotnet update-database
dotnet build
dotnet run
```
O servidor iniciará em `http://localhost:7267` utilizando o Swagger para visualização da API.

5. Inicie o Front-End:
```bash
cd gui
```
```bash
npm install
ng serve --open
```

A janela será aberta automáticamente, do contrário, deverá iniciar em `http://localhost:4200`

Com isso o projeto estará rodando localmente e pronto para ser testado!

## 🚥 Status

- [x] ~Arquitetura do projeto~
- [x] ~ADD SQL Server~
- [x] ~ADD Migrations~
- [x] ~ADD Materiais~
- [x] ~ADD Características~
- [x] ~ADD Metodologias de qualidade~
- [x] ~ADD Lotes~
- [x] ~MAKE Front-End~
- [x] ~MAKE Estilização do Front-End~
- [ ] ADD Lançamento de lotes
- [ ] ADD Cálculo de qualidade

Esta é a atual visualização da API e do Front-End.
### API
![](https://i.imgur.com/mNRO0v2.png)
### Front-End
![](https://i.imgur.com/xFtqZoF.png)
![](https://i.imgur.com/UVnC4z0.png)


## 📄 Referências
[Documentação do Dotnet](https://learn.microsoft.com/pt-br/dotnet/)

[Documentação do EntityFrameWork](https://learn.microsoft.com/en-us/ef/)

[Documentação do Angular](https://angular.io/docs)
