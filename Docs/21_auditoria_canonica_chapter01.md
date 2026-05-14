# Auditoria Canonica de `Chapter01`

Este documento compara tres cosas:

- la fuente de verdad narrativa en `00_explicacion_capitulo1_fuente_de_verdad.md`
- la traduccion tecnica en `16_guion_implementable_capitulo1.md`
- lo que hoy realmente corre en `Chapter01`

La meta es simple:

- saber que ya esta fiel al guion
- saber que esta aproximado
- saber que falta para llegar al `100%` canonico

## Criterio del semaforo

- `VERDE`: ya esta muy cerca del guion de tu amiga
- `AMARILLO`: existe y funciona, pero esta resumido, simplificado o le falta puesta en escena
- `ROJO`: no existe todavia o se comporta de forma distinta a lo que pide el guion

## Resumen ejecutivo

Estado actual estimado:

- flujo del capitulo: `VERDE`
- sistemas base del capitulo: `VERDE`
- texto exacto linea por linea: `AMARILLO`
- puesta en escena canonica: `AMARILLO`
- transiciones, tiempos y visual storytelling: `ROJO/AMARILLO`
- pulido audiovisual final: `ROJO`

Conclusion honesta:

- ya no estamos en prototipo vacio
- ya tenemos un vertical slice jugable y bastante fiel
- pero todavia no estamos en una version `100% canonica`

## Auditoria por bloque

### 1. Secuencia inicial

Fuente canonica:

- negro inicial
- pantalla de guardando
- titulo de capitulo
- fade a negro
- texto escribiendose
- fade a negro
- ding del celular
- efecto de abrir ojos

Estado actual: `AMARILLO`

Que ya esta:

- negro inicial
- guardando
- titulo del capitulo
- texto escribiendose
- transicion al cuarto
- ding del celular

Que falta o esta simplificado:

- el efecto de `abrir ojos` sigue siendo una version sobria, no una puesta en escena dedicada
- no esta montado el `SFX de tecleo` durante el texto manual
- los tiempos pueden necesitar ajuste fino contra el PDF

Diagnostico:

- narrativamente cumple
- visualmente todavia esta resumido

### 2. Telefono y cuarto de Jihuun

Fuente canonica:

- aparece una notificacion de Seongsu
- el jugador hace clic en la notificacion
- el celular se desliza a pantalla
- se ven los mensajes
- Jihuun piensa
- llega un segundo mensaje
- Jihuun piensa otra vez
- luego puede explorar el cuarto

Estado actual: `AMARILLO`

Que ya esta:

- telefono como sprite completo
- cierre manual del telefono
- pensamientos de Jihuun en el cuarto
- exploracion del cuarto

Que falta o difiere:

- hoy el telefono aparece como parte del flujo automatico; no hay paso intermedio de `clic a notificacion`
- el guion original separa dos mensajes y dos pensamientos
- nuestro flujo actual comprime esa parte en un sprite de telefono + bloque de pensamiento
- la exploracion por flechas no existe; hoy es exploracion simplificada por hotspots/botones

Diagnostico:

- la intencion narrativa esta
- la estructura exacta de interaccion aun no

### 3. Salida del cuarto y entrada de amigos

Fuente canonica:

- Jihuun sale por la puerta
- Seongsu entra con frustracion
- luego Jeongho entra con expresion dulce
- despues Jeongho le da la barra a Seongsu

Estado actual: `AMARILLO`

Que ya esta:

- salir por la puerta como trigger real
- linea de Seongsu
- linea de Jeongho
- linea de la barra
- pensamiento de Jihuun

Que falta o difiere:

- las entradas `deslizandose a escena` no estan montadas
- las expresiones exactas de cada beat no estan amarradas por linea
- la reaccion visual de Seongsu `awuitada` no existe aun

Diagnostico:

- el contenido esta
- la puesta en escena todavia no

### 4. Tutorial e indicador de confianza

Fuente canonica:

- aparece junto al primer dialogo con amigos
- explica el sistema
- se puede cerrar
- existen dos variables de confianza por personaje

Estado actual: `VERDE`

Que ya esta:

- popup tutorial
- boton cerrar
- dos valores internos separados
- HUD persistente
- foco de barra segun personaje en escena

Diferencias abiertas:

- la forma visual exacta del HUD es una decision de implementacion, no una instruccion cerrada del PDF

Diagnostico:

- funcionalmente esta bien alineado

### 5. Primera decision

Fuente canonica:

- `Sonrie ligeramente`
- `Solo observa`
- `Hace una sena a Jeongho`
- efectos correctos de confianza
- remate especial con Jeongho si se elige la tercera

Estado actual: `VERDE`

Que ya esta:

- prompt correcto
- opciones correctas
- deltas de confianza correctos
- remate de Jeongho implementado

Que aun podria mejorar:

- reacciones visuales y expresiones exactas de cada ruta

Diagnostico:

- mecanicamente esta bastante bien

### 6. Caminata con amigos

Fuente canonica:

- pensamiento de refugio emocional
- Seongsu pregunta si esta bien
- Jihuun responde en senas
- Jeongho responde en senas
- pensamientos largos de Jihuun
- amigos con expresion `TENDERNESS`
- fade al pasillo

Estado actual: `AMARILLO`

Que ya esta:

