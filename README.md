# ConTroll
A streaming/gaming companion utility

The initial release of this tool is primarily aimed to apply screen distortions while playing Zelda A Link to the Past Randomizer. The long term plans for this tool go far beyond that towards stream/chat management.

## Current Features
- Connects to OBS Websocket
- Connects to SNES Devices thru SNI (no QUsb2Snes support yet)
- Enables 'Social Distortion' (aka Mirror/Chaos Mode) - Applies screen distortions on a timed-interval

## Requirements
- Windows (for now, hopefully I can make this cross-platform in the future)
- [SNI](https://github.com/alttpo/sni)
  - Tested with SD2SNES and Snes9x-rr (might work for others)
- OBS v27.x or later (even if you dont stream, this is what does the screen flipping)
- A Capture Card/Method capable of zero-delay
  - This is an essential, see `Usage` section for more details
- [OBS StreamFX plugin](https://github.com/Xaymar/obs-StreamFX/wiki) (this may already come included in your version of OBS)
- [OBS Websocket plugin](https://obsproject.com/forum/resources/obs-websocket-remote-control-obs-studio-from-websockets.466/) (this comes included in OBS v28.x)
- [OBS Move Transition plugin](https://obsproject.com/forum/resources/move-transition.913/)
- An [OWR Branch](https://github.com/codemann8/ALttPDoorRandomizer/tree/OverworldShuffleDev) generated seed (there is game code that is required for this to work, only available on OWR)
  - Normally, I advise people to use the `OverworldShuffle` branch, but being this is very new, only the `OverworldShuffleDev` branch has the features to make this work

## Installation
- See Requirements above and ensure you have them installed
- Head to the Releases page and grab the .zip file, extract the contents to a folder of your choosing.
- Run ConTroll.exe

## Usage
I will explain more in the future, but the utility should be mostly self explanatory.
- If you haven't already, you will need to set up an OBS Websocket password, this is done within OBS.
- You'll need to verify the connection information is correct to ensure that OBS and SNI can get connected to the utility. The `Connection` tab is where you modify these connection settings.
- After OBS is connected (green circle), you'll need to select the Game Capture Source that is used for displaying your game. This is set in the `Config` tab. Ensure that there is a selected Game Device in the dropdown.
- In OBS, find your Game Capture Source, right-click on it and select `Windowed Projector (Source)`.
  - This opens a window, showing your game screen. We will be playing the game off of this view, putting your emulator/console out of sight.
- Load up the game, it is important to be in-game (title, intro, and file select screen are fine, just have the ROM loaded) before you start.
- Once everything is connected, click `Social Distortion`.
- Have fun!
- There are additional options available in the `Config` tab. You can change the time interval in between distortions. You can also pick and choose which distortions can get applied.

Keep in mind, this is very new, there are bound to be bugs. Try to make sure that you are in-game at all times. If there is an issue, try closing and reopening ConTroll.exe. If you do get an error message, expand the `Details` message and screenshot it and share it with me (I only care about the topmost part of the details, no need to scroll to the bottom).

#### Planned Features
- Social Distortion (screen transformations on timed intervals or chat-controlled)
- Chaos Mode (other effects on timed intervals or chat-controlled)
- Displaying/changing images/videos (triggered by actions/events in-game)
- Changing Twitch Game/Title information using presets
- OBS Source/Filter management (show/hide sources and filters with one press)
- Standard Twitch chat bot commands
- MIDI Controller Input (to control various things: in OBS, output a Twitch chat command, StreamDeck-like management)
- Possibly in the far future this could also turn into my own standalone LTTP tracker 
