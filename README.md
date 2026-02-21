# Cardinow - Digital Business Card & NFC Product Platform

**Version:** 2.0  
**Date:** January 4, 2026  

Cardinow is a platform for creating digital business cards and selling NFC-enabled products. The system supports roles, reseller management, wallet, payments, and extensive auditing.

---

## Table of Contents

- [Tech Stack](#tech-stack)  
- [Architecture](#architecture)  
- [Entities](#entities)  
- [DTOs](#dtos)  
- [Services](#services)  
- [Repositories](#repositories)  
- [Unit of Work](#unit-of-work)  
- [Validation](#validation)  
- [API Endpoints](#api-endpoints)  
- [Database Configuration](#database-configuration)  
- [Setup & Deployment](#setup--deployment)  
- [License](#license)  

---

## Tech Stack

- **Frontend:** Next.js 15, React, TypeScript, TailwindCSS, shadcn/ui  
- **Backend:** ASP.NET Core Web API, C#  
- **Database:** PostgreSQL  
- **ORM:** Entity Framework Core (Fluent API)  
- **Mapping:** AutoMapper  
- **Validation:** FluentValidation  
- **Containerization:** Docker  
- **Server:** Linux  
- **Payment Integration:** ZarinPal  
- **SMS Verification:** External SMS API  

---

## Architecture

The project follows a layered architecture:
Controllers --> Services --> Repositories --> DbContext --> Database

**Layers:**

1. **API / Controllers:** Handles HTTP requests, DTO binding, validation, and calls services.  
2. **Services:** Business logic, soft delete, wallet management, payment verification.  
3. **Repositories:** Generic repository for CRUD, specific repositories for complex queries.  
4. **Unit of Work:** Manages multiple repositories in a single transaction.  
5. **Entities:** Domain models with inheritance (`BaseEntity`).  
6. **DTOs:** Separate DTOs for Create, Update, and Read operations.  
7. **Validation:** FluentValidation for all incoming DTOs.  

---

## Entities

Key entities include:

- `User` - Admins, RestrictedAdmins, Customers, DedicatedResellers, AffiliateResellers  
- `Order` - Tracks product orders and statuses  
- `Product` - NFC products with pricing, stock, and reseller-specific pricing  
- `Payment` - Payment information, verification status  
- `Profile` - Digital card profile, links, banner/logo  
- `Reseller` - Domain, affiliate links, commission, renewal plans  
- `Wallet` - Balance, total sales, cashed out  
- `WalletTransaction` - Transaction logs for wallet operations  
- `Log` - Auditing logs for all actions  

All entities inherit from `BaseEntity` which contains:

```csharp
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}
```
## DTOs

- Create, Update, Read DTOs for all entities

- Example: CreateOrderDto, OrderReadDto, UpdateOrderStatusDto

- Used in controllers for data binding and service input/output

- AutoMapper profiles manage conversion between Entity and DTO

## Services

- `IUserService`, `UserService`

- `IProductService`, `ProductService`

- `IOrderService`, `OrderService`

- `IPaymentService`, `PaymentService`

- `IResellerService`, `ResellerService`

- `IWalletService`, `WalletService`

- `IWalletTransactionService`, `WalletTransactionService`

- `ILogService`, `LogService`

## Services handle:

- Business rules

- Soft deletes

- Auditing logs

- Wallet calculations

- Payment verification

- Reseller commission updates

## Repositories

- `IGenericRepository<T>` for basic CRUD

- Specific repositories for entities with complex queries (e.g., `IOrderRepository`, `IUserRepository`)

- Soft delete handled at repository/service layer

## Unit of Work

- `IUnitOfWork` aggregates multiple repositories

- Ensures transactional integrity across multiple operations

- Used in Services when multiple repositories are involved in one business operation

## Validation

- FluentValidation for all DTOs

- Example: `CreateOrderDtoValidator`

- Validates required fields, ranges, string length, patterns

- Integrated into controllers via DI or global middleware

## API Endpoints

### Auth / Users:

- `POST /api/auth/register` - Register user

- `POST /api/auth/verify` - Verify code

- `GET /api/users/logs` - Get audit logs

### Orders:

- `POST /api/orders` - Create order

- `PUT /api/orders/status` - Update order status

- `GET /api/orders/{id}` - Get order by Id

### Products:

- `POST /api/products` - Create product

- `PUT /api/products/{id}` - Update product

- `GET /api/products/{id}` - Get product

- `GET /api/products` - List all products

### Payments:

- `POST /api/payments` - Create payment

- `GET /api/payments/{id}` - Get payment by Id

- `GET /api/payments` - List payments

### Resellers:

- `GET /api/reseller/{userId}` - Get reseller info

- `PUT /api/reseller/{id}/domain` - Update domain

- `PUT /api/reseller/{id}/commission` - Update commission

### Wallets:

- `GET /api/wallet/{userId}` - Get wallet

- `POST /api/wallet/{userId}/cashout` - Request cashout

### Wallet Transactions:

- `GET /api/wallettransaction/{userId}` - List wallet transactions

## Database Configuration

- SQL with Entity Framework Core

- Fluent API used for:

    - Table names

    - Relationships (One-to-Many, Many-to-One)

    - Indexes and constraints

    - Soft delete filters

- Example:
```csharp
builder.Entity<User>()
    .HasMany(u => u.Orders)
    .WithOne(o => o.User)
    .HasForeignKey(o => o.UserId)
    .OnDelete(DeleteBehavior.Cascade);
```
## Setup & Deployment

1. Clone repo

2. Set environment variables:

```ash
DATABASE_URL=postgres://user:password@host:port/dbname
ZARINPAL_API_KEY=your_key
```

3. Apply migrations:
```bash
dotnet ef database update
```
4. Run backend:
```bash
dotnet run
```
5. Use Docker for production deployment

- HTTPS required for all endpoints

- Daily SQL backups recommended