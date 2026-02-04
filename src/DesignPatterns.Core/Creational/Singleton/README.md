# Patrón Singleton

## ¿Qué es el Singleton?

El patrón Singleton es un patrón de diseño **creacional** que garantiza que una clase tenga una única instancia (objeto) en toda la aplicación y proporciona un punto de acceso global a esa instancia.

## Propósito

- **Asegurar una única instancia**:  La clase controla su propia instanciación
- **Acceso global**: Proporciona un punto de acceso global a esa instancia única
- **Inicialización lazy**: La instancia se crea solo cuando se necesita

## Estructura
┌─────────────────────────┐ 
│ - Singleton             │ 
├─────────────────────────┤ 
│ - _instance: Singleton  │ 
├─────────────────────────┤ 
│ - Singleton()           │ 
│ + Instance: Singleton   │  
│ + DoSomething()         │ 
└─────────────────────────┘

## Ventajas ✅

- ✅ **Control centralizado**: Una única instancia controlada
- ✅ **Acceso global**: Fácil acceso desde cualquier parte del código
- ✅ **Lazy initialization**: Se crea solo cuando se necesita
- ✅ **Thread-safe**: Versiones seguras para entornos multi-hilo

## Desventajas ⚠️

- ⚠️ **Acoplamiento global**: El código depende de una instancia global
- ⚠️ **Difícil de testear**: Requiere mocking para pruebas unitarias
- ⚠️ **Oculta dependencias**: Las dependencias no son explícitas en constructores
- ⚠️ **Difícil de mantener**: Puede llevar a código spaghetti

## Cuándo usar Singleton

✓ Logging centralizado
✓ Gestión de configuración global
✓ Pool de conexiones a base de datos
✓ Caché centralizado
✓ Acceso a recursos compartidos

## Cuándo NO usar Singleton

✗ Como reemplazo de parámetros en métodos
✗ Cuando la instancia cambia durante la ejecución
✗ En código que necesita ser altamente testeable
✗ Como forma de global state (malo para testing)

## Variantes en C#

### 1. Lazy Initialization (Recomendado)
```csharp
public sealed class Singleton
{
    private static readonly Lazy<Singleton> _lazy = 
        new Lazy<Singleton>(() => new Singleton());

    public static Singleton Instance => _lazy. Value;

    private Singleton() { }
}