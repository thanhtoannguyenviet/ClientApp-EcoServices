const navSlide = () => {
    const burger = document.querySelector('.burger');
    const nav = document.querySelector('.nav__links'); 
    const navlink = document.querySelector('.nav__links li');
    burger.addEventListener('click',() => {
        nav.classList.toggle('nav__active');
        burger.classList.toggle('toggle');
        navlink.forEach((link, index) => {
            if (link.style.animation) {
                link.style.animation = '';
            } else {
                link.style.animation = `navLinkFade 0.5s ease forwards ${index / 7}s`;
            }
        });

    });
 
}
navSlide()