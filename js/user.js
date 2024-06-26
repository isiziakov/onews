var url = "http://localhost:5000/api/Account"

function enterClick(){
    var email = document.getElementById('floatingInput').value;
    var password = document.getElementById('floatingPassword').value;
    
    var body = JSON.stringify({
      email : email,
      password: password
    });

    var xhr = new XMLHttpRequest();
    xhr.open('POST', url + "/Login", true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.onload = function () {
      if (xhr.status == 401){
        document.getElementById ("error").style.visibility = "visible"
      }
      if (xhr.status == 200){
        sessionStorage.fio = xhr.responseText;
        sessionStorage.email = email;
        sessionStorage.password = password;
        window.location = "news.html";
      }
    };
    xhr.send(body);
}

function regClick(){
    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;
    var fio = document.getElementById('fio').value;
    var phone = document.getElementById('phone').value;
    var date = document.getElementById('date').value;
    var sex = document.querySelector('input[name="inlineRadioOptions"]:checked').value;
    var role = document.getElementById('role').value;

    var body = JSON.stringify({
      email : email,
      password: password,
      birthdate: date,
      sex: sex,
      phone: phone,
      name: fio,
      role: role
    });
    
    
    var xhr = new XMLHttpRequest();
    xhr.open('POST', url + "/Register", true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.onload = function () {
      if (xhr.status == 401){
        document.getElementById ("error").style.visibility = "visible"
        document.getElementById ("error").innerHTML = xhr.responseText
      }
      if (xhr.status == 200){
        document.getElementById ("error").style.visibility = "visible"
        document.getElementById ("error").innerHTML = xhr.responseText
      }
    };
    xhr.send(body);
}