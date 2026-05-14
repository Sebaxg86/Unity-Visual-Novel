# Entre tu silencio y el mío — Capítulo 1: Fuente de verdad

> Transcripción organizada del PDF de explicación del primer capítulo para uso como referencia de guion, decisiones, rutas, UI y programación en Unity.
>
> Nota: el contenido conserva la intención original del documento. Se acomodó en secciones para que sea más fácil usarlo como fuente de verdad.

---

## 1. Tipografías

### 1.1 ComicNeueSansID

**Uso:**

- Nombres de personajes.
- Diálogos.
- Pensamientos de la protagonista.
- Botón **Next** en diálogos o eventos.

**Notas:**

- Se usa cuando hablan **Jeongho** y **Seongsu**.
- Se usa cuando habla el **narrador** y cuando piensa **Jihuun**.
- Cuando **Jihuun** hable en señas, la palabra o frase debe aparecer entre comillas para diferenciarlo.

**Ejemplo de señas:**

```text
"Estoy cansada"
```

---

### 1.2 Starborn

**Uso:**

- Botones.
- Algunos títulos.

**Excepción:**

- No se usa en el botón **Next** de los diálogos.

**Nota importante:**

- Con esta tipografía se debe escribir siempre en mayúsculas; si no, ciertas letras tendrán estrellas.

---

### 1.3 To Japan

**Uso:**

- Únicamente para el título del juego.

**Nota:**

- Si se usa un fondo que ya contiene el título, esta tipografía sería opcional.

---

## 2. Guion y storyboard

El storyboard inicia después de presionar **New Game**.

---

## 3. Secuencia inicial del capítulo

### Escena 1 — Pantalla negra

- Pantalla en negro.
- De fondo se escucha el **BGM**.
- Duración: **2 segundos**.

---

### Escena 2 — Pantalla de guardando

- Fade in de negro a pantalla de **guardando**.
- Usar tipografía **ComicNeueSansID**.
- Duración: **4 segundos**.

---

### Escena 3 — Título del capítulo

- Fade in del título del capítulo:

```text
Capítulo 1: Un Nuevo Comienzo
```

**Tipografías:**

- `Capítulo 1`: ComicNeueSansID.
- `UN NUEVO COMIENZO`: Starborn.

**Nota:**

- En Starborn, escribir en mayúsculas para evitar que ciertas letras tengan estrellas.

**Duración:**

- 4 o 5 segundos.
- Puede ajustarse según criterio.

---

### Escena 4 — Fade a negro

- Fade in a negro.
- Duración: **3 segundos**.

---

### Escena 5 — Texto escribiéndose manualmente

- El texto debe verse como si se estuviera escribiendo manualmente.
- Debe escucharse el **SFX de tecleo**.

**Texto 1:**

```text
Uno pensaría que con los años la vida se haría más sencilla, que con cada día el peso sería más liviano, y vivir sería menos una carga.
```

**Pausa:**

- Entre el texto 1 y el texto 2 debe haber una pausa de unos segundos para que se sienta como si realmente la protagonista estuviera escribiendo.

**Texto 2:**

```text
Pero al parecer no.
```

---

### Escena 6 — Fade a negro

- Fade in a negro.
- Duración: **3 segundos**.

---

### Escenas 7, 8 y 9 — Despertar / abrir ojos

- Suena el **ding** de una notificación de celular.
- Se hace el efecto de **abrir los ojos**.
- Pendiente decidir si se hará por medio de imágenes u otro método.

---

## 4. Habitación de Jihuun

### Escena 10 — Notificación de Seongsu

- Escenario: cuarto de Jihuun.
- De fondo se escucha el **BGM**.
- En la esquina inferior derecha aparece una notificación de mensaje de **Seongsu**, su mejor amiga.

**Mensaje de Seongsu:**

```text
Ándale baja, no dejaré que tires tu vida a la borda.
```

---

### Escena 11 — Abrir celular

- El jugador hace clic en la notificación.
- El celular de Jihuun se desliza hacia la pantalla.
- La conversación aparece abierta.

**Nota de implementación:**

