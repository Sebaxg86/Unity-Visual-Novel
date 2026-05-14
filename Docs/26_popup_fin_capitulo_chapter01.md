# Popup de fin de capítulo para `Chapter01`

Esta guía monta el popup que aparece cuando termina el capítulo 1.

La meta es:

- fade a negro
- popup de `Logro desbloqueado`
- botón para volver al menú principal

## Antes de empezar

1. Abre:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegúrate de no estar en `Play Mode`
3. Selecciona `Canvas_Chapter01`

## Estructura que vamos a crear

Dentro de `Canvas_Chapter01`, crea esto:

- `Group_ChapterCompletePopup`
  - `IMG_ChapterCompletePanel`
  - `TXT_ChapterCompleteTitle`
  - `TXT_ChapterCompleteBody`
  - `BTN_ChapterCompleteConfirm`
    - `TXT_ChapterCompleteConfirm`

## Paso 1 - Crear `Group_ChapterCompletePopup`

1. Clic derecho sobre `Canvas_Chapter01`
2. `Create Empty`
3. Renombra a:
   `Group_ChapterCompletePopup`
4. En `Inspector`, pulsa `Add Component`
5. Agrega:
   `Canvas Group`
6. Luego agrega:
   `Chapter Complete Popup Controller`

## Paso 2 - Asegurar que quede arriba de todo

1. En `Hierarchy`, arrastra `Group_ChapterCompletePopup`
2. Déjalo al final de los hijos de `Canvas_Chapter01`

Esto es importante para que quede visualmente encima del fade negro y sí reciba clicks.

## Paso 3 - Crear `IMG_ChapterCompletePanel`

1. Clic derecho sobre `Group_ChapterCompletePopup`
2. `UI (Canvas) -> Image`
3. Renombra a:
   `IMG_ChapterCompletePanel`
4. En `Image`, usa:
   [cuadro cuadroso.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Common/cuadro cuadroso.png>)

### Rect Transform recomendado

- Anchor: `Middle Center`
- Pos X: `0`
- Pos Y: `0`
- Width: `920`
- Height: `460`

## Paso 4 - Crear `TXT_ChapterCompleteTitle`

1. Clic derecho sobre `Group_ChapterCompletePopup`
2. `UI (Canvas) -> Text - TextMeshPro`
3. Renombra a:
   `TXT_ChapterCompleteTitle`

### Configuración sugerida

- Anchor: `Top Center`
- Pos X: `0`
- Pos Y: `-70`
- Width: `760`
- Height: `80`
- Text: `Logro desbloqueado`
- Font Asset: `Starborn SDF`
- Font Size: `34`
- Alignment: `Center`
- Color: el que estés usando para títulos del proyecto

## Paso 5 - Crear `TXT_ChapterCompleteBody`

1. Clic derecho sobre `Group_ChapterCompletePopup`
2. `UI (Canvas) -> Text - TextMeshPro`
3. Renombra a:
   `TXT_ChapterCompleteBody`

### Configuración sugerida

- Anchor: `Middle Center`
- Pos X: `0`
- Pos Y: `-10`
- Width: `720`
- Height: `120`
- Text: `Capítulo 1 completado.`
- Font Asset: `ComicNeueSansID SDF`
- Font Size: `26`
- Alignment: `Center`
- Word Wrapping: activado

## Paso 6 - Crear `BTN_ChapterCompleteConfirm`

1. Clic derecho sobre `Group_ChapterCompletePopup`
2. `UI (Canvas) -> Button - TextMeshPro`
3. Renombra a:
   `BTN_ChapterCompleteConfirm`

### Rect Transform sugerido

- Anchor: `Bottom Center`
- Pos X: `0`
- Pos Y: `70`
- Width: `320`
- Height: `80`

### Si quieres darle look del proyecto

En el `Image` del botón puedes usar algún sprite de botón que ya estés reutilizando en tu UI.

Si por ahora quieres algo funcional y rápido, puede quedarse como botón TMP normal.

## Paso 7 - Renombrar el texto del botón

1. Expande `BTN_ChapterCompleteConfirm`
2. Selecciona el hijo TMP
3. Renómbralo a:
   `TXT_ChapterCompleteConfirm`
4. Ponle:
   `Volver al inicio`

### Fuente recomendada

- Font Asset: `ComicNeueSansID SDF` o `Starborn SDF`

## Paso 8 - Conectar `ChapterCompletePopupController`

Selecciona `Group_ChapterCompletePopup` y en `Chapter Complete Popup Controller` conecta:

- `Root Canvas Group` -> `Group_ChapterCompletePopup`
- `Title Text` -> `TXT_ChapterCompleteTitle`
- `Body Text` -> `TXT_ChapterCompleteBody`
- `Confirm Button Text` -> `TXT_ChapterCompleteConfirm`
- `Confirm Button` -> `BTN_ChapterCompleteConfirm`

Valores sugeridos:

- `Fade Duration = 0.24`

## Paso 9 - Conectar `Chapter01Director`

1. Selecciona `Canvas_Chapter01`
2. Busca `Chapter01Director`
3. Conecta:
   - `Chapter Complete Popup Controller` -> `Group_ChapterCompletePopup`

### Textos sugeridos

En la sección `Chapter Complete Popup`, deja:

- `Chapter Complete Popup Title = Logro desbloqueado`
- `Chapter Complete Popup Body = Capítulo 1 completado.`
- `Chapter Complete Popup Confirm Label = Volver al inicio`
- `Chapter Complete Popup Delay = 0.30`

## Qué debería pasar

Al terminar `Chapter01`:

1. suena el cierre
2. hace fade a negro
3. aparece el popup
4. pulsas `Volver al inicio`
5. vuelve al `MainMenu`

## Si algo falla

- no aparece el popup
  - revisa `Chapter Complete Popup Controller` en `Chapter01Director`
- aparece pero no se puede hacer click
  - asegúrate de que `Group_ChapterCompletePopup` esté al final de la jerarquía del canvas
- el botón no cambia de escena
  - revisa que `SceneFlowController` esté conectado en `Chapter01Director`
