# Patrón Interpreter

## ¿Qué es Interpreter?

Interpreter define una representación gramatical para un lenguaje y un intérprete para procesar sentencias en ese lenguaje.

## Propósito

- Definir lenguaje específico de dominio (DSL)
- Interpretar sentencias en ese lenguaje
- Evaluar expresiones complejas
- Construcción de compiladores simples
- Análisis sintáctico y semántico

## Ventajas ✅

- ✅ Fácil cambiar y extender gramática
- ✅ Implementar lenguajes simples
- ✅ Estructura clara y mantenible
- ✅ Separación de parsing e interpretación
- ✅ Flexible para múltiples contextos

## Desventajas ⚠️

- ⚠️ Clases numerosas para gramática compleja
- ⚠️ Rendimiento limitado
- ⚠️ Difícil para lenguajes complejos
- ⚠️ Overhead de creación de objetos
- ⚠️ Complejidad inicial alta

## Cuándo usar

✓ Lenguajes específicos de dominio
✓ Expresiones matemáticas simples
✓ Comandos personalizados
✓ Configuraciones dinámicas
✓ Consultas simples

## Cuándo NO usar

✗ Lenguajes Turing-completos
✗ Rendimiento crítico
✗ Gramáticas muy complejas