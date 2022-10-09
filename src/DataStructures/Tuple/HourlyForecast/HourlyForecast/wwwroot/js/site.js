// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function stopSpinner() {
    let spinnerElement = document.getElementById('spnId');
    spinnerElement.style.display = 'none';
}
function raiseError(text) {
    let errorAlertIdElement = document.getElementById("errorAlertId");
    errorAlertIdElement.innerHTML = text;
    errorAlertIdElement.removeAttribute('hidden');
}

function getPositionsOnSuccess(position) {

    let lat = position.coords.latitude;
    let long = position.coords.longitude;

    let latElement = document.getElementById('Latitude');
    let lonElement = document.getElementById('Longitude');

    latElement.value = lat;
    lonElement.value = long;
    stopSpinner();

}
function getCurrentLocation() {

    if (!navigator.geolocation) {
        raiseError("Your browser doesn't support get location");
    }
    else {
        navigator.geolocation.getCurrentPosition(getPositionsOnSuccess);
    }
}
