let sidebar = document.querySelector(".sidebar");
let closeBtn = document.querySelector("#btn");
let searchBtn = document.querySelector(".bx-search");

closeBtn.addEventListener("click", ()=>{
  sidebar.classList.toggle("open");
  menuBtnChange();//calling the function(optional)
});

searchBtn.addEventListener("click", ()=>{ // Sidebar open when you click on the search iocn
  sidebar.classList.toggle("open");
  menuBtnChange(); //calling the function(optional)
});

// following are the code to change sidebar button(optional)
function menuBtnChange() {
 if(sidebar.classList.contains("open")){
   closeBtn.classList.replace("bx-menu", "bx-menu-alt-right");//replacing the iocns class
 }else {
   closeBtn.classList.replace("bx-menu-alt-right","bx-menu");//replacing the iocns class
 }
}
///  sub menu
$(document).ready(function () {
    $('.sldm-toggle, .sldm-overlay').on("click", function (e) {
        e.preventDefault();
        $('.sldm').toggleClass('sldm-active');
        $('.sldm-bg-image').toggleClass('active');
    });

    $('.sldm-submenu > a').on("click", function (e) {
        e.preventDefault();
        $(this).toggleClass('sldm-open');
        $(this).parent().find('>ul').slideToggle(450);
    });

    $('.sldm-widget-toggle').on("click", function (e) {
        e.preventDefault();
        $($(this).data('target')).slideToggle(300);
    });
});
