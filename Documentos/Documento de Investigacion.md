# Diseño de evaluación- Grupo 04
En este documento se recoge el objetivo que se va a evaluar, las métricas que se van a utilizar para ello, y los eventos que se van a utilizar para poder recoger estas métricas.

## Objetivos
El objetivo de estas pruebas será determinar si la dificultad de Steam Mazehem es la esperada. Para ello, se han propuesto las siguientes preguntas de investigación:
### Preguntas de investigación:

* ¿El jugador tarda demasiado tiempo en completar el nivel 1? 
* ¿El jugador usa demasiados movimientos de salas en los niveles? 
* ¿El jugador es capaz de acertar los golpes a los enemigos?
* ¿Cómo varía el daño provocado por cada enemigo a lo largo de la partida?

## Métricas
Para responder a las preguntas de investigación previamente formuladas, se van a utilizar las siguientes métricas:

1. **¿El jugador tarda demasiado tiempo en completar el nivel 1?**

Para responder a esta pregunta, se utilizarán los percentiles. Se espera que el percentil 85 no corresponda a más de 5 minutos de partida en el nivel 1.

2. **¿El jugador usa demasiados movimientos de salas en los niveles?**

Para contestar esta pregunta, se utilizará la moda para determinar la cantidad de movimientos más repetida necesarios para pasar cada nivel. Se agruparán los valores en intervalos de 5, como [0,4], [5,9], hasta [50,54]. Se espera que en el nivel 1 la moda se encuentre en el intervalo [5,9], mientras que en el nivel 2 se espera que esté en el intervalo [15,19].

3. **¿El jugador es capaz de acertar los golpes a los enemigos?**

Se analizará la media de los porcentajes de acierto de golpes entre los usuarios. Se espera que la media de aciertos sea entre un 70% y un 80%.

4. **¿Cómo varía el daño provocado por cada enemigo a lo largo de la partida?**

Se utilizará la moda para determinar el enemigo que más daño hace en las partidas. Se espera que el orden sea: Sierra, Alcantarillas, Araña, Robot. Suponiendo que el robot sea el que más se repite en 100 golpes, se espera que la distribución sea de este estilo:

* Robot:40
* Araña: 30
* Alcantarilla:20
* Sierra:10
  
## Eventos
Aqui vamos a describir todos los eventos que va ejecutar nuestro sistema de telemetría ya sean de un carácter general o específicos del juego, empecemos con los eventos generales:
* **Evento base:** Se trata de la clase de la que heredaran todos los eventos que se hagan, este evento tiene los siguientes campos:
	- Hora del evento
	- Id del evento
  - Id de sesión
  - Id del usuario
* **Iniciar el sistema:** Es el primer evento que se debe recoger porque marca el inicio del trackeo de datos, tiene como parámetro el juego a trackear y el id de usuario (ambos se definen en el core del tracker).
* **Finalizar sistema:** Sera el ultimo evento de la sesión no tendrá parámetros opcionales
* **Inicio de sesion:** Se lanza la primera vez que se lanza el juego sera el encargado de crear la id de sesion
* **Fin de sesion:** se lanza al cerrar el juego
* **Inicio de partida:** Se lanza al darle a play
* **Fin de partida** Se lanza al salir de la partida.
* **Inicio de nivel**, se lanza al empezar un nivel. Tendrá los siguientes parámetros:
 - Id del nivel
* **Fin de nivel**, se lanza al terminar el nivel o porque se supera o porque se pierde.
 - Id del nivel
 - Causa de fin de nivel: ganar/perder
 - Vida restante del jugador al finalizar
* **Pausa:** el jugador pone el juego en pausa
* **Despausa:** el jugador sale de la pausa
* **Evento de Juego:** Se trata de un evento que servira de base para todos los eventos del juego
### Eventos del juego
* **Evento de ataque:** Evento de juego que se envía cuando el jugador realiza un ataque y guarda información relevante: __No me convence__
  - Lista de todos los objetos cercanos, a menos de 2m de distancia
  - Lista de objetos que colisionan con el ataque y sus posiciones
  - Posición del jugador
* **Evento Fin de nivel** Este evento se lanza cada vez que se finaliza un nivel, contiene la siguiente información:
  * Tiempo transcurrido en segundos desde inicio de nivel hasta que se envia este evento
  * Nivel en el que se encuentra
  * Cantidad de movimientos de sala
* **Evento de ataque** Este evento se lanza cada vez que el jugador lanza un ataque de parametros contiene:
  * posicion del jugador
* **Evento daño a enemigo** Este evento se lanza cada vez que un enemigo recibe daño:
  * Posicion del enemigo
* **Evento daño a jugador** Este evento se lanza cada vez que un enemigo ataca al jugador:
  * Tipo de enemigo
  * Posicion jugador
  * Posicion enemigo
  * Jugador sigue vivo (true o false)
Después tendremos otros eventos más específicos planteados para Steam Mazehem y más concretamente para las preguntas de investigación planteadas previamente __No me convence__