- Pendiente decidir si se hará con fotos, sprites o UI en Unity.

---

### Escena 12 — Pensamiento interno de Jihuun

Después de leer el mensaje de Seongsu, Jihuun piensa:

```text
¿Por qué me cuesta tanto?. Lo intentó, de verdad lo intento, pero siempre siento que estoy un paso atrás, como si nunca pudiera alcanzar lo que se espera de mí.

No entiendo por qué todo parece tan sencillo para los demás y yo sigo aquí, atrapada en mi propio ritmo.
```

---

### Escena 13 — Segundo mensaje de Seongsu

Seongsu manda otro mensaje:

```text
Pero si hechale prisa, que nos estamos achicharrando acá.
```

---

### Escena 14 — Pensamiento interno de Jihuun

Jihuun piensa:

```text
…Supongo que no tengo otra opción.
```

---

### Nota de SFX

- Cada notificación que llega tiene su propio **SFX**.
- También debe sonar un efecto al presionar cualquier tipo de botón.

---

### Escena 15 — Cerrar teléfono y exploración

- Se sale de la pantalla del teléfono.
- La idea es que al lado del teléfono haya una **tacha** para salir.
- Después de cerrar el teléfono, el jugador puede moverse dentro de la habitación usando las flechas.
- Algunos objetos serán interactuables.

**Objeto principal para iniciar el capítulo:**

- La puerta del cuarto.

---

## 5. Salida del cuarto y primer diálogo con amigos

### Escenas 16, 17 y 18 — Salir por la puerta

Para empezar el capítulo como tal, la protagonista debe salir por la puerta de su cuarto.

Al salir:

- **Seongsu** se desliza a escena con expresión de frustración.

**Diálogo de Seongsu:**

```text
¡Hasta que te dignas en salir! Se me iba a quemar la cabeza aquí afuera.
```

---

## 6. Indicador de confianza

### Aparición del indicador

Al aparecer el primer diálogo, aparece también el **indicador de confianza**.

Cuando aparezca, debe mostrarse una notificación explicando qué significa.

**Texto de la notificación:**

```text
INDICADOR DE CONFIANZA

El indicador de confianza muestra qué tan cómoda y abierta se siente Jihuun en sus interacciones.

Tus decisiones influyen en este nivel: puedes ayudarla a acercarse a los demás... o hacer que se cierre aún más.
```

**Botón:**

```text
Cerrar
```

---

## 7. Interacción con Jeongho y Seongsu

### Jeongho entra a escena

- **Jeongho** se desliza a escena.
- Tiene una expresión dulce.
- Mira de reojo a Seongsu.

**Diálogo de Jeongho:**

```text
Ya, ya salió, no generes más drama.
```

Seongsu hace una cara triste / awuitada.

---

### Jeongho le da comida a Seongsu

- Jeongho voltea hacia enfrente.
- Le da una barrita de comida a Seongsu.

**Diálogo de Jeongho:**

```text
Ya ya, ten. Se nota que lo necesitas.
```

---

### Pensamiento interno de Jihuun

Jihuun piensa:

```text
Una barra de proteína, muy creativo jajaja.
```

---

## 8. Primera decisión del jugador

### Escena 21 — Opciones de Jihuun

A Jihuun le aparece un cuadro de texto con opciones para elegir qué hacer.

Dependiendo de la elección, el indicador de confianza de sus amigos puede subir o mantenerse.

> Nota: No poner las letras A, B o C en el texto dentro del juego. Son solo para distinguir las rutas en este documento.

---

### Opción A — Sonríe ligeramente

**Texto de opción:**

```text
Sonríe ligeramente
```

**Efecto:**

- Sube un nivel en ambos indicadores de confianza.

---

### Opción B — Solo observa

**Texto de opción:**

```text
Solo observa
```

**Efecto:**

- Los indicadores se mantienen igual.

---

### Opción C — Hace una seña a Jeongho

**Texto de opción:**

```text
Hace una seña a Jeongho
```

**Efecto:**

- Sube un nivel solo en el indicador de Jeongho.

**Jihuun dice en señas:**

```text
"¿Ya lo tenías preparado?"
```

