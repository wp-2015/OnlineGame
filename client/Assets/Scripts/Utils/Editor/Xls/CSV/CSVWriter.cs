using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class CSVWriter : IDisposable
{
#if !UNITY_FLASH
    private static char separator = ',';
    private static char subSeparator = '+';
	
	private System.IO.StreamWriter m_file;
	private bool m_startOfLine = true;
    private bool m_disposed = false;
#endif
	
	public CSVWriter(string fileName, params string[] columns)
	{
#if !UNITY_FLASH
		try
		{
	        m_file = new System.IO.StreamWriter(fileName,false,System.Text.Encoding.UTF8);
			
			foreach (string column in columns)
			{
				WriteString(column);
			}
			
			EndRow();
		}
		catch (Exception ex)
		{
			Debug.LogError("Could not open: " + fileName + ", error: " + ex.Message);
		}
#endif
	}
	
	~CSVWriter()
	{
		Dispose(false);
	}
	
    public void Dispose()
    {
        Dispose(true);
#if !UNITY_FLASH
        GC.SuppressFinalize(this);
#endif
    }
	
    protected virtual void Dispose(bool disposing)
    {
#if !UNITY_FLASH
        if (!this.m_disposed)
        {
            if (disposing && m_file != null)
            {
				m_file.Dispose();
            }
			
            m_disposed = true;
        }
#endif
    }
	
	public void EndRow()
	{
#if !UNITY_FLASH
		if (m_file == null)
		{
			return;
		}
		
		m_file.Write('\n');
		m_startOfLine = true;
#endif
	}
	
	public void WriteInt(int val)
	{
#if !UNITY_FLASH
		if (!m_startOfLine)
		{
			m_file.Write(separator);
		}
		
		m_startOfLine = false;
		m_file.Write(val);
#endif
	}
	
	public void WriteFloat(float val)
	{
#if !UNITY_FLASH
		if (!m_startOfLine)
		{
			m_file.Write(separator);
		}
		
		m_startOfLine = false;
		m_file.Write(val);
#endif
	}
	
	public void WriteString(string val)
	{
#if !UNITY_FLASH
		if (!m_startOfLine)
		{
			m_file.Write(separator);
		}
		
		m_startOfLine = false;
		m_file.Write(val);
#endif
	}
	
	public void WriteStringArray(string[] vals)
	{
#if !UNITY_FLASH
		if (!m_startOfLine)
		{
			m_file.Write(separator);
		}
		
		m_startOfLine = false;
		bool firstVal = true;
		foreach (string val in vals)
		{
			if (!firstVal)
			{
				m_file.Write(subSeparator);
			}
			
			firstVal = false;
			m_file.Write(val);
		}
#endif
	}
}
