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

using FSPhone.Common;
using FSPhone.Common.CallControl;
using WaveLib.AudioMixer;

namespace FSPhone.Common {
	
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
	public delegate void AccountStateHandler (int accId, int accState);
	public class VoIPServer {
		static Form ownerForm;
		static MainForm mainForm;
		
		public static ESLconnection eslConnection;
		
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
			ThreadPool.QueueUserWorkItem(new WaitCallback(InboundMode));
		}
    	public static readonly int ESL_SUCCESS = 1;
	    static void InboundMode(Object stateInfo) {
	      //Initializes a new instance of ESLconnection, and connects to the host $host on the port $port, and supplies $password to freeswitch

	      eslConnection = new ESLconnection("localhost", "8021", "ClueCon");
	
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
	      mainForm.WriteLine(eslEvent.Serialize(String.Empty));
	
	      // Grab Events until process is killed
	      while (eslConnection.Connected() == ESL_SUCCESS)
	      {
	        eslEvent = eslConnection.RecvEvent();
	        mainForm.WriteLine(eslEvent.Serialize(String.Empty));
	      }
	    }
    
    	public StackProxy StackProxy;
		public Configurator Configurator;
		public CallManager CallManager;
		public Registrar Registrar;
		public CallLogger CallLogger;
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
	};
}

namespace ContaQ
{
	/// <summary>
	/// Description of ContaQForm.
	/// </summary>
	public partial class ContaQForm : Form
	{

	    private VoIPServer _factory = null;
	    private VoIPServer VoIPServer
	    {
	      get { return _factory; }
	    }

	    public bool IsInitialized
	    {
	      get { return VoIPServer.StackProxy.IsInitialized; }
	    }
	    
	    System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();  // Refresh Call List
	    
	    public ContaQForm()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();			
      		_factory = new VoIPServer(this);
		}
	    
	    private string requestArgs = null;
	    
	    public ContaQForm(String requestArgs) {
			InitializeComponent();
	    	this.requestArgs = requestArgs;
      		_factory = new VoIPServer(this);
	    }
	    
		private Boolean _isRecording = false;

		String _accountName = null;
		IAccount _account = null;

		String onIncomingCallUrl = null;
		String onHangupUrl = null;
		String onAlertingUrl = null;
		String onAnsweredUrl = null;
		String onRegisteredUrl = null;
		String onUnregisteredUrl = null;
		String[] mobilePrefixes;
		String[] landlinePrefixes;
		private Random randomNumber = new Random();
		
		private void VaiAllaHome() {
	      phoBrow.Open("file://" + Application.StartupPath + "/static/index.html");
		}
		
		private void PhoBrowTitleChanged(object sender, ContaQ.TextChangedArgs e) {
			SetTitle(e.Text);
		}
		private void PhoBrowStatusChanged(object sender, ContaQ.TextChangedArgs e) {
			SetBrowserStatus(e.Text);
		}
		
		private void SetBrowserStatus(string text){
			browserStatusLabel.Text = text;
		}
		
	    private void SetTitle(String title) {
			Text = "contaQ - [" + title + "]";
	    }
		
		void SetAccountStatus(string name, string opName, string status) {
			lblAccount.Text = name + " - " + status;
			lblOperator.Text = opName;
		}
	    
