# Plan Tecnico - Fase 1

La meta de fase 1 es simple: dejar el capitulo 1 jugable de inicio a fin.

## Objetivo de producto

Vertical slice completo:

`Main Menu -> Intro -> Cuarto -> Telefono -> Encuentro con amigos -> Decision 1 -> Pasillo -> Decision 2 -> Cafeteria -> Decision 3 -> Fin de capitulo`

## Alcance de fase 1

Incluye:

- flujo completo del capitulo 1
- caja de dialogo funcional
- pensamientos internos
- telefono como overlay
- indicador de confianza
- 3 decisiones
- transiciones / fades
- audio basico por escena

No incluye todavia:

- `save` real
- `load` real
- `settings` completos
- multiples capitulos
- sistema complejo de persistencia

## Estructura recomendada

Para no seguir mezclando todo en una sola escena, recomiendo:

- `MainMenu.unity`
- `Chapter01.unity`

Y dentro de `Chapter01` usar paneles / overlays para:

- dialogo
- telefono
- tutorial de confianza
- elecciones
- fades
- cierre de capitulo

## Sistemas minimos a construir

- `SceneFlowController`
  Cambia entre `MainMenu` y `Chapter01`.

- `FadeController`
  Maneja negro, fade in y fade out.

- `DialogueController`
  Muestra nombre, retrato, texto, pensamientos y controla `Next`.

- `ChoiceController`
  Presenta opciones y devuelve la seleccion.

- `TrustController`
  Guarda y actualiza confianza de `Seongsu` y `Jeongho`.

- `PhoneOverlayController`
  Abre, cierra y actualiza la UI del celular.

- `Chapter01Director`
  Orquesta el orden de beats del capitulo.

## Recomendacion de arquitectura

Para esta fase conviene ir por una arquitectura simple, no por una super herramienta editorial.

Recomendacion:

- Un `Chapter01Director` como coordinador principal
- Componentes reutilizables para dialogo, decisiones, fades y telefono
- Datos del capitulo en clases serializables simples

Esto es mas rapido y mas facil de aprender que construir desde ya un sistema grande con `ScriptableObject` para todo.

## Orden de implementacion recomendado

1. Separar menu y capitulo en escenas limpias
2. Dejar `DialogueController` y `Next` funcionando
3. Construir intro del capitulo
4. Construir overlay de telefono
5. Construir tutorial de confianza
6. Implementar Decision 1
7. Implementar pasillo y Decision 2
8. Implementar cafeteria y Decision 3
9. Implementar cierre de capitulo
10. Pulir audio, expresiones y transiciones

## Estructura sugerida en Assets

- `Assets/_Project/Core/`
- `Assets/_Project/Scenes/`
- `Assets/_Project/UI/`
- `Assets/_Project/Dialogue/`
- `Assets/_Project/Chapter01/`
- `Assets/_Project/Audio/`
- `Assets/_Project/Art/Backgrounds/`
- `Assets/_Project/Art/Characters/`

## Criterio de exito de fase 1

Fase 1 estara realmente cerrada cuando podamos:

1. Abrir el juego desde el menu principal
2. Terminar el capitulo 1 sin errores manuales
3. Ver las 3 decisiones funcionando
4. Ver cambios de confianza aplicados
5. Escuchar BGM y SFX principales
6. Llegar a `Capitulo 1 terminado`

## Lo mas importante

No perseguir perfeccion visual antes de tener flujo. Primero jugable. Luego bonito.
