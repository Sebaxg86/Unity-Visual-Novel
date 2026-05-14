# Resoluciones y Siguientes Pasos de `Chapter01`

Este documento fija decisiones de produccion ya tomadas para que no vuelvan a quedar ambiguas.

## Resoluciones cerradas

### Telefono de Jihuun

**Decision**
- se mantiene el enfoque actual: un sprite completo del telefono con la conversacion visible

**Motivo**
- ya comunica el mensaje correctamente
- es suficiente para esta fase
- evita construir una UI de chat mas costosa sin necesidad real

**Impacto tecnico**
- `PhoneOverlayController` se queda como overlay simple
- no vamos a desarmar el telefono en burbujas, avatar, hora y layout programado por ahora

### Estructura del capitulo

**Decision**
- seguimos usando el flujo de beats que ya existe en `Chapter01Director`

**Motivo**
- ya es jugable
- ya responde bien a `Next`, elecciones y cierre
- nos permite meter guion real sin rehacer todo el sistema

### Interacciones del cuarto

**Decision**
- `Salir`, `Bonsai` y `Barra` siguen vivas en esta fase

**Motivo**
- ayudan a que el cuarto no se sienta muerto
- son faciles de mantener

**Nota**
- `Bonsai` y `Barra` no vienen cerrados al 100% desde el documento canonico
- por ahora se consideran interacciones complementarias del prototipo

## Pendientes que siguen abiertos

### Intro visual completa

Falta decidir y montar:

- negro inicial
- pantalla de guardando
- titulo de capitulo
- texto con sensacion de escritura manual
- abrir ojos

### Pasillo con variacion visual

El documento fuente sugiere:

- opcion `Mirar a la gente`: escena un poco mas clara
- opcion `Bajar la mirada`: escena un poco mas oscura

Eso sigue pendiente.

### Confianza persistente

Hoy la confianza ya cambia en runtime.

Sigue pendiente:

- guardar ese estado
- mostrarlo de forma persistente entre escenas o cargas

### Audio completo

Todavia falta terminar de conectar:

- BGM real por beat
- SFX de boton
- SFX de suspiro
- ambiente de pasillo
- achievement final

## Orden recomendado de trabajo

1. validar en Unity el nuevo fallback narrativo
2. conectar audio base de `Chapter01`
3. pasar del fallback a datos configurados en Inspector o ScriptableObjects
4. romper la intro comprimida en eventos visuales reales
5. decidir si el menu de save/load/settings entra en fase 1 o fase 2

## Criterio de decision para lo que venga

Si algo:

- mejora el flujo del capitulo 1
- evita retrabajo
- y no obliga a redisenar media escena

entonces entra en fase 1.

Si algo:

- es bonito pero no desbloquea el capitulo
- depende de persistencia
- o mete mucha UI secundaria

entonces lo pateamos a fase 2 sin culpa.