	    private void RefreshAccountStatus() {
	  		_account = null;
	    	_accountName = null;
	      for (int i = 0; i < VoIPServer.Configurator.Accounts.Count; i++)
	      {
	      	IAccount acc = VoIPServer.Configurator.Accounts[i];
	      	string label = null;
			// check registration status
			if (i == VoIPServer.Configurator.DefaultAccountIndex) {
		  		_account = acc;
				switch (acc.RegState) {
					case (200):
				        label = "registered as " + acc.DisplayName;
				  		_accountName = acc.AccountName;
				  		if (onRegisteredUrl != null && !onRegisteredUrl.Equals("")) {
				  			phoBrow.Open(onRegisteredUrl.Replace("${operatorid}", _account.UserName));
					  		//SetTitle(label);
				  		}
				  		SetPhoneStatus(null);
				  		SetAccountStatus(acc.AccountName, acc.DisplayName, "registered");
				  		SetButtonsStatus(PhoneActions.Login);
						break;
					case (0):
				  		_account = acc;
				        label = "trying...";
				  		_accountName = acc.AccountName;
				  		SetAccountStatus(acc.AccountName, acc.DisplayName, "registering...");
				  		//SetTitle(label);
				  		SetPhoneStatus("Phone not ready");
				  		SetButtonsStatus(PhoneActions.Logout);
				       	break;
				    default:
				    	label = "not registered";
				  		_accountName = acc.AccountName;
				  		SetAccountStatus(acc.AccountName, acc.DisplayName, "not registered");
				  		if (onUnregisteredUrl != null && !onUnregisteredUrl.Equals("")) {
				  			phoBrow.Open(onUnregisteredUrl);
				  		}
				  		//SetTitle(label);
				  		SetPhoneStatus("Phone not ready");
				  		SetButtonsStatus(PhoneActions.Logout);
				    	break;
				  }
	         }
	      }
	    }

		private string urlWithPhoneParameters(String url, IStateMachine thisCall) {
			// una porcata - prendo caller e called da callingnumber 
			// separandoli con asterisco - se non c'è è il caller
			// e allora imposto il called a operatorid
			String[] numbers = thisCall.CallingNumber.Split('*');
			String caller = numbers[0];
			String called = "";
			
			if (numbers.Length>1) {
				called = numbers[1];
			} else {
				called = _account.UserName;
			}
			
			url = url
				//for backword compatibility
				.Replace("${number}", thisCall.CallingNumber)
				.Replace("${operatorid}", _account.UserName)
				//new variables
				.Replace("${callername}", thisCall.CallingName)
				.Replace("${caller}", caller)
				.Replace("${called}", called)
				;
			return url;
		}
	    private void RefreshCallStatus() {
          	if (IsInitialized) {
		    	System.Collections.Generic.Dictionary<int, IStateMachine> callList = VoIPServer.CallManager.CallList;
		
		        foreach (System.Collections.Generic.KeyValuePair<int, IStateMachine> kvp in callList)
		        {
		          IStateMachine thisCall = kvp.Value;
		          string number = thisCall.CallingNumber;
		          string name = thisCall.CallingName; 

		          btnHold.Text = "&pausa";

		          switch (thisCall.StateId) {
		          	case EStateId.ACTIVE:
		          		_currentCall = thisCall;
		          		if (onAnsweredUrl != null && !onAnsweredUrl.Equals(""))
		          			phoBrow.Open(urlWithPhoneParameters(onAnsweredUrl, thisCall));
		          		SetPhoneStatus("Talking with " + thisCall.CallingNumber );
		          		break;
		          	case EStateId.ALERTING:
		          		_currentCall = thisCall;
		          		if (onAlertingUrl != null && !onAlertingUrl.Equals(""))
		          			phoBrow.Open(urlWithPhoneParameters(onAlertingUrl, thisCall));
		          		SetPhoneStatus("Alerting " + thisCall.CallingNumber );
		          		break;
		          	case EStateId.CONNECTING:
		          		_currentCall = thisCall;
		          		SetPhoneStatus("Connecting to " + thisCall.CallingNumber + "...");
		          		break;
		          	case EStateId.HOLDING:
		          		_currentCall = thisCall;
		          		SetPhoneStatus("On hold (" + thisCall.CallingNumber + ")");
						btnHold.Text = "ri&prendi";
		          		break;
		          	case EStateId.IDLE:
		          		SetPhoneStatus(null);
		          		break;
		          	case EStateId.INCOMING:		          			
		          		if (_currentCall == null)
		          			_currentCall = thisCall;
		          		_incomingCall = thisCall;
		          		
		          		if (onIncomingCallUrl != null && !onIncomingCallUrl.Equals(""))
		          			phoBrow.Open(urlWithPhoneParameters(onIncomingCallUrl, thisCall));
		          		
		          		SetPhoneStatus(thisCall.CallingNumber + " is calling");
		          		break;
		          	case EStateId.NULL:
		          		SetPhoneStatus("Null (" + thisCall.CallingNumber + ")");
		          		break;
		          	case EStateId.RELEASED:
		          		SetPhoneStatus(thisCall.CallingNumber + " terminated the call");
		          		SetRecordingStatus(false);
		          		if (onHangupUrl != null && !onHangupUrl.Equals(""))
		          			phoBrow.Open(urlWithPhoneParameters(onHangupUrl, thisCall));
		          		break;
		          	case EStateId.TERMINATED:
		          		SetPhoneStatus("Call with " + thisCall.CallingNumber + " terminated");
		          		SetRecordingStatus(false);

		          		if (onHangupUrl != null && !onHangupUrl.Equals(""))
		          			phoBrow.Open(urlWithPhoneParameters(onHangupUrl, thisCall));
		          		break;
		          	default:
		          		break;
		          }		          
		    	}
	    	}
	    }
	    
