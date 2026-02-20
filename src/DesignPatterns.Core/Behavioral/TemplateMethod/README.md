# Patrón Template Method

## ¿Qué es Template Method?

Template Method define el esqueleto de un algoritmo en una clase base, permitiendo que las subclases redefinan pasos específicos sin cambiar la estructura del algoritmo.

## Propósito

- Definir estructura de algoritmo
- Permitir variaciones en pasos
- Evitar duplicación de código
- Mantener flujo consistente
- Principio DRY (Don't Repeat Yourself)

## Ventajas ✅

- ✅ Evita duplicación de código
- ✅ Controlado y predecible
- ✅ Reutilización de código
- ✅ Estructura clara
- ✅ Fácil mantener consistencia

## Desventajas ⚠️

- ⚠️ Requiere herencia
- ⚠️ Complejidad de jerarquía
- ⚠️ Hollywood Principle
- ⚠️ Difícil cambiar estructura

## Cuándo usar

✓ Algoritmo con estructura fija
✓ Variaciones en pasos específicos
✓ Código duplicado en subclases
✓ Control del flujo importante

## Cuándo NO usar

✗ Estructura muy variable
✗ Pocos pasos en común
✗ Mejor usar composición