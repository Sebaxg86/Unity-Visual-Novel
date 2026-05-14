# Guión Implementable de `Chapter01`

Este documento traduce la fuente de verdad del capítulo 1 a una forma útil para Unity.

La idea no es reemplazar [00_explicacion_capitulo1_fuente_de_verdad.md](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Docs/00_explicacion_capitulo1_fuente_de_verdad.md>), sino convertirlo en una guía ejecutable para el flujo que ya existe en `Chapter01Director`.

## Regla de uso

- `00_explicacion...` = fuente narrativa canónica
- este documento = traducción técnica para el prototipo actual
- si hay conflicto, manda el `00_...`

## Alcance actual del prototipo

Hoy `Chapter01` ya soporta:

- intro de texto
- teléfono con sprite
- cuarto con exploración simple
- interacciones de `Bonsai` y `Barra`
- salida del cuarto
- dialogo con amigos
- 3 decisiones
- confianza
- cafetería
- cierre con fade

Todavía no soporta de forma completa:

- pantalla de guardando
- título del capítulo como tarjeta separada
- efecto de abrir ojos
- exploración del cuarto con flechas
- variantes visuales del pasillo según opción
- persistencia real de save/load

## Beat map alineado al codigo

### Beat `Intro`

**Background**
- `introBackground`

**Función actual**
- `BeginIntro()`

**Texto objetivo**
- `Uno pensaría que con los años la vida se haría más sencilla...`
- `Pero al parecer no.`

**Nota**
- En el PDF original, antes de esto hay negro, guardando, título y fade.
- En el prototipo actual esos pasos siguen comprimidos en este arranque.

### Beat `WaitingForPhoneClose`

**Background**
- `roomBackground`

**Funcion actual**
- `BeginPhoneBeat()`

**Comportamiento**
- sonar notificación
- mostrar sprite del teléfono
- esperar `Close`

**Decision adoptada**
- el teléfono se queda como sprite completo de conversación
- no vamos a construir UI de chat más compleja por ahora

### Beat `Room`

**Texto objetivo**
- pensamiento interno de Jihuun después de leer los mensajes
- cierre con `...Supongo que no tengo otra opción.`

**Nota**
- el sprite del teléfono ya carga el mensaje visual
- no hace falta duplicar todo el chat en la caja de diálogo

### Beat `RoomExploration`

**Estado**
- implementado como exploración simple por botones

**Entradas actuales**
- `BTN_RoomExit`
- `BTN_Bonsai`
- `BTN_ProteinBar`

**Nota**
- esto es una adaptacion del documento original
- el PDF habla de exploración más libre con flechas

### Beat `RoomInspectingBonsai`

**Estado**
- contenido provisional

**Uso**
- pensamiento corto
- volver a la exploración

### Beat `RoomInspectingProteinBar`

**Estado**
- contenido provisional

**Uso**
- pensamiento corto
- volver a la exploración

### Beat `Friends`

**Background**
- `friendsBackground`

**Texto objetivo**
- Seongsu reclama que Jihuun por fin salió
- Jeongho baja el drama
- Jeongho le pasa comida a Seongsu
- Jihuun piensa lo de la barra de proteína

### Beat `FirstChoice`

**Prompt**
- `¿Cómo reacciona Jihuun al ver a sus amigos?`

**Opciones**
- `Sonríe ligeramente`
- `Solo observa`
- `Hace una seña a Jeongho`

**Trust**
- opción 1: `+1 Seongsu`, `+1 Jeongho`
- opción 2: sin cambio
- opción 3: `+1 Jeongho`

**Post-choice**
- si elige la seña a Jeongho, hay remate de Jeongho

### Beat `Hallway`

**Background**
- `hallwayBackground`

**Texto objetivo**
- sensación de refugio con sus amigos
- Seongsu pregunta si está bien
- Jihuun responde `"Estoy cansada"`
- Jeongho responde `"Mentirosa"`
- pensamiento de Jihuun
- preparación de la decisión del pasillo

### Beat `SecondChoice`

**Prompt**
- `¿Cómo procesa Jihuun el ruido del pasillo?`

**Opciones**
- `Mirar a la gente`
- `Bajar la mirada`
- `Ignorar todo`

**Trust**
- sin cambios por ahora

**Post-choice**
- cada opción tiene su texto propio

### Beat `Cafeteria`

**Background**
- `cafeteriaBackground`

**Texto objetivo**
- narración de la mañana
- chiste de Seongsu y Jeongho
- pedido de jugo de durazno
- narración del pedido y la convivencia
- pensamiento `Aquí... es fácil. No necesito hablar.`

### Beat `ThirdChoice`

**Prompt**
- `¿Cómo participa Jihuun en la conversación?`

**Opciones**
- `Propone idea de salir el fin de semana`
- `Solo observa`
- `Escribe en celular`

**Trust**
- opción 1: `+1 Seongsu`, `+1 Jeongho`
- opción 2: sin cambio
- opción 3: `+1 Seongsu`, `+1 Jeongho`

**Post-choice**
- opción 1: reacción de amigos y pensamiento del chico que mira
- opción 2: pensamiento del chico que mira
- opción 3: misma intención que opción 1 pero usando celular

### Beat `Ending`

**Texto objetivo**
- `Capítulo 1 terminado.`

**Cierre**
- fade a negro
- SFX de cierre / achievement si está asignado

## Que ya esta alineado con el guion real

- tono general del capítulo
- primera decisión
- decisión del pasillo
- decisión final
- idea del teléfono como trigger narrativo
- amigos como primer refugio emocional de Jihuun

## Qué sigue para dejarlo más canónico

1. pasar de fallback a datos configurados
2. separar la intro larga en sub-beats visuales reales
3. decidir si `Bonsai` y `Barra` quedan como interacciones canónicas
4. meter audio real en todos los beats
5. decidir si el pasillo tendrá variaciones visuales según opción
