# Patrón Mediator

## ¿Qué es Mediator?

Mediator define un objeto que encapsula cómo interactúan un conjunto de objetos. Promueve un acoplamiento débil al mantener los objetos de referencia entre sí indirectamente y permite variar sus interacciones independientemente.

## Propósito

- Encapsular interacciones complejas
- Reducir acoplamiento entre objetos
- Centralizar lógica de comunicación
- Facilitar mantenimiento
- Reutilización de componentes

## Ventajas ✅

- ✅ Desacoplamiento entre colegas
- ✅ Centraliza control
- ✅ Facilita cambios en interacciones
- ✅ Reduce dependencias
- ✅ Componentes reutilizables

## Desventajas ⚠️

- ⚠️ Mediator puede ser complejo
- ⚠️ Punto único de fallo
- ⚠️ Difícil debuggear
- ⚠️ Overhead de comunicación

## Cuándo usar

✓ Objetos comunican de forma compleja
✓ Lógica de comunicación reutilizable
✓ Reducir acoplamiento
✓ Múltiples interacciones

## Cuándo NO usar

✗ Comunicación simple
✗ Pocos objetos
✗ Sin lógica compartida