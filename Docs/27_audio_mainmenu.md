# Audio para `MainMenu`

Esta guía deja el `MainMenu` con música de fondo al entrar a la escena.

La meta es simple:

- abrir `MainMenu`
- que empiece a sonar `MainMenuBGM.mp3`
- que quede en loop

## Antes de empezar

1. Abre:
   `Assets/_Project/Scenes/MainMenu.unity`
2. Asegúrate de no estar en `Play Mode`

## Paso 1 - Crear el objeto de audio

1. En la `Hierarchy`, clic derecho
2. `Create Empty`
3. Renómbralo a:
   `Audio_MainMenu`

## Paso 2 - Agregar `Audio Source`

1. Selecciona `Audio_MainMenu`
2. En `Inspector`, pulsa `Add Component`
3. Agrega:
   `Audio Source`

## Paso 3 - Configurar el `Audio Source`

En `Audio Source`, deja:

- `Play On Awake = false`
- `Loop = true`
- `Spatial Blend = 0`
- `Volume = 0.45`

No pongas todavía el clip directo aquí; lo vamos a conectar desde `MainMenuController`.

## Paso 4 - Conectar `MainMenuController`

1. Selecciona el objeto que tiene `MainMenuController`
   - normalmente será `Canvas_MainMenu`
2. En `MainMenuController`, busca la sección `Audio`
3. Conecta:
   - `Music Source` -> `Audio_MainMenu`
   - `Background Music` -> [MainMenuBGM.mp3](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Audio/Music/MainMenuBGM.mp3>)
4. Deja:
   - `Loop Background Music = true`

## Qué debería pasar

Cuando entres a `MainMenu`:

1. la escena carga
2. la música empieza sola
3. se queda en loop

## Si algo falla

- no suena nada
  - revisa `Music Source`
  - revisa `Background Music`
  - revisa el volumen del `Audio Source`
- suena dos veces
  - revisa que no haya otro `Audio Source` con `Play On Awake`
- no hace loop
  - revisa `Loop Background Music`
