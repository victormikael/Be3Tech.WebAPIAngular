# Be3Tech.WebAPIAngular

Web API escrito em .NET 5 usando o Angular 12 no front-end.
<br><br>

<b>Depedências:</b>
- .NET 5
- Angular CLI 12

Na pasta raiz do projeto crie o arquivo <code>appsettings.json</code> com as seguintes linhas:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=ServerName,1515;Database=DB;UID=UserName;PWD=Password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```
Onde, <i>ServerName</i>; <i>UserName</i> e <i>Password</i> são variáveis e devem ser substituidas.

Depois, rode o comando <code>dotnet run</code> na pasta raiz.

Com o comando acima rodando, em outra instância do terminal, entre na pasta <i>ClientApp</i> e rode o comando <code>ng serve</code>

Em seguida acesse <code>http://localhost:4200</code> pelo navegador.
