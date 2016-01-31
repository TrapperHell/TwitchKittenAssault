#![Logo](Logo.png?raw=true)

Twitch Kitten Assault is a small game developed in 48 hours as part of the [2016 Global Game Jam](http://globalgamejam.org/2016/games/twitch-kitten-assault).

A kitten "MOBA" game in which Twitch viewers assume control of a cat sensei within one of the three cat castles (hereby known as 'catstles'). Each cat sensei is busy training the young kittens in the sacred art of jujutsu (and the lesser known, but nonetheless powerful, cat arts).

By typing messages in the Twitch chat, each viewer can select a lane through which to deploy the freshly trained kittens. These kittens then serve to defend against any incoming kittens (from enemy catstles), or even reach - and possibly overwhelm the enemy catstles.

### Gameplay

The Unity project in itself is a Twitch IRC listener - that reads the chat commands and produce visual output - which is in turn streamed on the Twitch channel. As such the only way to play the game is by hosting the Unity project, streaming it on Twitch and then message on the Twitch chat.

Commands are:

* --register
* --lane 0

The --register command is used the first time a viewer joins the Twitch chat, so that the system registers the viewer as a player and assigns him to one of the catstles. The --lane command is used to allow the player to deploy kittens to another lane. Replace 0 with either 1, 2 or 3 depending on the lane in which the kittens should be deployed.


### Usage Instructions

Please refer to [TwitchIRC-Unity](https://github.com/Grahnz/TwitchIRC-Unity) for information on how to set up the IRC client in Unity. Then use any screen-streaming software to stream the running game and play from Twitch room.