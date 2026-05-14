# Recursos y assets

Este documento describe cómo se organizan y utilizan los recursos del proyecto.

## Carpetas clave

### `Recursos/`

Contiene el material fuente entregado para el proyecto:

- fondos;
- personajes;
- UI;
- fuentes;
- audio;
- referencias auxiliares.

Su función es servir como respaldo y origen editorial de los assets. No es la carpeta de runtime de Unity.

### `Assets/`

Es la carpeta efectiva del proyecto Unity. Todo asset usado por el juego debe terminar importado aquí para que Unity lo registre con su `.meta` correspondiente.

### `Assets/_Project/`

Agrupa la implementación propia del proyecto en una estructura más clara.

Subcarpetas principales:

- `Art`
- `Audio`
- `Chapter01`
- `Core`
- `Dialogue`
- `Fonts`
- `Scenes`
- `Systems`
- `UI`

## Inventario general de recursos

### Tipografías

- `ComicNeueSansID.ttf`
- `Starborn.ttf`
- `To Japan.ttf`

### Fondos

- `Fondo_MainMenu`
- `Fondo_CuartoJihuun01`
- `Fondo_CuartoJihuun02`
- `Fondo_AfueraCasaJihuun`
- `Fondo_Calle`
- `Fondo_Escaleras`
- `Fondo_Cafeteria`

### Personajes

- `Seongsu`: expresiones, sprite de espaldas
- `Jeongho`: expresiones, sprite de espaldas, secuencia de seña `Mentirosa`

### Props e interactivos

- `Puerta`
- `Bonsai`
- `Barra_de_Proteina`

### UI

- menú principal;
- HUD de confianza;
- popups;
- botones;
- overlays del teléfono;
- modal de salida.

### Audio

- música del menú;
- música base de escenas;
- ambientes de calle, pasillo y cafetería;
- SFX de botones, notificaciones, logro, respiración, risas y typing.

## Reglas de trabajo con assets

- Los assets nuevos deben entrar a `Assets/` en lotes controlados.
- Los `.meta` nunca deben regenerarse manualmente si el asset ya está referenciado por escenas o prefabs.
- Mover o renombrar contenido ya importado debe hacerse preferentemente desde Unity.
- `Recursos/` se conserva como respaldo editorial; `Assets/` es la fuente de verdad técnica.
