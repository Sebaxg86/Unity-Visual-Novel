# Montaje de Elecciones en `Chapter01`

Esta guia agrega la UI de elecciones al `Chapter01` que ya montaste.

La meta es que el juego pueda mostrar opciones reales del jugador en medio del flujo.

## Objetivo

Dejar en `Chapter01`:

- un grupo de elecciones
- un fondo simple para la decision
- un texto de pregunta
- un contenedor de botones
- un boton plantilla
- `ChoiceController` conectado
- `Chapter01Director` conectado al `ChoiceController`

## Antes de empezar

1. Abre la escena:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegurate de no estar en `Play Mode`
3. Recuerda:
   - aqui **si queremos texto visible** en los botones
   - a diferencia del `MainMenu`, **no** vamos a ocultar el `Text (TMP)` de estas opciones

## Estructura recomendada

Dentro de `Canvas_Chapter01`, crea esto:

- `Group_Choices`
  - `IMG_ChoicePanel`
  - `TXT_ChoicePrompt`
  - `ChoiceButtonContainer`
    - `BTN_ChoiceTemplate`

## Como crear la estructura

### Crear `Group_Choices`

1. En la `Hierarchy`, selecciona `Canvas_Chapter01`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `Group_Choices`

### Crear `IMG_ChoicePanel`

1. Selecciona `Group_Choices`
2. Clic derecho
3. `UI (Canvas) -> Image`
4. Renombra a:
   `IMG_ChoicePanel`

### Crear `TXT_ChoicePrompt`

1. Selecciona `Group_Choices`
2. Clic derecho
3. `UI (Canvas) -> Text - TextMeshPro`
4. Renombra a:
   `TXT_ChoicePrompt`

### Crear `ChoiceButtonContainer`

1. Selecciona `Group_Choices`
2. Clic derecho
3. `Create Empty Child`
4. Renombra a:
   `ChoiceButtonContainer`

### Crear `BTN_ChoiceTemplate`

1. Selecciona `ChoiceButtonContainer`
2. Clic derecho
3. `UI (Canvas) -> Button - TextMeshPro`
4. Renombra a:
   `BTN_ChoiceTemplate`

## Acomodo basico

### `Group_Choices`

1. Selecciona `Group_Choices`
2. En `Inspector`, pulsa `Add Component`
3. Agrega:
   `CanvasGroup`

Deja por ahora:

- `Alpha = 0`
- `Interactable = false`
- `Blocks Raycasts = false`

### `IMG_ChoicePanel`

1. Selecciona `IMG_ChoicePanel`
2. En `Rect Transform` usa:
   - ancla: `middle center`
   - `Pos X = 0`
   - `Pos Y = 0`
   - `Width = 980`
   - `Height = 520`
3. En `Image`:
   - deja `Source Image` vacio
   - cambia `Color` a negro con algo de transparencia
   - por ejemplo:
     - `R = 0`
     - `G = 0`
     - `B = 0`
     - `A = 160`

### `TXT_ChoicePrompt`

1. Selecciona `TXT_ChoicePrompt`
2. En `Rect Transform` usa:
   - ancla: `middle center`
   - `Pos X = 0`
   - `Pos Y = 150`
   - `Width = 760`
   - `Height = 120`
3. En el componente `TextMeshProUGUI`:
   - escribe un texto temporal como:
     `Pregunta temporal`
   - `Font Size = 34`
   - alineacion centrada
   - color blanco

### `ChoiceButtonContainer`

1. Selecciona `ChoiceButtonContainer`
2. En `Rect Transform` usa:
   - ancla: `middle center`
   - `Pos X = 0`
   - `Pos Y = -40`
   - `Width = 760`
   - `Height = 240`
3. En `Inspector`, pulsa `Add Component`
4. Agrega:
   `Vertical Layout Group`
5. Configuralo asi:
   - `Spacing = 18`
   - `Child Alignment = Middle Center`
   - `Control Child Size`
     - `Width = true`
     - `Height = true`
   - `Child Force Expand`
     - `Width = true`
     - `Height = false`

### `BTN_ChoiceTemplate`

1. Selecciona `BTN_ChoiceTemplate`
2. En `Rect Transform` usa:
   - `Width = 700`
   - `Height = 64`
3. En el componente `Image`:
   - deja `Source Image` vacio
   - usa un color oscuro semitransparente
4. En su hijo `Text (TMP)`:
   - deja el texto visible
   - cambia el texto a:
     `Opcion temporal`
   - `Font Size = 28`
   - alineacion centrada
   - color blanco

## Componentes

### `Group_Choices`

1. Selecciona `Group_Choices`
2. Pulsa `Add Component`
3. Agrega:
   `ChoiceController`

Conecta estos campos:

- `Root Canvas Group`
  - arrastra `Group_Choices`
- `Prompt Text`
  - arrastra `TXT_ChoicePrompt`
- `Button Container`
  - arrastra `ChoiceButtonContainer`
- `Option Button Prefab`
  - arrastra `BTN_ChoiceTemplate`

Importante:

- el `ChoiceController` ya oculta automaticamente el `BTN_ChoiceTemplate` al arrancar
- no necesitas apagarlo manualmente

### `Canvas_Chapter01`

1. Selecciona `Canvas_Chapter01`
2. Busca el componente `Chapter01Director`
3. En el campo:
   `Choice Controller`
4. Arrastra:
   `Group_Choices`

## Que deberia pasar despues

Como `Chapter01Director` ya tiene elecciones fallback en codigo, al conectar `ChoiceController` deberia empezar a mostrar decisiones reales durante el flujo:

- una en el encuentro con amigos
- otra en el pasillo
- otra en la cafeteria

## Validacion minima

1. Guarda la escena
2. Dale `Play`
3. Avanza con `Next`
4. Cuando llegues al beat de amigos, deberia aparecer una pregunta con varias opciones
5. Al pulsar una opcion, deberia desaparecer la UI de eleccion y continuar el flujo
6. Luego deberia repetirse en pasillo y cafeteria

## Si algo se ve mal

Los problemas mas comunes son estos:

- no aparece nada
  - revisa que `Choice Controller` este conectado en `Chapter01Director`
- aparece la caja pero no los botones
  - revisa `Button Container`
  - revisa `Option Button Prefab`
- los botones salen pegados o raros
  - revisa `Vertical Layout Group`
- aparece siempre el boton plantilla aunque no haya choice
  - guarda, recompila y vuelve a dar `Play`

## Nota

- estas elecciones son ya funcionales para el prototipo
- mas adelante podremos ponerles arte propio y estilo final
