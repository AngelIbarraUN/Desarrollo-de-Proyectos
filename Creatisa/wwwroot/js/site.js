//import "../css/output.css"

document.addEventListener('DOMContentLoaded', () => {
    const myDrawerTrigger = document.querySelector('.drawer #my-drawer')
    document.querySelectorAll('.drawer .drawer-side ul li').forEach((el) => {
        el.addEventListener('click', () => {
            if (myDrawerTrigger) {
                myDrawerTrigger.checked = false;
            }
        })
    })
});

document.body.addEventListener("modalName", function(e){
    document.getElementById(e.detail.value).showModal();
});

/*
document.getElementById("htmx-modal-dialog").addEventListener("htmx:afterSwap", function(e) {
    //console.log(e.detail.elt);
    console.log(e);
});
*/