		private void SetRecordingStatus(Boolean newValue) {
			try {
				if (!newValue) {
		      		timerBlink.Enabled = false;
		      		_isRecording = false;
		      		btnRecord.Text="&registra";
		      		btnRecord.BackColor  = Color.Lime;
		      		btnRecord.Refresh();
				} else {
		      		btnRecord.Tag = btnRecord.BackColor;
		      		btnRecord.BackColor = Color.Red;
		      		timerBlink.Enabled = true;
		      		_isRecording = true;
		      		btnRecord.Text="sto &registrando";
		      		btnRecord.Refresh();
				}
			} catch (Exception ex) {
				Log.Error(ex.Message + " trying to switch recording status display");
			}
		}
		
	    void SetPhoneStatus(String status) {
	    	if ( status == null ) status = "Phone ready";
	    	sipStatusLabel.Text = status;
	    }

	    private void RefreshForm() {
			//RefreshAccountStatus();
			RefreshCallStatus();
	    }
	    
    //////////////////////////////////////////////////////////////////////////////////////
    /// Register callbacks and synchronize threads
    /// 
    delegate void DRefreshForm();
    delegate void DAccountStateChanged();
    delegate void DCallStateChanged(int sessionId);
    /*
    delegate void MessageReceivedDelegate(string from, string message);
    delegate void BuddyStateChangedDelegate(int buddyId, int status, string text);
    delegate void DMessageWaiting(int mwi, string text);
	*/
    public void onCallStateChanged(int sessionId)
    {
      if (InvokeRequired)
      	this.BeginInvoke(new DRefreshForm(this.RefreshForm));
      else
        RefreshForm();
    }

	delegate void DMySipRequest(object sender, SipRequestArgs args);

    public void onSipRequest(object sender, SipRequestArgs args) {
		object[] funcArgs= new object[]{sender,args};
	    this.BeginInvoke(new DMySipRequest(this.PhoBrowSipRequest),funcArgs);
    }

