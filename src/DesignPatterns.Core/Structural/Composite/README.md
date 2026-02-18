# Patrón Composite

## ¿Qué es Composite?

Composite compone objetos en estructuras de árbol para representar jerarquías parte-todo. Permite que los clientes traten objetos individuales y composiciones de forma uniforme.

## Propósito

- Representar jerarquías parte-todo
- Tratar objetos individuales y composiciones uniformemente
- Construir estructuras recursivas
- Simplificar código cliente

## Ventajas ✅

- ✅ Trabaja con estructuras recursivas fácilmente
- ✅ Código cliente simplificado
- ✅ Fácil agregar nuevos tipos
- ✅ Trata partes y todo de forma uniforme

## Desventajas ⚠️

- ⚠️ Puede hacer el diseño muy general
- ⚠️ Difícil restringir tipos de hijos
- ⚠️ Performance en estructuras muy grandes
- ⚠️ Complejidad en operaciones específicas

## Cuándo usar

✓ Estructuras de árbol (archivos, menús, UI)
✓ Parte-todo con jerarquías
✓ Código cliente sin importar estructura
✓ Operaciones en toda la jerarquía

## Cuándo NO usar

✗ Estructuras lineales
✗ Sin relaciones parte-todo
✗ Cuando tipos muy diferentes