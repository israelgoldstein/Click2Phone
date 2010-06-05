// 
// contaq cti utilities
//
function contaq(command, params){
    var thisCommand = 'contaq:' + command;
    if (params != null)
		thisCommand += '?' + params
	window.top.navigate(thisCommand);
}

function login(operatorId, pin, displayName, domain, registrar) {
	contaq('register','operatorid=' + operatorId +  '&pin=' + pin + '&displayname=' + displayName + '&domain=' + domain + '&registrar=' + registrar);
}
function call(number) {
	contaq('call','number='+number);
}

function answer() {
	contaq('answer');
}

function hangup() {
	contaq('hangup');
}

function logout() {
	contaq("unregister");
}

function record() {
	contaq("recordsession");
}

function callback(aaa) {
	contaq("setcallback", aaa);
}

function pickup(number) {
	contaq("call","number=&hash;8" + number);
}
