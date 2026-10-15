# Ping Pong Unity

Juego de Pong en 2D desarrollado en Unity. Dos jugadores controlan paletas a cada
lado de la pantalla e intentan anotar más puntos que el rival antes de que termine
el tiempo de una ronda.

## Características

- Pantalla de inicio con el título y un botón para comenzar.
- Partida por tiempo: cuenta regresiva de 1 minuto por ronda.
- Marcador independiente para cada jugador.
- Pantalla de GAME OVER con el ganador, el marcador final y opciones para reiniciar
  o salir.
- Sistema de pausa y confirmación antes de salir del juego.
- Efecto de rastro (partículas) en la pelota y diseño visual basado en el pack
  *Simple Ping Pong Assets*.

## Controles

| Jugador | Subir | Bajar |
|---------|-------|-------|
| Jugador 1 (izquierda) | `W` | `S` |
| Jugador 2 (derecha) | `↑` | `↓` |

### Atajos de teclado

| Tecla | Acción |
|-------|--------|
| `P` | Pausar / reanudar |
| `R` | Reiniciar la ronda |
| `Esc` | Salir del juego (pide confirmación) |

## Cómo jugar

1. Al iniciar aparece la pantalla de inicio: pulsa **INICIAR**.
2. Mueve tu paleta para evitar que la pelota pase y anota en el lado contrario.
3. Cuando el tiempo llega a `0:00` se muestra la pantalla de **GAME OVER** con el
   ganador. Pulsa **NUEVA RONDA** (o `R`) para jugar otra vez, o **SALIR** para cerrar.

## Estructura de scripts

- `Assets/GameManager.cs` — controla el estado del juego: marcador, temporizador,
  inicio, pausa, game over, reinicio y salida.
- `Assets/BallController.cs` — movimiento, rebotes y detección de goles de la pelota.
- `Assets/PaddleController.cs` — movimiento y límites de las paletas.
- `Assets/BallTrail.cs` y `Assets/GhostFade.cs` — efecto de rastro de la pelota.

## Cómo generar la aplicación (.exe)

1. En Unity, abre **File → Build Profiles** y selecciona el perfil **Windows**.
2. En **Scene List**, confirma que `SampleScene` esté añadida y marcada.
3. (Opcional) En **Player Settings** ajusta el nombre y la resolución.
4. Pulsa **Build** y elige una carpeta vacía de destino.
5. Para distribuir el juego, comprime la carpeta completa del build (el `.exe`
   necesita la carpeta `_Data` que lo acompaña).

## Requisitos

- Unity 6.6 (6000.6.5f1) o compatible.
- Render Pipeline: Universal Render Pipeline (URP).

## Créditos

- Arte: *Simple Ping Pong Assets* de **Esoe B.Studios**
  (https://myebstudios.itch.io/simple-ping-pong-assets).
- Fuente: **Teko** (Google Fonts).
