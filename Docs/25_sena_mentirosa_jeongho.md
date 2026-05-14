# Sena `Mentirosa` de Jeongho

Este ajuste hace que, cuando Jeongho diga `Mentirosa` en lenguaje de senas, su portrait derecho reproduzca los 3 sprites de `Sign_Mentirosa`.

El codigo ya esta listo.

Solo falta conectar los 3 frames en Unity.

## Paso 1 - Abrir la escena

1. Abre Unity.
2. Abre la escena `Chapter01`.
3. Asegurate de no estar en `Play Mode`.

## Paso 2 - Seleccionar `Chapter01Director`

1. En la `Hierarchy`, selecciona el objeto que tiene el componente `Chapter01Director`.
2. Ve al `Inspector`.

## Paso 3 - Buscar la seccion nueva

En `Chapter01Director`, busca:

- `Sign Animations`

Adentro veras:

- `Jeongho Mentirosa Sequence`
- `Jeongho Mentirosa Frame Duration`

## Paso 4 - Asignar los 3 frames

En `Jeongho Mentirosa Sequence`, pon tamaño `3`.

Luego arrastra estos sprites en orden:

1. [JeonghoSeña01.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Sign_Mentirosa/JeonghoSeña01.PNG>)
2. [JeonghoSeña02.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Sign_Mentirosa/JeonghoSeña02.PNG>)
3. [JeonghoSeña03.PNG](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Art/Characters/Jeongho/Sign_Mentirosa/JeonghoSeña03.PNG>)

## Paso 5 - Revisar velocidad

Por defecto, `Jeongho Mentirosa Frame Duration` esta en `0.13`.

Eso significa:

- cada frame dura `0.13` segundos
- la secuencia completa se ve rapida y natural

Si la sientes muy rapida:

- subela a `0.16` o `0.18`

Si la sientes lenta:

- bajala a `0.10`

## Paso 6 - Probar

1. Guarda la escena.
2. Dale `Play`.
3. Llega al bloque donde Jeongho firma `Mentirosa`.

Lo esperado:

- aparece la linea `"Mentirosa"`
- el portrait derecho de Jeongho reproduce los 3 sprites
- despues se queda en el ultimo frame hasta avanzar

## Nota importante

No hace falta tocar manualmente las lineas del dialogo.

`Chapter01Director` detecta automaticamente la linea:

- speaker `Jeongho`
- modo `Signed`
- texto `Mentirosa`

y le enchufa esa secuencia de forma automatica.
