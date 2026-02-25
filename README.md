# 🚀 API de Empleados — Prueba Técnica Redarbor

## 📌 Descripción

Este proyecto corresponde a una API RESTful desarrollada en **.NET 8** para la gestión de empleados, construida como parte de una prueba técnica.

La solución está implementada siguiendo principios de **Clean Architecture**, aplicando buenas prácticas de **OOP, DDD, SOLID y Clean Code**.

---

## 🎯 Funcionalidades

La API permite:

- 🔐 Autenticación mediante JWT
- 👤 Gestión completa de empleados (CRUD)
- 🔄 Cambio de contraseña
- 🗑 Eliminación lógica (Soft Delete)
- 🕒 Registro de último inicio de sesión (LastLogin)
- 📊 Auditoría de cambios mediante triggers en base de datos
- 🧪 Pruebas unitarias con xUnit + Moq
- 🐳 Despliegue mediante Docker

---

# 🏗 Arquitectura

Se implementó **Clean Architecture**, separando claramente las responsabilidades en proyectos independientes.

## 📂 Estructura de la solución

- **Redarbor.Api**  
  Controladores, configuración de JWT, Swagger y middleware.

- **Redarbor.Application**  
  Casos de uso, lógica de negocio, interfaces y contratos.

- **Redarbor.Domain**  
  Entidades del dominio y reglas de negocio.

- **Redarbor.Infrastructure**  
  Persistencia con Entity Framework Core y Dapper.

- **Redarbor.Tests**  
  Pruebas unitarias con xUnit y Moq.

---

# 🧱 Buenas Prácticas Aplicadas

---

## 🧩 Programación Orientada a Objetos (OOP)

El proyecto aplica correctamente los principios fundamentales de OOP:

- Encapsulamiento de entidades del dominio
- Separación clara de responsabilidades entre clases
- Uso de interfaces para desacoplar implementaciones
- Uso de abstracciones entre capas
- Control adecuado de modificadores de acceso

Cada clase tiene un propósito claro y bien definido.

---

## 🧠 Domain-Driven Design (DDD - Enfoque Táctico)

Se aplican conceptos fundamentales de DDD:

- 📦 Entidades ubicadas en la capa `Domain`
- 🧾 Reglas de negocio encapsuladas en el dominio
- 🔐 El dominio no depende de infraestructura
- 🔄 Separación clara entre lógica de negocio y acceso a datos
- 🧩 Interfaces (puertos) definidas en Application e implementadas en Infrastructure

Principio respetado:

> El dominio no conoce detalles técnicos externos.

---

## 📐 Principios SOLID

El proyecto cumple con los cinco principios SOLID:

### S — Single Responsibility Principle
Cada clase tiene una única responsabilidad clara  
(Ej: AuthService, EmployeeService, Repositories)

### O — Open/Closed Principle
Las clases pueden extenderse mediante interfaces sin modificar su código base.

### L — Liskov Substitution Principle
Las implementaciones respetan los contratos definidos por las interfaces.

### I — Interface Segregation Principle
Las interfaces están diseñadas de forma específica y no contienen métodos innecesarios.

### D — Dependency Inversion Principle
Las capas superiores dependen de abstracciones, no de implementaciones concretas.

Ejemplo:

Application depende de `IEmployeeRepository`, no de `EmployeeRepository`.

---

## 🧼 Clean Code

Se aplican prácticas de código limpio:

- Nombres descriptivos y expresivos
- Métodos pequeños y enfocados
- Eliminación de lógica duplicada
- Separación clara de lectura/escritura (CQRS básico)
- Inyección de dependencias
- Manejo claro y controlado de excepciones
- Código organizado por responsabilidad

El código prioriza:

- Legibilidad
- Mantenibilidad
- Escalabilidad

---

# 🏛 Clean Architecture

Se respeta la regla fundamental:

> Las dependencias siempre apuntan hacia el dominio.

Flujo de dependencias:

Api → Application → Domain
Infrastructure → Application

- El dominio no depende de ninguna capa externa.
- La infraestructura implementa contratos definidos en Application.
- La API solo orquesta las solicitudes.

---

# 🛠 Tecnologías Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Dapper
- SQL Server
- JWT Bearer Authentication
- BCrypt
- Swagger / OpenAPI
- xUnit
- Moq
- Docker

---

# 🔐 Seguridad

- Autenticación implementada mediante JWT
- Contraseñas almacenadas usando BCrypt
- Endpoints protegidos mediante `Bearer Token`
- Registro automático de `LastLogin`
- Eliminación lógica mediante campo `IsDeleted`
- Validaciones en capa de aplicación

---

# 📡 Endpoints

## 🔑 Autenticación

| Método | Endpoint | Descripción | Autenticación |
|--------|----------|------------|---------------|
| POST | `/api/auth/login` | Generación de token JWT | ❌ No |

---

## 👤 Empleados

| Método | Endpoint | Descripción | Autenticación |
|--------|----------|------------|---------------|
| GET | `/api/employees` | Obtener todos los empleados | ✅ Sí |
| GET | `/api/employees/{id}` | Obtener empleado por ID | ✅ Sí |
| POST | `/api/employees` | Crear empleado | ✅ Sí |
| PUT | `/api/employees/{id}` | Actualizar empleado | ✅ Sí |
| PUT | `/api/employees/{id}/change-password` | Cambiar contraseña | ✅ Sí |
| DELETE | `/api/employees/{id}` | Eliminación lógica | ✅ Sí |

⚠ Todos los endpoints de empleados requieren autenticación JWT.

---

# 🧪 Pruebas Unitarias

El proyecto incluye pruebas unitarias implementadas en:

**Redarbor.Tests**

### Tecnologías utilizadas:

- xUnit
- Moq

### Cobertura enfocada en:

- Servicios de autenticación
- Casos de uso de empleados
- Validaciones de negocio
- Manejo de errores

### Ejecutar pruebas:

Ejecutar en Bash:

dotnet test 

---

## 🐳 Docker

La aplicación puede ejecutarse completamente mediante Docker.

### 1️⃣ Construir imagen
docker build -t redarbor-api .
### 2️⃣ Ejecutar contenedor
docker run -p 5000:8080 redarbor-api

La API quedará disponible en:

http://localhost:5000

Swagger:

http://localhost:5000/swagger

---

## 💾 Persistencia

- Escritura → Entity Framework Core
- Lectura → Dapper
- Eliminación lógica → Campo IsDeleted
- Auditoría → Triggers SQL
- Registro automático de LastLogin

---

# ⚙ Configuración sin Docker

### 1️⃣ Clonar repositorio
git clone https://github.com/AndresCruzArd/Redarbor-API.git
### 2️⃣ Configurar cadena de conexión

Editar appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=RedarborDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

### 3️⃣ Ejecutar migraciones
dotnet ef database update
### 4️⃣ Ejecutar la API
dotnet run

---

## 📊 Estado Actual del Proyecto

- Arquitectura limpia correctamente aplicada
- Separación clara de capas
- Principios SOLID implementados
- Enfoque DDD táctico
- Código limpio y mantenible
- Persistencia híbrida EF + Dapper
- Tests unitarios implementados
- Docker funcional
- Buen desacoplamiento

---

## 👤 Autor

Andrés Cruz
Prueba técnica desarrollada para Redarbor.

---

## 🧠 Nota Final

Este proyecto demuestra:

- Diseño arquitectónico sólido
- Aplicación real de principios OOP, SOLID y DDD
- Enfoque profesional en seguridad
- Código mantenible y escalable.


