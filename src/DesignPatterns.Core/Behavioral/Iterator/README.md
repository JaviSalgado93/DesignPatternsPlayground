# Patrón Iterator

## ¿Qué es Iterator?

Iterator proporciona una forma de acceder secuencialmente a los elementos de una colección sin exponer su representación subyacente.

## Propósito

- Acceso secuencial a elementos
- Ocultar estructura interna
- Múltiples iteraciones simultáneas
- Diferentes formas de recorrido
- Abstracción de colecciones

## Ventajas ✅

- ✅ Acceso uniforme a colecciones
- ✅ Oculta estructura interna
- ✅ Múltiples iteradores simultáneos
- ✅ Responsabilidad única
- ✅ Fácil cambiar estructura interna

## Desventajas ⚠️

- ⚠️ Overhead de clases
- ⚠️ Complejidad inicial
- ⚠️ No ideal para colecciones pequeñas
- ⚠️ C# tiene IEnumerable nativo

## Cuándo usar

✓ Colecciones complejas
✓ Múltiples formas de recorrido
✓ Ocultar estructura interna
✓ Iterar sin exponer detalles

## Cuándo NO usar

✗ Colecciones simples
✗ Una sola forma de recorrido
✗ Mejor usar IEnumerable de C#