# Diseño de evaluación
En este documento se recoge el objetivo que se va a evaluar, las métricas que se van a utilizar para ello, los eventos que se van a utilizar para poder recoger estas métricas,...

## Objetivos
El objetivo de estas pruebas será determinar si la dificultad de Steam Mazehem es el esperado, para ello se han propuesto las siguientes preguntas de investigación:
### Preguntas de investigación:

* ¿El jugador tarda demasiado en completar el nivel 1? 
* ¿El jugador usa demasiados movimientos de salas en los niveles? 
* ¿El jugador es capaz de acertar los golpes a los enemigos?
* ¿Todos los enemigos hacen el mismo daño?

## Métricas
Para responder a las preguntas de investigación previamente hechas se van a utilizar las siguientes métricas:
1. **¿El jugador tarda demasiado en completar el nivel 1?**

Para poder responder a esta pregunta se usarán los percentiles para ello se espera que el percentil 85 no corresponda a más de 5 minutos de partida en el nivel 1

2. **¿El jugador usa demasiados movimientos de salas en los niveles?**

Para contestar esta pregunta de investigación usaremos la moda, es decir cual es la cantidad de movimientos más repetida que son necesarios para pasarse el nivel, para ello vamos a agrupar los valores en grupos de 5 es decir de [0,4], [5,9],....[50,54].

Se espera que en el nivel 1 la moda se encuentre en el intervalo [5,9] mientras que en el nivel 2 se espera que esté en el intervalo [15,19]

3. **¿El jugador es capaz de acertar los golpes a los enemigos?**

Con la intención de responder a esta pregunta se va a analizar la media de los porcentaje de acierto de golpes entre los usuarios.

Se espera que la media de aciertos sea de entre un 70% y un 80%

4. **¿Todos los enemigos hacen el mismo daño?**

Para responder la última pregunta usaremos la moda, ya que se trata del valor más repetido cosa que nos interesa para saber cual es el enemigo que mas daño hace en las partidas,

Se espera que el orden sea:
Sierra , Alcantarillas, Araña, Robot. suponiendo que el robot sea el que mas se repita en 100 golpes se espera que la distribución sea de este estilo:
* Robot:40
* Araña: 30
* Alcantarilla:20
* Sierra:10 
## Eventos
Aqui vamos a describir todos los eventos que va ejecutar nuestro sistema de telemetría ya sean de un carácter general o específicos del juego, empecemos con los eventos generales:
* **Evento base:** Se trata de la clase de la que heredaran todos los eventos que se hagan, este evento tiene los siguientes campos:
	- hora del evento
	- Id del evento
* **Iniciar el sistema:** Es el primer evento que se debe recoger porque marca el inicio del trackeo de datos, tiene como parámetro el juego a trackear y el id de usuario (ambos se definen en el core del tracker).
* **Finalizar sistema:** Sera el ultimo evento de la sesión no tendrá parámetros opcionales
* **Inicio de sesion:** Se lanza la primera vez que se lanza el juego sera el encargado de crear la id de sesion
* **Fin de sesion:** se lanza al cerrar el juego
* **Inicio de partida:** Se lanza al darle a play
* **Fin de partida** Se lanza al salir de la partida
* **Inicio de nivel**, se lanza al empezar un nivel
* **Fin de nivel**, se lanza al terminar el nivel o porque se supera o porque se pierde
* **Pausa:** el jugador pone el juego en pausa
* **Despausa:** el jugador sale de la pausa
* **Evento de Juego:** Se trata de un evento que servira de base para todos los eventos del juego tendran como parametros comunes:
	- Id de session
	- Id del usuario

	
Después tendremos otros eventos más específicos planteados para Steam Mazehem y más concretamente para las preguntas de investigación planteadas previamente
