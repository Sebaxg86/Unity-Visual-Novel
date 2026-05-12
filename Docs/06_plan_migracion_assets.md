# Plan de Migracion de Assets

Este documento define como pasar contenido de `Recursos/` hacia `Assets/` sin romper el proyecto de Unity.

## Principio base

No vamos a reemplazar carpetas viejas de `Assets/` a ciegas.

La estrategia segura es:

1. dejar intacto el prototipo actual
2. importar lotes nuevos dentro de `Assets/_Project/`
3. usar esos assets nuevos en la implementacion de fase 1

## Por que esta estrategia es la correcta

- `Assets/` ya tiene `.meta` y referencias vivas de Unity
- `Recursos/` es una fuente externa sin `.meta` de Unity
- sobreescribir nombres viejos puede romper referencias o mezclar materiales de forma confusa
- `Assets/_Project/` ya existe vacio y sirve perfecto como zona limpia de trabajo

## Reutilizacion detectada

Hay varios archivos que ya existen tanto en `Assets/` como en `Recursos/`.

### Duplicados reales o equivalentes cercanos

- tipografias:
  - `ComicNeueSansID.ttf`
  - `Starborn.ttf`
  - `To Japan.ttf`
- audio:
  - `Achievement.mp3`
  - `BoyGasp.mp3`
  - `BoySigh.mp3`
  - `GirlGasp.mp3`
  - `GirlSigh.mp3`
  - `MessageSent.mp3`
  - `POP.mp3`
  - `Paper Hearts.m4a`
- personajes base:
  - `Jeongho_Talking.png`
  - `Seongsu_Talking.PNG`

### Conclusion

Esos archivos no son prioridad de reimportacion. Primero conviene importar lo que no existe hoy en el proyecto.

## Assets nuevos de alto valor

Lo que `Recursos/` aporta y hoy falta en `Assets/`:

- fondos de lugares adicionales:
  - `Fondo_AfueraCasaJihuun.png`
  - `Fondo_Calle.JPG`
  - `Fondo_Escaleras.png`
  - `Fondo_CuartoJihuun01.png`
  - `Fondo_CuartoJihuun02.PNG`
- menu y UI refinada:
  - `Fondo_MainMenu.PNG`
  - `Titulo_MainMenu.PNG`
  - `Screen_MainMenu.png`
  - `Degradado_Azul-Rosa.png`
- sistema telefono:
  - `Phone_Message01.png`
  - `Phone_Message02.png`
- sistema confianza:
  - `Escala de Cofianza.png`
  - `IndicadordeConfianza_Barra.png`
  - `IndicadordeConfianza_Corazon.png`
  - `IndicadordeConfianza_POPup.png`
  - `BTN_Cerrar.png`
- objetos:
  - `Puerta.PNG`
  - `Bonsai.png`
  - `Barra_de_Proteina.png`
- expresiones completas:
  - 13 expresiones de `Seongsu`
  - 13 expresiones de `Jeongho`
  - sprites de espaldas
  - 3 frames de la sena de "mentirosa"
- audio adicional:
  - `MainMenuBGM.mp3`
  - `BGM_Escenas.mp3`
  - `PhoneNotification.mp3`
  - `ButtonClick.mp3`
  - `Footsteps.mp3`
  - `Puerta_Abriendose.mp3`
  - `Ambiente Cafteria.mp3`
  - `Ambiente pasillos Escuela.mp3`
  - `RuidoAfuera.mp3`
  - `Alarma.mp3`
  - `Seongsu Laugh.mp3`
  - `Jihuun laugh.mp3`
  - `Boy Laugh.mp3`

## Estructura destino recomendada

Todo nuevo asset de fase 1 deberia entrar aqui:

- `Assets/_Project/Art/Backgrounds/`
- `Assets/_Project/Art/Characters/Jeongho/`
- `Assets/_Project/Art/Characters/Seongsu/`
- `Assets/_Project/Art/Props/`
- `Assets/_Project/UI/MainMenu/`
- `Assets/_Project/UI/Dialogue/`
- `Assets/_Project/UI/Phone/`
- `Assets/_Project/UI/Trust/`
- `Assets/_Project/UI/Quit/`
- `Assets/_Project/Audio/Music/`
- `Assets/_Project/Audio/SFX/`

## Orden de migracion por lotes

### Lote 1 - Fondos

Importar primero:

- `Fondo_MainMenu.PNG`
- `Titulo_MainMenu.PNG`
- `Screen_MainMenu.png`
- `Degradado_Azul-Rosa.png`
- `Fondo_CuartoJihuun01.png`
- `Fondo_CuartoJihuun02.PNG`
- `Fondo_Escaleras.png`
- `Fondo_AfueraCasaJihuun.png`
- `Fondo_Cafeteria.jpg`

Objetivo:
dejar base visual del menu y del capitulo 1.

### Lote 2 - Personajes

Importar:

- expresiones de `Seongsu`
- expresiones de `Jeongho`
- sprites de espaldas
- `JeonghoSeña01-03`

Objetivo:
tener rango emocional suficiente para dialogo y escenas del capitulo.

### Lote 3 - UI funcional

Importar:

- botones principales
- telefono
- confianza
- quit modal
- props visuales de cuarto

Objetivo:
habilitar overlays y elecciones sin depender del prototipo viejo.

### Lote 4 - Audio

Importar:

- `MainMenuBGM.mp3`
- `BGM_Escenas.mp3`
- SFX de telefono, puerta, pasos, ambiente y risas

Objetivo:
dar ritmo basico al vertical slice.

## Que conservar del proyecto actual

Podemos conservar temporalmente:

- fuentes actuales en `Assets/Fonts/`
- escena actual como referencia visual
- scripts viejos como referencia del prototipo

No porque esten "bien", sino porque aun sirven para comparar y rescatar ideas mientras construimos fase 1.

## Que no hacer

- no copiar `Recursos/` entero dentro de `Assets/` de un solo golpe
- no sobreescribir `Assets/Characters/` ni `Assets/Sprites/` en sitio
- no borrar assets viejos antes de que fase 1 funcione con los nuevos
- no mover assets ya referenciados sin un motivo claro

## Regla de trabajo

Primero importamos limpio en `Assets/_Project/`.
Despues conectamos escenas, prefabs y scripts contra esos assets nuevos.
