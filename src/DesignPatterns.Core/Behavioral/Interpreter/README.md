# Patrón Iterator

## ¿Qué es Iterator?

Iterator proporciona una forma de acceder secuencialmente a los elementos de una colección sin exponer su representación subyacente. Permite iterar sobre diferentes estructuras de datos de manera uniforme.

## Propósito

- Acceder secuencialmente elementos
- Ocultar estructura interna
- Iterar diferentes colecciones
- Recorrido uniforme
- Múltiples iteradores simultáneos

## Ventajas ✅

- ✅ Acceso secuencial uniforme
- ✅ Oculta estructura interna
- ✅ Múltiples iteradores simultáneos
- ✅ Responsabilidad única
- ✅ Fácil agregar nuevas colecciones

## Desventajas ⚠️

- ⚠️ Complejidad adicional
- ⚠️ Overhead de memoria
- ⚠️ Más clases necesarias
- ⚠️ No soporta cambios durante iteración

## Cuándo usar

✓ Acceder elementos sin exponer estructura
✓ Múltiples formas de iteración
✓ Diferentes tipos de colecciones
✓ Múltiples iteradores simultáneos

## Cuándo NO usar

✗ Colecciones simples
✗ Sin necesidad de acceso secuencial
✗ Una sola forma de iteración