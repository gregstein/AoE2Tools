echo "==================================================="
echo "Installing Scroll Fix For AoE2 And Creating a Shortcut In Your Desktop"
echo "==================================================="
sudo wget https://github.com/SFTtech/sftscrollbugfixer/releases/download/v1.4.0.0/age2_x1_fixed.tar.gz -o aoe2fix.tar.gz &&
tar -xf aoe2fix.tar.gz --strip-components 1 --directory "/home/$USER/win32/dosdevices/c:/users/$USER/Application Data/Microsoft Games/Age of Empires ii/Age2_x1/" &&
wget "https://raw.githubusercontent.com/gregstein/AoE2Tools/master/WindowsFormsApplication3/linux/Age of Empires II Single Player.sh" -o "/home/$USER/Desktop/Age of Empires II Single Player.sh" && chmod +x "Age of Empires II Single Player.sh"
