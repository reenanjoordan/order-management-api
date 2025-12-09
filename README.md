# í»’ Order Management API

> Uma API robusta e elegante de gerenciamento de pedidos construÃ­da com **C# .NET 9**, seguindo princÃ­pios de **Domain-Driven Design (DDD)** e **Clean Architecture**.

---

## íº€ ComeÃ§ando Rapidinho

### âš¡ InstalaÃ§Ã£o em 3 Passos

1ï¸âƒ£ Clone
git clone https://github.com/reenanjoordan/order-management-api.git
cd order-management-api/OrderManagementAPI

2ï¸âƒ£ Compile
dotnet build

3ï¸âƒ£ Execute
cd OrderManagementAPI.API
dotnet run

í¼ **API:** http://localhost:5254
í³š **Swagger:** http://localhost:5254/swagger

## í³š Endpoints

### í¿ª Produtos
- `GET /api/products` - í³¦ Lista produtos
- `POST /api/products` - â• Cria produto

### í³‹ Pedidos
- `GET /api/orders` - í³‹ Lista pedidos
- `POST /api/orders` - â• Cria pedido
- `POST /api/orders/{id}/items` - í»ï¸ Adiciona produto
- `PUT /api/orders/{id}` - âœï¸ Atualiza
- `DELETE /api/orders/{id}` - í·‘ï¸ Deleta

## í·ª Testes (7/7 âœ…)


## í¿—ï¸ Arquitetura

- í¾¯ **Domain Layer** - Entidades e regras
- í¾¨ **Application Layer** - ServiÃ§os
- í²¾ **Infrastructure Layer** - EF Core
- í¼ **API Layer** - Controllers + Swagger

## í´§ Tecnologias

- í¿¦ .NET 9.0
- í³Š Entity Framework Core
- í·ª xUnit
- í³š Swagger
- í·ºï¸ AutoMapper

## í³Š PadrÃµes

âœ… Repository Pattern
âœ… Dependency Injection
âœ… DTO Pattern
âœ… Domain-Driven Design
âœ… Unit Testing

## í±¨â€í²» Autor

**Renan Jordan** - [@reenanjoordan](https://github.com/reenanjoordan)

---

âœ¨ **Status:** âœ… Pronto para ProduÃ§Ã£o | 7/7 Testes Passando | DocumentaÃ§Ã£o Completa

