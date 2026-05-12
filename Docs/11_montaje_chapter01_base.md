# Montaje de `Chapter01` Base en Unity

Esta guia monta la base de la escena `Chapter01`.

Todavia **no** vamos a dejar el capitulo completo.
La meta de este paso es tener:

- un fondo que cambie
- retrato izquierdo
- retrato derecho
- caja de dialogo
- nombre del personaje
- texto principal
- boton `Next`
- overlay de telefono
- overlay de confianza
- fade negro
- `Chapter01Director` conectado

## Objetivo

Dejar una escena `Chapter01` que ya tenga el esqueleto tecnico para que nuestros scripts funcionen.

## Antes de empezar

1. Abre Unity y asegurate de no estar en `Play Mode`.
2. Crea una escena nueva vacia.
3. Guardala en:
   `Assets/_Project/Scenes/Chapter01.unity`
4. Si quieres trabajar con referencia visual, puedes abrir la escena vieja `Assets/Scenes/CH1_Cafeteria.unity` en otra pestana y solo mirarla. No copies cosas a ciegas.

## Estructura recomendada

En la `Hierarchy`, crea exactamente esto:

- `Main Camera`
- `EventSystem`
- `SceneFlow`
- `Canvas_Chapter01`
  - `BG_Background`
  - `Portrait_Left`
  - `Portrait_Right`
  - `Group_Dialogue`
    - `IMG_DialogueBox`
    - `TXT_SpeakerName`
    - `TXT_Body`
    - `BTN_Next`
  - `Group_PhoneOverlay`
    - `IMG_PhoneMessage`
    - `BTN_PhoneClose`
  - `Group_TrustTutorial`
    - `IMG_TrustPopup`
    - `IMG_TrustBar_Seongsu`
    - `IMG_TrustBar_Jeongho`
  - `Group_Fade`

## Como crear la estructura

### Crear `SceneFlow`

1. Clic derecho en `Hierarchy`
2. `Create Empty`
3. Renombra a:
   `SceneFlow`

### Crear `Canvas_Chapter01`

1. Clic derecho en `Hierarchy`
2. `UI (Canvas) -> Canvas`
3. Renombra a:
   `Canvas_Chapter01`

### Crear `BG_Background`

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. `UI (Canvas) -> Image`
4. Renombra a:
   `BG_Background`

### Crear retratos

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. `UI (Canvas) -> Image`
4. Renombra a:
   `Portrait_Left`

Luego repite y crea:

- `Portrait_Right`

### Crear `Group_Dialogue`

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_Dialogue`

Dentro de `Group_Dialogue`, crea:

- `IMG_DialogueBox`
  - `UI (Canvas) -> Image`
- `TXT_SpeakerName`
  - `UI (Canvas) -> Text - TextMeshPro`
- `TXT_Body`
  - `UI (Canvas) -> Text - TextMeshPro`
- `BTN_Next`
  - `UI (Canvas) -> Button - TextMeshPro`

### Crear `Group_PhoneOverlay`

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_PhoneOverlay`

Dentro de `Group_PhoneOverlay`, crea:

- `IMG_PhoneMessage`
  - `UI (Canvas) -> Image`
- `BTN_PhoneClose`
  - `UI (Canvas) -> Button - TextMeshPro`

### Crear `Group_TrustTutorial`

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_TrustTutorial`

Dentro de `Group_TrustTutorial`, crea:

- `IMG_TrustPopup`
  - `UI (Canvas) -> Image`
- `IMG_TrustBar_Seongsu`
  - `UI (Canvas) -> Image`
- `IMG_TrustBar_Jeongho`
  - `UI (Canvas) -> Image`

### Crear `Group_Fade`

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_Fade`

Dentro de `Group_Fade`, crea:

- `IMG_FadeBlack`
  - `UI (Canvas) -> Image`

## Imagenes

Ahora asigna sprites.

### Fondo inicial

Selecciona `BG_Background` y en `Image -> Source Image` asigna:

- [Fondo_CuartoJihuun01.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Backgrounds/Fondo_CuartoJihuun01.png>)

### Retratos

Selecciona:

- `Portrait_Left`
  - asigna:
    [Seongsu_Talking.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Talking.PNG>)
