touch tmp_files
cd tmp files
gr='\033[0;32m'
NC='\033[0m' # No Color
echo ===================================================
printf "${gr}Age of Empires 2 Auto Installer For: Ubuntu 20.10 \n"
echo Setting up Wine Staging And Winetricks...
echo ===================================================

wget -nc https://dl.winehq.org/wine-builds/winehq.key
sudo apt-key add winehq.key
echo "deb https://dl.winehq.org/wine-builds/ubuntu/ eoan main" | sudo tee /etc/apt/sources.list.d/wine.list
sudo apt update


echo ===================================================
echo Installing Wine Staging And Winetricks
echo ===================================================

sudo apt install -y --install-recommends winehq-staging
sudo apt-get install -y winetricks

echo ===================================================
echo Booting 32bit Wine Enviroment
echo ===================================================

WINEPREFIX="$HOME/win32" WINEARCH=win32 wine wineboot
WINEPREFIX="$HOME/win32" WINEARCH=win32 winecfg

echo ===================================================
echo Installing Required Modules
echo ===================================================

WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks corefonts
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks cmd
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks directplay
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks d3dx9
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks d3dx10
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks dotnet461
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks dsound
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks xact

echo ===================================================
echo Setting up AoE2Tools And Steam
echo ===================================================

wget https://steamcdn-a.akamaihd.net/client/installer/SteamSetup.exe
WINEPREFIX="$HOME/win32" WINEARCH=win32 wine SteamSetup.exe
sudo apt install -y jq
file_get=$(wget -q -nv -O- https://api.github.com/repos/gregstein/AoE2Tools/releases/latest |  jq -r '.assets[] | select(.browser_download_url | contains(".exe")) | .browser_download_url') &And wget --output-document=AoE2Tools.exe $file_get
WINEPREFIX="$HOME/win32" WINEARCH=win32 wine AoE2Tools.exe

echo ===================================================
echo Installing Scroll Fix For AoE2 And Creating a Shortcut In Your Desktop
echo ===================================================

wget https://github.com/SFTtech/sftscrollbugfixer/releases/download/v1.4.0.0/age2_x1_fixed.tar.gz -o aoe2fix.tar.gz
tar -xvzf aoe2fix.tar.gz -C /home/$USER/.wine/drive_c/users/$USER/Application Data/Microsoft Games/Age of Empires ii/Age2_x1/
wget https://raw.githubusercontent.com/gregstein/AoE2Tools/master/WindowsFormsApplication3/aoe2-linux-shortcut.lnk -o /home/$USER/Desktop/Age of Empires II Single Player.lnk


echo ===================================================
printf "${gr}:: Installation Successful! :: \n"
printf "${gr}Age of Empires 2 Path: /home/$USER/.wine/drive_c/users/$USER/Application Data/Microsoft Games/Age of Empires ii\n"
printf "${gr}AoE2Tools Path: /home/$USER/.wine/drive_c/users/$USER/Application Data/AoE2Tools\n"
echo ===================================================
