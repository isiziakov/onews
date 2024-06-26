var url = "http://localhost:5000/api/Account"

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
  console.log(body)
      var xhr = new XMLHttpRequest();
      xhr.open('POST', url + "/UpdateUser", true);
      xhr.setRequestHeader('Content-type', 'application/json');
      xhr.onload = function () {
        if (xhr.status == 200){
          document.getElementById("ufio").innerHTML = document.getElementById("fio").value;
          sessionStorage.fio = document.getElementById("fio").value;
        }
      };
}