    /*
    public void onMessageReceived(string from, string message)
    {
      if (InvokeRequired)
        this.BeginInvoke(new MessageReceivedDelegate(this.MessageReceived), new object[] { from, message });
      else
        MessageReceived(from, message);
    }

    public void onBuddyStateChanged(int buddyId, int status, string text)
    {
      if (InvokeRequired)
        this.BeginInvoke(new BuddyStateChangedDelegate(this.BuddyStateChanged), new object[] { buddyId, status, text});
      else
        BuddyStateChanged(buddyId, status, text);
    }
*/
    public void onAccountStateChanged(int accId, int accState)
    {
      if (InvokeRequired)
        this.BeginInvoke(new DAccountStateChanged(this.RefreshAccountStatus));
      else
        RefreshAccountStatus();
    }
/*
    public void onMessageWaitingIndication(int mwi, string text)
    {
      if (InvokeRequired)
        this.BeginInvoke(new DMessageWaiting(this.MessageWaiting), new object[] { mwi, text });
      else
        MessageWaiting(mwi, text);
    }	    
*/
		void SetupDefaultAccount() {
			_account = VoIPServer.Configurator.Accounts[0];
			_account.AccountName="contaq";
			_account.DomainName="*";
			_account.HostName = "127.0.0.1";
			_account.DisplayName="non registrato";
			_account.UserName="nessuno";
			_account.Password="wrong";
	        _account.Id = _account.UserName;
	        _account.TransportMode = ETransportMode.TM_UDP;
			
			VoIPServer.Configurator.DefaultAccountIndex=0;
			VoIPServer.Configurator.Save();
		}

private class PhoneProvider {
	public string Name;
	public string Prefix;
	public PhoneProvider (string name,  string prefix) {
		this.Name = name;
		this.Prefix = prefix;
	}
	public override string ToString()
	{
		return Name;
	}
}

		void ContaQFormLoad(object sender, EventArgs e)
		{
			// RpG: creazione account di default
			SetupDefaultAccount();
			
			comboProvider.Items.Clear();
			comboProvider.Items.Add(new PhoneProvider("OkCom", "396"));
			comboProvider.Items.Add(new PhoneProvider("VoipCheap", "393"));
			comboProvider.Items.Add(new PhoneProvider("CallWithUs", "394"));
			comboProvider.Items.Add(new PhoneProvider("Unidata", "out-"));
			comboProvider.Items.Add(new PhoneProvider("SIPTraffic Bronze", "397"));
			comboProvider.Items.Add(new PhoneProvider("SIPTraffic Silver", "398"));
			comboProvider.Items.Add(new PhoneProvider("SIPTraffic Gold", "399"));
			comboProvider.Items.Add(new PhoneProvider("Interno", ""));
			comboProvider.SelectedIndex = 0;
			
			SetButtonsStatus(PhoneActions.Logout);

			//setup contaq:// handler event
			ProtocolHandlerListener.MySipRequest += new ContaQ.SipRequest(this.onSipRequest);
			//setup protocol handler 
			ProtocolHandlerListener.SetupProtocolHandler();
			//setup protocol handler and start listening
			ProtocolHandlerListener.StartListening();

			Log.Info("Loading icon");
			System.Drawing.Icon icon = new System.Drawing.Icon(Application.StartupPath + "\\static\\contaQ.ico");
			this.Icon = icon;
			Log.Info("Loading logo");
			picLogo.ImageLocation = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + ".bmp";
			
		  
		  	VaiAllaHome();
		  
	      	// Register callbacks from callcontrol
	      	VoIPServer.CallManager.CallStateRefresh += onCallStateChanged;
	      	// Register callbacks from pjsipWrapper
	      	VoIPServer.Registrar.AccountStateChanged += onAccountStateChanged;
	
	      	// Initialize and set factory for CallManager
	      
	      	int status = VoIPServer.CallManager.Initialize();
	      	VoIPServer.CallManager.CallLogger = VoIPServer.CallLogger;
	
			if (status != 0)
			{
				//(new Sipek.ErrorDialog("Initialize Error", "Init SIP stack problem! \r\nPlease, check configuration and start again! \r\nStatus code " + status)).ShowDialog();
				MessageBox.Show("Initialize Error - Init SIP stack problem! \r\nPlease, check configuration and start again! \r\nStatus code " + status);
				return;
			}
	      	
	      // scoh::::03.04.2008:::pjsip ISSUE??? At startup codeclist is different as later 
	      // set codecs priority...
	      // initialize/reset codecs - enable PCMU and PCMA only
	      int noOfCodecs = VoIPServer.StackProxy.getNoOfCodecs();
	      for (int i = 0; i < noOfCodecs; i++)
	      {
	        string codecname = VoIPServer.StackProxy.getCodec(i);
	        if (VoIPServer.Configurator.CodecList.Contains(codecname))
	        {
	          // leave default
	          VoIPServer.StackProxy.setCodecPriority(codecname, 128);
	        }
	        else
	        {
	          // disable
	          VoIPServer.StackProxy.setCodecPriority(codecname, 0);
	        }
	      }
	
	      // timer 
	      tmr.Interval = 1000;
	      tmr.Tick += new EventHandler(UpdateCallTimeout);

	      //handle startup args
	      if (requestArgs != null) {
	      	phoBrow.Open(requestArgs);
	      	requestArgs = null;
	      }
		}

