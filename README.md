### API-ASP.NET-Core-3-e-EF-Core-3




# Instalações:

 - 


 Migração e atuaçozação



 - dotnet ef migrations add UserMigration


 - dotnet ef database update

 # Hospedando

 - Cria um conta no Hiroku

 - Cria um projeto Hiroku

 - Cria uma imagem Docker usando o Visual Studio 2019

    - Escolha Linux, edita o arquivo "Dockerfile" e comenta o resto.

    <blockquete>
        FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
        WORKDIR /app
        COPY . .
        CMD ASPNETCORE_URLS=http://*$PORT dotnet dotnetcore2021.dll
    </blockquete>

    - Executa o comando

    <blockquete> dotnet publish -c Release </blockquete>

- Vai no caminho:

<blockquete> \src\Api.Application\bin\Release\netcoreapp3.1\publish </blockquete>

- E cola o arquivo "Dockerfile"

- Faça o login.

- Executa o comando, com o nome do projeto hiroko.

<blockquete> docker build -t dotnetcore2021 E:\\Estudo e Projetos\\Projetos BackEnd .NetCore\\API-ASP.NET-Core-3-e-EF-Core-3\\src\\Api.Application\\bin\\Release\\netcoreapp3.1\\publish</blockquete>

ou 


<blockquete> docker build -t dotnetcore2021 .</blockquete>

- Execute outro comando 

<blockquete> docker tag dotnetcore2021 registry.heroku.com/dotnetcore2021/web </blockquete>

- comando push

- executa o comando

<blockquete> heroku container:login </blockquete>

<blockquete> docker tag dotnetcore2021 registry.heroku.com/dotnetcore2021/web </blockquete>

- Espera carregar.

<blockquete> heroku container:release web --app dotnetcore2021 </blockquete>


- link de ajuda: 

https://dashboard.heroku.com/apps/dotnetcore2021/deploy/heroku-container