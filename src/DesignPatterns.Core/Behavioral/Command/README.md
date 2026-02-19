# Patrón Command

## ¿Qué es Command?

Command encapsula una solicitud como un objeto, permitiendo parametrizar clientes con diferentes solicitudes, encolar solicitudes y registrar solicitudes. También permite deshacer operaciones.

## Propósito

- Encapsular solicitud como objeto
- Desacoplar cliente del ejecutor
- Permitir undo/redo
- Encolar operaciones
- Registrar cambios

## Ventajas ✅

- ✅ Desacoplamiento entre cliente y ejecutor
- ✅ Permite undo/redo fácilmente
- ✅ Encolar y ejecutar después
- ✅ Registrar historial de cambios
- ✅ Crear macros de comandos

## Desventajas ⚠️

- ⚠️ Más clases en el código
- ⚠️ Complejidad adicional
- ⚠️ Overhead de memoria
- ⚠️ Difícil debuggear

## Cuándo usar

✓ Encapsular operaciones
✓ Undo/redo necesario
✓ Encolar operaciones
✓ Registrar cambios

## Cuándo NO usar

✗ Operaciones simples
✗ Sin necesidad de undo
✗ Pocas operaciones