	private int numberOfCalls = 0;
	
	public void UpdateCallTimeout(object sender, EventArgs e)
    {
      if (numberOfCalls == 0) return;

      for (int i = 0; i < numberOfCalls; i++ )
      {
      	/*
        ListViewItem item = listViewCallLines.Items[i];
        IStateMachine sm = (IStateMachine)item.Tag;
        if (sm.IsNull) continue;

        string duration = sm.RuntimeDuration.ToString();
        if (duration.IndexOf('.') > 0) duration = duration.Remove(duration.IndexOf('.')); // remove miliseconds

        item.SubItems[2].Text = duration;
        */
      }
      // restart timer
      if (numberOfCalls > 0)
      {
        tmr.Start();
      }

    }
		
		IStateMachine _currentCall = null;
		IStateMachine _incomingCall = null;
		
		enum PhoneActions {
			Call,
			Answer,
			Hangup,
			Record,
			Hold,
			Mute,
			Login,
			Logout,
			ShowKeypad
		}
		
		void SetButtonsStatus(PhoneActions button) {
			switch (button) {
				case PhoneActions.Login:
					btnCall.Enabled = true;
					//btnRecord.Enabled = false;
					//btnHold.Enabled = false;
					btnAnswer.Enabled = true;
					//btnRelease.Enabled = true;
					//btnMute.Enabled = false;
					//keyPad.Enabled=false;
					break;
				case PhoneActions.Logout:
					btnCall.Enabled = false;
					//btnRecord.Enabled = false;
					//btnHold.Enabled = false;
					btnAnswer.Enabled = false;
					//btnRelease.Enabled = false;
					//btnMute.Enabled = false;
					//keyPad.Enabled=false;
					break;
				case PhoneActions.Call:
				case PhoneActions.Answer:
					btnCall.Enabled = false;
					btnRecord.Enabled = true;
					btnHold.Enabled = true;
					btnAnswer.Enabled = false;
					btnRelease.Enabled = true;
					btnMute.Enabled = true;
					keyPad.Enabled=true;
					break;
				case PhoneActions.Hangup:
					btnCall.Enabled = true;
					btnRecord.Enabled = false;
					btnHold.Enabled = false;
					btnAnswer.Enabled = true;
					btnRelease.Enabled = false;
					btnMute.Enabled = false;
					keyPad.Enabled=false;
					break;
				case PhoneActions.ShowKeypad:
					keyPad.Visible=!keyPad.Visible;
					break;

			}
		}
		
		void BtnCallClick(object sender, EventArgs e)
		{
			string prefix = ((PhoneProvider)comboProvider.SelectedItem).Prefix;
			
			_currentCall = 
          		VoIPServer.CallManager.createOutboundCall(prefix + txtNumber.Text);
			SetButtonsStatus(PhoneActions.Call);			
		}
		
		void BtnReleaseClick(object sender, EventArgs e)
		{
			try {
				if (_currentCall != null) {
					VoIPServer.CallManager.onUserRelease(_currentCall.Session);
					_currentCall = null;
					SetRecordingStatus(false);
				}
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
			} finally {
				SetButtonsStatus(PhoneActions.Hangup);
			}
		}
		
