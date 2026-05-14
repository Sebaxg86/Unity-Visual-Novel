# Estado actual del proyecto

## Resumen ejecutivo

- **Motor:** Unity `6000.4.4f1`
- **Estado:** primera build jugable del capítulo 1 completada
- **Escenas principales:**
  - `Assets/_Project/Scenes/MainMenu.unity`
  - `Assets/_Project/Scenes/Chapter01.unity`

## Alcance logrado

El proyecto ya cuenta con una vertical slice funcional del capítulo 1, con flujo jugable desde el menú principal hasta el cierre del episodio.

### Implementado

- menú principal funcional;
- transición desde `New Game` hacia el capítulo;
- intro narrativa del capítulo 1;
- secuencia de teléfono;
- exploración mínima del cuarto;
- encuentro con Seongsu y Jeongho;
- tres decisiones jugables;
- sistema de confianza por personaje;
- HUD y tutorial de confianza;
- cambios de fondo con transiciones suaves;
- retratos, expresiones y señas;
- audio base del capítulo;
- popup final de logro y regreso al menú;
- build local para Windows.

## Estado técnico actual

La estructura principal ya no depende de la escena heredada `CH1_Cafeteria`. El proyecto fue reorganizado alrededor de escenas y sistemas propios dentro de `Assets/_Project/`.

### Estado de calidad

El capítulo 1 es jugable y suficientemente estable para pruebas internas o playtesting temprano. Aun así, sigue siendo una primera versión de producción, no una versión final comercial.

## Pendientes de siguiente fase

Los pendientes principales ya no están en el flujo base del capítulo 1, sino en sistemas complementarios y expansión:

- `Settings`
- `Save / Load`
- persistencia
- contenido del capítulo 2 en adelante
- refinamiento adicional de polish visual y audio

## Decisión de documentación

La documentación antigua de montaje paso a paso fue condensada en una estructura pública y general. El objetivo actual es mantener documentos que describan el proyecto, no notas personales de construcción.