**Reacción de Jeongho:**

- Jeongho se pone feliz.

**Diálogo de Jeongho:**

```text
Para que veas jajaja, era predecible.
```

---

### Transición después de cualquier opción

Elija lo que elija el jugador:

- Al presionar **Next**, hay un fade in a la escena de ellos caminando.
- En esa escena deben sonar:
  - SFX de pajaritos.
  - Sonido de puerta abriéndose.

---

## 9. Caminata con amigos

### Escena 22 — Pensamiento de Jihuun

Suena un **SFX de suspiro**.

Jihuun piensa:

```text
Me alegra estar con ellos… Aquí no siento que falte algo.
```

Luego aparece el siguiente texto:

```text
Estar con ellos la hacía olvidar sus problemas, aunque fuera por un rato. Eran como su pequeño refugio. Con ellos no importaba si a veces no podía hablar. No sentía que sobrara, como en otros lugares. De alguna manera, su conexión traspasaba esas barreras invisibles que tanto la frenaban.
```

---

### Escena 23 — Seongsu pregunta si está bien

Sus amigos se voltean.

**Diálogo de Seongsu:**

```text
¿Estás bien?
```

**Jihuun responde en señas:**

```text
"Estoy cansada"
```

> Nota: cuando Jihuun hable en señas, el texto debe ir entre comillas.

---

### Escena 24 — Jeongho responde en señas

Jeongho decide responder en señas.

**Jeongho dice en señas:**

```text
"Mentirosa"
```

---

### Escena 25 — Pensamientos de Jihuun

Jihuun piensa:

```text
A veces…
me siento atrapada en mi propia cabeza.
```

**Diálogo de Jeongho:**

```text
Pero te dejaremos tranquila… por ahora.
```

Jihuun piensa:

```text
Cada vez que alguien me pregunta por qué no hablo, siento que me estoy ahogando un poco más…

La gente no entiende lo agotador que es tener que depender siempre de los demás para comunicarme. A veces me siento atrapada en mi propia cabeza y en mis propios recuerdos.
```

Ambos amigos le sonríen con expresión **TENDERNESS**.

Después de unos segundos, hay un fade in a negro para aparecer en los pasillos de la escuela.

---

## 10. Pasillos de la escuela

### Pensamiento previo de Jihuun

Antes de la decisión en el pasillo, Jihuun piensa:

```text
Todos hablan…
Todos ríen…

Y yo…

[pausa de unos segundos]

Estoy aquí.

Pero no me siento presente.
```

**Audio de fondo:**

- SFX de gente hablando.
- El archivo está en la carpeta compartida.

---

## 11. Segunda decisión del jugador

### Escena 28 — Decisión en el pasillo

A Jihuun le aparece la siguiente decisión.

> Nota: No poner A, B o C dentro del juego. Son solo para referencia de rutas.

---

### Opción A — Mirar a la gente

**Texto de opción:**

```text
Mirar a la gente
```

**Texto en caja de Jihuun:**

```text
Levanto la mirada.

Por un segundo, todo se vuelve más claro.
Rostros. Movimiento. Ruido.

Demasiado.

Y entonces—
Alguien me está mirando..

[pausa]

No es como los demás.
No se aparta de inmediato.
```

**Nota visual opcional:**

- Se puede poner un recuadro blanco con baja opacidad.
- Jugar con los colores para que la escena se vea un poco más colorida, pero no demasiado.

---

### Opción B — Bajar la mirada

**Texto de opción:**

```text
Bajar la mirada
```

**Texto en caja de Jihuun:**

```text
Bajo la mirada.

Es más fácil así.

Nadie se detiene.
Nadie pregunta.

Solo pasos y ruido.
```

**Nota visual opcional:**

- Se puede hacer algo similar a la opción anterior, pero en vez de hacerlo más colorido, oscurecer un poco la escena.

---

### Opción C — Ignorar todo

**Texto de opción:**

```text
Ignorar todo
```

**Resultado:**

- No pasa nada realmente.
- Solo aparecen puntos suspensivos en el texto de Jihuun.

**Texto:**

