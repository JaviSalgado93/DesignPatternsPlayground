# Patrón Adapter

## ¿Qué es Adapter?

Adapter convierte la interfaz de una clase en otra interfaz que el cliente espera. Permite que clases incompatibles trabajen juntas.

## Propósito

- Hacer compatible código incompatible
- Integrar librerías externas
- Adaptar interfaces antiguas a nuevas
- Permitir reutilización de código existente

## Ventajas ✅

- ✅ Permite integrar código incompatible
- ✅ Reutiliza clases existentes
- ✅ Desacopla cliente de implementación
- ✅ Flexible para múltiples adaptaciones

## Desventajas ⚠️

- ⚠️ Complejidad adicional
- ⚠️ Posibles impactos de performance
- ⚠️ Puede ocultar problemas de diseño
- ⚠️ Múltiples adaptadores = confusión

## Cuándo usar

✓ Integrar librerías de terceros
✓ Trabajar con código legacy
✓ Interfaces incompatibles
✓ Sistemas modulares con cambios

## Cuándo NO usar

✗ Interfaces ya compatibles
✗ Para ocultar problemas de diseño
✗ Cuando refactorizar es mejor opción