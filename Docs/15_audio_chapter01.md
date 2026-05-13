# Audio Basico para `Chapter01`

Esta guia agrega audio basico al `Chapter01` que ya montaste.

La meta es tener:

- musica al inicio
- notificacion del telefono
- musica del cuarto / amigos
- musica o ambiente del pasillo
- ambiente de cafeteria
- sonido al salir del cuarto
- sonido al elegir opcion
- sonido al cierre del capitulo

## Objetivo

Dar ritmo y retroalimentacion al capitulo sin construir todavia un sistema de audio complejo.

## Antes de empezar

1. Abre:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegurate de no estar en `Play Mode`
3. Vamos a usar **2 AudioSource**:
   - uno para musica
   - uno para efectos

## Estructura recomendada

En la `Hierarchy`, crea esto:

- `Audio_Chapter01`
  - `Audio_BGM`
  - `Audio_SFX`

## Como crear la estructura

### Crear `Audio_Chapter01`

1. Clic derecho en la `Hierarchy`
2. `Create Empty`
3. Renombra a:
   `Audio_Chapter01`

### Crear `Audio_BGM`

1. Selecciona `Audio_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Audio_BGM`
5. Con `Audio_BGM` seleccionado, en `Inspector` pulsa `Add Component`
6. Agrega:
   `Audio Source`

### Crear `Audio_SFX`

1. Selecciona `Audio_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Audio_SFX`
5. Con `Audio_SFX` seleccionado, en `Inspector` pulsa `Add Component`
6. Agrega:
   `Audio Source`

## Configuracion de los AudioSource

### `Audio_BGM`

En el componente `Audio Source`, deja:

- `Play On Awake = false`
- `Loop = true`
- `Spatial Blend = 0`
- `Volume = 0.45`

### `Audio_SFX`

En el componente `Audio Source`, deja:

- `Play On Awake = false`
- `Loop = false`
- `Spatial Blend = 0`
- `Volume = 0.80`

## Conexion con `Chapter01Director`

1. Selecciona `Canvas_Chapter01`
2. Busca el componente `Chapter01Director`

Conecta estos campos:

### AudioSource

- `Music Source`
  - arrastra `Audio_BGM`
- `Sfx Source`
  - arrastra `Audio_SFX`

### Music

- `Intro Music`
  - [BGM_Escenas.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/Music/BGM_Escenas.mp3>)
- `Room Music`
  - [BGM_Escenas.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/Music/BGM_Escenas.mp3>)
- `Hallway Music`
  - [Ambiente pasillos Escuela.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Ambiente pasillos Escuela.mp3>)
- `Cafeteria Music`
  - [Ambiente Cafteria.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Ambiente Cafteria.mp3>)

### SFX

- `Phone Notification Sfx`
  - [PhoneNotification.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/PhoneNotification.mp3>)
- `Room Exit Sfx`
  - [Puerta_Abriendose.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Puerta_Abriendose.mp3>)
- `Choice Selected Sfx`
  - [ButtonClick.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/ButtonClick.mp3>)
- `Chapter Complete Sfx`
  - [Achievement.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Achievement.mp3>)

## Que deberia pasar despues

Cuando juegues `Chapter01`:

- al iniciar, suena musica
- al aparecer el telefono, suena notificacion
- al salir del cuarto, suena puerta
- al elegir opciones, suena click
- al pasar al pasillo, cambia el audio
- al pasar a cafeteria, cambia el audio
- al final, suena cierre de capitulo

## Validacion minima

1. Guarda la escena
2. Dale `Play`
3. Escucha si arranca musica al principio
4. Avanza hasta el telefono y escucha la notificacion
5. Avanza hasta la salida del cuarto y escucha la puerta
6. Haz una eleccion y escucha el click
7. Llega al cierre del capitulo y escucha el `Achievement`

## Si algo falla

- no suena nada
  - revisa `Music Source` y `Sfx Source`
- la musica no cambia
  - revisa que los clips si esten conectados
- la puerta o la notificacion no suenan
  - revisa los campos de SFX
- todo suena muy fuerte o muy bajo
  - ajusta `Volume` en `Audio_BGM` y `Audio_SFX`

## Nota

Esto es audio de fase 1.
Mas adelante podemos separar musica, ambiente y UI en un sistema mas elegante.
