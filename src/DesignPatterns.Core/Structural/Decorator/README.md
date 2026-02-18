# Patrón Decorator

## ¿Qué es Decorator?

Decorator agrega responsabilidades a un objeto dinámicamente. Proporciona una alternativa flexible a la subclasificación para extender funcionalidad.

## Propósito

- Agregar responsabilidades a objetos dinámicamente
- Alternativa flexible a la herencia
- Composición sobre herencia
- Combinaciones dinámicas de comportamiento

## Ventajas ✅

- ✅ Flexible, agrega comportamiento sin herencia
- ✅ Responsabilidad única (SRP)
- ✅ Composición dinámica
- ✅ Fácil combinar decoradores

## Desventajas ⚠️

- ⚠️ Muchos objetos pequeños
- ⚠️ Orden de decoradores importante
- ⚠️ Debugging más complejo
- ⚠️ Posible sobreingeniería

## Cuándo usar

✓ Agregar responsabilidades dinámicamente
✓ Evitar jerarquías de clases
✓ Composición de comportamientos
✓ Casos que no cumplen herencia

## Cuándo NO usar

✗ Cuando herencia es clara
✗ Pocos comportamientos adicionales
✗ Cuando orden no es importante