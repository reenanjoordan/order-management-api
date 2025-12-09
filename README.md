# Order Management API

Uma API robusta de gerenciamento de pedidos constru√≠da com **C# .NET 9**, seguindo princ√≠pios de **Domain-Driven Design (DDD)** e **Clean Architecture**.

## Ì∫Ä Come√ßando

### Instala√ß√£o

1. Clone o reposit√≥rio:
git clone https://github.com/reenanjoordan/order-management-api.git
cd order-management-api/OrderManagementAPI

2. Execute:

dotnet build
cd OrderManagementAPI.API
dotnet run

API: `http://localhost:5254`
Swagger: `http://localhost:5254/swagger`

## Ì≥ö Endpoints

### Produtos
- `GET /api/products` - Lista produtos
- `POST /api/products` - Cria produto

### Pedidos
- `GET /api/orders` - Lista pedidos
- `POST /api/orders` - Cria pedido
- `POST /api/orders/{id}/items` - Adiciona produto ao pedido
- `PUT /api/orders/{id}` - Atualiza pedido
- `DELETE /api/orders/{id}` - Deleta pedido

## Ì∑™ Testes

dotnet test

**7/7 testes passando** ‚úÖ

## ÌøóÔ∏è Arquitetura

- **Domain Layer** - Entidades e regras de neg√≥cio
- **Application Layer** - Servi√ßos e DTOs
- **Infrastructure Layer** - EF Core + InMemory
- **API Layer** - Controllers + Swagger

## Ì¥ß Tecnologias

- .NET 9.0
- Entity Framework Core
- xUnit
- Swagger/Swashbuckle
- AutoMapper

## Ì±§ Autor

**Renan Jordan** - [@reenanjoordan](https://github.com/reenanjoordan)

---

**Status:** ‚úÖ Pronto para Produ√ß√£o | Testes Passando | Documenta√ß√£o Completa
