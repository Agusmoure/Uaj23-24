# Diseño de evaluación - Grupo 04
En este documento se recoge el objetivo que se va a evaluar, las métricas que se van a utilizar para ello, y los eventos que se van a utilizar para poder recoger estas métricas.

## Objetivo
El objetivo de estas pruebas será determinar si la dificultad de cada nivel de Steam Mazehem es la adecuada. Para ello, se han propuesto las siguientes preguntas de investigación:

## Preguntas de investigación:

* ¿El jugador tarda demasiado tiempo en completar cada uno de los dos niveles? 
* ¿El jugador usa demasiados movimientos de salas en cada uno de los dos niveles? 
* ¿El jugador falla significativamente más ataques en el nivel 2 que en el nivel 1?
* ¿Es coherente la variación del daño provocado por cada elemento dañino a lo largo de los dos niveles?

## Métricas
Para responder a las preguntas de investigación previamente formuladas, se van a utilizar las siguientes métricas:

1. **Métrica 1: Tiempo de finalización de nivel**

Se estudiará la distribución del tiempo que se tarda en completar cada uno de los niveles. Apoyandonos para ello en el tiempo medio (media) y en la mediana del tiempo que se tarda en completar un nivel, no se tendrá en cuenta el tiempo que el juego este pausado. Para los cálculos solo se tendrán en cuenta los niveles que se han completado exitosamente.

2. **Métrica 2: Cantidad de movimientos por nivel**

Se evaluará la cantidad de movimientos necesarios para superar cada nivel. Utilizaremos la moda para identificar patrones en la distribución de movimientos por nivel, agrupándolos en intervalos de 5 movimientos, como [0,4], [5,9], etc. Para los cálculos solo se tendrán en cuenta los niveles que se han completado exitosamente.

3. **Métrica 3: Precisión de golpes a los enemigos**

Se estudiará la media de los porcentajes de acierto de golpes de los usuarios a los enemigos en los distintos niveles. Para calcularlo se tendrá en cuenta la cantidad de veces que el usuario ataca y las veces que un enemigo recibe daño.

4. **Métrica 4: Impactos de los elementos dañinos**

Se estudiará la distribución del número de veces que cada elemento dañino(enemigos, sierra, alcantarilla) impacta al jugador. Se calculará la media de impactos de cada elemento dañino por nivel, comparando el número de impactos de cada elemento con el total de impactos de elementos dañinos en ese nivel.
## Eventos
Aquí vamos a describir todos los eventos que va a ejecutar nuestro sistema de telemetría ya sean de un carácter general o específicos del juego. 

### Eventos Generales
* **BaseEvent:** Se trata de la clase de la que heredaran todos los eventos que se hagan, este evento tiene los siguientes campos:
	- Hora del evento
	- ID del evento
	- ID de sesión
	- ID del usuario
  - Tipo de evento
* **SessionStartEvent:** Es el primer evento que se lanza al iniciar el tracker, será el encargado de crear la ID de sesión.
* **SessionEndEvent:** Evento que se lanza al cerrar el tracker.
* **GameStartEvent:** Se lanza al darle a play.
* **GameEndEvent:** Se lanza al salir de la partida.
* **LevelStartEvent:** Se lanza al empezar un nivel. Tendrá el siguiente parámetro:
  * ID del nivel
* **LevelEndEvent:** Se lanza al terminar el nivel o porque se supera o porque se pierde.
  * ID del nivel
  * Causa de fin de nivel: ganar/perder/salir
* **PauseEvent:** El jugador pone el juego en pausa.
* **ResumeEvent:** El jugador vuelve al juego desde la pausa.
* **GameBaseEvent:** Se trata de un evento que servirá de base para todos los eventos del juego.
  - ID del nivel
  - ID de la partida

### Eventos Específicos del Juego
* **AttackEvent:** Este evento se lanza cada vez que el jugador lanza un ataque.
* **EnemyReceiveDamageEvent:** Este evento se lanza cada vez que un enemigo recibe daño:
  * Tipo de enemigo
* **PlayerReceiveDamageEvent:** Este evento se lanza cada vez que un enemigo hace daño al jugador:
  * Tipo de enemigo
* **RoomMoveEvent:** Este evento se lanza cada vez que el jugador desplaza una sala.

