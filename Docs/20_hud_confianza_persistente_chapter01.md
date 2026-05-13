# HUD de Confianza Persistente en `Chapter01`

Esta guia separa por fin las dos cosas que hoy estan mezcladas:

- `tutorial` de confianza
- `HUD` persistente de confianza

La meta final es:

- el popup solo explica el sistema
- el HUD vive aparte
- el HUD se queda visible durante el resto del capitulo
- Seongsu y Jeongho tienen cada quien su propia confianza
- pero visualmente solo se muestra `una` barra a la vez

## Lo que ya deje listo en codigo

Ya actualice:

- [TrustController.cs](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Systems/TrustController.cs>)
- [Chapter01Director.cs](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Chapter01/Chapter01Director.cs>)

Ahora el sistema soporta:

- `tutorialCanvasGroup`
- `hudCanvasGroup`
- mostrar tutorial o HUD segun lo que exista
- al cerrar el tutorial, mostrar el HUD
- resetear y ocultar todo al reiniciar capitulo
- cambiar el foco visible del HUD entre `Seongsu` y `Jeongho`

## Idea visual

Vamos a dejar:

- `Group_TrustTutorial`
  - `IMG_TrustPopup`
  - `BTN_TrustTutorialClose`

y aparte:

- `Group_TrustHUD`
  - `IMG_TrustBar_Seongsu`
  - `IMG_TrustBar_Jeongho`

Importante:

- en esta version **no** vamos a usar `Escala_de_Cofianza.png` como un tercer elemento visible
- `IMG_TrustBar_Seongsu` y `IMG_TrustBar_Jeongho` van a usar el mismo sprite:
  [Escala_de_Cofianza.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Trust/Escala_de_Cofianza.png>)
- los dos objetos van a quedar uno encima del otro
- pero el codigo solo mostrara `uno` a la vez

## Antes de empezar

1. Abre la escena:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegurate de no estar en `Play Mode`
3. En `Hierarchy`, ubica:
   `Canvas_Chapter01`

## Parte 1 - Crear `Group_TrustHUD`

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. Pulsa:
   `Create Empty Child`
4. Renombra el objeto a:
   `Group_TrustHUD`
5. Con `Group_TrustHUD` seleccionado, en `Inspector`, pulsa:
   `Add Component`
6. Agrega:
   `Canvas Group`

## Parte 2 - No crear una tercera barra

Aqui vamos a ser bien claros:

- el HUD tiene solo `2` valores reales internos
- uno para `Seongsu`
- uno para `Jeongho`
- pero visualmente solo ensena `1` barra a la vez

Por eso:

- **no** crees `IMG_TrustHUDBase`
- **no** pongas [Escala_de_Cofianza.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Trust/Escala_de_Cofianza.png>) como un tercer elemento visible aparte

Si ya lo creaste antes:

1. En `Hierarchy`, busca:
   `IMG_TrustHUDBase`
2. Seleccionalo
3. Presiona `Delete`

Eso dejara el HUD con solo dos barras reales y evitara la confusion visual.

## Parte 3 - Mover las dos barras fuera del tutorial

Aqui no vamos a crear barras nuevas. Vamos a reutilizar las que ya existen.

### Mover `IMG_TrustBar_Seongsu`

1. En `Hierarchy`, busca:
   `IMG_TrustBar_Seongsu`
2. Arrastralo con el mouse y sueltalo dentro de:
   `Group_TrustHUD`

### Mover `IMG_TrustBar_Jeongho`

1. En `Hierarchy`, busca:
   `IMG_TrustBar_Jeongho`
2. Arrastralo con el mouse y sueltalo dentro de:
   `Group_TrustHUD`

Al terminar, esos dos objetos ya **no** deben estar dentro de `Group_TrustTutorial`.

## Parte 4 - Configurar las barras dentro del HUD

### `IMG_TrustBar_Seongsu`

1. Selecciona `IMG_TrustBar_Seongsu`
2. En `Image -> Source Image`, deja:
   [Escala_de_Cofianza.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Trust/Escala_de_Cofianza.png>)
3. En el componente `Image`, revisa esto:
   - `Type = Filled`
   - `Fill Method = Horizontal`
   - `Fill Origin = Left`
4. En `Rect Transform`, usa anchor:
   `top center`
