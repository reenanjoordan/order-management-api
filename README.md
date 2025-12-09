# 🛒 Order Management API

> Uma API robusta e elegante de gerenciamento de pedidos construída com **C# .NET 9**, seguindo princípios de **Domain-Driven Design (DDD)** e **Clean Architecture**.

### ⚡ Instalação em 3 Passos

1️⃣ Clone
git clone https://github.com/reenanjoordan/order-management-api.git
cd order-management-api/OrderManagementAPI

2️⃣ Compile
dotnet build

3️⃣ Execute
cd OrderManagementAPI.API
dotnet run

🌐 **API:** http://localhost:5254
📚 **Swagger:** http://localhost:5254/swagger

## 📚 Endpoints

### 🏪 Produtos
- `GET /api/products` - 📦 Lista produtos
- `POST /api/products` - ➕ Cria produto

### 📋 Pedidos
- `GET /api/orders` - 📋 Lista pedidos
- `POST /api/orders` - ➕ Cria pedido
- `POST /api/orders/{id}/items` - 🛍️ Adiciona produto
- `PUT /api/orders/{id}` - ✏️ Atualiza
- `DELETE /api/orders/{id}` - 🗑️ Deleta

## 🧪 Testes (7/7 ✅)


## 🏗️ Arquitetura

- 🎯 **Domain Layer** - Entidades e regras
- 🎨 **Application Layer** - Serviços
- 💾 **Infrastructure Layer** - EF Core
- 🌐 **API Layer** - Controllers + Swagger

## 🔧 Tecnologias

- 🟦 .NET 9.0
- 📊 Entity Framework Core
- 🧪 xUnit
- 📚 Swagger
- 🗺️ AutoMapper

## 📊 Padrões

✅ Repository Pattern
✅ Dependency Injection
✅ DTO Pattern
✅ Domain-Driven Design
✅ Unit Testing

## 👨‍💻 Autor

**Renan Jordão** - [@reenanjoordan](https://github.com/reenanjoordan)

---

✨ **Status:** ✅ Pronto para Produção | 7/7 Testes Passando | Documentação Completa
