using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class CSVReader : IDisposable
{
    private static char[] separators = { ',' };
    private static char[] subSeparators = { '+' };
    private static char[] trimCharacters = { ' ', '"' };
	
#if UNITY_EDITOR || !UNITY_FLASH
    private System.IO.StringReader m_file;
	private string[] m_tokens = new string[0];
#endif
	private int m_lineIndex = -1;
	private int m_tokenIndex = 0;
    private bool m_silent = false;
    private bool m_disposed = false;

    public CSVReader(string fileName, bool silent = false)
	{
#if UNITY_EDITOR || !UNITY_FLASH
		m_silent = silent;
		
		try
		{
            if (fileName.Contains("://")) {
                WWW www = new WWW(fileName);
                while(!www.isDone){}
                m_file = new System.IO.StringReader(www.text);
            }else{
                System.IO.StreamReader r = new System.IO.StreamReader(fileName);
                m_file = new System.IO.StringReader(r.ReadToEnd());
            }
	        m_file.ReadLine(); // Skip first line (labels)
		}
		catch (Exception ex)
		{
			if (!m_silent)
			{
				Debug.LogWarning("Could not load: " + fileName + ", error: " + ex.Message);
			}
		}
#endif
	}


    public CSVReader(string fileName, System.Text.Encoding encoding, bool silent = false)
    {
#if UNITY_EDITOR || !UNITY_FLASH
        m_silent = silent;

        try
        {
            if (fileName.Contains("://")) {
                WWW www = new WWW(fileName);
                while(!www.isDone){}
                m_file = new System.IO.StringReader(www.text);
            }else{
                System.IO.StreamReader r = new System.IO.StreamReader(fileName);
                m_file = new System.IO.StringReader(r.ReadToEnd());
            }
            m_file.ReadLine(); // Skip first line (labels)
        }
        catch (Exception ex)
        {
            if (!m_silent)
            {
                Debug.LogWarning("Could not load: " + fileName + ", error: " + ex.Message);
            }
        }
#endif
    }

    ~CSVReader()
	{
		Dispose(false);
	}
	
    public void Dispose()
    {
        Dispose(true);
#if UNITY_EDITOR || !UNITY_FLASH
        GC.SuppressFinalize(this);
#endif
    }
	
    protected virtual void Dispose(bool disposing)
    {
        if (!this.m_disposed)
        {
#if UNITY_EDITOR || !UNITY_FLASH
            if (disposing && m_file != null)
            {
				m_file.Dispose();
            }
#endif
			
            m_disposed = true;
        }
    }
	
	public bool NextRow()
	{
#if UNITY_EDITOR || !UNITY_FLASH
		if (m_file == null)
		{
			return false;
		}
		
        string line = m_file.ReadLine();
		if (line == null)
		{
			// End of file
			return false;
		}
		
		m_tokens = line.Split(separators);
		m_tokenIndex = 0;
		++m_lineIndex;
		return true;
#else
        return false;
#endif
	}
	
	private string NextToken()
	{
#if UNITY_EDITOR || !UNITY_FLASH
		return m_tokens[m_tokenIndex++].Trim(trimCharacters);
#else
        return string.Empty;
#endif
	}
	
	public int ReadInt()
	{
#if UNITY_EDITOR || !UNITY_FLASH
		if (m_tokenIndex < m_tokens.Length)
		{
			string token = NextToken();
			int result = 0;
			if (!System.Int32.TryParse(token, out result) && !m_silent)
			{
				Debug.LogError(string.Format("Could not parse int on line {0}, token {1}: {2}", m_lineIndex + 1, m_tokenIndex + 1, token));
			}
			
			return result;
		}
		
		if (!m_silent)
		{
			Debug.LogWarning(string.Format("Out of tokens on line {0}, requested token at index {1}", m_lineIndex + 1, m_tokenIndex + 1));
		}
#endif
        return 0;
	}
	
	public float ReadFloat()
	{
#if UNITY_EDITOR || !UNITY_FLASH
		if (m_tokenIndex < m_tokens.Length)
		{
			string token = NextToken();
			float result = 0.0f;
			if (!float.TryParse(token, out result) && !m_silent)
			{
				Debug.LogError(string.Format("Could not parse float on line {0}, token {1}: {2}", m_lineIndex + 1, m_tokenIndex + 1, token));
			}
			
			return result;
		}
		
		if (!m_silent)
		{
			Debug.LogWarning(string.Format("Out of tokens on line {0}, requested token at index {1}", m_lineIndex + 1, m_tokenIndex + 1));
		}
#endif
        return 0.0f;
	}
	
	public string ReadString()
	{
#if UNITY_EDITOR || !UNITY_FLASH
		if (m_tokenIndex < m_tokens.Length)
		{
			return NextToken();
		}
		
		if (!m_silent)
		{
			Debug.LogWarning(string.Format("Out of tokens on line {0}, requested token at index {1}", m_lineIndex + 1, m_tokenIndex + 1));
		}
#endif
		return "";
	}
	
	public string[] ReadStringArray()
	{
#if UNITY_EDITOR || !UNITY_FLASH
		if (m_tokenIndex < m_tokens.Length)
		{
			string[] strings = m_tokens[m_tokenIndex++].Trim(trimCharacters).Split(subSeparators);
			if (strings.Length == 1 && string.IsNullOrEmpty(strings[0]))
			{
				return new string[0];
			}
			
			return strings;
		}
		
		if (!m_silent)
		{
			Debug.LogWarning(string.Format("Out of tokens on line {0}, requested token at index {1}", m_lineIndex + 1, m_tokenIndex + 1));
		}
#endif
		return new string[0];
	}
	
	public T ReadEnum<T>(T defaultValue)
	{
#if UNITY_EDITOR || !UNITY_FLASH
		string str = ReadString();
		if (!string.IsNullOrEmpty(str))
		{
			try
			{
				return (T)Enum.Parse(typeof(T), str, true);
			}
			catch (System.Exception)
			{
			}
		}
#endif
		return defaultValue;
	}
}
