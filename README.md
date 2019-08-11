# What is Polar BEAR?
![Screenshot](Polar_BEAR_Logo.png)

Polar BEAR stands for Polar **B**ased **E**xtending **A**rm **R**obot. 

# Arduino
The Arduino is the heart of this project. It is responsible for controlling the electrical components that make up the arm. The Arduino opens a serial connection which allows for data to be passed back and forth from a computer.


# Desktop
![alt text](https://cdn.discordapp.com/attachments/375167727314272259/608321506023309333/unknown.png)

## Design
The GUI was created using WPF and C#. Initially the GUI was written to adhere to the Model View View-Model (MVVM) architectural pattern. However due to time constraints not every part of the GUI strictly follows MVVM.  

## Function
The desktop GUI is responsible for sending commands to the Arduino in order to move the Polar BEAR. Manual controls are provided to allow users to position the arm as needed. Pathing options is also available through the GUI. The path editor allows users to create sets of steps to for the arm to follow. These paths can be saved and then loaded at a later time.


# Parts List
[Arduino Mega](https://www.amazon.com/gp/product/B01H4ZLZLQ/)

[A4988 Stepper Driver](https://www.amazon.com/gp/product/B01ALJLK3K/)

[NEMA 17 Stepper](https://www.amazon.com/Stepper-Motor-Bipolar-64oz-Printer/dp/B00PNEQI7W/)

[Cytron Motor Controller (x2)](https://www.amazon.com/gp/product/B07NP6XNPR/)

[Tilt and Rotation Motors](https://www.servocity.com/32-rpm-hd-premium-planetary-gear-motor-w-encoder)
