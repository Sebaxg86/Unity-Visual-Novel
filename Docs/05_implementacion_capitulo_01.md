# Implementación del capítulo 1

Este documento resume cómo quedó implementado el capítulo 1 desde el punto de vista jugable y técnico.

## Objetivo

Construir una vertical slice jugable, fiel al guion base, que permitiera recorrer el capítulo 1 completo desde el menú principal hasta su cierre.

## Flujo implementado

El flujo actual del capítulo sigue esta secuencia:

1. intro narrativa;
2. entrada al cuarto de Jihuun;
3. notificación y secuencia del teléfono;
4. exploración mínima del cuarto;
5. salida al encuentro con Seongsu y Jeongho;
6. tutorial de confianza;
7. primera decisión;
8. calle;
9. pasillos;
10. segunda decisión;
11. cafetería;
12. tercera decisión;
13. cierre de capítulo;
14. popup de logro;
15. retorno al menú principal.

## Sistemas integrados

### Diálogo

- typewriter para texto;
- control de nombre del hablante;
- manejo de pensamientos, señas y narración;
- retratos con foco visual dinámico.

### Elecciones

- tres decisiones en el capítulo;
- opciones con aparición suave;
- selección con feedback sonoro;
- ramificaciones inmediatas de texto.

### Confianza

- dos valores internos: Seongsu y Jeongho;
- popup tutorial;
- HUD persistente después del tutorial;
- una sola barra visible según el personaje en foco.

### Teléfono

- notificación previa;
- apertura y cierre con animación vertical;
- mensajes como sprites completos;
- secuencia intercalada con pensamientos de Jihuun.

### Dirección visual

- cambios de fondo con transición suave;
- expresiones configurables por beat;
- secuencia especial de la seña `Mentirosa` para Jeongho;
- entradas más naturales de retratos en beats importantes.

### Audio

- música del menú;
- música y ambientes por tramo;
- efectos de notificación, botones, popup, logro y typing;
- ajustes de volumen por contexto cuando fue necesario.

## Resultado

El capítulo 1 quedó cerrado como una primera experiencia jugable y coherente. El foco de la fase actual fue:

- fidelidad narrativa;
- claridad visual;
- estabilidad suficiente para build;
- base sólida para futura expansión.

## Trabajo futuro

El siguiente bloque natural del proyecto no está en el capítulo 1, sino en sistemas transversales:

- `Settings`
- `Save / Load`
- persistencia
- nuevos capítulos
- playtesting y ajustes finos
