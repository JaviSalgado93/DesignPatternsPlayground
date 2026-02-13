# Builder (Constructor)

## ¿Qué es Builder?

Builder separa la construcción de un objeto complejo de su representación, permitiendo crear diferentes representaciones usando el mismo proceso de construcción.

## Propósito

- Construir objetos complejos paso a paso
- Evitar constructores con muchos parámetros
- Hacer código más legible y mantenible
- Crear diferentes variaciones del mismo objeto

## Ventajas ✅

- ✅ Evita constructores con muchos parámetros
- ✅ Código más legible y fluido
- ✅ Flexible para crear variaciones
- ✅ Separación clara entre construcción y representación

## Desventajas ⚠️

- ⚠️ Más código de lo necesario
- ⚠️ Overhead para objetos simples
- ⚠️ Requiere crear clase Builder
- ⚠️ Puede ser excesivo para pocos parámetros

## Cuándo usar

✓ Objetos con muchos parámetros opcionales
✓ StringBuilder, HttpClient ya lo usan
✓ Configuraciones complejas
✓ Constructores con múltiples variaciones

## Cuándo NO usar

✗ Objetos simples
✗ Pocos parámetros
✗ Que nunca cambian