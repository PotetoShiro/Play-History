### Play-History
  Um plugin que cria um WebSocket Server e ao terminar uma música, irá enviar informações da jogada através do WebSocket.

## Depêndencias
-WebSocket-Sharp: ^1.0.4
-Bs Utils: ^1.10.0

## Instalação
  1. Instale as depêndencias no ModAssistant.
  2. Extraia o arquivo Zip na pasta do seu jogo.
  3. Baixe ou crie o Html que irá receber as informações da jogada.

## Parâmetros
  Utilizando-os é possível mudar algumas coisas na visualização da página, para utilizar é necessário colocar '?' no endereço da página e após isso os argumentos, sendo separados   por '&', por exemplo: '?scale=0.7&background=3'.
- scale: Muda a escala da página, podendo ficar menor ou maior. (0 a 1, como por exemplo 0.8, por padrão é 1)
- limit: O limite de músicas que pode aparecer. (por padrão é 5)
- mode: Muda o jeito que a musica é mostrada, podendo ser Horizontal ou Vertical. (por padrão é Vertical)
- color: Muda a cor das letras. (pode utilizar o nome da cor em ingles ou em Hex, por padrão é branco)
- background: Muda o fundo do elemento do mapa. (1 a 10, por padrão é 1)
- op: Muda a opacidade do background. (0 a 100, por padrão é 100)
- scroll: Faz com que o nome da música passe de um lado para o outro se for muito grande. (true ou false, por padrão é true)
- scrollSpeed: Modifica a velocidade em que o nome da música é mostrado (valor de 0 a 100,por padrão é 90)
- debug: Irá mostrar as informações recebidas da música. (true ou false, por padrão é false)

## Como Funciona
  Um WebSocket é criado no endereço ws://127.0.0.1:7890/Echo através do Plugin e ao terminar a música será enviado as informaçÕes de sua jogada como a pontuação, accuracy, miss,     duração da música, nome da música, rank e dificuldade da música.
  
## Créditos
- Luke por me ajudar a fazer o Html e suas opiniões.

## Dúvidas
  Se houver alguma dúvida me chame no discord: ඞ Shiro ඞ#2985.
