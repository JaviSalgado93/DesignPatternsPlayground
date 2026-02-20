# Patrón Memento

## ¿Qué es Memento?

Memento captura y externaliza el estado interno de un objeto sin violar la encapsulación, permitiendo restaurar el objeto a este estado posteriormente. Proporciona un mecanismo para guardar y restaurar estados sin exponer la estructura interna del objeto.

## Propósito

- Guardar estado interno
- Restaurar estados anteriores
- Mantener encapsulación
- Historial de cambios
- Undo/redo sin exposición

## Ventajas ✅

- ✅ Preserva encapsulación
- ✅ Permite undo/redo
- ✅ Historial de estados
- ✅ Fácil crear snapshots
- ✅ Limpio y simple

## Desventajas ⚠️

- ⚠️ Consumo de memoria
- ⚠️ Overhead de copia
- ⚠️ Serialización compleja
- ⚠️ Gestión de historial

## Cuándo usar

✓ Implementar undo/redo
✓ Guardar checkpoints
✓ Historial de cambios
✓ Transacciones reversibles

## Cuándo NO usar

✗ Estados muy grandes
✗ Sin necesidad de historial
✗ Frecuentes cambios