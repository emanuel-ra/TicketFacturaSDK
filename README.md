# TicketFacturaSDK

Una biblioteca de clases (.NET) para facilitar el consumo de la API de [Ticket factura].

---

## 🚀 Características

- Manejo de usuarios, productos y órdenes (según endpoints disponibles).
- Fácil de configurar y extender.
- Basado en `HttpClient`, soporta inyección de dependencias.
- Pensado para ser limpio, escalable y mantenible.

---

## 📦 Instalación

### Opción 1: Compilar e incluir

1. Clona este repositorio o descarga el código fuente.
2. Compila el proyecto `MyApiSdk`.
3. Agrega la referencia al `.dll` en tu proyecto cliente.

### Opción 2: Referenciar el proyecto (recomendado en desarrollo)

1. Añade el proyecto `MyApiSdk` a tu solución.
2. Agrega una referencia al proyecto desde tu aplicación.

---

## ⚙️ Configuración inicial

Primero crea una configuración:

```csharp
var config = new ApiConfig
{
    BaseUrl = "https://api.example.com",
    ApiKey = "tu_api_key_aquí",
    TimeoutSeconds = 30 // Opcional
};
