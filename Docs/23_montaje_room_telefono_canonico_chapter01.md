# Montaje Canonico de `Room + Telefono` en `Chapter01`

Esta guia monta el bloque del cuarto y telefono mas cerca del PDF original.

La idea final es esta:

1. Jihuun despierta en su cuarto
2. aparece una notificacion de Seongsu abajo a la derecha
3. el jugador hace clic en la notificacion
4. se abre `Phone_Message01`
5. Jihuun piensa su bloque largo
6. llega el segundo mensaje y se actualiza a `Phone_Message02`
7. Jihuun piensa `...Supongo que no tengo otra opcion.`
8. solo entonces puede cerrar el telefono
9. empieza la exploracion del cuarto

## Lo que ya deje listo en codigo

Ya actualice:

- [Chapter01Director.cs](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Chapter01/Chapter01Director.cs>)
- [PhoneOverlayController.cs](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Systems/PhoneOverlayController.cs>)
- [PhoneNotificationOverlayController.cs](</C:/Users/sebas/OneDrive/Escritorio/Entre tu Silencio y El Mio/Assets/_Project/Systems/PhoneNotificationOverlayController.cs>)

Ahora el sistema soporta:

- una notificacion clicable
- `Phone_Message01`
- `Phone_Message02`
- cerrar el telefono solo al final del bloque

## Antes de empezar

1. Abre la escena:
   `Assets/_Project/Scenes/Chapter01.unity`
2. Asegurate de no estar en `Play Mode`
3. En `Hierarchy`, ubica:
   `Canvas_Chapter01`

## Parte 1 - Crear `Group_PhoneNotification`

1. Selecciona `Canvas_Chapter01`
2. Clic derecho
3. Pulsa:
   `Create Empty Child`
4. Renombra el objeto a:
   `Group_PhoneNotification`
5. Con `Group_PhoneNotification` seleccionado, en `Inspector`, pulsa:
   `Add Component`
6. Agrega:
   `Canvas Group`
7. Pulsa otra vez `Add Component`
8. Agrega:
   `PhoneNotificationOverlayController`

## Parte 2 - Crear el boton de notificacion

1. Selecciona `Group_PhoneNotification`
2. Clic derecho
3. Pulsa:
   `UI (Canvas) -> Button - TextMeshPro`
4. Renombra ese objeto a:
   `BTN_PhoneNotification`

### Limpiar el texto por defecto del boton

1. Expande `BTN_PhoneNotification`
2. Selecciona el hijo:
   `Text (TMP)`
3. En el `Inspector`, desactiva el objeto completo

## Parte 3 - Crear los textos de la notificacion

### `TXT_PhoneNotificationSender`

1. Selecciona `BTN_PhoneNotification`
2. Clic derecho
3. Pulsa:
   `UI (Canvas) -> Text - TextMeshPro`
4. Renombra el objeto a:
   `TXT_PhoneNotificationSender`

### `TXT_PhoneNotificationBody`

1. Selecciona `BTN_PhoneNotification`
2. Clic derecho
3. Pulsa:
   `UI (Canvas) -> Text - TextMeshPro`
4. Renombra el objeto a:
   `TXT_PhoneNotificationBody`

## Parte 4 - Acomodar la notificacion

### `BTN_PhoneNotification`

1. Selecciona `BTN_PhoneNotification`
2. En `Rect Transform`, usa anchor:
   `bottom right`
3. Deja estos valores aproximados:
   - `Pos X = -140`
   - `Pos Y = 220`
   - `Width = 470`
   - `Height = 135`
4. En el componente `Image`, usa un color oscuro semitransparente
5. Si quieres que se vea mas elegante, deja:
   - `Alpha` medio
   - esquinas suaves usando el sprite por defecto del boton

### `TXT_PhoneNotificationSender`

1. Selecciona `TXT_PhoneNotificationSender`
2. En `Rect Transform`, usa anchor:
   `top left`
