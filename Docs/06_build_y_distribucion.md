# Build y distribución

Este documento resume el proceso de generación de build y distribución del proyecto.

## Estado actual

El proyecto ya fue compilado con éxito como una build jugable de Windows.

## Escenas usadas en build

Orden recomendado en `Build Settings`:

1. `MainMenu`
2. `Chapter01`

## Plataforma

Configuración principal utilizada:

- `Windows, Mac, Linux`
- target de Windows
- arquitectura `x86_64`

## Salida de build

La build debe generarse fuera de `Assets/`, por ejemplo:

```text
Builds/Windows/
```

o

```text
Builds/EntreTuSilencio_Windows/
```

## Distribución

Para compartir el juego con otras personas no debe enviarse únicamente el `.exe`. Debe distribuirse la carpeta completa generada por Unity, comprimida como `.zip` si se desea compartir de forma simple.

Contenido típico:

- ejecutable `.exe`
- carpeta `*_Data`
- librerías y archivos de soporte de Unity

## Validaciones recomendadas antes de compartir

- verificar que `MainMenu` se vea correctamente escalado;
- confirmar que la música del menú se reproduce;
- recorrer `Chapter01` de principio a fin;
- validar decisiones, audio, popup final y regreso al menú;
- revisar la consola de Unity antes del build final.

## Reglas de repositorio

- las builds no deben usarse como fuente de verdad del proyecto;
- el repositorio debe almacenar código, escenas, assets y documentación;
- las builds pueden compartirse por separado para pruebas o releases internas.
