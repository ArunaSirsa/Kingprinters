
function loadUserName() {
    // let name = localStorage.getItem("loggedUser");
    // if (name) {
    //     let span = document.getElementById("userName");
    //     if (span) span.textContent = name;
    //     console.log(name);

 const name = localStorage.getItem("loggedUser");

   // console.log("Loaded Name:", name); // Debug

    const span = document.getElementById("userName");

   // console.log("Span Found:", span); // Debug

    if (span && name) {
        span.textContent = name;
    }

else {
        console.log("Waiting for header...");
        setTimeout(loadUserName, 200);}

   
}



    


document.addEventListener("DOMContentLoaded", loadUserName);