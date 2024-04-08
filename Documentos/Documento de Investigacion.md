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

1. **¿El jugador tarda demasiado tiempo en completar cada uno de los dos niveles?**

Para responder a esta pregunta, se utilizarán percentiles. Se espera que el percentil 85 no corresponda a más de 3 minutos de partida en el nivel 1, y que en el nivel2, el percentil 70 no corresponda a más de 7 minutos. Calcularemos el tiempo que se tarda en completar cada uno de los niveles y el número de veces que se ha completado cada nivel

2. **¿El jugador usa demasiados movimientos de salas en cada uno de los dos niveles?**

Para contestar esta pregunta, se utilizará la moda para determinar la cantidad de movimientos más repetida necesarios para pasar cada nivel. Se agruparán los valores en intervalos de 5 movimientos, como [0,4], [5,9], hasta [50,54]. Se espera que en el nivel 1 la moda se encuentre en el intervalo [5,9], mientras que en el nivel 2 se espera que esté en el intervalo [15,19].

3. **¿El jugador falla significativamente más golpes en el nivel 2 que en el nivel 1?**

Se analizará la media de los porcentajes de acierto de golpes de los usuarios a los enemigos en los distintos niveles. Se espera que la media total de aciertos entre los dos niveles sea entre un 70% y un 80%, y que no haya una variación superior al 10% entre los niveles. Para calcularlo se tendrá en cuenta la cantidad de veces que el usuario ataca y las veces que un enemigo recibe daño.

4. **¿Es coherente la variación del daño provocado por cada enemigo a lo largo de los dos niveles?**

Se utilizará la moda para determinar el enemigo que más daño hace en cada nivel. Se espera que la distribución, cada 100 golpes, sea de este estilo:

* Robot: 45%
* Alcantarilla: 25%
* Sierra: 20%
* Araña: 10%

Con un margen de error del 5%.
## Eventos
Aqui vamos a describir todos los eventos que va a ejecutar nuestro sistema de telemetría ya sean de un carácter general o específicos del juego, empecemos con los eventos generales:
* **Evento base:** Se trata de la clase de la que heredaran todos los eventos que se hagan, este evento tiene los siguientes campos:
	- Hora del evento
	- Id del evento
	- Id de sesión
	- Id del usuario
* **Inicio de sesion:** Es el primer evento que se lanza al iniciar el tracker, será el encargado de crear la id de sesion.
* **Fin de sesion:** Evento que se lanza al cerrar el tracker.
* **Inicio de partida:** Se lanza al darle a play
* **Fin de partida** Se lanza al salir de la partida.
* **Inicio de nivel**, se lanza al empezar un nivel. Tendrá los siguientes parámetros:
  * Id del nivel
* **Fin de nivel**, se lanza al terminar el nivel o porque se supera o porque se pierde.
  * Id del nivel
  * Causa de fin de nivel: ganar/perder/salir/otro
* **Pausa:** el jugador pone el juego en pausa
* **Reanudar:** El jugador vuelve al juego desde la pausa
* **Evento de Juego:** Se trata de un evento que servira de base para todos los eventos del juego
### Eventos del juego
* **Evento Fin de nivel** Este evento se lanza cada vez que se finaliza un nivel, contiene la siguiente información:
* **AttackEvent** Este evento se lanza cada vez que el jugador lanza un ataque, contiene el siguiente parámetro:
  * posicion del jugador
* **EnemyReceiveDamageEvent** Este evento se lanza cada vez que un enemigo recibe daño:
  * Posicion del enemigo
* **PlayerReceiveDamageEvent** Este evento se lanza cada vez que un enemigo hace daño al jugador:
  * Tipo de enemigo
  * Posicion jugador
  * Posicion enemigo
* **PlayerDeadEvent** Este evento se lanza cuando el jugador muere:
  * posicion del jugador
* **RoomMoveEvent** Este evento se lanza cada vez que el jugador desplaza una sala.