		void BtnAnswerClick(object sender, EventArgs e)
		{
			if (_incomingCall != null) {
				_currentCall = _incomingCall;
				_incomingCall = null;
				VoIPServer.CallManager.onUserAnswer(_currentCall.Session);
				txtNumber.Text = _currentCall.CallingNumber;
			}
			SetButtonsStatus(PhoneActions.Answer);
		}
		
		void BtnShowMainformClick(object sender, EventArgs e)
		{
			//new Sipek.MainForm().ShowDialog();
			MessageBox.Show("Non più implementato!");
		}		
		
		void NotHandled(ContaQ.SipRequestArgs e) {
			String msg = "command not handled: " + e.Command;
				
			Hashtable args = e.Arguments;
			
			foreach (string key in e.Arguments.Keys) {
				msg += "\n\r   " + key + "=" + e.Arguments[key] + " ";
			}
			
			MessageBox.Show(msg, "sip request");
		}
		
		private string autoRoute(String number) {
			String prefix = ((PhoneProvider)comboProvider.Items[0]).Prefix;			
			
			if (number.StartsWith("auto-3")) { // cellulare
				if (mobilePrefixes != null && mobilePrefixes.Length > 0 ) {
					prefix = mobilePrefixes[randomNumber.Next(0,mobilePrefixes.Length)];
				}
			} else { // fisso
				if (landlinePrefixes != null && landlinePrefixes.Length > 0 ) {
					prefix = landlinePrefixes[randomNumber.Next(0,landlinePrefixes.Length)];
				}
			}
			
			return number.Replace("auto-", prefix);
		}
		
		private void setNumberAndPrefix(string number) {

			if (number.StartsWith("auto-")) {
				number = autoRoute(number);
			}

			if (number.StartsWith("#"))  {
				//è una funzione interna
				comboProvider.SelectedIndex = comboProvider.Items.Count -1;
			} else {
				foreach(PhoneProvider provider in comboProvider.Items) {
					if (number.StartsWith(provider.Prefix) && provider.Prefix.Length > 0) {
						comboProvider.SelectedItem = provider;
						txtNumber.Text=number.Substring(provider.Prefix.Length);
						return;
					}
				}
			}
			
			txtNumber.Text=number;
		}
		
		private void doCall(string number) {
			setNumberAndPrefix(number);
			BtnCallClick(btnCall, null);
		}
		