```text
...
```

---

## 12. Transición al resto del día

### Escena 29 — Timelapse

- La idea es que haya un timelapse para dar a entender que pasó el día.

---

### Escena 30 — Seongsu invita a la cafetería

Seongsu aparece y dice:

```text
¡Ven! Vamos a la cafe.
```

---

### Escena 31 — Fade a cafetería

- Se hace un fade in a la escena de cafetería.

---

## 13. Cafetería

### Escenas 32 y 33 — Entrada de Seongsu y Jeongho

- Al inicio solo aparece Seongsu en escena.
- Cuando Jeongho habla, aparece deslizándose en escena.

**Narrador / caja de texto de Jihuun:**

```text
La mañana pasó como todas las demás: clases, notas, miradas rápidas entre los compañeros. Jihuun se sentía como una sombra, como si no pudiera encajar completamente, pero al mismo tiempo, no quería llamar la atención.
```

---

## 14. Interacción en cafetería

### Seongsu

**Expresión:** confundida.

```text
¿Sabes qué se me antoja? Un pastel de mango.
```

---

### Jeongho

**Expresión:** neutral.

```text
Te tropezaste con una planta, no salvaste el mundo.
```

---

### Seongsu

**Expresión:** confundida.

```text
¿Y tú qué vas a pedir?
```

---

### Acción de Jihuun

Jihuun hace señas:

```text
"Jugo de durazno"
```

---

### Jeongho

**Expresión:** neutral.

```text
Obvio. Desde que te conozco, la más adicta al jugo de durazno.
```

---

### Narrador

```text
Seongsu sonrió con cariño y fue a hacer el pedido.
```

```text
Jeongho sacó su celular para enseñarle a Jihuun un video absurdo de un gato atrapado en una bolsa de papel.
```

**Acción:**

- Jihuun se ríe.

---

### Narrador

```text
Seongsu volvió con la bandeja: dos pasteles, un café americano y su jugo de durazno.
```

> Nota: no se verán físicamente, pero el narrador lo menciona.

---

### Seongsu

**Expresión:** feliz.

```text
Ahí tienes. Tu dosis de vida líquida.
```

---

### Narrador

```text
Seongsu, sin decir nada más, partió su pastelito por la mitad y le ofreció un pedazo a Jihuun. Como siempre, como si fuera algo que no necesitaba explicación.
```

```text
El jugo de durazno estaba frío contra sus labios, un pequeño alivio bajo el sol que ya empezaba a picar en la piel. Jihuun bebía a pequeños sorbos mientras escuchaba a Jeongho hablar sobre una película vieja que, según él, era "cine de culto" solo porque casi nadie la conocía.
```

```text
Seongsu, del otro lado, bufaba exageradamente y le decía que tenía gustos de señor de cincuenta años.
```

---

### Seongsu

**Expresión:** feliz.

```text
Apostaría a que ni siquiera tiene subtítulos.
```

---

### Seongsu

**Expresión:** feliz.

```text
Es más, apuesto a que ni el director se acuerda que la hizo.
```

---

### Acción de Jihuun

Jihuun sonrió.

Casi sin pensarlo, firmó de forma rápida y sencilla:

```text
"Ni yo la conozco"
```

---

### Seongsu

**Expresión:** feliz.

```text
¿Ya ves? Hasta Jihuun lo dice, y ella es la más cool de nosotros.
```

---

### Pensamiento de Jihuun

```text
Aquí… es fácil. No necesito hablar.
```

---

## 15. Última decisión del capítulo

A Jihuun le toca la última decisión del capítulo.

---

### Opción A — Propone idea de salir el fin de semana

**Texto de opción:**

```text
Propone idea de salir el fin de semana
```

**Efecto:**

- Sube un nivel en los indicadores de confianza de sus amigos.

**Pensamiento de Jihuun:**

```text
Levanto las manos antes de pensarlo demasiado.

Hago la seña torpemente… pero suficiente.

No estoy segura de si lo entenderán.
```

**Seongsu:**

```text
¡¿Burbujas?! ¡Me encanta!
```

**Jeongho:**

