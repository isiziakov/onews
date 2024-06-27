var url = "http://localhost:5000/api/Account";
var id = -1;

function getInfo(){
    var email = sessionStorage.email;
    var password = sessionStorage.password;

    var body = JSON.stringify({
        email : email,
        password: password
      });
  
      var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/GetInfo", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
          let user = JSON.parse(xhr.responseText);
          document.getElementById("fio").value = user.Name;
          document.getElementById("phone").value = user.Phone;
          document.getElementById("role").value = user.Role;
          document.getElementById("date").value = user.Birthdate.substr(0, 10);
          id = user.Id;
          getUserEvents();
        }
      };
      xhr.send(body);
}

function update(){
    var email = sessionStorage.email;
    var password = sessionStorage.password;
    var name = document.getElementById("fio").value;
    var phone = document.getElementById("phone").value;
    var role = document.getElementById("role").value;
    var birthdate = document.getElementById("date").value;

    var body = JSON.stringify({
        email : email,
        password: password,
        name : name,
        role : role,
        phone : phone,
        birthdate : birthdate
      });
      var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/UpdateUser", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
          document.getElementById("ufio").innerHTML = document.getElementById("fio").value;
          sessionStorage.fio = document.getElementById("fio").value;
        }
      };
      xhr.send(body);
}

function getUserEvents(){
  var xhr = new XMLHttpRequest();
  xhr.open('POST', "http://localhost:5000/api/Event/GetEventsForUser", true);
  xhr.setRequestHeader('Content-type', 'application/json');
  xhr.onload = function () {
    if (xhr.status == 200){
      events = JSON.parse(xhr.responseText);
      events.forEach(element => {
        var newElement = '<div class="row" onclick=toNews(' + element.id + ')>';
        newElement +='<div class="col-8 mb-4">';
        newElement +='<textarea style="width: 100%;">' + element.name + '</textarea>';
        newElement +='</div>';
        newElement +='<div class="col-4 mb-4">';
        newElement +='<div class="form-floating">';
        newElement +='<input type="date" class="form-control" id="edate' + element.id + '" value="' + element.date.substr(0, 10) + '" readonly>';
        newElement +='<label for="edate">Дата проведения</label>';
        newElement +='</div>';
        newElement +='</div>';
        newElement +='</div>';     
        document.getElementById('events').insertAdjacentHTML( 'beforeend', newElement );
      });
      getUserPastEvents();
    }
  };
  xhr.send(id);
}

function getUserPastEvents(){
  var xhr = new XMLHttpRequest();
  xhr.open('POST', "http://localhost:5000/api/Event/GetPastEventsForUser", true);
  xhr.setRequestHeader('Content-type', 'application/json');
  xhr.onload = function () {
    if (xhr.status == 200){
      events = JSON.parse(xhr.responseText);
      events.forEach(element => {
        var newElement = '<div class="row" onclick=toNews(' + element.id + ')>';
        newElement += '<h3 class="h4 mb-3 fw-normal">' + element.name + '</h3>'
        newElement +='<div class="form-floating">';
        newElement +='<input type="date" class="form-control" id="edate' + element.id + '" value="' + element.date.substr(0, 10) + '" readonly>';
        newElement +='<label for="edate' + element.id + '">Дата проведения</label>';
        newElement +='</div>';   
        newElement +='<p>' + element.result + '</p>'
        newElement +='</div>';     
        console.log(element);
        document.getElementById('pastevents').insertAdjacentHTML( 'beforeend', newElement );
      });
    }
  };
  xhr.send(id);
}

function toNews(id){
  window.location = "new.html?" + id;
}