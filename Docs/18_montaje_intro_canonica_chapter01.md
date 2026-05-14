# Montaje de Intro Canonica para `Chapter01`

Esta guia monta la intro canonica del capitulo 1 en la escena `Chapter01`.

La meta es que, al dar `Play`, el flujo empiece asi:

1. pantalla negra
2. `Guardando...`
3. titulo del capitulo
4. texto inicial de Jihuun
5. fade al cuarto
6. notificacion del telefono
7. telefono visible

## Antes de empezar

1. Abre Unity.
2. Abre la escena:
   `Assets/_Project/Scenes/Chapter01.unity`
3. Asegurate de **no estar en Play Mode**.
4. En la `Hierarchy`, ubica:
   `Canvas_Chapter01`
5. Vamos a crear 3 grupos nuevos dentro de ese `Canvas`.

## Estructura que vamos a crear

Dentro de `Canvas_Chapter01`, crea esto:

- `Group_IntroSaving`
  - `IMG_IntroSavingBG`
  - `TXT_IntroSaving`
- `Group_IntroChapterTitle`
  - `IMG_IntroChapterTitleBG`
  - `TXT_IntroChapterNumber`
  - `TXT_IntroChapterName`
- `Group_IntroMonologue`
  - `IMG_IntroMonologueBG`
  - `TXT_IntroMonologue`

## Parte 1 - Crear `Group_IntroSaving`

### Crear el contenedor

1. En `Hierarchy`, selecciona `Canvas_Chapter01`.
2. Clic derecho sobre `Canvas_Chapter01`.
3. Pulsa:
   `Create Empty Child`
4. Renombra el objeto a:
   `Group_IntroSaving`
5. Con `Group_IntroSaving` seleccionado, en `Inspector`, pulsa:
   `Add Component`
6. Busca:
   `Canvas Group`
7. Agrega ese componente.

### Crear el fondo negro

1. Selecciona `Group_IntroSaving`.
2. Clic derecho.
3. Pulsa:
   `UI (Canvas) -> Image`
4. Renombra ese objeto a:
   `IMG_IntroSavingBG`

### Acomodar el fondo negro

1. Selecciona `IMG_IntroSavingBG`.
2. En `Inspector`, ubica `Rect Transform`.
3. En el cuadrito de anchors, elige `stretch` completo.
4. Deja:
   - `Left = 0`
   - `Right = 0`
   - `Top = 0`
   - `Bottom = 0`
5. En el componente `Image`, cambia `Color` a negro o casi negro.
   Puedes usar algo como:
   - `R 0`
   - `G 0`
   - `B 0`
   - `A 255`

### Crear el texto `Guardando...`

1. Selecciona `Group_IntroSaving`.
2. Clic derecho.
3. Pulsa:
   `UI (Canvas) -> Text - TextMeshPro`
4. Si Unity pregunta por importar TMP essentials y ya no lo ha hecho, acepta.
5. Renombra el objeto a:
   `TXT_IntroSaving`

### Acomodar el texto `Guardando...`

1. Selecciona `TXT_IntroSaving`.
2. En `Rect Transform`, pon anchor de `middle center`.
3. Deja un ancho aproximado de:
   - `Width = 900`
   - `Height = 120`
4. En el componente `TextMeshProUGUI`:
   - `Text = Guardando...`
   - `Alignment = Center / Middle`
   - `Font Size = 64` o `72`
   - `Color = blanco`

## Parte 2 - Crear `Group_IntroChapterTitle`

### Crear el contenedor

1. Selecciona `Canvas_Chapter01`.
2. Clic derecho.
3. `Create Empty Child`
4. Renombra a:
   `Group_IntroChapterTitle`
5. `Add Component`
6. Agrega:
   `Canvas Group`

### Crear el fondo

1. Selecciona `Group_IntroChapterTitle`.
2. Clic derecho.
3. `UI (Canvas) -> Image`
4. Renombra a:
   `IMG_IntroChapterTitleBG`
5. Igual que antes, ponlo en `stretch` completo y color negro.

### Crear `TXT_IntroChapterNumber`

1. Selecciona `Group_IntroChapterTitle`.
2. Clic derecho.
3. `UI (Canvas) -> Text - TextMeshPro`
4. Renombra a:
   `TXT_IntroChapterNumber`

### Configurar `TXT_IntroChapterNumber`

1. Anchor:
   `middle center`
2. En `Rect Transform`:
   - `Pos Y = 40`
   - `Width = 1000`
   - `Height = 100`
3. En `TextMeshProUGUI`:
   - `Text = Capitulo 1`
   - `Alignment = Center / Middle`
   - `Font Size = 52`
   - `Color = blanco`

### Crear `TXT_IntroChapterName`

1. Selecciona `Group_IntroChapterTitle`.
2. Clic derecho.
3. `UI (Canvas) -> Text - TextMeshPro`
4. Renombra a:
   `TXT_IntroChapterName`

