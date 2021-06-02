using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Captura.Local
{
    public static class ArquivoIni
    {
        [DllImport("KERNEL32")]	private static extern int GetPrivateProfileString(string lpAppName, 
			string lpKeyName, string lpDefault,	StringBuilder lpReturnedString, int nSize,string lpFileName);

		[DllImport("kernel32")] private static extern int WritePrivateProfileString(string section,
			string key,string val,string filePath);

	
		public static string LeArquivoIni(string Secao,string Chave,string Arquivo)
		{
			int retlen  = 0;
			StringBuilder strRet = new StringBuilder(200);
			retlen = GetPrivateProfileString(Secao,Chave,"",strRet,200,Arquivo);			
			return strRet.ToString();
		}
		public static void EscreveArquivoIni(string Secao,string Chave,string Valor,string Arquivo)
		{
			WritePrivateProfileString(Secao,Chave,Valor,Arquivo);
		}
    }
}
