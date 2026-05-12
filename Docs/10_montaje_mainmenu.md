# Montaje de `MainMenu` en Unity

Esta guia monta una escena limpia de menu principal usando los assets nuevos de `Assets/_Project/`.

## Objetivo

Dejar una escena `MainMenu` con:

- fondo
- titulo
- `Press Start`
- botones `New Game`, `Continue`, `Settings`, `Quit`
- modal de `Quit`
- controlador de flujo hacia `Chapter01`

## Antes de empezar

1. Abre Unity y asegurate de **no estar en `Play Mode`**.
2. Crea una escena nueva vacia.
3. Guardala en:
   `Assets/_Project/Scenes/MainMenu.unity`
4. En la `Hierarchy`, entiende esto antes de crear nada:
   - `SceneFlow` sera un **objeto vacio**
   - `Canvas_MainMenu` sera un **Canvas**
   - `CanvasGroup` **no aparece en el menu de crear objetos**
   - `CanvasGroup` se agrega desde `Inspector -> Add Component`
5. En Unity 6, para crear botones, usa:
   - `UI (Canvas) -> Button - TextMeshPro`
   No uses `Legacy` para este menu.

## Estructura recomendada

En la `Hierarchy`, crea exactamente esto, en este orden:

1. Clic derecho en la `Hierarchy`
2. Elige `Create Empty`
3. Renombra el objeto a:
   `SceneFlow`

Luego:

1. Clic derecho en la `Hierarchy`
2. Elige `UI (Canvas) -> Canvas`
3. Renombra ese objeto a:
   `Canvas_MainMenu`

Dentro de `Canvas_MainMenu`, crea estos hijos:

1. Selecciona `Canvas_MainMenu`
2. Clic derecho
3. `UI (Canvas) -> Image`
4. Renombra a:
   `BG_MainMenu`

Despues:

1. Selecciona `Canvas_MainMenu`
2. Clic derecho
3. `UI (Canvas) -> Image`
4. Renombra a:
   `Title_MainMenu`

Despues:

1. Selecciona `Canvas_MainMenu`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_PressStart`

Dentro de `Group_PressStart`, crea:

1. Selecciona `Group_PressStart`
2. Clic derecho
3. `UI (Canvas) -> Button - TextMeshPro`
4. Renombra a:
   `BTN_PressStart`

Despues:

1. Selecciona `Canvas_MainMenu`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_MainOptions`

Dentro de `Group_MainOptions`, crea 4 botones:

1. `BTN_NewGame`
2. `BTN_Continue`
3. `BTN_Settings`
4. `BTN_Quit`

Cada uno se crea asi:

1. Selecciona `Group_MainOptions`
2. Clic derecho
3. `UI (Canvas) -> Button - TextMeshPro`
4. Renombra el boton

Despues:

1. Selecciona `Canvas_MainMenu`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_SettingsPlaceholder`

Despues:

1. Selecciona `Canvas_MainMenu`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_QuitModal`

Dentro de `Group_QuitModal`, crea estos hijos:

1. `IMG_QuitPanel`
   - crear con `UI (Canvas) -> Image`
2. `BTN_QuitYes`
   - crear con `UI (Canvas) -> Button - TextMeshPro`
3. `BTN_QuitNo`
   - crear con `UI (Canvas) -> Button - TextMeshPro`
4. `BTN_QuitClose`
   - crear con `UI (Canvas) -> Button - TextMeshPro`

Al final, tu `Hierarchy` deberia verse asi:

- `Main Camera`
- `EventSystem`
- `SceneFlow`
- `Canvas_MainMenu`
  - `BG_MainMenu`
  - `Title_MainMenu`
  - `Group_PressStart`
    - `BTN_PressStart`
  - `Group_MainOptions`
    - `BTN_NewGame`
    - `BTN_Continue`
    - `BTN_Settings`
    - `BTN_Quit`
  - `Group_SettingsPlaceholder`
  - `Group_QuitModal`
    - `IMG_QuitPanel`
    - `BTN_QuitYes`
    - `BTN_QuitNo`
    - `BTN_QuitClose`

## Imagenes

Ahora asigna sprites a cada objeto visual **y acomodalos**.

En Unity, cuando creas UI nueva:

- casi todo aparece en el centro
- con tamaño por defecto
- y los botones `TextMeshPro` traen un texto hijo que dice `Button`

Por eso se ve todo amontonado.

### Regla base para acomodar UI

Cada objeto UI tiene arriba en el `Inspector` un componente llamado `Rect Transform`.

Eso controla:

- posicion
- tamaño
- anclaje en pantalla

Cuando te diga `ancla`, haz esto:

1. Selecciona el objeto
2. Ve al `Inspector`
3. Arriba, en `Rect Transform`, busca el pequeño cuadrito de anclajes
4. Haz clic ahi
5. Elige el preset indicado

