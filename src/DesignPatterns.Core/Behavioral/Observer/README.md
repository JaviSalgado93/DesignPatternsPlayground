# Patrón Observer

## ¿Qué es Observer?

Observer define una dependencia uno-a-muchos entre objetos, de modo que cuando un objeto cambia de estado, todos sus dependientes son notificados automáticamente. También conocido como patrón Publish-Subscribe.

## Propósito

- Notificar múltiples objetos
- Desacoplar productor/consumidor
- Cambios automáticos
- Suscripción/desuscripción
- Reactividad

## Ventajas ✅

- ✅ Desacoplamiento débil
- ✅ Cambios automáticos
- ✅ Suscripción dinámica
- ✅ Fácil agregar observadores
- ✅ Soporte para eventos

## Desventajas ⚠️

- ⚠️ Orden de notificación impredecible
- ⚠️ Performance con muchos observadores
- ⚠️ Memory leaks si no se desuscribe
- ⚠️ Debugging difícil

## Cuándo usar

✓ Cambios de estado requieren notificación
✓ Múltiples objetos interesados
✓ Independencia entre objetos
✓ Eventos y reactividad

## Cuándo NO usar

✗ Un solo observador
✗ Sin cambios de estado
✗ Orden crítico de notificación