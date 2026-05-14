# Interacciones del Cuarto en `Chapter01`

Esta guia extiende la salida del cuarto para que la habitacion tenga interacciones simples:

- puerta
- bonsai
- barra de proteina

La meta es:

1. termina el dialogo del cuarto
2. aparecen 3 hotspots/botones
3. si pulsas `Bonsai`, sale un pensamiento corto y vuelves al cuarto
4. si pulsas `Barra`, sale otro pensamiento corto y vuelves al cuarto
5. si pulsas `Salir`, recien pasas a los amigos

## Objetivo

Hacer que el cuarto se sienta mas como escena jugable y menos como tramite automatico.

## Antes de empezar

1. Abre:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegurate de no estar en `Play Mode`
3. Esta guia reutiliza tu `Group_RoomExit`

## Estructura recomendada

Dentro de `Group_RoomExit`, deja esto:

- `BTN_RoomExit`
- `BTN_RoomBonsai`
- `BTN_RoomProteinBar`

## Como crear los dos botones nuevos

### Crear `BTN_RoomBonsai`

1. En la `Hierarchy`, selecciona `Group_RoomExit`
2. Clic derecho
3. `UI (Canvas) -> Button - TextMeshPro`
4. Renombra a:
   `BTN_RoomBonsai`

### Crear `BTN_RoomProteinBar`

1. En la `Hierarchy`, selecciona `Group_RoomExit`
2. Clic derecho
3. `UI (Canvas) -> Button - TextMeshPro`
4. Renombra a:
   `BTN_RoomProteinBar`

## Acomodo basico

Puedes trabajarlos como hotspots visibles o como botones discretos.

### Opcion simple y clara

Dejalos como botones visibles con texto.

#### `BTN_RoomExit`

- texto hijo `Text (TMP)`:
  - `Salir`
- `Rect Transform`:
  - ancla: `middle right`
  - `Pos X = -170`
  - `Pos Y = 40`
  - `Width = 220`
  - `Height = 90`

#### `BTN_RoomBonsai`

- texto hijo `Text (TMP)`:
  - `Bonsai`
- `Rect Transform`:
  - ancla: `middle right`
  - `Pos X = -420`
  - `Pos Y = -10`
  - `Width = 180`
  - `Height = 70`

#### `BTN_RoomProteinBar`

- texto hijo `Text (TMP)`:
  - `Barra`
- `Rect Transform`:
  - ancla: `middle right`
  - `Pos X = -420`
  - `Pos Y = -100`
  - `Width = 180`
  - `Height = 70`

### Opcion visual

Si prefieres, puedes asignar sprites:

- `BTN_RoomBonsai`
  - [Bonsai.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Props/Bonsai.png>)
- `BTN_RoomProteinBar`
  - [Barra_de_Proteina.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Props/Barra_de_Proteina.png>)

Si usas sprite:

1. Asignalo en `Image -> Source Image`
2. Activa `Preserve Aspect`
3. Si no quieres texto encima, desactiva el hijo `Text (TMP)`

## Conexion con `Chapter01Director`

1. Selecciona `Canvas_Chapter01`
2. Busca el componente `Chapter01Director`
3. Conecta estos campos nuevos:

- `Room Bonsai Button`
  - arrastra `BTN_RoomBonsai`
- `Room Protein Bar Button`
  - arrastra `BTN_RoomProteinBar`

No hace falta conectar `On Click()` manualmente.
El script lo hace por codigo.

## Validacion minima

1. Guarda la escena
2. Dale `Play`
3. Avanza hasta terminar el dialogo del cuarto
4. Deberian aparecer los 3 botones/hotspots
5. Pulsa `Bonsai`
6. Deberian salir un par de pensamientos y luego volver al cuarto
7. Pulsa `Barra`
8. Deberia pasar lo mismo
9. Pulsa `Salir`
10. Recién ahi deberia continuar a los amigos

## Si algo falla

- los botones nuevos no hacen nada
  - revisa que esten conectados en `Chapter01Director`
- no reaparecen despues de inspeccionar
  - revisa si `Group_RoomExit` sigue con `CanvasGroup`
- brinca directo a los amigos
  - revisa que `BTN_RoomExit` siga conectado en `Chapter01Director`

## Nota

Esto sigue siendo una version simple, pero ya es interaccion real del cuarto.
Mas adelante podemos convertir estos botones en hotspots invisibles mejor colocados sobre el arte.
