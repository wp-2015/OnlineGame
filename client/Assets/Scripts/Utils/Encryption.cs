using System;
using System.Text;

public class Encryption {

	public static string MD5Conversion(byte[] buffer){
		System.Security.Cryptography.MD5 alg = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] data = alg.ComputeHash(buffer);
		StringBuilder sBuilder = new StringBuilder();
		for(int i = 0; i < data.Length; i++){
			sBuilder.Append(data[i].ToString("x2"));
		}
		return sBuilder.ToString();
	}
}