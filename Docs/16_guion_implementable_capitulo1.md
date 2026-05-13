# Guion Implementable de `Chapter01`

Este documento traduce la fuente de verdad del capitulo 1 a una forma util para Unity.

La idea no es reemplazar [00_explicacion_capitulo1_fuente_de_verdad.md](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Docs/00_explicacion_capitulo1_fuente_de_verdad.md>), sino convertirlo en una guia ejecutable para el flujo que ya existe en `Chapter01Director`.

## Regla de uso

- `00_explicacion...` = fuente narrativa canonica
- este documento = traduccion tecnica para el prototipo actual
- si hay conflicto, manda el `00_...`

## Alcance actual del prototipo

Hoy `Chapter01` ya soporta:

- intro de texto
- telefono con sprite
- cuarto con exploracion simple
- interacciones de `Bonsai` y `Barra`
- salida del cuarto
- dialogo con amigos
- 3 decisiones
- confianza
- cafeteria
- cierre con fade

Todavia no soporta de forma completa:

- pantalla de guardando
- titulo del capitulo como tarjeta separada
- efecto de abrir ojos
- exploracion del cuarto con flechas
- variantes visuales del pasillo segun opcion
- persistencia real de save/load

## Beat map alineado al codigo

### Beat `Intro`

**Background**
- `introBackground`

**Funcion actual**
- `BeginIntro()`

**Texto objetivo**
- `Uno pensaria que con los anos la vida se haria mas sencilla...`
- `Pero al parecer no.`

**Nota**
- En el PDF original, antes de esto hay negro, guardando, titulo y fade.
- En el prototipo actual esos pasos siguen comprimidos en este arranque.

### Beat `WaitingForPhoneClose`

**Background**
- `roomBackground`

**Funcion actual**
- `BeginPhoneBeat()`

**Comportamiento**
- sonar notificacion
- mostrar sprite del telefono
- esperar `Close`

**Decision adoptada**
- el telefono se queda como sprite completo de conversacion
- no vamos a construir UI de chat mas compleja por ahora

### Beat `Room`

**Texto objetivo**
- pensamiento interno de Jihuun despues de leer los mensajes
- cierre con `...Supongo que no tengo otra opcion.`

**Nota**
- el sprite del telefono ya carga el mensaje visual
- no hace falta duplicar todo el chat en la caja de dialogo

### Beat `RoomExploration`

**Estado**
- implementado como exploracion simple por botones

**Entradas actuales**
- `BTN_RoomExit`
- `BTN_Bonsai`
- `BTN_ProteinBar`

**Nota**
- esto es una adaptacion del documento original
- el PDF habla de exploracion mas libre con flechas

### Beat `RoomInspectingBonsai`

**Estado**
- contenido provisional

**Uso**
- pensamiento corto
- volver a la exploracion

### Beat `RoomInspectingProteinBar`

**Estado**
- contenido provisional

**Uso**
- pensamiento corto
- volver a la exploracion

### Beat `Friends`

**Background**
- `friendsBackground`

**Texto objetivo**
- Seongsu reclama que Jihuun por fin salio
- Jeongho baja el drama
- Jeongho le pasa comida a Seongsu
- Jihuun piensa lo de la barra de proteina

### Beat `FirstChoice`

**Prompt**
- `Como reacciona Jihuun al ver a sus amigos?`

**Opciones**
- `Sonrie ligeramente`
- `Solo observa`
- `Hace una sena a Jeongho`

**Trust**
- opcion 1: `+1 Seongsu`, `+1 Jeongho`
- opcion 2: sin cambio
- opcion 3: `+1 Jeongho`

**Post-choice**
- si elige la sena a Jeongho, hay remate de Jeongho

### Beat `Hallway`

**Background**
- `hallwayBackground`

**Texto objetivo**
- sensacion de refugio con sus amigos
- Seongsu pregunta si esta bien
- Jihuun responde `"Estoy cansada"`
- Jeongho responde `"Mentirosa"`
- pensamiento de Jihuun
- preparacion de la decision del pasillo

### Beat `SecondChoice`

**Prompt**
- `Como procesa Jihuun el ruido del pasillo?`

**Opciones**
- `Mirar a la gente`
- `Bajar la mirada`
- `Ignorar todo`

**Trust**
- sin cambios por ahora

**Post-choice**
- cada opcion tiene su texto propio

### Beat `Cafeteria`

**Background**
- `cafeteriaBackground`

**Texto objetivo**
- narracion de la manana
- chiste de Seongsu y Jeongho
- pedido de jugo de durazno
- narracion del pedido y la convivencia
- pensamiento `Aqui... es facil. No necesito hablar.`

### Beat `ThirdChoice`

**Prompt**
- `Como participa Jihuun en la conversacion?`

**Opciones**
- `Propone idea de salir el fin de semana`
- `Solo observa`
- `Escribe en celular`

**Trust**
- opcion 1: `+1 Seongsu`, `+1 Jeongho`
- opcion 2: sin cambio
- opcion 3: `+1 Seongsu`, `+1 Jeongho`

**Post-choice**
- opcion 1: reaccion de amigos y pensamiento del chico que mira
- opcion 2: pensamiento del chico que mira
- opcion 3: misma intencion que opcion 1 pero usando celular

### Beat `Ending`

**Texto objetivo**
- `Capitulo 1 terminado.`

**Cierre**
- fade a negro
- SFX de cierre / achievement si esta asignado

## Que ya esta alineado con el guion real

- tono general del capitulo
- primera decision
- decision del pasillo
- decision final
- idea del telefono como trigger narrativo
- amigos como primer refugio emocional de Jihuun

## Que sigue para dejarlo mas canon

1. pasar de fallback a datos configurados
2. separar la intro larga en sub-beats visuales reales
3. decidir si `Bonsai` y `Barra` quedan como interacciones canonicas
4. meter audio real en todos los beats
5. decidir si el pasillo tendra variaciones visuales segun opcion