3. Deja estos valores aproximados:
   - `Pos X = 24`
   - `Pos Y = -18`
   - `Width = 300`
   - `Height = 36`
4. Texto inicial:
   - `Seongsu <3`
5. Usa un tamano visible, por ejemplo:
   - `Font Size = 26`

### `TXT_PhoneNotificationBody`

1. Selecciona `TXT_PhoneNotificationBody`
2. En `Rect Transform`, usa anchor:
   `top left`
3. Deja estos valores aproximados:
   - `Pos X = 24`
   - `Pos Y = -58`
   - `Width = 415`
   - `Height = 58`
4. Texto inicial:
   - `Andale baja, no dejare que tires tu vida a la borda.`
5. Usa un tamano un poco menor, por ejemplo:
   - `Font Size = 22`
6. Activa `Word Wrapping`

## Parte 5 - Configurar `PhoneNotificationOverlayController`

1. Selecciona `Group_PhoneNotification`
2. En el componente `PhoneNotificationOverlayController`, conecta:

- `Root Canvas Group` -> `Group_PhoneNotification`
- `Sender Text` -> `TXT_PhoneNotificationSender`
- `Body Text` -> `TXT_PhoneNotificationBody`
- `Tap Button` -> `BTN_PhoneNotification`

## Parte 6 - Estado inicial correcto

### `Group_PhoneNotification`

En su `Canvas Group`, deja:

- `Alpha = 0`
- `Interactable = false`
- `Blocks Raycasts = false`

## Parte 7 - Actualizar el telefono principal

1. Selecciona `Group_PhoneOverlay`
2. En `PhoneOverlayController`, no cambies nada raro
3. Solo asegurate de que siga conectado:

- `Root Canvas Group` -> `Group_PhoneOverlay`
- `Message Image` -> `IMG_PhoneMessage`
- `Default Message Sprite` -> `Phone_Message01.png`
- `Close Button` -> `BTN_PhoneClose`

## Parte 8 - Conectar todo al `Chapter01Director`

1. Selecciona el objeto donde vive `Chapter01Director`
   - normalmente `Canvas_Chapter01`
2. En el componente `Chapter01Director`, conecta:

- `Phone Notification Controller` -> `Group_PhoneNotification`
- `First Phone Message` -> `Phone_Message01.png`
- `Second Phone Message` -> `Phone_Message02.png`

No hace falta cablear `On Click()` manual en el boton de notificacion.
El script ya escucha el click.

## Parte 9 - Ajuste del boton `Close` del telefono

No cambies el `BTN_PhoneClose`.

Importante:

- el codigo ahora lo oculta al principio
- y lo vuelve a mostrar cuando ya termino el bloque canonico del telefono

Si al probarlo sigues viendo el boton `Close` demasiado pronto:

- no es que lo hayas conectado mal
- es que Unity no recompilo aun

## Parte 10 - Comportamiento esperado

En `Play`, el orden correcto ahora debe ser:

1. se ve el cuarto
2. aparece notificacion abajo a la derecha
3. haces clic
4. se abre `Phone_Message01`
5. Jihuun piensa su bloque largo
6. suena otra notificacion
7. el sprite cambia a `Phone_Message02`
8. Jihuun piensa `...Supongo que no tengo otra opcion.`
9. aparece `Close`
10. cierras el telefono
11. empieza la exploracion del cuarto

## Validacion minima

1. Guarda la escena
2. Dale `Play`
3. Llega al cuarto
4. Verifica que aparezca la notificacion
5. Haz clic en ella
6. Verifica que primero salga `Phone_Message01`
7. Espera el segundo mensaje
8. Verifica que cambie a `Phone_Message02`
9. Verifica que `Close` aparezca solo al final
10. Cierra el telefono
11. Verifica que entra a la exploracion del cuarto

## Si algo sale raro

Respóndeme con una de estas:

- `notification no aparece`
- `no cambia a message02`
- `close sale demasiado pronto`
- `no entra a exploracion`
- `se ve feo pero funciona`
