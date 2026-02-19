# Patrón Bridge

## ¿Qué es Bridge?

Bridge desacopla una abstracción de su implementación para que ambas puedan variar independientemente. Evita la explosión de subclases.

## Propósito

- Desacoplar abstracción de implementación
- Permitir que ambas varíen independientemente
- Evitar jerarquías de clases profundas
- Compartir implementación entre múltiples abstracciones

## Ventajas ✅

- ✅ Elimina dependencias entre abstracción e implementación
- ✅ Reduce explosión de subclases
- ✅ Principio Open/Closed
- ✅ Cambiar implementación en tiempo de ejecución

## Desventajas ⚠️

- ⚠️ Complejidad adicional
- ⚠️ Más interfaces a mantener
- ⚠️ Curva de aprendizaje pronunciada
- ⚠️ Overhead para casos simples

## Cuándo usar

✓ Cuando hay dos dimensiones de variación
✓ Para evitar jerarquías binarias
✓ Cambiar implementación en runtime
✓ Arquitecturas complejas

## Cuándo NO usar

✗ Jerarquías simples
✗ Una sola dimensión de variación
✗ Cuando refactorizar es mejor opción