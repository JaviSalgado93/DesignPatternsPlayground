# Patrón Chain of Responsibility

## ¿Qué es Chain of Responsibility?

Chain of Responsibility evita acoplar el remitente de una solicitud con su receptor, dando la oportunidad a más de un objeto de manejar la solicitud. Encadena los objetos receptores y pasa la solicitud a lo largo de la cadena.

## Propósito

- Desacoplar remitente del receptor
- Pasar solicitud por cadena
- Permitir múltiples manejadores
- Procesamiento dinámico

## Ventajas ✅

- ✅ Desacoplamiento entre objetos
- ✅ Responsabilidades flexibles
- ✅ Fácil agregar nuevos manejadores
- ✅ Orden de cadena dinámico

## Desventajas ⚠️

- ⚠️ No garantiza procesamiento
- ⚠️ Difícil debuggear
- ⚠️ Performance si cadena es larga
- ⚠️ Complejo de entender

## Cuándo usar

✓ Múltiples objetos pueden manejar solicitud
✓ Manejador no conocido en avance
✓ Procesamiento en cadena
✓ Solicitudes complejas

## Cuándo NO usar

✗ Solo un manejador
✗ Procesamiento secuencial simple
✗ Necesaria garantía de procesamiento