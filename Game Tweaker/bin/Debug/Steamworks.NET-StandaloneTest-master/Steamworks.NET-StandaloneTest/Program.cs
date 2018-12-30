using System;
using System.Threading;
using Steamworks;
using System.Windows.Forms;

namespace SteamworksNET_StandaloneTest {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WK_Cloud_Insta.WK_Cloud_Installer());
        }
    }
    //class Program {
    //    static CallResult<NumberOfCurrentPlayers_t> m_NumberOfCurrentPlayers;
    //    static CallResult<LeaderboardFindResult_t> m_callResultFindLeaderboard;
    //    static Callback<PersonaStateChange_t> m_PersonaStateChange;
    //    static Callback<UserStatsReceived_t> m_UserStatsReceived;

    //    static void InitializeCallbacks() {
    //        m_NumberOfCurrentPlayers = CallResult<NumberOfCurrentPlayers_t>.Create(OnNumberOfCurrentPlayers);
    //        m_callResultFindLeaderboard = CallResult<LeaderboardFindResult_t>.Create(OnFindLeaderboard);
    //        m_PersonaStateChange = Callback<PersonaStateChange_t>.Create(OnPersonaStateChange);
    //        m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(
    //            (pCallback) => {
    //                Console.WriteLine("[" + UserStatsReceived_t.k_iCallback + " - UserStatsReceived] - " + pCallback.m_eResult + " -- " + pCallback.m_nGameID + " -- " + pCallback.m_steamIDUser);
    //            });
    //    }

    //    static void Main(string[] args) {
    //        try {
    //            if (!SteamAPI.Init()) {
    //                Console.WriteLine("SteamAPI.Init() failed!");
    //                return;
    //            }
    //        }
    //        catch (DllNotFoundException e) { // We check this here as it will be the first instance of it.
    //            Console.WriteLine(e);
    //            return;
    //        }

    //        if (!Packsize.Test()) {
    //            Console.WriteLine("You're using the wrong Steamworks.NET Assembly for this platform!");
    //            return;
    //        }

    //        if (!DllCheck.Test()) {
    //            Console.WriteLine("You're using the wrong dlls for this platform!");
    //            return;
    //        }

    //        InitializeCallbacks(); // We do this after SteamAPI.Init() has occured


    //        Console.WriteLine("Requesting Current Stats - " + SteamUserStats.RequestCurrentStats());

    //        //Console.WriteLine("CurrentGameLanguage: " + SteamApps.GetCurrentGameLanguage());

    //        //Console.WriteLine("GetDLCCount: " + SteamApps.BIsDlcInstalled(TestConstants.Instance.k_AppId_PieterwTestDLC)); //SteamUtils.GetAppID()
    //        for (int iDLC = 0; iDLC < SteamApps.GetDLCCount(); ++iDLC)
    //        {
    //            AppId_t AppID;
    //            bool Available;
    //            string Name;
    //            bool ret = SteamApps.BGetDLCDataByIndex(iDLC, out AppID, out Available, out Name, 128);
    //            if (AppID.ToString() == "239550" && Available == true)
    //            {
    //                Console.WriteLine("FE is Valid!");
    //            }
    //            if (AppID.ToString() == "355950" && Available == true)
    //            {
    //                Console.WriteLine("AK is Valid!");
    //            }
    //            if (AppID.ToString() == "488060" && Available == true)
    //            {
    //                Console.WriteLine("ROR is Valid!");
    //            }
    //            //Console.WriteLine("BGetDLCDataByIndex(" + iDLC + ", out AppID, out Available, out Name, 128) : " + ret + " -- " + AppID + " -- " + Available + " -- " + Name);
    //        }
            
    //        Console.WriteLine("PersonaName: " + SteamFriends.GetPersonaName());

    //        {
    //            string folder;
    //            uint length = SteamApps.GetAppInstallDir(SteamUtils.GetAppID(), out folder, 260);
    //            Console.WriteLine("AppInstallDir: " + length + " " + folder);
    //        }


    //        m_NumberOfCurrentPlayers.Set(SteamUserStats.GetNumberOfCurrentPlayers());
    //        Console.WriteLine("Requesting Number of Current Players");

    //        {
    //            SteamAPICall_t hSteamAPICall = SteamUserStats.FindLeaderboard("Quickest Win");
    //            m_callResultFindLeaderboard.Set(hSteamAPICall);
    //            Console.WriteLine("Requesting Leaderboard");
    //        }

    //        while (true) {
    //            // Must be called from the primary thread.
    //            SteamAPI.RunCallbacks();

    //            if (Console.KeyAvailable) {
    //                ConsoleKeyInfo info = Console.ReadKey(true);

    //                if (info.Key == ConsoleKey.Escape) {
    //                    break;
    //                }
    //                else if (info.Key == ConsoleKey.Spacebar) {
    //                    SteamUserStats.RequestCurrentStats();
    //                    Console.WriteLine("Requesting Current Stats");
    //                }
    //                else if (info.Key == ConsoleKey.D1) {
    //                    SteamAPICall_t hSteamAPICall = SteamUserStats.FindLeaderboard("Quickest Win");
    //                    m_callResultFindLeaderboard.Set(hSteamAPICall);
    //                    Console.WriteLine("FindLeaderboard() - " + hSteamAPICall);
    //                }
    //                else if (info.Key == ConsoleKey.D2) {
    //                    SteamAPICall_t hSteamAPICall = SteamUserStats.GetNumberOfCurrentPlayers();
    //                    m_NumberOfCurrentPlayers.Set(hSteamAPICall);
    //                    Console.WriteLine("GetNumberOfCurrentPlayers() - " + hSteamAPICall);
    //                }
    //            }

    //            Thread.Sleep(50);
    //        }
    //        SteamAPI.Shutdown();
    //    }

		
    //    static void OnNumberOfCurrentPlayers(NumberOfCurrentPlayers_t pCallback, bool bIOFailure) {
    //        Console.WriteLine("[" + NumberOfCurrentPlayers_t.k_iCallback + " - NumberOfCurrentPlayers] - " + pCallback.m_bSuccess + " -- " + pCallback.m_cPlayers);
    //    }
		
    //    static void OnFindLeaderboard(LeaderboardFindResult_t pCallback, bool bIOFailure) {
    //        Console.WriteLine("[" + LeaderboardFindResult_t.k_iCallback + " - LeaderboardFindResult] - " + pCallback.m_bLeaderboardFound + " -- " + pCallback.m_hSteamLeaderboard);
    //    }
		
    //    static void OnPersonaStateChange(PersonaStateChange_t pCallback) {
    //        Console.WriteLine("[" + PersonaStateChange_t.k_iCallback + " - PersonaStateChange] - " + pCallback.m_ulSteamID + " -- " + pCallback.m_nChangeFlags);
    //    }
    //}
}
