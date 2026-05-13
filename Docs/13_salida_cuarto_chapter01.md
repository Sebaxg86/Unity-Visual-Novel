# Salida del Cuarto en `Chapter01`

Esta guia agrega una interaccion minima para que Jihuun no pase automaticamente del cuarto al encuentro con amigos.

La meta es simple:

- termina el dialogo del cuarto
- aparece una salida interactiva
- el jugador pulsa esa salida
- entonces recien pasan al beat de amigos

## Objetivo

Dejar una salida del cuarto funcional en la escena `Chapter01`.

## Antes de empezar

1. Abre:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegurate de no estar en `Play Mode`
3. No necesitas borrar nada de lo que ya existe

## Estructura recomendada

Dentro de `Canvas_Chapter01`, crea esto:

- `Group_RoomExit`
  - `BTN_RoomExit`

## Como crear la estructura

### Crear `Group_RoomExit`

1. En la `Hierarchy`, selecciona `Canvas_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_RoomExit`

### Crear `BTN_RoomExit`

1. Selecciona `Group_RoomExit`
2. Clic derecho
3. `UI (Canvas) -> Button - TextMeshPro`
4. Renombra a:
   `BTN_RoomExit`

## Acomodo basico

### `Group_RoomExit`

1. Selecciona `Group_RoomExit`
2. Ve al `Inspector`
3. Pulsa `Add Component`
4. Agrega:
   `CanvasGroup`

Dejalo asi:

- `Alpha = 0`
- `Interactable = false`
- `Blocks Raycasts = false`

### `BTN_RoomExit`

1. Selecciona `BTN_RoomExit`
2. En `Rect Transform` usa:
   - ancla: `middle right`
   - `Pos X = -170`
   - `Pos Y = 50`
   - `Width = 220`
   - `Height = 90`

3. En el componente `Image` tienes dos caminos:

#### Opcion simple

Deja el boton como boton normal y cambia el color a algo visible pero discreto.

#### Opcion con sprite

Si quieres probar algo mas visual, en `Image -> Source Image` puedes asignar:

- [Puerta.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Props/Puerta.PNG>)

Si usas el sprite de puerta:

- activa `Preserve Aspect`

4. Selecciona el hijo `Text (TMP)` del boton
5. Cambia el texto a:
   `Salir`

Si usaste sprite de puerta y no quieres texto encima:

- puedes desactivar ese hijo `Text (TMP)`

## Conexion con `Chapter01Director`

1. Selecciona `Canvas_Chapter01`
2. En el `Inspector`, busca el componente `Chapter01Director`
3. Conecta estos campos nuevos:

- `Room Exit Canvas Group`
  - arrastra `Group_RoomExit`
- `Room Exit Button`
  - arrastra `BTN_RoomExit`

No hace falta configurar `On Click()` manualmente.
El script se conecta al boton por codigo.

## Validacion minima

1. Guarda la escena
2. Dale `Play`
3. Avanza con `Next` hasta terminar el tramo del cuarto
4. En vez de saltar directo a los amigos, deberia aparecer la salida del cuarto
5. Pulsa `Salir`
6. Entonces deberia pasar al beat de amigos

## Si algo falla

- no aparece la salida
  - revisa `Room Exit Canvas Group`
  - revisa `Room Exit Button`
- aparece visible desde el inicio
  - revisa `CanvasGroup` de `Group_RoomExit`
  - debe empezar en `Alpha = 0`
- pulsas el boton y no pasa nada
  - revisa que en `Chapter01Director` si esten conectados los dos campos nuevos

## Nota

Esta es una interaccion minima.
Mas adelante podemos reemplazarla por hotspots reales del cuarto, objetos examinables y una puerta integrada de forma mas bonita.
