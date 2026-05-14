# Capitulo 1 - Flujo de Referencia

Este documento resume el flujo del capitulo 1 a partir de `Docs/Documento_explicacion/*.png`.

## Personajes clave

- `Jihuun`
  Protagonista. Gran parte del capitulo gira alrededor de su mundo interno, su incomodidad social y su forma de comunicarse.
- `Seongsu`
  Mejor amiga de Jihuun. Energia alta, afectuosa, empuja el movimiento del capitulo.
- `Jeongho`
  Amigo del grupo. Mas seco en tono, pero atento y sensible.
- `Observador desconocido`
  Presencia que aparece al final como semilla narrativa.

## Reglas narrativas importantes

- Cuando `Jihuun` se comunica en senas, el texto debe aparecer entre comillas.
- Los pensamientos internos son parte central del tono del juego.
- El capitulo mezcla dialogo externo, monologo interno, transiciones visuales y pequenas elecciones.

## Flujo alto nivel

1. `Main Menu`
   `New Game` debe comenzar el capitulo 1.

2. `Intro`
   Pantalla negra con BGM, pantalla de "guardando", titulo `Capitulo 1: Un nuevo comienzo`, texto interno con efecto de escritura y SFX de tecleo.

3. `Despertar`
   Transicion a cuarto de Jihuun con efecto visual de abrir los ojos.

4. `Telefono`
   Llega notificacion de Seongsu, se abre overlay de telefono, Jihuun lee mensaje y responde internamente.

5. `Salida del cuarto`
   Jihuun cierra el telefono, puede moverse en la habitacion y salir por la puerta.

6. `Encuentro con amigos`
   Aparecen Seongsu y Jeongho, se introduce el indicador de confianza y su tutorial.

7. `Decision 1`
   Reaccion social inicial de Jihuun:
   - Sonrie ligeramente: `+1 Seongsu`, `+1 Jeongho`
   - Solo observa: `0`
   - Hace una sena a Jeongho: `+1 Jeongho`

8. `Transicion a escuela / pasillo`
   Se escucha ambiente escolar. Jihuun tiene monologo interno y aparece decision introspectiva.

9. `Decision 2`
   Como procesa el entorno:
   - Mirar a la gente
   - Bajar la mirada
   - Ignorar todo
   Esta decision cambia tono visual y texto, pero no necesariamente la confianza.

10. `Cafeteria`
    Seongsu y Jeongho conversan, Jihuun se integra, hay bromas, comida y pequenos alivios emocionales.

11. `Decision 3`
    Ultima decision del capitulo:
    - Propone plan para el fin de semana: `+1 Seongsu`, `+1 Jeongho`
    - Solo observa: `0`
    - Escribe en celular: mismo impacto social que proponer, pero usando telefono

12. `Observador`
    Jihuun detecta de nuevo al chico que la observa. Esto debe quedar como semilla para el siguiente capitulo.

13. `Cierre`
    Fade a negro, SFX de logro, texto tipo `Capitulo 1 terminado`.

## Audio y ritmo

- La intro usa BGM, tecleo y pausas cortas
- El telefono usa notificacion y sonido de click
- El cuarto usa ambiente calmado
- El encuentro con amigos y cafeteria usan SFX de voces / risas / suspiros segun la escena
- El pasillo usa ambiente escolar
- El cierre usa `Achievement.mp3`

## Nota de produccion

La escena actual de cafeteria solo representa una parte tardia del capitulo. No debe tomarse como estructura final del flujo.