Despues ajusta los valores numericos que te diga.

### Fondo y titulo

- `BG_MainMenu`
  - en `Inspector`, componente `Image`, campo `Source Image`
  - asigna:
    [Fondo_MainMenu.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/MainMenu/Fondo_MainMenu.PNG>)
  - en `Rect Transform`:
    - ancla: `stretch` completo
    - `Left = 0`
    - `Right = 0`
    - `Top = 0`
    - `Bottom = 0`
  - en `Image`, deja el color en blanco
  - si no se ve la textura, revisa otra vez `Source Image`

- `Title_MainMenu`
  - en `Inspector`, componente `Image`, campo `Source Image`
  - asigna:
    [Titulo_MainMenu.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/MainMenu/Titulo_MainMenu.PNG>)
  - en `Rect Transform`:
    - ancla: `top center`
    - `Pos X = 0`
    - `Pos Y = -110`
    - `Width = 900`
    - `Height = 250`
  - si se deforma, activa `Preserve Aspect` en el componente `Image`

### Boton `Press Start`

- `BTN_PressStart`
  - selecciona el objeto
  - en su componente `Image`, asigna:
    [BTN_pressstart.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/MainMenu/Buttons/BTN_pressstart.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 0`
    - `Pos Y = 200`
    - `Width = 360`
    - `Height = 110`
  - expande `BTN_PressStart` en la `Hierarchy`
  - selecciona su hijo `Text (TMP)` o parecido
  - en el `Inspector`, desactiva la casilla del objeto arriba del todo
  - esto oculta el texto `Button` que estorba encima del sprite

### Botones principales

- `BTN_NewGame`
  - en `Image`, asigna:
    [BTN Main Menu_newgame.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/MainMenu/Buttons/BTN Main Menu_newgame.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 0`
    - `Pos Y = 80`
    - `Width = 420`
    - `Height = 115`
  - desactiva su hijo `Text (TMP)`

- `BTN_Continue`
  - en `Image`, asigna:
    [BTN Main Menu_continue.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/MainMenu/Buttons/BTN Main Menu_continue.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 0`
    - `Pos Y = -10`
    - `Width = 420`
    - `Height = 115`
  - desactiva su hijo `Text (TMP)`

- `BTN_Settings`
  - en `Image`, asigna:
    [BTN Main Menu_settings.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/MainMenu/Buttons/BTN Main Menu_settings.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 0`
    - `Pos Y = -100`
    - `Width = 420`
    - `Height = 115`
  - desactiva su hijo `Text (TMP)`

- `BTN_Quit`
  - en `Image`, asigna:
    [BTN Main Menu_quit.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/MainMenu/Buttons/BTN Main Menu_quit.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 0`
    - `Pos Y = -190`
    - `Width = 420`
    - `Height = 115`
  - desactiva su hijo `Text (TMP)`

### Modal `Quit`

**Importante:** `Group_QuitModal` no lleva sprite.
`Group_QuitModal` es solo un contenedor.

Los sprites van en sus hijos:

- `IMG_QuitPanel`
  - en `Image`, asigna:
    [CuadroTexto_Quit.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Quit/CuadroTexto_Quit.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 0`
    - `Pos Y = 0`
    - `Width = 520`
    - `Height = 300`

- `BTN_QuitYes`
  - en `Image`, asigna:
    [BTN_yes.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Quit/BTN_yes.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = -90`
    - `Pos Y = -70`
    - `Width = 160`
    - `Height = 70`
  - desactiva su hijo `Text (TMP)`

- `BTN_QuitNo`
  - en `Image`, asigna:
    [BTN_No.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Quit/BTN_No.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 90`
    - `Pos Y = -70`
    - `Width = 160`
    - `Height = 70`
  - desactiva su hijo `Text (TMP)`

- `BTN_QuitClose`
  - en `Image`, asigna:
    [BTN_Tacha.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Quit/BTN_Tacha.png>)
  - en `Rect Transform`:
    - ancla: `middle center`
    - `Pos X = 190`
    - `Pos Y = 95`
    - `Width = 40`
    - `Height = 40`
  - desactiva su hijo `Text (TMP)`

## Componentes

### `SceneFlow`

1. Selecciona `SceneFlow`
2. Ve al `Inspector`
3. Pulsa `Add Component`
4. Escribe:
   `SceneFlowController`
5. Seleccionalo

No agregues `FadeOverlayController` todavia.

### `Canvas_MainMenu`

Cuando creaste el Canvas, Unity ya debio agregar automaticamente:

- `Canvas`
- `Canvas Scaler`
- `Graphic Raycaster`

No tienes que agregarlos a mano si ya estan ahi.

## CanvasGroups

`CanvasGroup` no se crea desde el menu de `Hierarchy`.

Se agrega asi:

1. Selecciona el objeto
2. Ve al `Inspector`
3. Pulsa `Add Component`
4. Escribe:
   `CanvasGroup`
5. Seleccionalo

Haz eso en estos 4 objetos:

- `Group_PressStart`
- `Group_MainOptions`
- `Group_SettingsPlaceholder`
- `Group_QuitModal`

Despues ajusta sus valores asi en el componente `CanvasGroup`:

- `Group_PressStart`
  - `Alpha = 1`
- `Group_MainOptions`
  - `Alpha = 0`
- `Group_SettingsPlaceholder`
  - `Alpha = 0`
- `Group_QuitModal`
  - `Alpha = 0`

Esto deja la escena ordenada tambien en modo edicion.

## Controlador principal

En `Canvas_MainMenu`, agrega el script `MainMenuController`:

1. Selecciona `Canvas_MainMenu`
2. Ve al `Inspector`
3. Pulsa `Add Component`
4. Escribe:
   `MainMenuController`
5. Seleccionalo

Despues conecta estos campos arrastrando objetos desde la `Hierarchy` al `Inspector`:

- `Press Start Group`
  - arrastra `Group_PressStart`
- `Main Options Group`
  - arrastra `Group_MainOptions`
- `Settings Placeholder Group`
  - arrastra `Group_SettingsPlaceholder`
- `Quit Modal Group`
  - arrastra `Group_QuitModal`
- `Scene Flow Controller`
  - arrastra `SceneFlow`

Deja activado:

- `Start With Only Press Start`

## Botones y eventos

En Unity 6, los botones `Button - TextMeshPro` traen varios componentes.

El que nos importa para conectar acciones es el componente `Button`, en la parte `On Click()`.

### `BTN_PressStart`

1. Selecciona `BTN_PressStart`
2. En `Inspector`, busca el componente `Button`
3. Baja hasta `On Click()`
4. Pulsa el boton `+`
5. Arrastra `Canvas_MainMenu` al espacio vacio del evento
6. En el desplegable, elige:
   `MainMenuController -> OnPressStart()`

### `BTN_NewGame`

Haz lo mismo y elige:

- `MainMenuController -> StartNewGame()`

### `BTN_Continue`

Haz lo mismo y elige:

- `MainMenuController -> ContinueGame()`

### `BTN_Settings`

Haz lo mismo y elige:

- `MainMenuController -> OpenSettings()`

### `BTN_Quit`

Haz lo mismo y elige:

- `MainMenuController -> OpenQuitModal()`

### Botones del modal `Quit`

- `BTN_QuitYes`
  - `MainMenuController -> ConfirmQuit()`
- `BTN_QuitNo`
  - `MainMenuController -> CloseQuitModal()`
- `BTN_QuitClose`
  - `MainMenuController -> CloseQuitModal()`

## Build Settings

Cuando la escena `MainMenu` ya exista:

1. Ve a `File -> Build Profiles`
   o `File -> Build Settings`, segun como te aparezca en Unity 6
2. Agrega la escena actual

Orden recomendado:

1. `MainMenu`
2. `Chapter01`

Si `Chapter01` todavia no existe, no pasa nada. Agregaremos esa despues.

## Validacion minima

Cuando termines:

1. Guarda la escena
2. Dale `Play`
3. Deberias ver el fondo del menu ocupando toda la pantalla
4. Deberias ver el titulo arriba
5. Deberias ver solo `Press Start`
6. No deberias ver el texto gris `Button`
7. Al pulsar `Press Start`, deberian aparecer los botones principales
8. Al pulsar `Quit`, deberia aparecer el modal
9. Al pulsar `No` o `Tacha`, el modal deberia cerrarse

Si algo no aparece o no responde, no adivines: dime exactamente en que paso te atoraste.

## Nota

- En este proyecto estamos usando la UI clasica de Unity (`uGUI`) dentro de un `Canvas`
- Por eso estamos creando objetos desde `UI (Canvas)`
- Los botones `TextMeshPro` son correctos para este proyecto
- No vamos a usar `Legacy` para este menu
- La vista `Scene` no siempre se vera igual que la vista `Game`
- `Game` es la referencia real de como se ve al correr
- Para trabajar comodo en `Scene`, deja guardado el estado inicial del menu asi:
  - `Group_PressStart` -> `Alpha = 1`
  - `Group_MainOptions` -> `Alpha = 0`
  - `Group_SettingsPlaceholder` -> `Alpha = 0`
  - `Group_QuitModal` -> `Alpha = 0`
- Si necesitas editar un grupo oculto, sube temporalmente su `Alpha` a `1`, acomodalo y luego regresalo a `0`
