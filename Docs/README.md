# Documentación del proyecto

Esta carpeta reúne la documentación pública y vigente de `Entre tu Silencio y el Mío`.

## Objetivo

La documentación se reorganizó para cumplir tres funciones:

1. explicar el estado real del proyecto;
2. conservar una fuente de verdad narrativa y técnica del capítulo 1;
3. servir como referencia para futuras iteraciones sin depender de notas de montaje paso a paso.

## Estructura actual

- `00_explicacion_capitulo1_fuente_de_verdad.md`  
  Fuente narrativa y de dirección del capítulo 1.

- `01_glosario_unity.md`  
  Conceptos básicos de Unity usados por el proyecto.

- `02_estado_actual.md`  
  Estado técnico actual, alcance logrado y pendientes de alto nivel.

- `03_recursos_y_assets.md`  
  Organización de assets, flujo entre `Recursos/` y `Assets/`, e inventario general.

- `04_arquitectura_tecnica.md`  
  Estructura de escenas, sistemas y scripts principales.

- `05_implementacion_capitulo_01.md`  
  Resumen de cómo quedó implementado el capítulo 1.

- `06_build_y_distribucion.md`  
  Proceso de build, distribución y validación de una versión jugable.

## Criterios de mantenimiento

- `Recursos/` conserva materiales fuente y referencias externas.
- `Assets/` contiene únicamente contenido importado y usado por Unity en runtime.
- Las decisiones canónicas de narrativa, UI y dirección del capítulo 1 deben reflejarse primero en `00_explicacion_capitulo1_fuente_de_verdad.md`.
- La documentación debe describir el proyecto de forma general y reutilizable; no como instrucciones personales de una sesión de trabajo.
