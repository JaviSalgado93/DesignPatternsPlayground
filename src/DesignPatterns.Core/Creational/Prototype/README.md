# Patrón Prototype

## ¿Qué es Prototype?

Prototype define una interfaz para crear un objeto, pero deja que sea una subclase quien decida qué clase instanciar. Usa clonación para crear nuevos objetos basados en un prototipo existente.

## Propósito

- Crear objetos clonando un prototipo existente
- Evitar subclases de creadores
- Copiar objetos complejos de forma eficiente
- Crear variaciones basadas en un original

## Ventajas ✅

- ✅ Evita jerarquías de clases complejas
- ✅ Clonación más eficiente que crear desde cero
- ✅ Flexible para crear variaciones
- ✅ Reduce acoplamiento

## Desventajas ⚠️

- ⚠️ Clonación profunda puede ser compleja
- ⚠️ Objetos circulares son difíciles de clonar
- ⚠️ Puede ser más lento que crear instancias
- ⚠️ Requiere implementar ICloneable correctamente

## Cuándo usar

✓ Crear copias de objetos costosos
✓ Cuando crear desde cero es caro
✓ Cuando necesitas variaciones de un objeto
✓ Sistemas con muchas variantes similares

## Cuándo NO usar

✗ Objetos simples
✗ Cuando copiar es más caro que crear
✗ Relaciones circulares complejas