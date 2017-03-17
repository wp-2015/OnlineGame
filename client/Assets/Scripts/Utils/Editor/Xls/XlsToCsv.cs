using UnityEngine;
using UnityEditor;
using System.Data;
using System.Xml;
using System.IO;

public class XlsToCsv : XlsReader {
	
	public XlsToCsv (string fileName):base(fileName) {
		
	}

	public void ConverToCSV(int tableIndex = 0, int length = 0) {
		if (GetTableCount() > tableIndex){
			string a = "";
			int row_no = 0;
			int count = length > 0 ? length : GetColLength(tableIndex);
			while (row_no < GetRowLength(tableIndex)) {
				DataRow dataRow = GetRowData (row_no, tableIndex);
				if (dataRow != null){
					for (int i = 0; i < count; i++) {
						string str = dataRow [i].ToString ().Trim ();
						a +=  (str + ",");
					}
					a += "\n";
				}
				row_no++;
			}

			if (!Directory.Exists (XlsToCsvConfig.SAVE_PATH)) {
				Directory.CreateDirectory (XlsToCsvConfig.SAVE_PATH);
			}
			string output = XlsToCsvConfig.SAVE_PATH + GetTableName(tableIndex) + ".csv";                     // 要保存的文件路径
			if (File.Exists (output)) {
				File.Delete (output);
			}
			StreamWriter csv = new StreamWriter(@output, false);
			csv.Write(a);
			csv.Close();

			Debug.Log("File converted succussfully");
		}
	}


	public static void ConvertAchievementConfigToCsv () {
		XlsToCsv obj = new XlsToCsv (XlsToCsvConfig.achievementPath);
		obj.ConverToCSV ();
	}

	public static void ConvertLeaderboardConfigToCsv () {
		XlsToCsv obj = new XlsToCsv (XlsToCsvConfig.leaderboardPath);
		obj.ConverToCSV ();
	}

	public static void ConvertIAPConfigToCsv (){
		XlsToCsv obj = new XlsToCsv (XlsToCsvConfig.IAP_CONFIG_FILE);
		obj.ConverToCSV (0, 8);
	}

	public static void ConvertExchangeGiftToCsv(){
		XlsToCsv obj = new XlsToCsv (XlsToCsvConfig.exchangeGiftPath);
		obj.ConverToCSV ();
	}

	public static void ConvertLocalizationToCSV () {
		XlsToCsv obj = new XlsToCsv (XlsToCsvConfig.localizationPath);
		obj.ConverToCSV ();
	}

	public static void ConvertGigtsConfigToCSV(){
		XlsToCsv obj = new XlsToCsv (XlsToCsvConfig.giftsPath);
		obj.ConverToCSV ();
	}

	public static void ConvertCustomAnimalConfigToCSV(){
		XlsToCsv obj = new XlsToCsv (XlsToCsvConfig.customAnimalPath);
		obj.ConverToCSV ();
	}
}


