# Glosario básico de Unity

Este glosario resume los conceptos mínimos necesarios para entender la estructura de este proyecto.

## Escena

Una escena es una unidad de contenido jugable dentro de Unity. Puede contener cámaras, luces, fondos, personajes, UI, audio y scripts.

En este proyecto existen dos escenas principales:

- `MainMenu`
- `Chapter01`

## GameObject

Un `GameObject` es la unidad base de trabajo en Unity. Todo lo visible o interactivo en una escena se representa como un `GameObject`.

Ejemplos:

- un botón;
- una imagen de fondo;
- un personaje;
- una cámara;
- un objeto vacío que agrupa otros elementos.

## Componente

Un componente agrega comportamiento o capacidad a un `GameObject`.

Ejemplos usados en el proyecto:

- `Image`
- `Button`
- `Canvas`
- `CanvasGroup`
- `AudioSource`
- scripts en C#

## Canvas

Un `Canvas` es la superficie donde vive la interfaz de usuario de Unity. Aquí se dibujan botones, textos, overlays, HUD y cajas de diálogo.

## CanvasGroup

`CanvasGroup` permite controlar un grupo completo de UI mediante:

- visibilidad (`alpha`);
- capacidad de recibir clics;
- interacción de sus hijos.

Se usa ampliamente para mostrar y ocultar pantallas de forma suave.

## Hierarchy

La `Hierarchy` es el árbol de objetos de la escena abierta. Muestra relaciones padre-hijo entre `GameObjects`.

## Inspector

El `Inspector` es el panel donde se editan propiedades, componentes y referencias del objeto seleccionado.

## Rect Transform

Es la variante de `Transform` usada por la UI. Controla tamaño, posición y anclajes dentro de un `Canvas`.

## Prefab

Un prefab es una plantilla reutilizable de objetos configurados. Permite reutilizar UI, props o entidades con la misma estructura.

## Asset

Un asset es cualquier archivo usado por Unity:

- sprites;
- audio;
- fuentes;
- escenas;
- scripts;
- materiales;
- animaciones.

## Archivo `.meta`

Cada asset importado por Unity tiene un archivo `.meta` con un identificador único (`GUID`). Las escenas y prefabs referencian ese `GUID`, por lo que borrar o regenerar `.meta` sin cuidado puede romper referencias.
