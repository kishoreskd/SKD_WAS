const allmySideMenu = document.querySelectorAll('#mysidebar .side-menu.top li a');



allmySideMenu.forEach(item => {
    const li = item.parentElement;
    const anch = item;

    var current = location.pathname;
    const val = anch.getAttribute("href");
    console.log(current);
    if (anch.getAttribute("href").includes(current)) {
        //console.log(i);
        li.classList.add('active');

    } else {

        anch.parentElement.classList.remove('active');
    }
    //item.addEventListener('click', function () {
    //    allSideMenu.forEach(i => {

    //        console.log(i);

    //        i.parentElement.classList.remove('active');
    //    })
    //    li.classList.add('active');
    //})

});



// TOGGLE SIDEBAR
const menuBar = document.querySelector('#mycontent nav .bx.bx-menu');
const sidebar = document.getElementById('mysidebar');

menuBar.addEventListener('click', function () {
    sidebar.classList.toggle('hide');
})


const searchButton = document.querySelector('#mycontent nav form .form-input button');
const searchButtonIcon = document.querySelector('#mycontent nav form .form-input button .bx');
const searchForm = document.querySelector('#mycontent nav form');

searchButton.addEventListener('click', function (e) {
    if (window.innerWidth < 576) {
        e.preventDefault();
        searchForm.classList.toggle('show');
        if (searchForm.classList.contains('show')) {
            searchButtonIcon.classList.replace('bx-search', 'bx-x');
        } else {
            searchButtonIcon.classList.replace('bx-x', 'bx-search');
        }
    }
})

if (window.innerWidth < 768) {
    sidebar.classList.add('hide');
} else if (window.innerWidth > 576) {
    searchButtonIcon.classList.replace('bx-x', 'bx-search');
    searchForm.classList.remove('show');
}


window.addEventListener('resize', function () {
    if (this.innerWidth > 576) {
        searchButtonIcon.classList.replace('bx-x', 'bx-search');
        searchForm.classList.remove('show');
    }
})

const switchMode = document.getElementById('switch-mode');

switchMode.addEventListener('change', function () {
    if (this.checked) {
        document.body.classList.add('dark');
    } else {
        document.body.classList.remove('dark');
    }
})