- `Portrait_Right`
  - asigna:
    [Jeongho_Talking.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Talking.png>)

### Overlay del telefono

- `IMG_PhoneMessage`
  - asigna:
    [Phone_Message01.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Phone/Phone_Message01.png>)

### Overlay de confianza

- `IMG_TrustPopup`
  - asigna:
    [IndicadordeConfianza_POPup.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Trust/IndicadordeConfianza_POPup.png>)
- `IMG_TrustBar_Seongsu`
  - asigna:
    [IndicadordeConfianza_Barra.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Trust/IndicadordeConfianza_Barra.png>)
- `IMG_TrustBar_Jeongho`
  - asigna:
    [IndicadordeConfianza_Barra.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Trust/IndicadordeConfianza_Barra.png>)

### Boton `Next`

Para `BTN_Next` puedes dejar el boton visual simple por ahora.

Solo cambia el texto hijo `Text (TMP)` a:

- `Next`

### Boton cerrar telefono

Para `BTN_PhoneClose`, por ahora deja un boton simple y cambia el texto hijo a:

- `Close`

### Fade negro

Selecciona `IMG_FadeBlack`:

1. En `Image`, deja `Source Image` vacio
2. Cambia `Color` a negro

## Acomodo basico

### `Canvas_Chapter01`

En `Canvas Scaler`, deja:

- `UI Scale Mode = Scale With Screen Size`
- `Reference Resolution = 1920 x 1080`

### `BG_Background`

En `Rect Transform`:

- ancla: `stretch` completo
- `Left = 0`
- `Right = 0`
- `Top = 0`
- `Bottom = 0`

### `Portrait_Left`

En `Rect Transform`:

- ancla: `bottom left`
- `Pos X = 280`
- `Pos Y = 250`
- `Width = 420`
- `Height = 620`

Activa `Preserve Aspect` en `Image`.

### `Portrait_Right`

En `Rect Transform`:

- ancla: `bottom right`
- `Pos X = -280`
- `Pos Y = 250`
- `Width = 420`
- `Height = 620`

Activa `Preserve Aspect` en `Image`.

### `Group_Dialogue`

Agrega `CanvasGroup`.

En `IMG_DialogueBox`, usa:

- ancla: `bottom center`
- `Pos X = 0`
- `Pos Y = 120`
- `Width = 1250`
- `Height = 260`

Si no quieres buscar un sprite ahora, puedes dejar `Image` con color semitransparente:

- `Color = negro con alfa bajo`

### `TXT_SpeakerName`

En `Rect Transform`:

- ancla: `bottom left`
- `Pos X = 420`
- `Pos Y = 255`
- `Width = 260`
- `Height = 60`

Texto inicial:

- `Seongsu`

### `TXT_Body`

En `Rect Transform`:

- ancla: `bottom center`
- `Pos X = 0`
- `Pos Y = 110`
- `Width = 1030`
- `Height = 140`

Texto inicial:

- `Texto de prueba del capitulo 1.`

### `BTN_Next`

En `Rect Transform`:

- ancla: `bottom right`
- `Pos X = -420`
- `Pos Y = 60`
- `Width = 140`
- `Height = 60`

Si ves el texto por defecto montado raro, ajusta su hijo `Text (TMP)` o dejalo centrado.

### `Group_PhoneOverlay`

Agrega `CanvasGroup`.

En `IMG_PhoneMessage`:

- ancla: `middle center`
- `Pos X = 0`
- `Pos Y = 0`
- `Width = 700`
- `Height = 900`

Activa `Preserve Aspect`.

En `BTN_PhoneClose`:

- ancla: `middle center`
- `Pos X = 0`
- `Pos Y = -430`
- `Width = 170`
- `Height = 60`

### `Group_TrustTutorial`

Agrega `CanvasGroup`.

En `IMG_TrustPopup`:

- ancla: `middle center`
- `Pos X = 0`
- `Pos Y = 0`
- `Width = 700`
- `Height = 450`

Activa `Preserve Aspect`.

En `IMG_TrustBar_Seongsu`:

- ancla: `middle center`
- `Pos X = -110`
- `Pos Y = -80`
- `Width = 220`
- `Height = 28`

En `IMG_TrustBar_Jeongho`:

