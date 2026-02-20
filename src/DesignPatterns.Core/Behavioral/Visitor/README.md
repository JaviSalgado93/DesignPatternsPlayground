# Patrón Visitor

## ¿Qué es Visitor?

Visitor representa una operación a ser realizada en elementos de una estructura de objetos. Visitor permite definir nuevas operaciones sin cambiar las clases de los elementos sobre los que opera.

## Propósito

- Operaciones en estructuras complejas
- Separar algoritmo de estructura
- Agregar operaciones sin cambiar elementos
- Double dispatch
- Mantener elementos estables

## Ventajas ✅

- ✅ Agregar operaciones sin cambiar elementos
- ✅ Agrupar lógica relacionada
- ✅ Fácil agregar nuevas operaciones
- ✅ Separa datos de lógica
- ✅ Double dispatch elegante

## Desventajas ⚠️

- ⚠️ Difícil agregar nuevos elementos
- ⚠️ Complejidad inicial alta
- ⚠️ Viola encapsulación
- ⚠️ Requiere acceso a miembros privados

## Cuándo usar

✓ Muchas operaciones distintas
✓ Estructura de objetos estable
✓ Operaciones sin relación
✓ Árbol de objetos complejo

## Cuándo NO usar

✗ Pocos operaciones
✗ Estructura cambia frecuentemente
✗ Operaciones relacionadas