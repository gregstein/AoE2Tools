gacutil.exe -i "ComponentFactory.Krypton.Design.dll"
gacutil.exe -i "ComponentFactory.Krypton.Docking.dll"
gacutil.exe -i "ComponentFactory.Krypton.Navigator.dll"
gacutil.exe -i "ComponentFactory.Krypton.Ribbon.dll"
gacutil.exe -i "ComponentFactory.Krypton.Toolkit.dll"
gacutil.exe -i "ComponentFactory.Krypton.Workspace.dll"

::REBOOT:
shutdown.exe /r /t 00

::EXITPROGRAM:
::exit

::SET /P M=Type y, n and press enter:
::IF %M%==y GOTO REBOOT
::IF %M%==n GOTO EXITPROGRAM