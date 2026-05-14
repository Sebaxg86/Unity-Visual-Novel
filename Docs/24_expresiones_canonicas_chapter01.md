# Expresiones Canonicas de `Chapter01`

Este paso conecta las expresiones reales de `Seongsu` y `Jeongho` al `Chapter01Director`.

No vamos a tocar la escena a ciegas.

Vamos a llenar exactamente los campos nuevos que quedaron en el script.

## Que cambio en codigo

En `Chapter01Director` ahora existe una seccion nueva:

- `Character Portrait Libraries`

Adentro hay dos bloques:

- `Seongsu Portraits`
- `Jeongho Portraits`

Cada bloque sirve para que el capitulo use expresiones distintas por linea.

Si no llenas estos campos, el juego sigue funcionando, pero se vera con los retratos viejos que ya tenia la escena.

## Paso 1 - Abrir la escena correcta

1. Abre Unity.
2. Abre la escena `Chapter01`.
3. Asegurate de no estar en `Play Mode`.

## Paso 2 - Seleccionar el director del capitulo

1. En la `Hierarchy`, busca el objeto que tiene el componente `Chapter01Director`.
2. Haz clic en ese objeto.
3. Ve al `Inspector`.

## Paso 3 - Buscar la seccion nueva

1. Baja en el `Inspector`.
2. Busca el encabezado:
   - `Character Portrait Libraries`
3. Expande:
   - `Seongsu Portraits`
   - `Jeongho Portraits`

## Paso 4 - Llenar la libreria de Seongsu

En `Seongsu Portraits`, arrastra estos sprites:

- `Neutral` -> [Seongsu_Neutral.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Neutral.PNG>)
- `Talking` -> [Seongsu_Talking.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Talking.PNG>)
- `Confused` -> [Seongsu_Confused.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Confused.PNG>)
- `Happy` -> [Seongsu_HappyTears.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_HappyTears.PNG>)
- `Tenderness` -> [Seongsu_Ternderness_Happy.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Ternderness_Happy.PNG>)
- `Upset` -> [Seongsu_Upset.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Upset.PNG>)
- `Sad` -> [Seongsu_Sad.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Sad.PNG>)
- `Angry` -> [Seongsu_Angry.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Angry.PNG>)
- `Shocked` -> [Seongsu_Shocked.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Shocked.PNG>)
- `Malicious` -> [Seongsu_Malicious.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Seongsu/Expressions/Seongsu_Malicious.PNG>)

## Paso 5 - Llenar la libreria de Jeongho

En `Jeongho Portraits`, arrastra estos sprites:

- `Neutral` -> [Jeongho_Neutral.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Neutral.png>)
- `Talking` -> [Jeongho_Talking.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Talking.png>)
- `Confused` -> [Jeongho_Confused.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Confused.PNG>)
- `Happy` -> [Jeongho_HappyTears.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_HappyTears.PNG>)
- `Tenderness` -> [Jeongho_Tenderness.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Tenderness.png>)
- `Upset` -> [Jeongho_Upset.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Upset.png>)
- `Sad` -> [Jeongho_Sad.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Sad.PNG>)
- `Angry` -> [Jeongho_Angry.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Angry.PNG>)
- `Shocked` -> [Jeongho_Shocked.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Shocked.png>)
- `Malicious` -> [Jeongho_Malicious.png](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Expressions/Jeongho_Malicious.png>)

## Paso 6 - Guardar

1. Guarda la escena.

## Paso 7 - Probar los beats donde mas se nota

Dale `Play` a `Chapter01` y revisa estos puntos:

1. `Friends`
   - Seongsu debe arrancar mas `Upset`
   - Jeongho debe entrar mas suave

2. `StreetWalk`
   - ambos deben sentirse mas `Tenderness`
   - `Estas bien?` debe verse mas suave

3. `Cafeteria`
   - Seongsu debe verse `Confused` al principio
   - Jeongho debe verse `Neutral`
   - al volver la bandeja, Seongsu debe verse mas `Happy`

4. `Ultima decision`
   - opciones A y C deben verse mas alegres

## Si algo se ve raro

Si al probar notas algo asi:

- `esta expresion no encaja`
- `Jeongho se ve demasiado intenso`
- `Seongsu deberia verse mas triste aqui`

no pasa nada. Lo ajustamos beat por beat.

La idea de esta pasada es dejar el sistema listo y luego afinar direccion visual fina.