		void PhoBrowSipRequest(object sender, ContaQ.SipRequestArgs e)
		{
			this.BringToFront();

			e.Cancel = true;
			switch (e.Command) {
				case ContaQ.SipRequestArgs.cmdTEST:
					MessageBox.Show("Ok, the thing is working",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
				case ContaQ.SipRequestArgs.cmdSHELL:
					//MessageBox.Show("This is the shell command: " + (string)e.Arguments["executable"] + " " + (string)e.Arguments["arguments"] ,this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					try {
						System.Diagnostics.Process proc = new System.Diagnostics.Process();
						proc.EnableRaisingEvents=false;
						proc.StartInfo.FileName=(string)e.Arguments["executable"];
						proc.StartInfo.Arguments=(string)e.Arguments["arguments"];
						proc.Start();
						proc.WaitForExit();
					} catch (Exception ex){
						MessageBox.Show(ex.Message, this.Text + " - shell execute",MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;
				case ContaQ.SipRequestArgs.cmdOPEN:
					phoBrow.Open((string)e.Arguments["url"]);			
					break;
				case ContaQ.SipRequestArgs.cmdCALL:
					//handles sip:call?number=raffaeleguidi
					//		  sip:call?number=1000
					doCall((string)e.Arguments["number"]);
					break;
				case ContaQ.SipRequestArgs.cmdANSWER:
					//handles sip:answer
					BtnAnswerClick(btnAnswer, null);
					break;
				case ContaQ.SipRequestArgs.cmdHANGUP:
					//handles sip:hangup
					BtnReleaseClick(btnRelease, null);
					break;
				case ContaQ.SipRequestArgs.cmdREGISTER:
					//handles sip:register?operatorid=contaq&pin=contaq
	      			VoIPServer.Registrar.unregisterAccounts();
	      			int accIndex = VoIPServer.Configurator.DefaultAccountIndex;
	      			IAccount acc = VoIPServer.Configurator.Accounts[accIndex];
	      			acc.AccountName = "contaq";
	      			acc.UserName = (string)e.Arguments["operatorid"];
	      			acc.Password = (string)e.Arguments["pin"];
	      			acc.DomainName = (string)e.Arguments["domain"];
	      			acc.HostName = (string)e.Arguments["registrar"];
	      			
	      			if ((string)e.Arguments["displayname"] != null)
	      				acc.DisplayName = (string)e.Arguments["displayname"];
	      			else 
	      				acc.DisplayName = "Operatore " + acc.UserName;

	      			if ((string)e.Arguments["proxy"] != null)
		      			acc.ProxyAddress = (string)e.Arguments["proxy"];
	      			else
		      			acc.ProxyAddress = "";
	      			
	      			VoIPServer.Registrar.registerAccounts();
	      			
					break;
				case ContaQ.SipRequestArgs.cmdUNREGISTER:
					//handles sip:unregister
					//it is not perfect
					//but it works
					_account.UserName ="occupato";
					_account.DisplayName="non disponibile";
					_account.Password="whatthehell!wrongpassword?!?";
					VoIPServer.Registrar.Config.Save();
	      			VoIPServer.Registrar.registerAccounts();
					break;
				case ContaQ.SipRequestArgs.cmdSETCALLBACK:					
					foreach (string key in e.Arguments.Keys) {
						String url = format((string)e.Arguments[key]);
						switch (key.ToLower()) {
							case "onincomingcall":
								onIncomingCallUrl = url;
								break;
							case "onhangup":
								onHangupUrl = url;
								break;
							case "onalerting":
								onAlertingUrl = url;
								break;
							case "onanswered":
								onAnsweredUrl = url;
								break;
							case "onregistered":
								onRegisteredUrl = url;
								break;
							case "onunregistered":
								onUnregisteredUrl = url;
								break;
						}
					}
					break;
				case ContaQ.SipRequestArgs.cmdRECORDSESSION:
					//handles sip:recordsession
					// recording is implemented server side 
					// transferring the call to a recording enabled
					// extension - has to be unique to each user
					BtnRecordClick(btnRecord, null);
					break;
				case ContaQ.SipRequestArgs.cmdTRANSFER:
					//handles sip:transfer?number=123454345
					txtNumber.Text=(string)e.Arguments["number"];
					BtnTransferClick(btnTransfer, null);
					break;
				case ContaQ.SipRequestArgs.cmdHOLD:
					//handles sip:hold
					BtnHoldClick(btnTransfer, null);
					break;
				case ContaQ.SipRequestArgs.cmdRETRIEVE:
					//handles sip:hold
					BtnHoldClick(btnTransfer, null);
					break;
				case ContaQ.SipRequestArgs.cmdHOME:
					VaiAllaHome();
					break;
				case ContaQ.SipRequestArgs.cmdSETAUTOROUTING:
					mobilePrefixes = e.Arguments["mobile"].ToString().Split(';');
					landlinePrefixes = e.Arguments["landline"].ToString().Split(';');
					break;
				default:
					// handles sip:132412351
					// for compatibility with other phones
					//e.Cancel = false;
					doCall(e.Command);
					break;
			}
		}
		string format(string url) {
			if (url == null) return null;
			//replace ${root} with app.path
			url = url.Replace("${root}", "file://" + Application.StartupPath);
			//correct backspaces
			url = url.Replace("%5c", "\\");
			return url;
		}

		void PhoBrowLoad(object sender, EventArgs e)
		{
			
		}
		
		void BtnOpenUrlClick(object sender, EventArgs e)
		{
			phoBrow.Open(txtNumber.Text);
		}
		
		void BtnTransferClick(object sender, EventArgs e)
		{
			if (_currentCall != null) {
				VoIPServer.CallManager.onUserTransfer(_currentCall.Session, txtNumber.Text);
				VoIPServer.CallManager.onUserRelease(_currentCall.Session);
			}			
		}
		
		void BtnHoldClick(object sender, EventArgs e)
		{
			if (_currentCall != null) {
				VoIPServer.CallManager.onUserHoldRetrieve(_currentCall.Session);
			}			
		}
		
		void BtnRecordClick(object sender, EventArgs e)
		{
			if (keyPad.Visible) {
				//se è visibile vuol dire che è abilitato il pass through
				//nascondi tastierino e disablita dtmf passthrough
				BtnShowKeypadClick(sender, e);
			}
			try {
				if (_isRecording) {
					DialogResult res = MessageBox.Show(
							"La chiamata è già in fase di registrazione.\r\n\r\nSe si procede la registrazione precedente andrà persa.\r\n\r\nContinuo?"
					                                   ,"Registrazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
					if (res == DialogResult.No ) return;
				}
				
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "*", VoIPServer.Configurator.DtmfMode);
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "*", VoIPServer.Configurator.DtmfMode);
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "*", VoIPServer.Configurator.DtmfMode);

	        	SetRecordingStatus(true);
	      		
			} catch (Exception ex) {
				Log.Error(ex.Message + " trying to switch recording status");
			}
			//txtNumber.Text="RECORD-" + _account.UserName;
			//BtnTransferClick(btnTransfer, null);
			//BtnReleaseClick(btnRelease, null);
		}
		
