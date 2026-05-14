# Tutorial de Confianza Canonico en `Chapter01`

Esta guia ajusta el tutorial de confianza para que se comporte mas parecido al documento canonico:

- aparece junto al primer dialogo con amigos
- bloquea clicks detras
- se cierra con un boton
- luego el jugador sigue leyendo y despues elige

## Lo que ya hice en codigo

Ya deje listo el soporte en:

- [TrustController.cs](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Systems/TrustController.cs>)
- [Chapter01Director.cs](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Chapter01/Chapter01Director.cs>)

Eso significa:

- el tutorial ya no depende de un temporizador
- ahora espera a que exista un boton de cierre
- y se dispara al entrar el primer dialogo del beat `Friends`

## Antes de empezar

1. Abre la escena:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegurate de no estar en `Play Mode`
3. En `Hierarchy`, ubica:
   `Group_TrustTutorial`

Si no recuerdas donde esta:

- normalmente esta dentro de `Canvas_Chapter01`

## Estructura que vamos a dejar

Dentro de `Group_TrustTutorial` debe existir al final:

- `IMG_TrustPopup`
- `IMG_TrustBar_Seongsu`
- `IMG_TrustBar_Jeongho`
- `BTN_TrustTutorialClose`

## Parte 1 - Crear el boton de cierre

1. En `Hierarchy`, selecciona:
   `Group_TrustTutorial`
2. Clic derecho.
3. Pulsa:
   `UI (Canvas) -> Button - TextMeshPro`
4. Renombra el objeto a:
   `BTN_TrustTutorialClose`

## Parte 2 - Acomodar el boton

1. Selecciona `BTN_TrustTutorialClose`
2. En `Rect Transform`, usa anchor de:
   `middle center`
3. Deja estos valores aproximados:
   - `Pos X = 0`
   - `Pos Y = 115`
   - `Width = 220`
   - `Height = 58`

Si el popup que ya tienes es mas grande o mas pequeno, acomoda el boton visualmente para que quede centrado en la parte alta-media del popup y no tape las barras de confianza.

## Parte 3 - Estilo minimo funcional

### Fondo del boton

1. Con `BTN_TrustTutorialClose` seleccionado, ve al componente `Image`
2. Si quieres, puedes dejarlo simple:
   - `Source Image` vacio
   - `Color` rosa suave o morado suave

Por ejemplo algo sobrio:

- `R = 237`
- `G = 161`
- `B = 174`
- `A = 255`

### Texto del boton

1. Expande `BTN_TrustTutorialClose`
2. Selecciona su hijo `Text (TMP)`
3. En `TextMeshProUGUI` deja:
   - `Text = Cerrar`
   - `Font Size = 28`
   - `Alignment = Center / Middle`
   - `Color = blanco`

## Parte 4 - Conectar el boton al `TrustController`

1. Selecciona `Group_TrustTutorial`
2. En `Inspector`, ubica el componente:
   `TrustController`
3. Busca el campo:
   `Tutorial Close Button`
4. Arrastra desde `Hierarchy`:
   `BTN_TrustTutorialClose`
   a ese campo

Importante:

- **no** necesitas configurar `On Click()` manualmente en el boton
- el `TrustController` ya lo conecta por codigo

## Parte 5 - Asegurarte de que el grupo sigue oculto al inicio

1. Selecciona `Group_TrustTutorial`
2. En el componente `Canvas Group`, deja:
   - `Alpha = 0`
   - `Interactable = false`
   - `Blocks Raycasts = false`

## Parte 6 - Como probar

1. Guarda la escena
2. Dale `Play`
3. Avanza el capitulo:
   - intro
   - telefono
   - cuarto
   - salir del cuarto
4. En cuanto entre el primer dialogo con amigos, deberia aparecer el tutorial de confianza
5. Pulsa `Cerrar`
6. Luego deberias poder seguir con `Next`
7. La primera eleccion ya no debe esperar un temporizador

## Resultado esperado

El orden correcto ahora deberia sentirse asi:

1. sales del cuarto
2. entra el primer dialogo con amigos
3. aparece tutorial de confianza
4. pulsas `Cerrar`
5. sigues leyendo
6. luego llega la primera eleccion

## Si algo sale raro

Si pasa alguna de estas cosas:

- el tutorial no aparece
- el boton no cierra
- la eleccion sigue saliendo con delay raro
- el popup aparece pero no bloquea clicks

dime exactamente cual de esas cuatro paso y lo corregimos sobre eso, sin adivinar.
