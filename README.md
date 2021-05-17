# ValidatePassword

Validate password é uma api criada como treino do design pattern chain of responsability. Seu objetivo é dizer se uma senha atende todos os requisitos especificados.

## Como executar
##### Execute os seguintes comandos na pasta /WebApi
```dockerfile
docker build . -t validatepassword
docker run -d -p 80:80 validatepassword
```
##### Para executar os testes unitários executo o seguinte comando na pasta /Test
```dockerfile
dotnet test
```

## Rotas e requests
Execute um POST na rota /password com o payload abaixo
```json
{
    "Password":"AbTp9fokc"
}
```

### Retornos
A api retorna status code <b>200</b> caso a senha passe por todas as regras de negocios ou <b>400</b> caso não cumpra alguma regra

## Como adicionar novas regras de negocios na API.

Seguindo o design pattern <a href="https://imasters.com.br/desenvolvimento/arquitetura-e-desenvolvimento-de-software-parte-14-chain-responsability">Chain of Responsability</a>, basta: 
- desenvolver a validaçao no dominio <a href="https://github.com/caiowWillian/ValidatePassword/blob/main/WebApi/Model/UserPassword.cs">/WebApi/Model/UserPassword.cs</a>
- Criar um novo handler em <a href="https://github.com/caiowWillian/ValidatePassword/tree/main/WebApi/Handlers/Password">WebApi/Handlers/Password</a>
- Criar o elo na corrente de validação em <a href="https://github.com/caiowWillian/ValidatePassword/blob/main/WebApi/Model/UserPassword.cs">/WebApi/Model/UserPassword.cs</a>
```c#
        public bool IsValid()
        {
            var middleware = new CheckWhiteSpaceHandler();
            middleware.LinkWith(new CheckLengthHandler())
            .LinkWith(new CheckLowerCaseHandler())
            .LinkWith(new CheckupperCaseHandler())
            .LinkWith(new CheckSpecialCharHandler())
            .LinkWith(new CheckRepeatCharHandler())
            .LinkWith(new CheckHasDigitHandler());
            .LinkWith(new CheckNewRule()); //Nova Validação
            return middleware.Check(this);
        }
```

## Uso do Chain of responsability
Esse problema poderia ser facilmente resolvido com uma <a href="https://www.computerhope.com/jargon/r/regex.htm">Regex</a>, a escolha do chain of responsability visa a facilidade de adicionar novas regras de negocio no futuro sem precisar retestar as regras já existentes.
