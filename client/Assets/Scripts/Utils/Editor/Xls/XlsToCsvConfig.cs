using UnityEngine;
using UnityEditor;
using System.Collections;

public class XlsToCsvConfig : Editor {
	
	private static string documentPath = Application.dataPath + "/../Document/";
	private static string configPath = documentPath + "Config/";

	public static string achievementPath = configPath + "Achievement.xlsx";
	public static string leaderboardPath = configPath + "Leaderboard.xlsx";
	public static string iapPath = configPath + "Iap.xlsx";
	public static string exchangeGiftPath = configPath + "/CNY/ExchangeGift.xlsx";

	public static string SAVE_PATH = Application.dataPath + "/../Assets/Resources/Yodo1/Config/";

	#region China 
	public static string giftsPath = configPath + "Gifts.xlsx";
	public static string localizationPath = configPath + "Yodo1Localization.xlsx";
	public static string customAnimalPath = configPath + "CustomAnimal.xlsx";
	public static string IAP_CONFIG_FILE = Application.dataPath + "/../Assets/Yodo1SDK/Editor/Config/IapConfig.xlsx";
	#endregion
}
