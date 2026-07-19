# Reto Técnico - Blazor Web App + API REST

## Descripción

Aplicación desarrollada en **Blazor Web App** (.NET, interactividad en modo Server)
que consume una API REST y despliega los datos en una grilla.

Como no se contaba con el endpoint de la API original, se desarrolló también una
**API REST propia en ASP.NET Core** que expone los mismos datos con la misma
estructura solicitada, para demostrar tanto el consumo como la construcción de
una API.

## Estructura del proyecto

```
├── RetoTecnico/     → Aplicación Blazor Web App (frontend)
└── MiApi2/          → API REST en ASP.NET Core (backend)
```

## Requisitos

- .NET SDK 8.0 o superior instalado (`dotnet --version` para verificar)

## Cómo ejecutar el proyecto

Se necesitan **dos terminales abiertas al mismo tiempo**, una por proyecto.

### 1. Levantar la API

En una terminal:

```
cd MiApi2
dotnet run
```

Va a quedar escuchando en algo como `http://localhost:5097` (el puerto puede
variar). Se puede probar el endpoint directamente en el navegador:

```
http://localhost:5097/api/tiposmovimiento
```

Debe devolver el JSON con los tipos de movimiento.

### 2. Levantar la aplicación Blazor

En una segunda terminal:

```
cd RetoTecnico
dotnet run
```

Va a quedar escuchando en otro puerto (por ejemplo `http://localhost:5282`).
Abrir esa URL en el navegador — la grilla se muestra directamente en la página
de inicio (`/`) y también en `/movimientos`.

> Nota: si el puerto de la API cambia al ejecutarla en otro equipo, hay que
> actualizar la URL base en `RetoTecnico/Program.cs` (línea de
> `client.BaseAddress`) para que coincida con el puerto real de `MiApi2`.

## Arquitectura y decisiones técnicas

- **Blazor Web App con render mode `InteractiveServer`**: la lógica corre en
  el servidor, evitando problemas de CORS al llamar la API desde el navegador
  y simplificando el manejo de estado.
- **Separación en capas**: el modelo (`Models/TipoMovimiento.cs`), el servicio
  encargado de la llamada HTTP (`Services/TipoMovimientoService.cs`), y la
  página que solo se encarga de mostrar los datos (`Pages/Movimientos.razor`)
  están separados para mantener responsabilidades claras.
- **Inyección de dependencias**: el `HttpClient` se registra en `Program.cs`
  con `AddHttpClient`, y se inyecta automáticamente donde se necesita.
- **Programación asíncrona (`async`/`await`)**: la llamada a la API no bloquea
  la aplicación mientras espera la respuesta.
- **CORS habilitado en la API**: permite que la aplicación Blazor (u otras)
  puedan consumir los datos sin ser bloqueadas por el navegador.

## Estructura del JSON devuelto por la API

```json
[
    { "Codigo": 29, "Descripcion": "Ajuste al Inventario", "VActiva": false },
    { "Codigo": 51, "Descripcion": "Avance Produccion", "VActiva": false },
    { "Codigo": 17, "Descripcion": "Balance Inicial", "VActiva": false }
]
```
