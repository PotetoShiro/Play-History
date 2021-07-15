### Play-History
  This plugin expose your last game information, using a custom stream overlay with a WebSocket you can show this informations in your Obs. 

## Dependences
- WebSocket-Sharp: ^1.0.4
- Bs Utils: ^1.10.0

## Installation
  1. Install all dependencies on ModAssistant.
  2. Extract the zip into your Beat Saber directory.
  3. Download or Create a Html to receive informations about your play. 

## Parameters
  Using some parameters, you can change the style of the page, to use this it's required put '?' after the address in your Browser and to many parameters you should use '&',     
  for example: '?scale=0.7&background=3'. 
- scale: Change the page's scale. (a float number that goes from 0 to 1, for example: 'scale='0.8')
- limit: The limit of the musics on Html. (by default is 5, for example: 'limit=3')
- mode: Change how the plays will be shown. (by default is Vertical, for example: 'mode=Horizontal')
- color: Change the letter colors. (you can use the color's name or a HEX value, by default is White, for example: 'color=green')
- background: Change the preset background. (from 1 to 10, by default is 1, for example: 'background=5')
- op: Change the background's opacity. (from 0 to 100, by default is 100, for example: 'op=80')
- scroll: Scroll the name if is extensive. (true or false, by default is true, for example: 'scroll=false')
- scrollSpeed: Change the Scroll's Speed. (from 0 to 100, by default is 90, for example: 'scrollSpeed=80')
- debug: It's will show you the console log. (true or false, by default is false, for example: 'debug=true')

## How it works
  A WebSocket is created on the address ws://127.0.0.1:7890/Echo through the plugin and when the music ends, your informations will be sended.

## Html Examples
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/1.png?raw=true)
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/2.png?raw=true)
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/3.png?raw=true)
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/4.png?raw=true)
  
## Doubt
  If you have any doubt, call me in discord: ඞ Shiro ඞ#2985.
