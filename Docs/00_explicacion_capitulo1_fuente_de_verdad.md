# Entre tu Silencio y el Mío — Fuente de verdad del capítulo 1

Este documento reúne la información canónica del capítulo 1 para narrativa, puesta en escena, UI y comportamiento general del juego.

## Propósito

Su función es fijar la intención del capítulo 1 y registrar las decisiones ya cerradas durante la implementación. Si existe una discrepancia entre el juego y esta documentación, este archivo debe usarse como referencia principal.

## Identidad visual y tipográfica

### ComicNeueSansID

Uso recomendado:

- nombres de personajes;
- diálogos;
- pensamientos de Jihuun;
- texto del botón `Next`.

### Starborn

Uso recomendado:

- botones del menú;
- títulos secundarios;
- rótulos UI de carácter decorativo.

Regla:

- debe usarse en mayúsculas para evitar variaciones no deseadas del set tipográfico.

### To Japan

Uso recomendado:

- título principal del juego, cuando no forme parte del fondo como imagen.

## Reglas narrativas y de representación

### Protagonista

La protagonista del capítulo 1 es **Jihuun**. Toda la progresión emocional del episodio está contada desde su percepción.

### Pensamientos, señas y narración

- Cuando Jihuun tiene un pensamiento interno:
  - se muestra su nombre;
  - se ocultan los retratos laterales;
  - no se muestra HUD de confianza.

- Cuando Jihuun se comunica en señas:
  - se muestra su nombre;
  - los retratos visibles permanecen en escena;
  - el foco visual se atenúa para reforzar que la acción principal es su intervención.

- Cuando hay narración pura:
  - no se muestra nombre;
  - no se muestran retratos.

### Sistema de confianza

El sistema trabaja con dos valores internos:

- `confianzaSeongsu`
- `confianzaJeongho`

La presentación final acordada es:

- tutorial emergente explicativo;
- HUD persistente posterior al tutorial;
- una sola barra visible a la vez;
- la barra visible cambia según el personaje en foco narrativo.

## Flujo canónico del capítulo 1

### 1. Secuencia de apertura

Orden esperado:

1. negro;
2. pantalla de guardado;
3. título del capítulo;
4. texto de apertura con efecto typewriter;
5. transición al cuarto de Jihuun;
6. notificación del teléfono.

Texto de apertura:

```text
Uno pensaría que con los años la vida se haría más sencilla, que con cada día el peso sería más liviano, y vivir sería menos una carga.

Pero al parecer no.
```

### 2. Cuarto de Jihuun

Elementos centrales:

- cuarto como primer espacio íntimo;
- notificación inicial de Seongsu;
- secuencia del teléfono;
- exploración mínima del cuarto;
- salida al encuentro con sus amigos.

Mensajes clave de Seongsu:

```text
Ándale baja, no dejaré que tires tu vida a la borda.
```

```text
Pero sí échale prisa, que nos estamos achicharrando acá.
```

Pensamientos clave de Jihuun:

```text
¿Por qué me cuesta tanto? Lo intento, de verdad lo intento, pero siempre siento que estoy un paso atrás, como si nunca pudiera alcanzar lo que se espera de mí.

No entiendo por qué todo parece tan sencillo para los demás y yo sigo aquí, atrapada en mi propio ritmo.
```

```text
...Supongo que no tengo otra opción.
```

### 3. Encuentro con Seongsu y Jeongho

Objetivo dramático:

- mostrar a Seongsu y Jeongho como el primer refugio emocional de Jihuun;
- introducir el tutorial del sistema de confianza;
- abrir la primera decisión social del episodio.

### 4. Primera elección

Prompt:

```text
¿Cómo reacciona Jihuun al ver a sus amigos?
```

Opciones:

1. `Sonríe ligeramente`
2. `Solo observa`
3. `Hace una seña a Jeongho`

Impacto de confianza:

- opción 1: `+1 Seongsu`, `+1 Jeongho`
- opción 2: sin cambio
- opción 3: `+1 Jeongho`

### 5. Calle y pasillos

Objetivo dramático:

- reforzar la sensación de aislamiento de Jihuun aun cuando está acompañada;
- marcar la diferencia entre la seguridad que siente con sus amigos y el ruido del entorno escolar.

Intervenciones clave:

- Seongsu pregunta si Jihuun está bien.
- Jihuun responde en señas:

```text
"Estoy cansada"
```

- Jeongho responde:

```text
"Mentirosa"
```

Para esa línea se utiliza la secuencia visual de tres sprites de la seña de Jeongho.

### 6. Segunda elección

Prompt:

```text
¿Cómo procesa Jihuun el ruido del pasillo?
```

Opciones:

1. `Mirar a la gente`
2. `Bajar la mirada`
3. `Ignorar todo`

Impacto de confianza:

- no altera valores por ahora;
- sí altera el texto y la percepción emocional del beat.

### 7. Cafetería

Objetivo dramático:

- bajar la tensión social;
- mostrar una convivencia donde Jihuun puede sentirse cómoda sin necesidad de hablar;
- preparar el contraste con la observación silenciosa del chico desconocido.

Pensamiento clave:

```text
Aquí... es fácil. No necesito hablar.
```

### 8. Tercera elección

Prompt:

```text
¿Cómo participa Jihuun en la conversación?
```

Opciones:

1. `Propone idea de salir el fin de semana`
2. `Solo observa`
3. `Escribe en celular`

Impacto de confianza:

- opción 1: `+1 Seongsu`, `+1 Jeongho`
- opción 2: sin cambio
- opción 3: `+1 Seongsu`, `+1 Jeongho`

### 9. Cierre del capítulo

El cierre debe incluir:

- el remate emocional del chico que observa a Jihuun;
- fade final;
- popup de logro desbloqueado;
- retorno al menú principal.

## Decisiones de implementación ya cerradas

- El teléfono se representa mediante sprites completos de conversación, no mediante una UI de chat reconstruida.
- La exploración del cuarto se resolvió con interacciones simples sobre objetos clave.
- El sistema de confianza permanece separado por personaje, pero el HUD muestra una sola barra visible a la vez.
- El capítulo 1 termina con popup de cierre y regreso al menú.

## Pendientes fuera del alcance actual

- sistema completo de `Settings`;
- sistema de `Save / Load`;
- persistencia real entre sesiones;
- continuidad del capítulo 2 en adelante.