5. Deja estos valores aproximados:
   - `Pos X = 0`
   - `Pos Y = -38`
   - `Width = 260`
   - `Height = 78`

### `IMG_TrustBar_Jeongho`

1. Selecciona `IMG_TrustBar_Jeongho`
2. En `Image -> Source Image`, deja:
   [Escala_de_Cofianza.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/UI/Trust/Escala_de_Cofianza.png>)
3. En el componente `Image`, revisa esto:
   - `Type = Filled`
   - `Fill Method = Horizontal`
   - `Fill Origin = Left`
4. En `Rect Transform`, usa anchor:
   `top center`
5. Deja estos valores aproximados:
   - `Pos X = 0`
   - `Pos Y = -38`
   - `Width = 260`
   - `Height = 78`

Importante:

- `IMG_TrustBar_Seongsu` y `IMG_TrustBar_Jeongho` deben quedar exactamente en la misma posicion
- eso es intencional
- el codigo ocultara uno y mostrara el otro segun el foco narrativo

## Parte 5 - Limpiar el popup del tutorial

Cuando termines de mover las barras, `Group_TrustTutorial` debe quedarse asi:

- `IMG_TrustPopup`
- `BTN_TrustTutorialClose`

Si adentro de `Group_TrustTutorial` todavia ves:

- `IMG_TrustBar_Seongsu`
- `IMG_TrustBar_Jeongho`

es porque no se movieron bien.

## Parte 6 - Conectar el nuevo HUD al `TrustController`

1. Selecciona `Group_TrustTutorial`
2. En el componente `TrustController`, conecta estos campos:

- `Hud Canvas Group` -> arrastra `Group_TrustHUD`
- `Seongsu Fill Image` -> arrastra `IMG_TrustBar_Seongsu`
- `Jeongho Fill Image` -> arrastra `IMG_TrustBar_Jeongho`
- `Tutorial Canvas Group` -> deja `Group_TrustTutorial`
- `Tutorial Close Button` -> deja `BTN_TrustTutorialClose`

Importante:

- `TrustController` sigue viviendo en `Group_TrustTutorial`
- eso esta bien
- solo que ahora controla dos grupos distintos

## Parte 7 - Estado inicial correcto

### `Group_TrustTutorial`

En su `Canvas Group`, deja:

- `Alpha = 0`
- `Interactable = false`
- `Blocks Raycasts = false`

### `Group_TrustHUD`

En su `Canvas Group`, deja:

- `Alpha = 0`
- `Interactable = false`
- `Blocks Raycasts = false`

## Parte 8 - Como deberia comportarse

En `Play`, el orden esperado ahora es:

1. entras al beat de amigos
2. aparece el popup del tutorial
3. pulsas `Cerrar`
4. desaparece el popup
5. aparece el HUD persistente
6. el HUD se queda visible durante elecciones, pasillo y cafeteria
7. cuando el foco narrativo esta en `Seongsu`, se ve su barra
8. cuando el foco narrativo esta en `Jeongho`, se ve la de el
9. las decisiones siguen cambiando los valores internos por separado

## Parte 9 - Por que existen dos barras

Esto no es un capricho del prototipo.

Viene del documento canonico:

- existe `confianzaSeongsu`
- existe `confianzaJeongho`

y algunas decisiones afectan a ambos, mientras que otras afectan solo a uno.

Por eso:

- una barra = no alcanza
- dos valores internos = modelo correcto

Y esto tambien es importante:

- si ves una `tercera barra`, eso no significa un tercer valor
- significa que montamos mal el HUD visual
- en esta version correcta:
  - existen `2` valores internos
  - existen `2` imagenes superpuestas
  - pero solo `1` se muestra al mismo tiempo

## Validacion minima

1. Guarda la escena
2. Dale `Play`
3. Avanza hasta el primer dialogo con amigos
4. Cierra el tutorial
5. Verifica que aparezca el HUD arriba
6. Verifica que solo veas `una` barra
7. Sigue avanzando y revisa si cambia el foco entre `Seongsu` y `Jeongho`
8. Toma decisiones y verifica que el HUD sigue vivo

## Si algo sale raro

Respóndeme con una de estas:

- `hud listo`
- `no aparece el hud`
- `el popup no se oculta`
- `las barras no cambian`
- `se ve desacomodado`