		void PicLogoClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			if (me.Button== MouseButtons.Right) {
				panelAdvanced.Visible=!panelAdvanced.Visible;
			}
		}
		
		void BtnHomeClick(object sender, EventArgs e)
		{
			VaiAllaHome();
		}
		
		void TimerBlinkTick(object sender, EventArgs e)
		{
			if (btnRecord.BackColor == Color.Red) {
				btnRecord.BackColor = Button.DefaultBackColor;
				timerBlink.Interval=250;
			} else {
				btnRecord.BackColor = Color.Red;
				timerBlink.Interval=1000;
			}
		}
		
		void NumericKeyPad1Load(object sender, EventArgs e)
		{
			
		}
		
		void NumericKeyPad1KeyPressed(object sender, string keyPressed)
		{
			
		}
		
		void KeyPadLoad(object sender, EventArgs e)
		{
			
		}
		
		void KeyPadKeyPressed(object sender, string keyPressed)
		{
			try {
				VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, keyPressed, VoIPServer.Configurator.DtmfMode);
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtnMuteClick(object sender, EventArgs e)
		{
			Mixers mMixers = new Mixers();
			//MixerLine pbline = mMixers.Playback.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.SRC_WAVEOUT);
			MixerLine recline = mMixers.Recording.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.SRC_MICROPHONE);
			foreach (MixerLine line in mMixers.Recording.UserLines) {
				MessageBox.Show(line.ToString() + " " + line.Selected + " " + line.Id);
			}
		}
		
		
		void BtnShowKeypadClick(object sender, EventArgs e)
		{
			SetButtonsStatus(PhoneActions.ShowKeypad);
			try {
			if (keyPad.Visible) {
				// enter DTMF pass-through mode (see yate configuration)
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "*", VoIPServer.Configurator.DtmfMode);
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "#", VoIPServer.Configurator.DtmfMode);
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "*", VoIPServer.Configurator.DtmfMode);
			} else {
				// send sequence to exit DTMF pass-through mode
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "#", VoIPServer.Configurator.DtmfMode);
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "*", VoIPServer.Configurator.DtmfMode);
	        	VoIPServer.CallManager.onUserDialDigit(_currentCall.Session, "#", VoIPServer.Configurator.DtmfMode);
			}
			} catch (Exception ex){
				Log.Error(ex.Message + " trying to enable/disable key passthrough mode");
			}
		}
	}
}