```text
Ok, eso sí no me lo esperaba.
```

**Acción:**

- Jihuun se ríe.
- Ambos amigos hacen expresión de felicidad.

**Pensamiento de Jihuun al sentir que alguien la mira:**

```text
Alguien me estaba mirando otra vez.

[pausa breve]

Levanté la vista, y ahí estaba él.

Ese chico que siempre parecía estar en el lugar correcto para hacerme sentir incómoda.

No era que él hiciera algo malo. No era como los otros que se reían o susurraban. Su mirada era distinta, como de curiosidad, pero igual de pesada. No me gustaba ser observada así. No me gustaba sentirme un bicho raro en exhibición.

Bajé la cabeza rápidamente, reprimiendo el impulso de fruncir el ceño.

No era su culpa, Solo estaba... curioso. Quizá.
```

Después de eso, unos segundos después, la pantalla se funde a negro.

---

### Opción B — Solo observa

**Texto de opción:**

```text
Solo observa
```

**Efecto:**

- No sucede nada realmente en términos del indicador de confianza.

**Pensamiento de Jihuun al sentir que alguien la mira:**

```text
Alguien me estaba mirando otra vez.

[pausa breve]

Levanté la vista, y ahí estaba él.

Ese chico que siempre parecía estar en el lugar correcto para hacerme sentir incómoda.

No era que él hiciera algo malo. No era como los otros que se reían o susurraban. Su mirada era distinta, como de curiosidad, pero igual de pesada. No me gustaba ser observada así. No me gustaba sentirme un bicho raro en exhibición.

Bajé la cabeza rápidamente, reprimiendo el impulso de fruncir el ceño.

No era su culpa, Solo estaba... curioso. Quizá.
```

**Nota:**

- Antes de acabar el capítulo y que la pantalla se haga negra, la escena se queda unos segundos estática.

---

### Opción C — Escribe en celular

**Texto de opción:**

```text
Escribe en celular
```

**Resultado:**

- Pasa lo mismo que en la opción A.
- La diferencia es que, en vez de decirlo con señas, Jihuun lo dice en su celular.

---

## 16. Cierre del capítulo

Al fundirse la pantalla en negro:

- Suena un SFX de **Achievement**.
- Aparece un mensaje indicando que terminaste el capítulo.

**Texto sugerido:**

```text
Capítulo 1 terminado
```

Después de eso, termina el capítulo.

---

## 17. Colores

| Elemento | Color |
|---|---:|
| Botón **NEXT** | `#876883` |
| Degradado nombre **SEONGSU** | `#D37091` |
| Degradado nombre **JEONGHO** | `#3D528C` |
| Textos de diálogos | `#FFFFFF` |
| Texto cuando Jihuun debe elegir una respuesta | `#B74B5D` |
| Botón **Sí** en sección Quit | `#EDA1AE` |
| Botón **No** en sección Quit | `#876883` |
| Títulos de pantallas | `#FFFFFF` |
| Sombra de títulos | `#000000` con opacidad menor |

---

## 18. Pantallas

## 18.1 Main Menu

La idea es que el menú principal se vea como la referencia visual del PDF.

**Botones del menú principal:**

```text
Continue
New Game
Settings
Quit
```

**Notas:**

- Hay un **BGM** para el main menu.
- El acomodo debe parecerse a la referencia visual.

---

## 18.2 Save / Load / Settings

Sobre las pantallas de **Settings** y **Save**:

- Puede hacerse directamente en Unity si resulta más fácil.
- Se compartió el fondo con degradado de azul a rosa.
- La idea visual del acomodo es similar a la referencia del PDF.

**Opciones laterales vistas en la referencia:**

```text
History
Save
Load
Settings
Main Menu
About
Help
Quit
Return
```

**Slots de guardado:**

- Página 1.
- Varios slots vacíos.
- Un slot con imagen, fecha y hora.

---

## 18.3 Settings

La pantalla de settings contiene opciones como:

```text
Display
Skipping
After Choices
```

**Opciones visuales de referencia:**

```text
Full Screen / Windowed
All Messages / Read Messages
On / Off
```

**Sliders:**

