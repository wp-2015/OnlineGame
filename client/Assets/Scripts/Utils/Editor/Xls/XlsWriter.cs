using UnityEditor;
using System.Data;
using System.Xml;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

public class XlsWriter : Editor {
	private IWorkbook workbook = null;
	private string _fileName = "";
	private int _rowDataCount;
	private List<ISheet> _sheetList;

	public XlsWriter (string fileName, string sheetName){
		_sheetList = new List<ISheet> ();
		_rowDataCount = 0;
		_fileName = fileName;

		if (fileName.IndexOf (".xlsx") > 0) {
			// 2007版本  经测试mac和pc平台下有bug 写xlsx报错
			workbook = new XSSFWorkbook ();
		} else if (fileName.IndexOf (".xls") > 0) {
			// 2003版本
			workbook = new HSSFWorkbook ();
		}
		ISheet _sheet = workbook.CreateSheet(sheetName);
		_sheetList.Add (_sheet);
	}
		
	public void AddSheet(string sheetName){
		ISheet _sheet = workbook.CreateSheet(sheetName);
		_sheetList.Add (_sheet);
		_rowDataCount = 0;
	}

	//添加一行数据 by string[]
	public void AddRowDataWithArr(string[] rowDataList) {
		ISheet _sheet = _sheetList[_sheetList.Count - 1];
		IRow row = _sheet.CreateRow(_rowDataCount);
		for (int j = 0; j < rowDataList.Length; ++j) {
			row.CreateCell(j).SetCellValue(rowDataList[j] == null ? "" : rowDataList[j].ToString());
		}
		++_rowDataCount;
	}

	//添加一行数据 by List<string>
	public void AddRowDataWithList(List<string> rowDataList){
		ISheet _sheet = _sheetList[_sheetList.Count - 1];
		IRow row = _sheet.CreateRow(_rowDataCount);
		for (int j = 0; j < rowDataList.Count; ++j) {
			row.CreateCell(j).SetCellValue(rowDataList[j] == null ? "" : rowDataList[j].ToString());
		}
		++_rowDataCount;
	}

	//写入到文件
	public void SaveFile (){
		FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		workbook.Write(fs); //写入到excel
		if (fs != null) {
			fs.Close ();
		}
	}
}
