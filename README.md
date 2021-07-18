### Play-History
  This plugin shows your last played songs information, using a custom stream overlay with a WebSocket. You can show this overlay as a browser in your Obs. 

## Dependences
- WebSocket-Sharp: ^1.0.4
- Bs Utils: ^1.10.0

## Installation
  1. Install all dependencies on ModAssistant.
  2. Extract the zip into your Beat Saber directory.
  3. Use the Play_History_Overlay.html in the release or Create a Html to receive informations about your play. 

## Parameters
  **Only works in Play_History_Overlay.Html**
  Using some parameters, you can change the style of the page. To use this it's required put '?' after the address in your Browser and to many parameters you have to use '&',     
  for example: '?scale=0.7&background=3'. 
- scale: Change the page's scale. (a decimal number that goes from 0 to 1, for example: 'scale='0.8')
- limit: The limit of songs on Html. (by default is 5, for example: 'limit=3')
- mode: Change how the plays will be shown. (by default is Vertical, for example: 'mode=Horizontal')
- color: Change the letter colors. (you can use the color's name or a HEX value, by default is White, for example: 'color=green')
- background: Change the preset background. (from 1 to 10, by default is 1, for example: 'background=5')
- op: Change the background's opacity. (from 0 to 100, by default is 100, for example: 'op=80')
- scrollSpeed: Change the Scroll's Speed of the Song's Name (only used if the Song's name is too long). (from 0 to 100, by default is 90, for example: 'scrollSpeed=80')

## How it works
  A WebSocket is created on the address ws://127.0.0.1:7890/Echo through the plugin and when the music ends, your informations will be sended. For Example if a map is finished     this informations will be sent in JSON:
- SongName (String): The song's Name
- SongAuthorName (String): The song's author name
- LevelAuthorName (String): The level's author name
- LevelHash (String): The level's hash
- Rank (String): the play's rank
- Duration (Float): The level's duration
- Bpm (Float): The level's bpm
- Miss (Int): The play's miss
- ModifiedScore (Int): The play's score
- MaxCombo (Int): the play's max combo
- FullCombo (Boolean): if it's full combo in the play
- Acc (Double): the play's acc
- LevelEndStateType (Int): if the map was cleared(1) or failed(2).

## Html Examples
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/4.png?raw=true)
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/5.gif?raw=true)
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/6.gif?raw=true)
![img](https://github.com/PotetoShiro/Play-History/blob/main/Examples/7.gif?raw=true)
  
## Questions
  If you have any questions, call me in discord: ඞ Shiro ඞ#2985.
