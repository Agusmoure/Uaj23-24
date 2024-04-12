# Diseño de evaluación - Grupo 04
En este documento se recoge el objetivo que se va a evaluar, las métricas que se van a utilizar para ello, y los eventos que se van a utilizar para poder recoger estas métricas.

## Objetivo
El objetivo de estas pruebas será determinar si la dificultad de cada nivel de Steam Mazehem es la adecuada. Para ello, se han propuesto las siguientes preguntas de investigación:

## Preguntas de investigación:

* ¿El jugador tarda demasiado tiempo en completar cada uno de los dos niveles? 
* ¿El jugador usa demasiados movimientos de salas en cada uno de los dos niveles? 
* ¿El jugador falla significativamente más golpes en el nivel 2 que en el nivel 1?
* ¿Es coherente la variación del daño provocado por cada enemigo a lo largo de los dos niveles?

## Métricas
Para responder a las preguntas de investigación previamente formuladas, se van a utilizar las siguientes métricas:

1. **Métrica 1: Tiempo para completar el nivel 1**

Se analizará la distribución del tiempo que los jugadores toman para completar el nivel 1, utilizando percentiles para identificar si hay problemas de tiempo excesivo. También se examinará el número de veces que se ha completado cada nivel.

2. **Métrica 2: Cantidad de movimientos por nivel**

Se examinará el número de movimientos que los jugadores emplean para completar cada nivel. Los valores se agruparán en intervalos de 5 movimientos, como [0,4], [5,9], hasta [50,54]. La moda de esta distribución nos indicará si los niveles requieren de muchos movimientos, adaptándose a la dificultad prevista. 

3. **Métrica 3: Precisión de golpes a los enemigos**

Se analizará la media de los porcentajes de acierto de golpes de los usuarios a los enemigos en los distintos niveles. Para calcularlo se tendrá en cuenta la cantidad de veces que el usuario ataca y las veces que un enemigo recibe daño.

4. **Métrica 4: Daño infligido por los enemigos**

Se evaluará qué enemigo inflige mayor daño de manera consistente, identificando desbalances en el daño que cada tipo de enemigo debería causar. Se utilizará la moda para determinar el enemigo que más daño hace en cada nivel. Se espera que la distribución, cada 100 golpes, sea de este estilo:

* Robot: 45%
* Alcantarilla: 25%
* Sierra: 20%
* Araña: 10%

Con un margen de error del 5%.
## Eventos
Aquí vamos a describir todos los eventos que va a ejecutar nuestro sistema de telemetría ya sean de un carácter general o específicos del juego. 

### Eventos Generales
* **BaseEvent:** Se trata de la clase de la que heredaran todos los eventos que se hagan, este evento tiene los siguientes campos:
	- Hora del evento
	- ID del evento
	- ID de sesión
	- ID del usuario
* **SessionStartEvent:** Es el primer evento que se lanza al iniciar el tracker, será el encargado de crear la ID de sesión.
* **SessionEndEvent:** Evento que se lanza al cerrar el tracker.
* **GameStartEvent:** Se lanza al darle a play.
* **GameEndEvent:** Se lanza al salir de la partida.
* **LevelStartEvent:** Se lanza al empezar un nivel. Tendrá el siguiente parámetro:
  * ID del nivel
* **LevelEndEvent:** Se lanza al terminar el nivel o porque se supera o porque se pierde.
  * Id del nivel
  * Causa de fin de nivel: ganar/perder/salir/otro
* **PauseEvent:** El jugador pone el juego en pausa.
* **ResumeEvent:** El jugador vuelve al juego desde la pausa.
* **GameBaseEvent:** Se trata de un evento que servirá de base para todos los eventos del juego.

### Eventos Específicos del Juego
* **AttackEvent:** Este evento se lanza cada vez que el jugador lanza un ataque.
* **EnemyReceiveDamageEvent:** Este evento se lanza cada vez que un enemigo recibe daño:
  * Tipo de enemigo
* **PlayerReceiveDamageEvent:** Este evento se lanza cada vez que un enemigo hace daño al jugador:
  * Tipo de enemigo
* **PlayerDeadEvent:** Este evento se lanza cuando el jugador muere:
  * Posición del jugador
* **RoomMoveEvent:** Este evento se lanza cada vez que el jugador desplaza una sala.
