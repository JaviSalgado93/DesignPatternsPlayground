# Patrón State

## ¿Qué es State?

State permite que un objeto altere su comportamiento cuando su estado interno cambia. El objeto parecerá cambiar de clase. Encapsula diferentes comportamientos en objetos de estado separados.

## Propósito

- Comportamiento dependiente de estado
- Eliminar condicionales complejos
- Encapsular transiciones
- Estados explícitos
- Simplificar máquinas de estado

## Ventajas ✅

- ✅ Elimina sentencias if/switch
- ✅ Responsabilidad única
- ✅ Fácil agregar estados
- ✅ Transiciones claras
- ✅ Comportamiento explícito

## Desventajas ⚠️

- ⚠️ Muchas clases nuevas
- ⚠️ Complejidad inicial
- ⚠️ Overhead de objetos
- ⚠️ Más código boilerplate

## Cuándo usar

✓ Objeto con múltiples estados
✓ Comportamiento depende de estado
✓ Transiciones complejas
✓ Lógica condicional compleja

## Cuándo NO usar

✗ Pocos estados
✗ Lógica simple
✗ Estados inmutables