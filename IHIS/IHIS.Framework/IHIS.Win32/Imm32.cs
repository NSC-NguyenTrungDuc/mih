using System;
using System.Text;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	/// <summary>
	/// Imm32에 대한 요약 설명입니다.
	/// </summary>
	public class Imm32
	{
		//flag에 따라 변환중가나(GCS_COMPREADSTR), 변환완료읽기문자(GCS_RESULTREADSTR)	변환완료문자(GCS_RESULTSTR)를 가져옴
		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern int ImmGetCompositionString(IntPtr hIMC, GCSFlags flags, StringBuilder lpBuf, int dwBufLen);
		//Window의  Input Context Handle 를 가져옴
		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr ImmGetContext(IntPtr hWnd);
		//Context Release
		[DllImport("imm32.dll", CharSet=CharSet.Auto)]
		public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);

		//IMM Flags
		public enum GCSFlags
		{
			GCS_COMPATTR			= 0x0010,	//Retrieve or update the attribute of the composition string
			GCS_COMCLAUSE			= 0x0020,	//Retrieve or update clause information of the compositiion string
			GCS_COMPREADATTR		= 0x0002,	//Retrieve or update the attributes of the reading string of the current composition
			GCS_COMPREADCLAUSE		= 0x0004,	//Retrieve or update the clause information of the reading string of the composition string
			GCS_COMPREADSTR			= 0x0001,	//Retrieve or update the reading string of the current composition(전환중가나)
			GCS_COMPSTR				= 0x0008,	//Retrieve or update the current composition string
			GCS_CURSORPOS			= 0x0080,	//Retrieve or update the cursor position in compsition string
			GCS_DELTASTART			= 0x0100,	//Retrieve or update the starting position of and changes in composition string
			GCS_RESULTCLAUSE		= 0x1000,	//Retrieve or update clause information of the result string
			GCS_RESULTREADCLAUSE	= 0x0400,	//Retrieve or update clause information of the reading string
			GCS_RESULTREADSTR		= 0x0200,	//Retrieve or update the reading string(전환완료읽기문자)
			GCS_RESULTSTR			= 0x0800	//Retrieve or update the string of the composition result(전환완료문자)
			
		}
	}
}
