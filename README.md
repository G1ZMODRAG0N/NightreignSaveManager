# 💾 NightreignSaveManager

## Description

This is a simple save manager for Nightreign. I wanted something that let me retain my progress when playing duos. Features include the ability to backup, archive, and convert save files into Seemless compatible .co2 formats.
[When converting a save from a Seemless save file back into a Vanilla one USE AT YOUR OWN RISK. Seemless saves have a chance to be flagged and banned from online use as we are not sure what may be modified differently from Vanilla.]

---

## Features

- Save conversion Vanilla .sl2/ Seemless .co2
- Backup all active save files
- Restore backups
- Import save files
- Rename save files
- Maintain an archive of past saves 

## Requirements

- Currently the application is built to target framework .NET 8.0 but is self-contained. This choice was made to keep a simplistic single .exe application.

---

## Installation

1. Drag and drop all files in NR_SaveManager_v#.#.#.zip into a folder of your choosing (preferably its own).
2. Open NR_SaveManager_v1.#.#.exe
3. Proceed to manage game saves

---

## FAQ

Q: What does this application do?
A: It allows you to import save files from Elden Ring Nightreign. After imported the file will be placed in an archived folder where you may convert to seemless/vanilla .ext, rename, or backup. (other options to come)

Q: Is this application safe?
A: This application is indeed safe. Most applications that modify files or have hyperlink buttons will be flagged by malware ai scans, these tend to be false-positives. I have ensured that if these flags get triggered it is at a minimum and that the application gets approved on release.
For further transparency this is the current VirusTotal result: https://www.virustotal.com/gui/file/b2e24e442847a1dcc2e02d25969ba4e11adefc9c8616665f25de2c069939bde1/detection/f-b2e24e442847a1dcc2e02d25969ba4e11adefc9c8616665f25de2c069939bde1-1749958354

Q: Does this application support pirated copies of the game?
A: Short answer, no. This application does not support pirated copies of the game. You're welcome to attempt use but by no means do I promise successful functionality.

Q: Where do I report suggestions/issues/feedback?
A: See bottom of the README

Q: How do I import a save?
A: File > Import > Vanilla/Seemless Save File(s). By default the application will direct you to the appdata folder the save files exist in.

Q: Can I convert my Seemless save file into a Vanilla save file so I can maintain my game progress?
A: You can but I do warn you of the risk of your account being banned from online use. If there isn't anything modified by Seemless on the save file level then it is a simple change of extension name.

Q: How do I backup my save files?
A: There is a simple button labeled 'Backup Saves'. This will automatically take all active save files in the directory and copy them as .bak files in the backup folder generated on first time use.
Use 'Restore a Save' button to select a file to bring back and make as your active save file.

Q: Why am I getting 'Unable to load file' when I start my game?
A: If you are not using a pirated copy of the game please report these issues in the Github repo or Nexus mod page. I am actively looking for any issues with files being unable to load after conversion.
As for now please double check that you are converting the correct .sl2/.co2 files. Use the dates listed to confirm.


---

## Configuration

All required directories for archiving and backups will be generated on first run.

---

## Planned Additions

- Launch shortcuts for Vanilla and Seemless
- Additional warnings and checks for files
- Multiple steam profile support
- Possible relic modifications
- Adjustments with usability

## Suggestions/Feedback/Issues

For feedback open an issue on GitHub https://github.com/G1ZMODRAG0N/NightreignSaveManager 
or comment on Nexus https://www.nexusmods.com/eldenringnightreign/mods/166.

<a href='https://ko-fi.com/T6T41GCSS1' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://storage.ko-fi.com/cdn/kofi6.png?v=6' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>
