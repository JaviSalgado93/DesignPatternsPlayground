# Factory Method (Método de Fábrica)

## ¿Qué es Factory Method?

Factory Method es un patrón de diseño **creacional** que define una interfaz para crear objetos, pero deja que las subclases decidan qué clase instanciar.

## Propósito

- **Desacoplamiento**: El código cliente no conoce las clases concretas
- **Flexibilidad**: Fácil agregar nuevos tipos sin modificar código existente
- **Responsabilidad única**: Cada clase se encarga de crear sus propias instancias

## Estructura
┌────────────────────────────┐ 
│        IProduct            │ 
├────────────────────────────┤
│      + Operation()         │ 
└────────────────────────────┘ 
                △              
                │              
      ┌─────────┴─────────┐    
      │         │         │    
┌────────┐┌────────┐┌────────┐ 
│ProductA││ProductB││ProductC│ 
└────────┘└────────┘└────────┘ 
      △         △         △    
      │         │         │    
┌────────────────────────────┐ 
│       Creator (Factory)    │
├────────────────────────────┤  
│      + FactoryMethod()     │ 
└────────────────────────────┘


## Ventajas ✅

- ✅ Desacoplamiento entre cliente y productos concretos
- ✅ Principio Single Responsibility
- ✅ Principio Open/Closed (fácil extender)
- ✅ Código más limpio y mantenible

## Desventajas ⚠️

- ⚠️ Más clases de las necesarias
- ⚠️ Complejidad inicial mayor
- ⚠️ Overhead para casos simples

## Cuándo usar Factory Method

✓ Cuando no conoces de antemano qué tipo de objeto necesitas
✓ Cuando quieres delegar la creación a subclases
✓ Cuando necesitas flexibilidad en la creación de objetos
✓ Cuando el tipo de objeto depende de parámetros en tiempo de ejecución

## Cuándo NO usar Factory Method

✗ Para casos muy simples (usa constructor directo)
✗ Cuando solo hay un tipo de objeto
✗ Cuando la lógica es trivial

## Variantes en C#

### 1. Factory Method Simple
```csharp
public abstract class Creator
{
    public abstract IProduct FactoryMethod();
    
    public void BusinessLogic()
    {
        var product = FactoryMethod();
        product.Operation();
    }
}