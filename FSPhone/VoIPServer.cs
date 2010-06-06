/*
 * Created by SharpDevelop.
 * User: gz8vnr
 * Date: 03/11/2008
 * Time: 14.43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using ContaQ;
using FSPhone.Common.CallControl;
using WaveLib.AudioMixer;

namespace FSPhone.Common
{
	public class VoIPServer {
		static Form ownerForm;
		static MainForm mainForm;
		
		public ESLconnection eslConnection;
		
		public VoIPServer (Form form) {
			Configurator = new Configurator();
			Configurator.Accounts = new List<IAccount>();
			Configurator.Accounts.Add(new MockAccount());
			CallManager = new CallManager();
			Registrar = new Registrar();
			StackProxy = new StackProxy();
			ownerForm = form;
	      	mainForm = new MainForm();	      
	      	mainForm.Show(ownerForm);
	      	mainForm.Server = this;
	        eslConnection = new ESLconnection("localhost", "8021", "ClueCon");
			//ThreadPool.QueueUserWorkItem(new WaitCallback(InboundMode));
			InboundMode.Invoke(null);
		}
	    	public static readonly int ESL_SUCCESS = 1;
	    void InboundMode(Object stateInfo) {
	      //Initializes a new instance of ESLconnection, and connects to the host $host on the port $port, and supplies $password to freeswitch
	
	      //eslConnection = new ESLconnection("localhost", "8021", "ClueCon");
	
	      if (eslConnection.Connected() != ESL_SUCCESS)
	      {
	        mainForm.WriteLine("Error connecting to FreeSwitch");
	        return;
	      }
	
	      //Set log level
	      //ESL.eslSetLogLevel((int)enLogLevel.DEBUG);
	
	      // Subscribe to all events 
	      ESLevent eslEvent = eslConnection.SendRecv("event plain ALL");
	
	      if (eslEvent == null)
	      {
	        mainForm.WriteLine("Error subscribing to all events");
	        return;
	      }
	
	      //Turns an event into colon-separated 'name: value' pairs. The format parameter isn't used
	      //mainForm.WriteLine(eslEvent.Serialize(String.Empty));
	      //mainForm.WriteLine(eslEvent.Serialize(String.Empty));
	
	      // Grab Events until process is killed
	      while (eslConnection.Connected() == ESL_SUCCESS)
	      {
	        eslEvent = eslConnection.RecvEvent();
	        Application.DoEvents();
	        //Log.Info(eslEvent.getType() + " " + eslEvent.GetBody());
	        //mainForm.WriteLine(eslEvent.Serialize(String.Empty));
	        mainForm.WriteLine(eslEvent.getType() + " " + eslEvent.GetBody());
	      }
	    }
	    
	    	public StackProxy StackProxy;
		public Configurator Configurator;
		public CallManager CallManager;
		public Registrar Registrar;
		public CallLogger CallLogger;
	}
	public delegate void AccountStateHandler(int accId, int accState);

	public static class Log {
		private static void log(string eventType, string message) {
			System.Diagnostics.Debug.WriteLine(eventType + " - " + DateTime.Now + ": " + message);
		}
		public static void Error(String message) {
			log("ERROR", message);
		}
	
		public static void Info(String message) {
			log("INFO", message);
		}
	}
	
	public enum EStateId {
		ACTIVE,
		ALERTING,
		CONNECTING,
		HOLDING,
		IDLE,
		INCOMING,
		NULL,
		RELEASED,
		TERMINATED
	}
	
	public enum ETransportMode{
		TM_UDP
	}
	public class StackProxy {
		public Boolean IsInitialized;
		public int getNoOfCodecs() {
			Log.Info("getNoOfCodecs");
			return 0;
		}
		public string getCodec(int codecNumber) {
			throw new NotImplementedException();
		}
		public void setCodecPriority(String codecname, int dunno) {
			throw new NotImplementedException();
		}
	}
	public class Configurator {
		public List<IAccount> Accounts;
		public int DefaultAccountIndex;
		public Collection<String> CodecList;
		public string DtmfMode;
		public void Save() {
			Log.Info("save");
		}
	}
	
	public class Registrar {
		public event AccountStateHandler AccountStateChanged;
		public Configurator Config;
		public void unregisterAccounts() {
			throw new NotImplementedException();
		}
		public void registerAccounts() {
			throw new NotImplementedException();
		}
	}
	public class CallLogger {
	}
	public class MockAccount : IAccount {
		int regState = 0;
		int IAccount.RegState {
			get {
				return regState;
			}
			set {
				regState = value;
			}
		}
		string accountName;		
		string IAccount.AccountName {
			get {
				return accountName;
			}
			set {
				accountName = value;
			}
		}
		string userName;
		string IAccount.UserName {
			get {
				return userName;
			}
			set {
				userName = value;
			}
		}
		string domainName;
		string IAccount.DomainName {
			get {
				return domainName;
			}
			set {
				domainName = value;
			}
		}
		string hostName;
		string IAccount.HostName {
			get {
				return hostName;
			}
			set {
				hostName = value;
			}
		}
		string displayName;
		string IAccount.DisplayName {
			get {
				return displayName;
			}
			set {
				displayName=value;
			}
		}
		string password;
		string IAccount.Password {
			get {
				return password;
			}
			set {
				password = value;
			}
		}
		string proxyAddress;
		string IAccount.ProxyAddress {
			get {
				return proxyAddress;
			}
			set {
				proxyAddress = value;
			}
		}
		string id;
		string IAccount.Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}
		ETransportMode transportMode;
		ETransportMode IAccount.TransportMode {
			get {
				return transportMode;
			}
			set {
				transportMode = value;
			}
		}
	}

	public interface IAccount {
		
		int RegState {get; set;}
		string AccountName  {get; set;}
		string UserName {get; set; }
		string DomainName  {get; set;}
		string HostName  {get; set;}
		string DisplayName {get; set;}
		string Password {get; set;}
		string ProxyAddress {get; set;}
		string Id {get; set;}
		ETransportMode TransportMode {get; set;}
	}
}

namespace FSPhone.Common.CallControl {
	public delegate void StateHandler (int sessionId);
	public class CallManager {
		public System.Collections.Generic.Dictionary<int, IStateMachine> CallList;
		public event StateHandler CallStateRefresh;
		public int Initialize() {
			Log.Info("initialize");
			return 0;
		}
		public CallLogger CallLogger;
		public IStateMachine createOutboundCall(String number2call) {
			throw new NotImplementedException();
		}
		public void onUserRelease(String session) {
			throw new NotImplementedException();
		}
		public void onUserAnswer(String session) {
			throw new NotImplementedException();
		}
		public void onUserTransfer(String session, String destinationNumber) {
			throw new NotImplementedException();
		}
		public void onUserHoldRetrieve(String session) {
			throw new NotImplementedException();
		}
		public void onUserDialDigit(String session, String digit, String dtmfMode) {
			throw new NotImplementedException();
		}
	}
	public interface IStateMachine {
		string CallingNumber {get; set;}
		string CallingName {get; set;}
		string Session {get; set;}
		EStateId StateId {get; set;}
	}

}


