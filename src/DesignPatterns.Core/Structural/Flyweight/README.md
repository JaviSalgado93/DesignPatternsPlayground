# Patrón Flyweight

## ¿Qué es Flyweight?

Flyweight utiliza el compartir para soportar eficientemente grandes números de objetos pequeños. Reduce el uso de memoria compartiendo datos comunes entre múltiples objetos.

## Propósito

- Reducir uso de memoria
- Compartir estado intrínseco
- Optimizar performance
- Manejar miles de objetos

## Ventajas ✅

- ✅ Reduce memoria significativamente
- ✅ Mejora performance
- ✅ Escala para muchos objetos
- ✅ Centraliza estado compartido

## Desventajas ⚠️

- ⚠️ Complejidad adicional
- ⚠️ Overhead de CPU (lookup)
- ⚠️ Thread-safety si es necesario
- ⚠️ Difícil debuggear

## Cuándo usar

✓ Muchos objetos similares
✓ Memoria es crítica
✓ Estado intrínseco compartible
✓ Caché de objetos

## Cuándo NO usar

✗ Pocos objetos
✗ Sin estado compartible
✗ Sin problemas de memoria