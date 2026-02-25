# 🚀 API de Empleados — Prueba Técnica Redarbor

## 📌 Descripción

Este proyecto corresponde a una **API RESTful desarrollada en .NET 8** para la gestión de empleados, construida como parte de una prueba técnica.

La solución está implementada siguiendo principios de **Clean Architecture**, separación de responsabilidades y buenas prácticas de desarrollo backend.

La API permite:

- Autenticación mediante JWT
- Gestión completa de empleados (CRUD)
- Cambio de contraseña
- Eliminación lógica (Soft Delete)
- Registro de último inicio de sesión (`LastLogin`)
- Auditoría de cambios mediante triggers en base de datos

---

## 🏗 Arquitectura

Se implementó **Clean Architecture**, separando claramente las responsabilidades:


Redarbor.Api
→ Controladores, configuración de JWT, Swagger y middleware.

Redarbor.Application
→ Casos de uso, lógica de negocio y servicios.

Redarbor.Domain
→ Entidades del dominio y reglas de negocio.

Redarbor.Infrastructure
→ Persistencia con EF Core y Dapper.

Redarbor.Tests
→ Proyecto preparado para pruebas unitarias.


### Principios aplicados

- Clean Architecture  
- SOLID  
- Inyección de Dependencias  
- Separación lectura/escritura (CQRS básico)  
- Encapsulamiento de lógica de dominio  

---

## 🛠 Tecnologías Utilizadas

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- Dapper  
- SQL Server  
- JWT Bearer Authentication  
- BCrypt (Hash seguro de contraseñas)  
- Swagger / OpenAPI  

---

## 🔐 Seguridad

La autenticación se implementa mediante **JWT (JSON Web Tokens)**.

- Las contraseñas se almacenan usando **BCrypt**
- Los endpoints protegidos requieren token Bearer
- Se registra el `LastLogin` cada vez que el usuario inicia sesión correctamente
- Eliminación lógica mediante campo `IsDeleted`

---

## 📡 Endpoints

### 🔑 Autenticación

| Método | Endpoint | Descripción |
|--------|----------|------------|
| POST | `/api/auth/login` | Autenticación y generación de token |

---

### 👤 Empleados

| Método | Endpoint | Descripción |
|--------|----------|------------|
| GET | `/api/employees` | Obtener todos los empleados |
| GET | `/api/employees/{id}` | Obtener empleado por ID |
| POST | `/api/employees` | Crear empleado |
| PUT | `/api/employees/{id}` | Actualizar empleado |
| PUT | `/api/employees/{id}/change-password` | Cambiar contraseña |
| DELETE | `/api/employees/{id}` | Eliminación lógica |

⚠ Todos los endpoints de empleados requieren autenticación JWT.

---

## 🧪 Ejemplo de Login

### Request

```json
POST /api/auth/login
{
  "username": "usuario",
  "password": "password"
}
Response
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "username": "usuario"
}

Luego el token debe enviarse en los demás endpoints:

Authorization: Bearer {token}
💾 Persistencia

Escritura → Entity Framework Core

Lectura → Dapper

Eliminación lógica → campo IsDeleted

Auditoría → Triggers SQL

Registro automático de LastLogin al autenticar correctamente

⚙ Configuración
1️⃣ Clonar repositorio
git clone https://github.com/AndresCruzArd/Redarbor-API.git
2️⃣ Configurar cadena de conexión

Editar appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=RedarborDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
3️⃣ Ejecutar migraciones
dotnet ef database update
4️⃣ Ejecutar la API
dotnet run
5️⃣ Abrir Swagger
https://localhost:{puerto}/swagger
📊 Mejoras Futuras

Tests unitarios con xUnit + Moq

Autorización por roles

Refresh Tokens

Dockerización

Logging estructurado

Validaciones con FluentValidation

👤 Autor

Andrés Cruz
Prueba técnica desarrollada para Redarbor.

🧠 Notas Finales

Este proyecto fue desarrollado aplicando buenas prácticas modernas de desarrollo backend, priorizando:

Seguridad

Mantenibilidad

Escalabilidad

Claridad arquitectónica