### Configurar `TXT_IntroChapterName`

1. Anchor:
   `middle center`
2. En `Rect Transform`:
   - `Pos Y = -40`
   - `Width = 1400`
   - `Height = 140`
3. En `TextMeshProUGUI`:
   - `Text = UN NUEVO COMIENZO`
   - `Alignment = Center / Middle`
   - `Font Size = 72`
   - `Color = blanco`

## Parte 3 - Crear `Group_IntroMonologue`

### Crear el contenedor

1. Selecciona `Canvas_Chapter01`.
2. Clic derecho.
3. `Create Empty Child`
4. Renombra a:
   `Group_IntroMonologue`
5. `Add Component`
6. Agrega:
   `Canvas Group`

### Crear el fondo

1. Selecciona `Group_IntroMonologue`.
2. Clic derecho.
3. `UI (Canvas) -> Image`
4. Renombra a:
   `IMG_IntroMonologueBG`
5. Ponlo en `stretch` completo.
6. Color negro.

### Crear el texto del monologo

1. Selecciona `Group_IntroMonologue`.
2. Clic derecho.
3. `UI (Canvas) -> Text - TextMeshPro`
4. Renombra a:
   `TXT_IntroMonologue`

### Configurar el texto del monologo

1. Selecciona `TXT_IntroMonologue`.
2. En `Rect Transform`, usa anchor de `middle center`.
3. Deja algo parecido a esto:
   - `Width = 1400`
   - `Height = 500`
4. En `TextMeshProUGUI`:
   - `Text =` dejalo vacio
   - `Alignment = Center / Middle`
   - `Font Size = 44`
   - `Color = blanco`
5. Activa `Word Wrapping` si no lo esta.

## Parte 4 - Dejar ocultos los 3 grupos

Haz esto para cada uno:

- `Group_IntroSaving`
- `Group_IntroChapterTitle`
- `Group_IntroMonologue`

### Como ocultarlo

1. Selecciona el grupo.
2. En el componente `Canvas Group`, deja:
   - `Alpha = 0`
   - `Interactable = false`
   - `Blocks Raycasts = false`

## Parte 5 - Conectar todo en `Chapter01Director`

1. En la `Hierarchy`, selecciona el objeto que tiene:
   `Chapter01Director`
   En tu escena seguramente es `Canvas_Chapter01` o un objeto similar que ya usamos antes.
2. En `Inspector`, ubica el componente:
   `Chapter01Director`

### Activa la intro canonica

1. Busca:
   `Use Canonical Intro Sequence`
2. Dejalo activado.

### Asigna los 3 CanvasGroup

Arrastra estos objetos desde la `Hierarchy` a sus campos:

- `Group_IntroSaving` -> `Intro Saving Canvas Group`
- `Group_IntroChapterTitle` -> `Intro Chapter Title Canvas Group`
- `Group_IntroMonologue` -> `Intro Monologue Canvas Group`

### Asigna los textos TMP

Arrastra estos objetos:

- `TXT_IntroSaving` -> `Intro Saving Text`
- `TXT_IntroChapterNumber` -> `Intro Chapter Number Text`
- `TXT_IntroChapterName` -> `Intro Chapter Name Text`
- `TXT_IntroMonologue` -> `Intro Monologue Text`

## Parte 6 - Valores que puedes dejar tal cual

En `Chapter01Director`, puedes dejar estos valores como estan:

- `Intro Black Hold Duration = 2`
- `Intro Saving Duration = 4`
- `Intro Chapter Title Duration = 4.5`
- `Intro Monologue Pause Duration = 1.35`
- `Intro Wake Reveal Duration = 0.7`
- `Intro Monologue Characters Per Second = 34`

Y estos textos:

- `Intro Saving Label = Guardando...`
- `Intro Chapter Number Label = Capitulo 1`
- `Intro Chapter Name Label = UN NUEVO COMIENZO`

## Parte 7 - Importante sobre el "abrir ojos"

Por ahora, el "abrir ojos" no esta hecho con parpados ni mascaras.

La version actual sera:

- pantalla negra
- ding
- fade al cuarto
- telefono visible

Eso esta bien para esta fase. Ya respeta la estructura narrativa aunque el efecto visual todavia sea simple.

## Parte 8 - Como probar

1. Guarda la escena.
2. Asegurate de que no haya errores rojos en `Console`.
3. Dale `Play`.

## Lo que deberias ver

En orden:

1. negro
2. `Guardando...`
3. `Capitulo 1`
4. `UN NUEVO COMIENZO`
5. texto inicial escribiendose
6. fade al cuarto
7. telefono
8. al cerrar telefono, sigue el flujo normal

## Que me debes decir al terminar

Respóndeme una de estas dos:

- `intro canonica lista`
- o `me atoré en el paso X`
