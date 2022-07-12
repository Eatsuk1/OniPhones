//document.getElementById('addaddress').addEventListener('click',function addPopup() {
//    document.querySelector('.bg-addform').style.display = 'flex';
//});

function createAlert() {
    alert("this is an alert");
}
//function addPopup() {
//    document.getElementById('addaddress').style.display = 'flex';
//};


//function addClose() {
//    document.querySelector('.bg-addform').style.display = 'none';
//};




const Showpopup() {
    const BtnAddress = document.getElementById('addaddress');
    BtnAddress.onclick = () => {
        BtnAddress.classList.add('active');
    }
}