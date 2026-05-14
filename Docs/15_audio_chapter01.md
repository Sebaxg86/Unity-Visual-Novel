# Audio Basico para `Chapter01`

Esta guia agrega audio basico al `Chapter01` que ya montaste.

La meta es tener:

- musica al inicio
- notificacion del telefono
- musica del cuarto / amigos
- ambiente de calle
- musica o ambiente del pasillo
- ambiente de cafeteria
- entrada suave entre musicas
- popup de confianza y elecciones con sonido de aparicion
- suspiro y risa de Jihuun en momentos clave
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
- `Street Music`
  - [RuidoAfuera.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/RuidoAfuera.mp3>)
- `Hallway Music`
  - [Ambiente pasillos Escuela.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Ambiente pasillos Escuela.mp3>)
- `Cafeteria Music`
  - [Ambiente Cafteria.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Ambiente Cafteria.mp3>)

### SFX

- `Phone Notification Sfx`
  - [PhoneNotification.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/PhoneNotification.mp3>)
- `Intro Typewriter Sfx`
  - dejalo vacio por ahora hasta que exista el `.mp3`
  - si usas un audio largo de persona escribiendo, funciona mejor con `Intro Typewriter Audio Mode = LoopWhileTyping`
  - si algun dia usas un click muy corto por tecla, usa `OneShotTicks`
- `Ui Popup Sfx`
  - [POP.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/POP.mp3>)
- `Room Exit Sfx`
  - [Puerta_Abriendose.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Puerta_Abriendose.mp3>)
- `Choice Selected Sfx`
  - [ButtonClick.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/ButtonClick.mp3>)
- `Jihuun Sigh Sfx`
  - [GirlSigh.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/GirlSigh.mp3>)
- `Jihuun Laugh Sfx`
  - [Jihuun laugh.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Jihuun laugh.mp3>)
- `Chapter Complete Sfx`
  - [Achievement.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/SFX/Achievement.mp3>)

### Timings utiles

- `Music Transition Duration`
  - prueba con `0.42`
- `Fallback Music Volume`
  - prueba con `0.45`
- `Street Music Volume Multiplier`
  - prueba con `1.40`
  - si `Ambiente_Afuera.mp3` se oye muy bajito, subelo a `1.6` o `1.8`
- `Intro Typewriter Sfx Min Interval`
  - prueba con `0.045`
- `Intro Typewriter Volume Multiplier`
  - prueba con `1.2`
  - si sigue bajito, prueba `1.4` o `1.6`
- `Intro Typewriter Sfx Characters Per Tick`
  - prueba con `2`
- `Intro Typewriter Pause Threshold`
  - prueba con `0.09`
- `Intro Typewriter Space Delay Multiplier`
  - prueba con `0.35`
- `Intro Typewriter Comma Pause`
  - prueba con `0.075`
- `Intro Typewriter Sentence Pause`
  - prueba con `0.14`
- `Intro Typewriter Ellipsis Pause`
  - prueba con `0.22`

## Que deberia pasar despues

Cuando juegues `Chapter01`:

- al iniciar, suena musica
- la intro de Jihuun se escribe con pausas mas naturales
- al aparecer el telefono, suena notificacion
- al aparecer el popup de confianza, suena `POP`
- al aparecer una eleccion, suena `POP`
- al salir del cuarto, suena puerta
- al empezar la caminata, Jihuun suelta un suspiro
- cuando el guion menciona que Jihuun se rie o sonrie, suena su risa
- al elegir opciones, suena click
- al pasar a calle, pasillo o cafeteria, el cambio de musica se siente suave
- al final, suena cierre de capitulo

## Validacion minima

1. Guarda la escena
2. Dale `Play`
3. Escucha si arranca musica al principio
4. Avanza hasta el telefono y escucha la notificacion
5. Llega al popup de confianza y escucha `POP`
6. Haz una eleccion y escucha primero `POP` al aparecer y luego `click` al elegir
7. Avanza a la caminata y escucha el suspiro de Jihuun
8. Llega a cafeteria y escucha si la musica cambia suave
9. Llega al cierre del capitulo y escucha el `Achievement`

## Si algo falla

- no suena nada
  - revisa `Music Source` y `Sfx Source`
- la musica no cambia
  - revisa que los clips si esten conectados
- la musica cambia pero corta muy seco
  - sube `Music Transition Duration`
- la calle se oye mas baja que el resto
  - sube `Street Music Volume Multiplier`
- la intro se siente demasiado rapida o robotica
  - ajusta los valores `Intro Typewriter ...`
- el audio de tipeo se encabalga o sigue sonando despues
  - usa `Intro Typewriter Audio Mode = LoopWhileTyping`
  - revisa `Intro Typewriter Pause Threshold`
- el typing se oye muy bajito
  - sube `Intro Typewriter Volume`
  - luego prueba `Intro Typewriter Volume Multiplier`
- la puerta o la notificacion no suenan
  - revisa los campos de SFX
- el popup o las elecciones salen mudas
  - revisa `Ui Popup Sfx`
- la caminata se siente muda
  - revisa `Jihuun Sigh Sfx`
- todo suena muy fuerte o muy bajo
  - ajusta `Volume` en `Audio_BGM` y `Audio_SFX`

## Nota

Esto es audio de fase 1.
Mas adelante podemos separar musica, ambiente y UI en un sistema mas elegante.
