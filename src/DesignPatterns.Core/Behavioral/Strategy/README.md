# Patrón Strategy

## ¿Qué es Strategy?

Strategy define una familia de algoritmos, encapsula cada uno y los hace intercambiables. Strategy permite que el algoritmo varíe independientemente de los clientes que lo utilizan.

## Propósito

- Encapsular algoritmos
- Algoritmos intercambiables
- Evitar condicionales
- Dinámico en tiempo de ejecución
- Políticas configurables

## Ventajas ✅

- ✅ Intercambia algoritmos en tiempo de ejecución
- ✅ Elimina sentencias condicionales
- ✅ Responsabilidad única
- ✅ Fácil de testear
- ✅ Open/Closed Principle

## Desventajas ⚠️

- ⚠️ Muchas clases nuevas
- ⚠️ Overhead si pocos algoritmos
- ⚠️ Acoplamiento con interfaz
- ⚠️ Complejidad adicional

## Cuándo usar

✓ Múltiples algoritmos para tarea
✓ Cambios dinámicos de algoritmo
✓ Evitar condicionales complejas
✓ Testeo independiente

## Cuándo NO usar

✗ Un solo algoritmo
✗ Algoritmos raramente cambian
✗ Complejidad innecesaria