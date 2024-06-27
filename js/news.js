var url = "http://localhost:5000/api/Event"

var user = ""
getUser();


function loadnews(){
    xhr = new XMLHttpRequest();
        xhr.open('Get', url + "/GetEvents", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
          let news = JSON.parse(xhr.responseText);
          let container = document.getElementById('news')
          news.forEach(element => {
            var newElement = '<div class="row">'            
            newElement += '<div class="row gx-5">'
            newElement +=  '<div class="col-md-6 mb-4">'
            newElement += '<div class="bg-image hover-overlay ripple shadow-2-strong rounded-5" data-mdb-ripple-color="light">'
            newElement +=  '<img src="' + element.Image + '" class="img-fluid">'
            newElement += '</div>'
            newElement += '</div>'
            newElement += '<div class="col-md-6 mb-4">'
            newElement += '<a href="new.html?' + element.Id + '"><h4><strong>' + element.Name + '</strong></h4></a>'
            newElement += '<p class="text-muted">' + element.Description + '</p>'
            newElement += '<a href="new.html?' + element.Id + '">Читать далее...</a>'
            newElement += '</div>'
            newElement += '</div>'
            newElement += '</div>'
            container.insertAdjacentHTML( 'beforeend', newElement )
          });
        }
      };
      xhr.send();
}

function loadevent(){
    const queryString = window.location.search;
    var id = queryString.replace('?', '');

    var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/GetEvent", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
          let event = JSON.parse(xhr.responseText);
          document.getElementById("name").innerHTML = event.Name;
          if (event.Result != null){
            document.getElementById ("results").style.visibility = "visible";
            document.getElementById ("result").innerHTML = event.Result;
          }
          else{
            if (user.Type != "Функционер"){
                if (event.Type == "мероприятие"){
                    checkReg();
                }
            }
            else{
                loadParticipants();
            }
          }
          if (event.Date != null){
            document.getElementById ("date").style.visibility = "visible";
            document.getElementById ("date").innerHTML = event.Date.substr(0, 10);
          }
          if (event.Adress != null){
            document.getElementById ("adress").style.visibility = "visible";
            document.getElementById ("adress").innerHTML = event.Adress;
          }
          loadStrings();
        }
      };
      xhr.send(id);
}

function loadStrings(){
    const queryString = window.location.search;
    var id = queryString.replace('?', '');

    var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/GetEventStrings", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
          let event = JSON.parse(xhr.responseText);
          let container = document.getElementById('news')
          event.forEach(element => {
            var newElement = '';
            if (element.Text != null){
                newElement += '<p>' + element.Text + '</p>'
            }
            else{
                newElement += '<p><img src="' + element.Image + '"/></p>'
            }
            container.insertAdjacentHTML( 'beforeend', newElement )
          });
        }
      };
      xhr.send(id);
}

function getUser(){
    var email = sessionStorage.email;
    var password = sessionStorage.password;

    var body = JSON.stringify({
        email : email,
        password: password
      });
  
      var xhr = new XMLHttpRequest();
      xhr.open('POST', "http://localhost:5000/api/Account/GetInfo", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
          user = JSON.parse(xhr.responseText);
        }
      };
      xhr.send(body);
}

function checkReg(){
    const queryString = window.location.search;
    var id = queryString.replace('?', '');

    var body = JSON.stringify({
        EventId : id,
        UserID: user.Id
      });

      var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/CheckReg", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
            document.getElementById('reg').style.visibility = "visible"
          if (xhr.responseText == "false"){
            document.getElementById('reg').innerHTML = "Зарегистрироваться";
            document.getElementById('reg').onclick = function() { makeReg() };
          }
          else{
            document.getElementById('reg').innerHTML = "Отменить регистрацию";
            document.getElementById('reg').onclick = function() { removeReg() };
          }
        }
      };
      xhr.send(body);
}

function makeReg(){
    const queryString = window.location.search;
    var id = queryString.replace('?', '');

    var body = JSON.stringify({
        EventId : id,
        UserID: user.Id
      });

      var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/MakeReg", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
            checkReg();
        }
      };
      xhr.send(body);
}

function removeReg(){
    const queryString = window.location.search;
    var id = queryString.replace('?', '');

    var body = JSON.stringify({
        EventId : id,
        UserID: user.Id
      });

      var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/RemoveReg", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
            checkReg();
        }
      };
      xhr.send(body);
}

function loadParticipants(){
    const queryString = window.location.search;
    var id = queryString.replace('?', '');

      var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/GetAllReg", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
            users = JSON.parse(xhr.responseText);
            if (users.length > 0){
                document.getElementById('participants').style.visibility = "visible";
                users.forEach(element => {
                    var newElement = '<p>' + element.name + '</p>';            
                    document.getElementById('participants').insertAdjacentHTML( 'beforeend', newElement )
                  });
            }
        }
      };
      xhr.send(id);
}