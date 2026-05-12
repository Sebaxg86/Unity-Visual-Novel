# Verificacion de Scripts Nuevos en Unity

Despues de agregar scripts nuevos a `Assets/_Project/`, hay que hacer una validacion corta en Unity.

## Objetivo

Confirmar que:

- Unity importe los scripts sin errores de compilacion
- los componentes nuevos aparezcan en el Inspector
- podamos seguir al montaje de escenas sin deuda tecnica oculta

## Pasos

1. Abre Unity con el proyecto y asegurate de no estar en `Play Mode`.
2. Espera a que termine cualquier recompilacion o importacion.
3. Abre la pestaña `Console`.
4. Confirma que no haya errores rojos de compilacion.
5. En la `Hierarchy`, crea temporalmente un `Empty GameObject`.
6. Con ese objeto seleccionado, en `Inspector` usa `Add Component`.
7. Busca y verifica que aparezcan estos componentes:
   - `SceneFlowController`
   - `FadeOverlayController`
   - `DialogueController`
   - `ChoiceController`
   - `TrustController`
   - `PhoneOverlayController`
   - `Chapter01Director`
8. Si aparecen, elimina ese `Empty GameObject` temporal.

## Resultado esperado

Si todo sale bien:

- no hay errores en `Console`
- los scripts aparecen como componentes agregables

## Si algo falla

Si Unity marca errores, lo util es compartir:

- el texto exacto del error rojo
- el nombre del archivo que marca Unity

Con eso normalmente se corrige rapido.
