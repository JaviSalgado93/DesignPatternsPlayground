# Patrón Proxy

## ¿Qué es Proxy?

Proxy proporciona un sustituto o marcador de posición para otro objeto para controlar el acceso a él. Permite diferentes tipos de control sin cambiar el objeto original.

## Propósito

- Controlar acceso a otro objeto
- Lazy loading de recursos costosos
- Proteger acceso (seguridad)
- Logging y auditoría
- Cachear resultados

## Ventajas ✅

- ✅ Lazy loading/carga diferida
- ✅ Control de acceso fino
- ✅ Caching de resultados
- ✅ Logging y monitoreo
- ✅ Objeto original sin cambios

## Desventajas ⚠️

- ⚠️ Complejidad adicional
- ⚠️ Overhead de performance
- ⚠️ Indirección en código
- ⚠️ Difícil mantener sincronización

## Cuándo usar

✓ Control de acceso a recurso costoso
✓ Lazy loading necesario
✓ Logging y auditoría requerida
✓ Caching de operaciones

## Cuándo NO usar

✗ Objeto simple de acceder
✗ Sin necesidad de control
✗ Cuando overhead no es aceptable