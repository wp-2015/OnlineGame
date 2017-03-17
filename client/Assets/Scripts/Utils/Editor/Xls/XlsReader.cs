using UnityEditor;
using System.Data;
using System.Xml;
using System.IO;

using System.Collections;
using System.Collections.Generic;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

public class XlsReader : Editor {
	public class KeyObject{
		public int index;
		public string name;
		public KeyObject(int id, string na){
			index = id;
			name = na;
		}
	}

	private Dictionary<KeyObject, DataTable> _xlxData;
	private FileStream fs = null;
	private IWorkbook workbook = null;

	public XlsReader(string fileName){
		_xlxData = new Dictionary<KeyObject, DataTable> ();
		fs = new FileStream (fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		if (fileName.EndsWith(".xlsx")) { 
			// Reading from a binary Excel file (format; *.xlsx)
			workbook = new XSSFWorkbook(fs);
		}

		if (fileName.EndsWith(".xls")) {
			// Reading from a binary Excel file ('97-2003 format; *.xls)
			workbook = new HSSFWorkbook(fs);
		}

		//读取xlsx、xls数据
		int sheetNum = workbook.NumberOfSheets;
		for (int i = 0; i < sheetNum; ++i){
			KeyObject key = new KeyObject (i, workbook.GetSheetName(i));
			DataTable dataTable = new DataTable ();
			_xlxData [key] = dataTable;
			ParseXlxData (workbook.GetSheetAt(i), dataTable);
		}

		if (fs != null) {
			fs.Close ();
		}
	}

	//解析xls、xlsx数据
	void ParseXlxData(ISheet sheet, DataTable dataTable){
		if (sheet != null){
			//列
			IRow firstRow = sheet.GetRow(0);
			int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

			for (int i = firstRow.FirstCellNum; i < cellCount; ++i) {
				ICell cell = firstRow.GetCell(i);
				string cellValue = cell.StringCellValue;
				DataColumn column = new DataColumn(cellValue == null ? "" : cellValue);
				dataTable.Columns.Add(column);
			}

			//行
			int rowStart = sheet.FirstRowNum;
			int rowCount = sheet.LastRowNum;

			for (int i = rowStart; i <= rowCount; ++i){
				IRow row = sheet.GetRow (i);
				if (row != null){
					DataRow dataRow = dataTable.NewRow ();
					for (int j = row.FirstCellNum; j < cellCount; ++j){
						ICell cell = row.GetCell (j);
						dataRow [j] = (cell != null ? cell.ToString() : "");
					}
					dataTable.Rows.Add (dataRow);
				}
			}
		}
	}

	//根据sheel索引获取数据表
	DataTable GetDataTableWithTableIndex (int index){
		DataTable ret = null;
		foreach(var item in _xlxData){
			if (item.Key.index == index){
				ret = item.Value;
				break;
			}
		}
		return ret;
	}

	//根据sheel名称获取数据表
	DataTable GetDataTableWithTableName (string tableName){
		DataTable ret = null;
		foreach(var item in _xlxData){
			if (item.Key.name.Equals(tableName)){
				ret = item.Value;
				break;
			}
		}
		return ret;
	}

	//获取sheert 的列数
	public int GetColLength(int tableIndex = 0){
		int ret = 0;
		DataTable data = GetDataTableWithTableIndex (tableIndex);
		if (data != null){
			ret = data.Columns.Count;
		}
		return ret;
	}
		
	//获取sheert 的行数
	public int GetRowLength(int tableIndex = 0){
		int ret = 0;
		DataTable data = GetDataTableWithTableIndex (tableIndex);
		if (data != null){
			ret = data.Rows.Count;
		}
		return ret;
	}

	//获取一行的数据
	public DataRow GetRowData (int rowIndex, int tableIndex = 0){
		DataRow ret = null;
		DataTable data = GetDataTableWithTableIndex (tableIndex);
		if (data != null){
			ret = data.Rows[rowIndex];
		}
		return ret;
	}

	//获取数据表的个数
	public int GetTableCount (){
		return _xlxData.Count;
	}

	//获取数据表名称
	public string GetTableName (int tableIndex){
		string ret = "XlxBase";
		foreach(var item in _xlxData){
			if (item.Key.index == tableIndex){
				ret = item.Key.name;
				break;
			}
		}
		return ret;
	}
}
