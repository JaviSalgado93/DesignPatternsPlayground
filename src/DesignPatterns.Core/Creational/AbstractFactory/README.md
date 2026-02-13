# Patrón Abstract Factory

## ¿Qué es Abstract Factory?

Abstract Factory define una interfaz para crear familias de objetos relacionados sin especificar sus clases concretas.

## Propósito

- Crear familias de objetos relacionados
- Desacoplar el cliente de las clases concretas
- Garantizar que los productos de una familia funcionen juntos

## Ventajas ✅

- ✅ Desacoplamiento total del cliente
- ✅ Garantiza coherencia entre productos
- ✅ Fácil cambiar familias completas
- ✅ Responsabilidad única

## Desventajas ⚠️

- ⚠️ Muchas clases
- ⚠️ Complejidad inicial
- ⚠️ Difícil agregar nuevos tipos

## Cuándo usar

✓ Sistemas multiplataforma (Windows, macOS, Linux)
✓ Temas UI (Light, Dark, High Contrast)
✓ Familias de componentes relacionados
✓ Cuando necesitas garantizar compatibilidad

## Cuándo NO usar

✗ Para un único producto
✗ Cuando la familia es muy pequeña
✗ Casos simples