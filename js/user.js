var url = "http://localhost:5000/api/Account"

function enterClick(){
    var email = document.getElementById('floatingInput').value;
    var password = document.getElementById('floatingPassword').value;
    var body = JSON.stringify({
      email : "1",
      password: "1"
    });

    var xhr = new XMLHttpRequest();
    xhr.open('POST', url + "/Login", true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.onload = function () {
      if (xhr.status == 401){
        document.getElementById ("error").style.visibility = "visible"
      }
    };
    xhr.send(body);
}