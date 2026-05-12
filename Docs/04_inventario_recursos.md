# Inventario de Recursos

Este inventario resume el contenido de `Recursos/`, que hoy aparece como contenido nuevo y aun no esta importado a `Assets/`.

## Estado general

- `Recursos/` esta mejor organizado que el `Assets/` actual
- Hoy Git lo reporta como contenido nuevo no trackeado
- Debe tratarse como fuente de importacion, no como carpeta final de runtime dentro del juego

## Tipografias

- `ComicNeueSansID.ttf`
- `Starborn.ttf`
- `To Japan.ttf`

## Fondos

- Menu:
  - `Fondo_MainMenu.PNG`
  - `Screen_MainMenu.png`
  - `Titulo_MainMenu.PNG`
- Color:
  - `Fondos Colores/Degradado_Azul-Rosa.png`
- Lugares:
  - `Fondo_AfueraCasaJihuun.png`
  - `Fondo_Cafeteria.jpg`
  - `Fondo_Calle.JPG`
  - `Fondo_CuartoJihuun01.png`
  - `Fondo_CuartoJihuun02.PNG`
  - `Fondo_Escaleras.png`

## Personajes

- `Seongsu`
  - 13 expresiones
  - 1 sprite de espaldas
- `Jeongho`
  - 13 expresiones
  - 1 sprite de espaldas
  - 3 frames extra para la sena de "mentirosa"

## UI y HUD

- `Botones/`
  20 archivos entre menu principal, flechas, save/load, settings y tacha
- `HUD/`
  - `Escala de Cofianza.png`
  - `HUD_Settings.png`
- `Indicador de Confianza/`
  - base
  - boton cerrar
  - variantes de color / estado
- `Quit/`
  - botones `Yes`, `No`, `Tacha`
  - cuadro del modal
- `Phone_Message01.png`
- `Phone_Message02.png`

## Objetos de escena

- `Puerta.PNG`
- `Bonsai.png`
- `Barra_de_Proteina.png`

## Audio

- Musica:
  - `BGM_Escenas.mp3`
  - `MainMenuBGM.mp3`
  - `Paper Hearts.m4a`
- SFX:
  - `Achievement.mp3`
  - `Alarma.mp3`
  - `Ambiente Cafteria.mp3`
  - `Ambiente pasillos Escuela.mp3`
  - `Boy Laugh.mp3`
  - `BoyGasp.mp3`
  - `BoySigh.mp3`
  - `ButtonClick.mp3`
  - `Footsteps.mp3`
  - `GirlGasp.mp3`
  - `GirlSigh.mp3`
  - `Jihuun laugh.mp3`
  - `MessageSent.mp3`
  - `PauseMusic.mp3`
  - `PhoneNotification.mp3`
  - `POP.mp3`
  - `Puerta_Abriendose.mp3`
  - `RuidoAfuera.mp3`
  - `Seongsu Laugh.mp3`

## Carpetas hoy vacias

- `Recursos/Save/`
- `Recursos/Settings/`

Esto sugiere que la referencia visual de `save` y `settings` vive en el documento explicativo, no en assets separados listos para importar.

## Observaciones utiles

- El `Assets/Characters` actual solo tiene muy pocos sprites comparado con `Recursos/Personajes`
- `Recursos/` ya contiene casi todo lo necesario para fase 1 del capitulo
- Antes de importar, conviene definir una estructura destino dentro de `Assets/_Project/`

## Orden recomendado de importacion

1. `Tipografias`
2. `Fondos`
3. `Personajes`
4. `UI y HUD`
5. `Audio`

## Recomendacion practica

No reemplazar assets a ciegas. Importar en lotes pequenos, validar en Unity, y luego conectar referencias desde `Inspector`.
