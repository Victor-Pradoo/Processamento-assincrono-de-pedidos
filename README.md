# Processamento Assíncrono de Pedidos (RabbitMQ + ASP.NET Core)

Este projeto simula o processamento assíncrono de pedidos usando ASP.NET Core e RabbitMQ.


## Tecnologias Utilizadas

- C# com ASP.NET Core
- Pacote MassTransit.RabbitMQ 
- Docker (para execução local)
- .NET 8.0.0

### Requisitos

- [.NET 8.0.0 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

---

## Como Executar Localmente

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
```
### 2. Instale o pacote MassTransi.RabbitMQ na sua solução

Utilize o NuPackage manager para instalar o pacote necessario para trabalhar com o RabbitMQ

### 3. Suba o RabbitMQ com Docker

Execute no terminal:

```bash
docker run -d --hostname rabbitmq-local --name rabbitmq-dev -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

### 4. Acesse o RabbitMQ através do localhost

Acesse http://localhost:15672/#/ para entrar na interface do RabbitMQ

### 5. Execute o projeto e utilize os Endpoints

Ao executar o projeto a página do Swagger irá aparecer e uma nova fila aparecerá na aba Connections da interface RabbitMQ
