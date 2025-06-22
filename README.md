# unity-junior-data-persistence-prototype-7

## Screenshots

https://github.com/user-attachments/assets/42180737-7a06-40e1-9c5e-92324c5b144a

## Table of Contents
1. [Description](#description)
2. [Installation](#installation)
3. [Run](#run)
4. [Credits](#credits)
5. [Contributing](#contributing)
6. [License](#license)

## Description

This prototype is part of the Junior Programmer Pathway from Unity Learn. Its purpose is to teach the fundamentals of gameplay mechanics through scripting in C#.
Unlike earlier prototypes, this project starts with a fully functional game. The focus is on enhancing the game by implementing features such as saving the best score and displaying a leaderboard.

### Purpose

It's a **Break the Wall** game and we must code score feature as:

- **Player name** (saving data between scenes)
  - Create a new Start Menu scene for the game with a text entry field prompting the user to enter their name, and a Start button.
  - When the user clicks the Start button, the Main game scene will be loaded and their name will be displayed next to the score. 
- **High score** (saving data between sessions):
  - As the user plays, the current high score will be displayed on the screen alongside the player name who created the score.
  - If the high score is beaten, the new score and player name will be displayed instead.
  - The highest score will be saved between sessions, so that if the player closes and reopens the application, the high score and player name will be retained.

## Controls

| **Key** | **Action**           |
|:-------:|----------------------|
| `A` or `←`| Move to the left   |
| `D` or `→`| Move to the right  |
| `ESCAPE`  | Return to menu     |

### Technologies used

- **Unity** – Version 6000.0.47f1
- **C#** – Used for gameplay scripting
  
### Challenges and Future Features

During development, I explored alternative methods for data persistence and discovered how to use JSON serialization to store player data instead of relying solely on PlayerPrefs.

## Installation

You can download pre-built releases for your supported operating system from the GitHub Releases page. Available builds include:
- macOS
- Windows
- Linux

## Run

To run the program, simply double-click the executable file for your operating system.

### MacOS

Unzip and open the .app file.

### Windows

Unzip and double-click the .exe file.

### Linux

```bash
chmod +x Prototype_7_Linux.x86_64
./Prototype_7_Linux.x86_64
```

### Web

Play on [browser](https://vpekdas.github.io/unity-junior-data-persistence-prototype-7)

## Credits

This project is based on the Unity **Junior Programmer Pathway** by Unity Learn.
Many thanks to the instructors for their excellent step-by-step video tutorials and guidance.

## Contributing

To report issues, please create an issue here:  [issue tracker](https://github.com/Vpekdas/unity-junior-data-persistence-prototype-7/issues).

If you'd like to contribute, please follow the steps outlined in [CONTRIBUTING.md](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).