- pensamiento inicial
- `Estas bien?`
- `Estoy cansada`
- `Mentirosa`
- pensamientos posteriores
- reglas visuales de Jihuun ya mejoradas

Que falta o difiere:

- el texto largo de refugio emocional sigue resumido
- los pensamientos posteriores siguen comprimidos respecto al PDF
- la expresion `TENDERNESS` no esta montada linea por linea
- el fade hacia pasillo existe como cambio de beat, pero no como mini escena dramatizada

Diagnostico:

- contenido correcto en intencion
- falta expansion y direccion visual

### 7. Pasillos de la escuela

Fuente canonica:

- pensamiento previo de Jihuun
- decision del pasillo
- tres rutas
- variantes visuales sugeridas segun opcion

Estado actual: `AMARILLO`

Que ya esta:

- pensamiento previo
- decision del pasillo
- tres opciones
- textos posteriores distintos por ruta
- aparicion del chico que mira

Que falta o difiere:

- no existen variantes visuales del pasillo segun opcion
- algunos textos post-decision estan abreviados frente al PDF
- el peso del silencio y las pausas aun no estan trabajados del todo

Diagnostico:

- la estructura existe
- la escena aun no tiene todo su peso canonico

### 8. Transicion al resto del dia

Fuente canonica:

- timelapse
- Seongsu invita a la cafeteria
- fade a cafeteria

Estado actual: `ROJO`

Que ya esta:

- salto narrativo funcional hacia cafeteria

Que falta:

- timelapse
- linea `Ven! Vamos a la cafe.`
- beat intermedio antes de cafeteria

Diagnostico:

- hoy el juego llega a cafeteria demasiado directo

### 9. Cafeteria

Fuente canonica:

- solo aparece Seongsu al inicio
- cuando Jeongho habla, entra despues
- narracion mas larga de la manana
- pedido
- video del gato
- Jihuun se rie
- regreso de Seongsu con bandeja
- chistes de pelicula
- Jihuun firma
- pensamiento final de comodidad

Estado actual: `AMARILLO`

Que ya esta:

- base de la conversacion
- pedido de jugo de durazno
- narracion del pedido
- video del gato
- bromas sobre la pelicula
- `Ni yo la conozco`
- pensamiento `Aqui... es facil. No necesito hablar.`

Que falta o difiere:

- el arranque visual con solo Seongsu y luego entrada de Jeongho no esta montado
- parte de la narracion larga esta comprimida
- falta la accion de `Jihuun se rie` como beat visual claro
- faltan expresiones exactas por tramo

Diagnostico:

- esta bastante cerca en estructura
- aun no esta completo en ritmo y detalle

### 10. Ultima decision y cierre

Fuente canonica:

- tres opciones finales
- opcion A y C acercan a sus amigos
- opcion B se queda pasiva
- el pensamiento del chico que mira es largo y mas incomodo
- luego funde a negro
- suena `Achievement`
- aparece mensaje de capitulo terminado

Estado actual: `AMARILLO`

Que ya esta:

- tres opciones
- efectos de confianza base
- pensamiento del chico que mira
- fade de cierre
- mensaje de capitulo terminado

Que falta o difiere:

- las rutas A y C estan simplificadas
- el pensamiento del chico que mira esta mucho mas corto que en el PDF
- la diferencia entre A y C no esta dramatizada del todo
- la quietud de la opcion B antes del negro no esta trabajada
- el `Achievement` y cierre audiovisual siguen pendientes

Diagnostico:

- cierra bien como prototipo
- no cierra aun como escena final canonica

## Auditoria de convenciones de escritura

### Senas

Fuente canonica:

- todo lo que Jihuun diga en senas debe verse entre comillas

Estado actual: `VERDE`

Nota:

- ya lo resolvimos desde el sistema: `DialogueSpeakerMode.Signed` agrega comillas visuales

### Pensamientos de Jihuun

Fuente canonica:

- deben verse claramente como pensamiento de Jihuun

Estado actual: `VERDE`

Nota:

- ya se muestra `Jihuun`
- ya se ocultan los portraits

### Narrador

Fuente canonica:

- no debe verse como si fuera dialogo normal

Estado actual: `VERDE`

Nota:

- ya no muestra nombre
- ya no muestra portraits

## Brechas reales para llegar a 100%

Las brechas mas importantes hoy son estas:

1. Reemplazar texto resumido por texto exacto del PDF
2. Separar beats que hoy estan comprimidos:
   - telefono
   - caminata
   - transicion a cafeteria
   - cierre final
3. Montar puesta en escena faltante:
   - entradas deslizandose
   - expresiones por linea
   - timelapse
   - beat de risa de Jihuun
4. Cerrar audio y timing:
   - tecleo
   - notificaciones
   - puerta
   - suspiro
   - achievement
5. Decidir si la exploracion del cuarto se queda como adaptacion o vuelve a flechas para respetar el storyboard

## Veredicto final

Si hoy tuvieramos que poner nota de fidelidad canonica al capitulo:

- `estructura`: alta
- `texto exacto`: media
- `puesta en escena`: media-baja
- `acabado`: baja

Traduccion humana:

- ya se parece claramente al capitulo de tu amiga
- pero todavia no es la version final que ella imaginaba
- el camino al `100%` ya no es inventar sistema
- el camino al `100%` es cerrar detalle, staging y texto exacto