- ancla: `middle center`
- `Pos X = 110`
- `Pos Y = -80`
- `Width = 220`
- `Height = 28`

### `Group_Fade`

Agrega `CanvasGroup`.

En `IMG_FadeBlack`:

- ancla: `stretch` completo
- `Left = 0`
- `Right = 0`
- `Top = 0`
- `Bottom = 0`

## CanvasGroups

Agrega `CanvasGroup` a:

- `Group_Dialogue`
- `Group_PhoneOverlay`
- `Group_TrustTutorial`
- `Group_Fade`

Deja estos valores iniciales:

- `Group_Dialogue`
  - `Alpha = 1`
- `Group_PhoneOverlay`
  - `Alpha = 0`
- `Group_TrustTutorial`
  - `Alpha = 0`
- `Group_Fade`
  - `Alpha = 1`

## Componentes

### `SceneFlow`

Agrega:

- `SceneFlowController`

### `Group_Fade`

Agrega:

- `FadeOverlayController`

En el campo `Overlay Canvas Group`, arrastra:

- `Group_Fade`

### `Group_Dialogue`

Agrega:

- `DialogueController`

Conecta:

- `Root Canvas Group` -> `Group_Dialogue`
- `Speaker Name Text` -> `TXT_SpeakerName`
- `Body Text` -> `TXT_Body`
- `Left Portrait Image` -> `Portrait_Left`
- `Right Portrait Image` -> `Portrait_Right`
- `Next Button` -> `BTN_Next`

### `Group_PhoneOverlay`

Agrega:

- `PhoneOverlayController`

Conecta:

- `Root Canvas Group` -> `Group_PhoneOverlay`
- `Message Image` -> `IMG_PhoneMessage`
- `Default Message Sprite` -> `Phone_Message01.png`
- `Close Button` -> `BTN_PhoneClose`

### `Group_TrustTutorial`

Agrega:

- `TrustController`

Conecta:

- `Seongsu Fill Image` -> `IMG_TrustBar_Seongsu`
- `Jeongho Fill Image` -> `IMG_TrustBar_Jeongho`
- `Tutorial Canvas Group` -> `Group_TrustTutorial`

### `Canvas_Chapter01`

Agrega:

- `Chapter01Director`

Conecta:

- `Background Image` -> `BG_Background`
- `Fade Overlay Controller` -> `Group_Fade`
- `Scene Flow Controller` -> `SceneFlow`
- `Dialogue Controller` -> `Group_Dialogue`
- `Phone Overlay Controller` -> `Group_PhoneOverlay`
- `Trust Controller` -> `Group_TrustTutorial`

En backgrounds asigna:

- `Intro Background` -> `Fondo_CuartoJihuun01.png`
- `Room Background` -> `Fondo_CuartoJihuun01.png`
- `Friends Background` -> `Fondo_AfueraCasaJihuun.png`
- `Hallway Background` -> `Fondo_Escaleras.png`
- `Cafeteria Background` -> `Fondo_Cafeteria.jpg`

En phone asigna:

- `First Phone Message` -> `Phone_Message01.png`

Por ahora no conectes `Choice Controller`.

## Botones y eventos

### `BTN_Next`

1. Selecciona `BTN_Next`
2. En `Button -> On Click()`
3. Pulsa `+`
4. Arrastra `Group_Dialogue`
5. Elige:
   `DialogueController -> OnNextPressed()`

### `BTN_PhoneClose`

No hace falta conectar nada manual si ya lo pusiste en el campo `Close Button` del `PhoneOverlayController`.

## Build Settings

Agrega `Chapter01` a `Build Settings` o `Build Profiles`.

Orden recomendado:

1. `MainMenu`
2. `Chapter01`

## Validacion minima

Cuando termines:

1. Guarda la escena
2. Dale `Play`
3. Deberias ver fade desde negro
4. Deberias ver el fondo
5. Deberias ver la caja de dialogo
6. Si no cargaste dialogos todavia, no pasa nada
7. Si pulsas `Close` en el telefono cuando aparezca, deberia cerrar el overlay

## Nota

- Igual que en `MainMenu`, usa el ojito de la `Hierarchy` para trabajar overlays por separado
- `Game` manda mas que `Scene`
- Si algo se ve amontonado, casi siempre es `Rect Transform`
