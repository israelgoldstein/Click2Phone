/*
 * Created by SharpDevelop.
 * User: gz8vnr
 * Date: 22/12/2008
 * Time: 17.27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Microsoft.Win32;

namespace ContaQ
{
	class Program
	{
		static void Main(string[] args)
		{
			try {
				ProtocolHandlerListener.SendRequest(args[0]);
			} catch (Exception ex) {
				//Log.Info(ex.Message);
				try {
					ProtocolHandlerListener.SetupProtocolHandler();
					ProtocolHandlerListener.StartListening();
				} catch (Exception ex2) {
					System.Console.WriteLine(ex2.Message);
				}
			}
		}
	}

	public class ProtocolHandlerListener : MarshalByRefObject
	{
		public static string ProtocolPrefix = "contaq";
		public static string ServiceName = "contaqConsoleHandler";
		public static int port = 9998;

		public  class ResponseCodes {
			public static int OK = 200;
			public static int Error = 501;
			public static int NotFound = 404;
		}

		public static event SipRequest MySipRequest;
		
		public int HandleRequest(string requestString)
		{
			//togliere il codice e mettere in onSipRequest
			//qui passare solo la stringa
			SipRequestArgs srArgs = new SipRequestArgs();
			Uri url = new Uri(requestString);
			srArgs.Command = url.Host.ToString();

			string original = url.PathAndQuery.ToString();
			string[] swp = original.Split('?');
			if (swp.Length == 1) {
				//no arguments
				srArgs.Command = original;
			} else {
				srArgs.Command = swp[0];
				foreach (string kvpair in swp[1].Split('&')) {
					swp = kvpair.Split('=');
					string key = swp[0].ToLower();
					string val="";
					if (swp.Length > 1) {
						//argument with no value
						val = Uri.UnescapeDataString(swp[1]);
					} 
					srArgs.Arguments.Add(key, val);
				}
			}
	        MySipRequest(this, srArgs);
	        
			return ResponseCodes.OK;
		}
		
		public static int SendRequest(String requestString) {
			TcpChannel tcpChannel = new TcpChannel();
			
			int result = ResponseCodes.Error;
			
			try {
				ChannelServices.RegisterChannel(tcpChannel, true);
				
				Type requiredType = typeof(ContaQ.ProtocolHandlerListener);
				
				ProtocolHandlerListener remoteObject = 
					(ProtocolHandlerListener)Activator.GetObject(
						requiredType,
						"tcp://localhost:" + port +"/" + ServiceName);
				result = remoteObject.HandleRequest(requestString);
				Console.WriteLine(result);
				ChannelServices.UnregisterChannel(tcpChannel);
			} catch (Exception ex) {
				ChannelServices.UnregisterChannel(tcpChannel);
			}
			return result;
		}
		
		public static void StartListening()
		{
			TcpChannel tcpChannel = new TcpChannel(9998);
			ChannelServices.RegisterChannel(tcpChannel, true);

			Type commonInterfaceType = typeof(ContaQ.ProtocolHandlerListener);
			
			RemotingConfiguration.RegisterWellKnownServiceType(
									commonInterfaceType, 
									ServiceName, 
									WellKnownObjectMode.SingleCall);
		}
		
		public static void SetupProtocolHandler() {
			try {
				RegistryKey regKey = Registry.ClassesRoot.CreateSubKey(@ProtocolPrefix, RegistryKeyPermissionCheck.Default);
				regKey.SetValue("", "CONTAQ:Contaq call handler protocol");
				regKey.SetValue("URL Protocol", "");
	
				regKey = Registry.ClassesRoot.CreateSubKey(@ProtocolPrefix + "\\shell\\open\\command", RegistryKeyPermissionCheck.Default);
				String exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
				regKey.SetValue("", "\"" + exePath + "\" \"%1\"");
			} catch (Exception ex) {
				// do nothing
			}
		}
	}
}





