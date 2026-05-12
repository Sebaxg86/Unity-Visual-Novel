# Checklist Manual en Unity

Este documento describe cuando debes intervenir tu directamente y como hacerlo paso a paso.

## Cuando te voy a pedir intervencion manual

Normalmente cuando haga falta una de estas cosas:

- validar visualmente que un asset se ve bien en Unity
- confirmar imports masivos despues de que Unity genere `.meta`
- ajustar una referencia desde `Inspector`
- revisar que una escena no quedo con objetos rosas, invisibles o deformados

## Antes de importar un lote

1. abre Unity con el proyecto correcto
2. asegúrate de no estar en `Play Mode`
3. espera a que Unity termine cualquier importacion pendiente
4. abre la `Console` por si aparece algun error
5. confirma que la escena actual este guardada

## Despues de que yo importe o copie assets a `Assets/_Project/`

1. vuelve a Unity
2. espera a que termine la barra de importacion
3. abre la carpeta nueva dentro de `Assets/_Project/`
4. selecciona 2 o 3 assets de muestra
5. en el `Inspector`, revisa que:
   - imagenes de UI / personajes esten como `Sprite (2D and UI)`
   - se vean correctamente en el preview
   - audios tengan preview reproducible
6. si algo se ve raro, me dices exactamente que asset y como se ve

## Validacion manual recomendada por tipo

### Imagenes de personajes

Revisa:

- que tengan transparencia correcta
- que no salgan recortadas raro
- que no se vean borrosas en el preview

### Fondos

Revisa:

- que la resolucion se vea limpia
- que el encuadre corresponda al storyboard

### Audio

Revisa:

- que el clip reproduzca
- que el volumen no este reventado
- que el nombre corresponda a su uso

## Cuando te pida arrastrar referencias en Unity

Te lo voy a dar asi de concreto:

1. abre escena `X`
2. selecciona objeto `Y` en `Hierarchy`
3. ve al componente `Z` en `Inspector`
4. arrastra asset `A` desde `Project`
5. presiona `Play`
6. confirma si ocurre `B`

## Lo que no te voy a pedir a ciegas

- no te voy a mandar a mover carpetas delicadas sin contexto
- no te voy a pedir que "arregles algo en Unity" sin ruta exacta
- no te voy a dejar solo con errores vagos tipo "revisa referencias"

## Señales de alerta para avisarme de inmediato

- sprites magenta o rosa fuerte
- botones que ya no responden al hover
- textos desaparecidos
- audios que ya no cargan
- errores rojos en `Console`
- escenas que tardan mucho en abrir tras un cambio

## Tu papel en esta metodologia

Yo hago:

- analisis tecnico
- cambios de archivos
- migracion planeada
- arquitectura
- scripts
- documentacion

Tu haces cuando haga falta:

- validacion visual en Unity
- confirmar que el comportamiento coincide con el storyboard
- revisar sensaciones de ritmo, look y UX

## Regla simple

Si Unity requiere ojos humanos para confirmar algo visual, te lo voy a señalar paso a paso.
Si no, yo lo resuelvo directamente.
