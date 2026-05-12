# Docs

Esta carpeta concentra la documentacion operativa del proyecto.

## Fuentes de verdad

- `Docs/Documento_explicacion/`
  Storyboard visual, ritmo, textos, colores y referencias de UI.
- `Recursos/`
  Assets fuente organizados por categoria. Hoy aun no estan importados formalmente a `Assets/`.
- `Assets/`
  Implementacion actual del proyecto Unity.

## Orden recomendado de lectura

1. `01_glosario_unity.md`
2. `02_estado_actual.md`
3. `03_capitulo_01.md`
4. `04_inventario_recursos.md`
5. `05_plan_fase_1.md`
6. `06_plan_migracion_assets.md`
7. `07_checklist_unity_importacion.md`

## Reglas de trabajo

- `Recursos/` es la fuente de assets originales, no la fuente de referencias de Unity.
- Todo asset usado por el juego debe terminar dentro de `Assets/`, importado por Unity.
- Si un asset ya fue importado y ya tiene `.meta`, se debe mover o renombrar desde Unity cuando sea posible.
- La prioridad tecnica actual es cerrar un vertical slice del capitulo 1.
- `save`, `load` y `settings` completos pueden esperar hasta que el flujo principal sea jugable.

## Objetivo de esta documentacion

Que cualquier avance nuevo responda estas preguntas rapido:

- Que existe hoy.
- Que falta para que el capitulo 1 sea jugable.
- Que recursos reales ya estan listos para importar.
- En que orden conviene construir el proyecto.
