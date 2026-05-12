# Glosario Unity Basico

Este glosario esta pensado para este proyecto, no como teoria general.

## Conceptos clave

- `Scene`
  Un escenario completo del juego. Puede contener camara, UI, fondos, personajes, audio y scripts.
  Hoy el proyecto solo tiene una escena jugable principal: `Assets/Scenes/CH1_Cafeteria.unity`.

- `GameObject`
  La unidad base de Unity. Un boton, un personaje, una camara y un texto son `GameObject`.

- `Component`
  La capacidad que se le pega a un `GameObject`.
  Ejemplos comunes en este proyecto: `Image`, `Button`, `AudioSource`, `TextMeshProUGUI`, scripts C#.

- `Canvas`
  El contenedor principal de UI. Todo lo visual de menu, dialogos, overlays y botones vive aqui.

- `Panel`
  Un grupo de UI dentro de un `Canvas`.
  En este proyecto actual se usan paneles para encender y apagar pantallas como `Panel_TitlePage`, `Panel_CuartoJihuun` y `Panel_Cafeteria`.

- `Script`
  Codigo C# que da comportamiento al juego.
  Ejemplos actuales: `GameManager`, `TextCreator`, `Scene01Events`.

- `Prefab`
  Una plantilla reutilizable de Unity.
  Si un telefono, una caja de dialogo o un personaje se van a reusar mucho, conviene convertirlos en `Prefab`.

- `Asset`
  Cualquier archivo que Unity usa: imagenes, audio, fuentes, escenas, animaciones, materiales y scripts.

- `Inspector`
  El panel donde Unity muestra y permite editar componentes, referencias y propiedades del objeto seleccionado.

- `Build Settings`
  La lista de escenas que el juego puede cargar al ejecutar un build.

- `TMP`
  `TextMesh Pro`. Es el sistema de texto moderno que ya usa este proyecto.

- `AudioSource`
  El componente que reproduce un audio en escena.

## Regla critica de Unity

Unity guarda la identidad de cada asset en su archivo `.meta`.

- Archivo real: `mi_imagen.png`
- Identidad Unity: `mi_imagen.png.meta`
- Referencias en escenas y prefabs: apuntan al `GUID` del `.meta`

Si se borra o regenera mal un `.meta`, se pueden romper referencias aunque el PNG siga existiendo.

## Como pensar este proyecto

La forma mas sana de verlo es asi:

- `MainMenu`
  Pantalla inicial del juego.
- `Chapter01`
  Flujo jugable del primer capitulo.
- `UI overlays`
  Telefono, tutorial de confianza, elecciones, confirmacion de quit.
- `Dialogue system`
  Caja de texto, nombre, retratos, `Next`, pensamiento interno y elecciones.

## Idea practica

Para aprender Unity sin ahogarse, primero hay que dominar esto:

1. `Scene`
2. `GameObject`
3. `Component`
4. `Canvas`
5. `Button`
6. `Script` conectado desde `Inspector`

Con eso ya puedes leer la mayor parte de este proyecto sin sentir que todo es magia negra.
