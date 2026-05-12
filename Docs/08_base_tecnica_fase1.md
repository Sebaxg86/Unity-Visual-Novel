# Base Tecnica - Fase 1

Este documento resume la base de scripts nueva que vive en `Assets/_Project/`.

## Idea general

No vamos a seguir creciendo sobre los scripts del prototipo en `Assets/Scripts/`.

La base nueva separa responsabilidades:

- flujo entre escenas
- fades
- dialogo
- elecciones
- confianza
- overlay de telefono

## Scripts nuevos

### `Assets/_Project/Core/FadeOverlayController.cs`

Responsabilidad:

- mostrar negro instantaneo
- ocultar negro instantaneo
- hacer fade a negro
- hacer fade desde negro

Uso esperado:

- transiciones de inicio / fin de escena
- apertura del capitulo
- cierre de capitulo

### `Assets/_Project/Core/SceneFlowController.cs`

Responsabilidad:

- cargar `MainMenu`
- cargar `Chapter01`
- recargar escena actual
- cerrar el juego

Detalle:

- puede usar `FadeOverlayController` si se le asigna uno en el Inspector

### `Assets/_Project/Dialogue/DialogueLine.cs`

Es una clase de datos serializable.

Define una linea de dialogo con:

- nombre del hablante
- modo de dialogo
- color opcional del nombre
- retrato izquierdo
- retrato derecho
- foco visual
- texto

Modos actuales:

- `Spoken`
- `Thought`
- `Narration`
- `Signed`

Regla importante:

- `Signed` envuelve el texto en comillas automaticamente

### `Assets/_Project/Dialogue/DialogueController.cs`

Responsabilidad:

- mostrar nombre
- mostrar texto
- mostrar retratos
- resaltar quien tiene el foco
- ejecutar efecto de escritura
- resolver el boton `Next`

Comportamiento:

- si haces click en `Next` mientras el texto se esta escribiendo, completa la linea
- si haces click despues, avanza a la siguiente
- cuando termina una secuencia, dispara `SequenceFinished`

### `Assets/_Project/Dialogue/ChoiceOption.cs`

Clase de datos serializable para una opcion.

Incluye:

- `optionId`
- `label`
- `seongsuTrustDelta`
- `jeonghoTrustDelta`

### `Assets/_Project/Dialogue/ChoiceController.cs`

Responsabilidad:

- mostrar una pregunta
- instanciar botones dinamicos
- devolver la opcion elegida

No aplica confianza por si solo.
Solo emite el evento `ChoiceSelected`.

### `Assets/_Project/Systems/TrustController.cs`

Responsabilidad:

- guardar confianza de `Seongsu`
- guardar confianza de `Jeongho`
- aplicar deltas
- actualizar fills / textos si se conectan en UI
- mostrar / ocultar tutorial de confianza si se asigna un `CanvasGroup`

### `Assets/_Project/Systems/PhoneOverlayController.cs`

Responsabilidad:

- abrir el overlay del telefono
- cambiar la imagen del mensaje
- cerrar el overlay

Tambien expone eventos `Opened` y `Closed`.

### `Assets/_Project/Chapter01/Chapter01Director.cs`

Responsabilidad:

- arrancar el flujo del capitulo 1
- cambiar fondos por beat
- abrir el telefono en el momento correcto
- encadenar dialogos y elecciones
- aplicar cambios de confianza cuando corresponde
- cerrar el capitulo con fade

Importante:

- no contiene el contenido final del capitulo por si solo
- funciona como coordinador para que luego podamos cargar dialogos, choices y sprites desde el Inspector

### `Assets/_Project/UI/MainMenu/MainMenuController.cs`

Responsabilidad:

- manejar `Press Start`
- mostrar las opciones principales
- abrir placeholder de `Settings`
- abrir/cerrar modal de `Quit`
- arrancar `Chapter01`

### `Assets/_Project/Core/CanvasGroupPanelController.cs`

Responsabilidad:

- mostrar
- ocultar
- alternar paneles basados en `CanvasGroup`

Sirve para overlays sencillos y modales sin meter logica extra.

## Que sigue

Con esta base ya podemos montar:

1. una escena limpia de `MainMenu`
2. una escena limpia de `Chapter01`
3. conectar el `Chapter01Director` a la UI real del capitulo

## Nota importante

Los scripts viejos del prototipo siguen existiendo como referencia:

- `Assets/Scripts/GameManager.cs`
- `Assets/Scripts/TitlePage.cs`
- `Assets/Scripts/TextCreator.cs`
- `Assets/Scripts/Scene01/Scene01Events.cs`

Pero la idea no es seguir construyendo sobre ellos.
La idea es usarlos solo como referencia historica mientras fase 1 despega en `Assets/_Project/`.