```text
Background Music
Sound Effects
Text Speed
Auto Speed
```

**Menú lateral:**

```text
Return
Save
Load
Settings
Menu
Quit
```

---

## 18.4 Confirmación de Quit

Cuando el jugador presione **Quit**, debe aparecer un recuadro de confirmación.

**Texto:**

```text
DO YOU WANT TO QUIT?
```

**Botones:**

```text
Yes
No
```

**Notas de color:**

- Botón Yes: `#EDA1AE`.
- Botón No: `#876883`.

---

## 19. Notas de implementación para Unity

### Sistemas requeridos

- Sistema de diálogos.
- Sistema de narrador / pensamientos internos.
- Sistema para texto de señas entre comillas.
- Sistema de decisiones.
- Sistema de indicadores de confianza por personaje.
- Sistema de transiciones:
  - Fade in.
  - Fade out.
  - Fade a negro.
- Sistema de SFX:
  - Notificación.
  - Botones.
  - Tecleo.
  - Puerta.
  - Pajaritos.
  - Suspiro.
  - Gente hablando.
  - Achievement.
- Sistema de teléfono / chat.
- Sistema de exploración en habitación con flechas.
- Objetos interactuables.
- Menú principal.
- Pantalla de guardado/carga.
- Pantalla de settings.
- Confirmación de salida.

---

## 20. Variables narrativas sugeridas

### Indicadores de confianza

```csharp
int confianzaSeongsu;
int confianzaJeongho;
```

### Decisiones principales

```text
decision_primera_interaccion
- Sonríe ligeramente
- Solo observa
- Hace una seña a Jeongho

Decision_pasillo
- Mirar a la gente
- Bajar la mirada
- Ignorar todo

decision_final_cafeteria
- Propone idea de salir el fin de semana
- Solo observa
- Escribe en celular
```

---

## 21. Tabla rápida de rutas y efectos

| Momento | Opción | Efecto narrativo | Efecto confianza |
|---|---|---|---|
| Primera decisión | Sonríe ligeramente | Jihuun responde de forma abierta | +1 Seongsu, +1 Jeongho |
| Primera decisión | Solo observa | Jihuun se mantiene reservada | Sin cambio |
| Primera decisión | Hace una seña a Jeongho | Interacción especial con Jeongho | +1 Jeongho |
| Pasillo | Mirar a la gente | Nota a alguien mirándola; escena más clara/colorida | No especificado |
| Pasillo | Bajar la mirada | Evita mirar; escena más oscura | No especificado |
| Pasillo | Ignorar todo | Solo aparecen puntos suspensivos | No especificado |
| Cafetería/final | Propone salir el fin de semana | Propone plan en señas | +1 Seongsu, +1 Jeongho |
| Cafetería/final | Solo observa | Se queda pasiva; misma mirada desconocida | Sin cambio |
| Cafetería/final | Escribe en celular | Mismo resultado que proponer, pero usando celular | Igual que opción A |

---

## 22. Convenciones de escritura

### Diálogos normales

Usar el nombre del personaje y luego su diálogo.

```text
Seongsu:
¿Estás bien?
```

---

### Pensamientos internos

Marcar claramente como pensamiento de Jihuun.

```text
Jihuun piensa:
Aquí… es fácil. No necesito hablar.
```

---

### Señas

Todo lo que Jihuun diga en señas debe escribirse entre comillas.

```text
"Estoy cansada"
```

---

### Narrador

Usar una caja de texto de narrador o caja de Jihuun según la implementación visual.

```text
Narrador:
La mañana pasó como todas las demás...
```

---

## 23. Pendientes marcados en el documento

- Definir cómo se hará el efecto de abrir los ojos.
- Definir cómo se mostrará el celular de Jihuun:
  - ¿Imágenes?
  - ¿Sprites?
  - ¿UI programada en Unity?
- Definir objetos interactuables adicionales en la habitación.
- Confirmar duración exacta de algunas escenas.
- Confirmar si las variaciones visuales en la decisión del pasillo se implementarán.
- Confirmar cómo se guardarán y mostrarán los indicadores de confianza.

