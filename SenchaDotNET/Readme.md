# SenchaDOTNet
This project demonstrates how Sencha framework might be used in Asp.net applications

## Installation instructions

1. Download and install the Sencha Cmd 6 and Sencha SDK if not already present in your system. 
  See [Sencha Documentation](https://docs.sencha.com/extjs/6.0.2/guides/getting_started/getting_started.html) for instructions
2. Clone or download the demo repository
3. Demo repository contains multiple demo projects. We need only consider files under demo/SenchaDotNet
4. Open a command prompt & navigate to the demo/SenchaDotNET/SenchaDotNET/apps/homepage/ 
5. Run the following command:
    ```
      sencha app install --frameworks <Path to the Sencha SDK folder>
    ```
   This will copy the sencha sdk under  demo\SenchaDotNET\SenchaDotNET\ext folder
6. The project demonstrates a multi-page sencha application.  Each page in sencha is treated as an "app".  
   This sample project has two apps/pages:
   * Home Page :  under   demo\SenchaDotNET\SenchaDotNET\apps\homepage
   * Login Page:  under   demo\SenchaDotNET\SenchaDotNET\apps\loginpage
   
   To build these apps, in the command window navigate to each of the above folders and issue the sencha app build command
   ```
      sencha app build
   ```   
7.  Open the demo\SenchaDotNET\SenchaDotNET.sln in Visual Studio 2015 and run the application
