# Arquitectura técnica

Este documento resume la estructura técnica actual del proyecto.

## Escenas principales

### `MainMenu`

Ruta:

```text
Assets/_Project/Scenes/MainMenu.unity
```

Responsabilidad:

- pantalla inicial;
- navegación básica del menú;
- música de fondo;
- salida del juego.

### `Chapter01`

Ruta:

```text
Assets/_Project/Scenes/Chapter01.unity
```

Responsabilidad:

- flujo completo del capítulo 1;
- diálogo;
- cambios de fondo;
- overlays;
- elecciones;
- confianza;
- audio;
- cierre de capítulo.

## Scripts principales

### Núcleo

- `Assets/_Project/Core/SceneFlowController.cs`  
  Control de navegación entre escenas y salida del juego.

- `Assets/_Project/Core/FadeOverlayController.cs`  
  Fades generales de entrada y salida.

- `Assets/_Project/Core/CanvasGroupPanelController.cs`  
  Utilidad para mostrar y ocultar grupos UI.

### Menú

- `Assets/_Project/UI/MainMenu/MainMenuController.cs`  
  Lógica del menú principal, botones, modal de salida y BGM.

### Capítulo 1

- `Assets/_Project/Chapter01/Chapter01Director.cs`  
  Director principal del flujo del capítulo 1. Orquesta beats, fondos, audio, diálogo, overlays y cierre.

### Diálogo

- `Assets/_Project/Dialogue/DialogueLine.cs`  
  Modelo de datos de una línea de diálogo.

- `Assets/_Project/Dialogue/DialogueController.cs`  
  Render de nombre, texto, retratos, foco visual y typewriter.

- `Assets/_Project/Dialogue/ChoiceOption.cs`  
  Modelo de una opción de decisión.

- `Assets/_Project/Dialogue/ChoiceController.cs`  
  Presentación y selección de elecciones en pantalla.

### Sistemas auxiliares

- `Assets/_Project/Systems/TrustController.cs`  
  Tutorial, HUD y valores de confianza.

- `Assets/_Project/Systems/PhoneOverlayController.cs`  
  Aparición, ocultamiento y animación del teléfono.

- `Assets/_Project/Systems/PhoneNotificationOverlayController.cs`  
  Notificación clicable previa a la apertura del teléfono.

- `Assets/_Project/Systems/ChapterCompletePopupController.cs`  
  Popup de fin de capítulo y retorno al menú.

## Principios de implementación

- La lógica se organiza por sistemas acotados, no por una sola escena heredada gigante.
- `Chapter01Director` funciona como coordinador de alto nivel del episodio.
- Los sistemas de UI se apoyan en `CanvasGroup` para controlar visibilidad e interacción.
- El capítulo mezcla datos narrativos, dirección visual y secuencias interactivas dentro de una vertical slice única.

## Decisiones estructurales importantes

- `MainMenu` y `Chapter01` quedaron separados en escenas distintas.
- El capítulo 1 se resolvió como una experiencia cerrada y jugable antes de abordar `Save / Load` o `Settings`.
- El proyecto prioriza cierre funcional y fidelidad narrativa antes que una generalización temprana de todos los sistemas.
