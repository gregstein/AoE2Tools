mkdir tmp_files
cd tmp_files
gr='\033[0;32m'
NC='\033[0m' # No Color
echo ===================================================
printf "${gr}Age of Empires 2 Auto Installer For: Ubuntu 18.04 \n"
echo Setting up Wine Staging And Winetricks...
echo ===================================================

wget -O- -q https://download.opensuse.org/repositories/Emulators:/Wine:/Debian/xUbuntu_18.04/Release.key | sudo apt-key add -    
echo "deb http://download.opensuse.org/repositories/Emulators:/Wine:/Debian/xUbuntu_18.04 ./" | sudo tee /etc/apt/sources.list.d/wine-obs.list
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
WINEPREFIX="$HOME/win32" WINEARCH=win32 winetricks steam
echo ===================================================
echo Setting up AoE2Tools And Steam
echo ===================================================
sudo apt-get install -y jq && file_get=$(wget -q -nv -O- https://api.github.com/repos/gregstein/AoE2Tools/releases/latest |  jq -r '.assets[] | select(.browser_download_url | contains(".exe")) | .browser_download_url') && wget --output-document=AoE2Tools.exe $file_get && WINEPREFIX="$HOME/win32" WINEARCH=win32 wine AoE2Tools.exe &&

echo "==================================================="
printf "${gr}:: Installation Successful! :: \n"
printf "${gr}Age of Empires 2 Path: /home/$USER/.wine/drive_c/users/$USER/Application Data/Microsoft Games/Age of Empires ii\n"
printf "${gr}AoE2Tools Path: /home/$USER/.wine/drive_c/users/$USER/Application Data/AoE2Tools\n"
echo "==================================================="
