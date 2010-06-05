/*
 * Creato da SharpDevelop.
 * Utente: OI43839
 * Data: 02/06/2010
 * Ora: 12.01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EmbeddedFreeSWITCH
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			FreeSWITCH.Native.freeswitch fs = new FreeSWITCH.Native.freeswitch();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}