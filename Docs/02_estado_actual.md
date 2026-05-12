# Estado Actual del Proyecto

## Resumen rapido

- Version de Unity detectada: `6000.4.4f1`
- Rama actual de Git: `feature/fase1`
- Escena principal actual: `Assets/Scenes/CH1_Cafeteria.unity`
- El proyecto actual es un prototipo visual, no un capitulo completo jugable

## Lo que ya existe

- Fondo de menu principal
- Fondo de cuarto
- Fondo de cafeteria
- Caja de dialogo basica
- Botones de menu y `Next`
- Musica y algunos SFX
- Scripts base para cambiar paneles y escribir texto letra por letra

## Lo que hoy esta incompleto

- `New Game` no dispara el flujo completo del capitulo 1
- El boton `Next` actual recibe hover pero no tiene logica funcional completa
- La escena actual mezcla menu, cuarto y cafeteria en un solo lugar
- No existe flujo de telefono
- No existe tutorial funcional del indicador de confianza
- No existen elecciones ni cambios de confianza
- No existe secuencia del pasillo / escaleras / escuela
- No existe cierre de capitulo

## Gaps contra el documento de tu amiga

- Intro de capitulo con negro > guardando > titulo > texto interno
- Efecto de "abrir ojos" para entrar al cuarto
- Overlay de telefono con mensajes de Seongsu
- Exploracion minima del cuarto
- Encuentro inicial con Seongsu y Jeongho
- Tutorial del sistema de confianza
- Decision social 1
- Transicion al pasillo / escuela
- Decision introspectiva 2
- Escena de cafeteria completa
- Decision final del capitulo
- Pantalla de "capitulo terminado"

## Conclusion tecnica

El Unity actual cubre solo una fraccion del storyboard. Lo correcto no es seguir parchando `CH1_Cafeteria` a ciegas, sino reconstruir el flujo del capitulo 1 con una estructura mas clara.

## Decision recomendada

Para fase 1:

- separar `MainMenu` y `Chapter01`
- mantener el alcance acotado al capitulo 1
- dejar `save/load/settings` completos para despues
- construir primero el flujo jugable de principio a fin
