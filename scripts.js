

document.getElementById("search-toggle").addEventListener("click", function(event) {
    let searchInput = document.getElementById("search-input");
    let searchButton = document.getElementById("search-button");

    searchInput.classList.toggle("d-inline-block");
    searchButton.classList.toggle("d-inline-block");

    searchInput.focus(); // Устанавливаем фокус на поле ввода
    event.stopPropagation();
});

document.addEventListener("click", function(event) {
    let searchContainer = document.querySelector(".search-container");
    let searchInput = document.getElementById("search-input");
    let searchButton = document.getElementById("search-button");

    if (!searchContainer.contains(event.target)) {
        searchInput.classList.remove("d-inline-block");
        searchButton.classList.remove("d-inline-block");
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const themeToggle = document.getElementById("theme-toggle");
    const navbar = document.querySelector(".navbar");
    const header = document.querySelector("header");
    const footer = document.querySelector("footer");

    // Проверяем, была ли тема сохранена
    if (localStorage.getItem("theme") === "light") {
        document.body.classList.add("light-theme");
        navbar.classList.add("light-theme");
        header.classList.add("light-theme");
        footer.classList.add("light-theme");
        themeToggle.textContent = "🌞";
    }

    themeToggle.addEventListener("click", function () {
        document.body.classList.toggle("light-theme");
        navbar.classList.toggle("light-theme");
        header.classList.toggle("light-theme");
        footer.classList.toggle("light-theme");

        if (document.body.classList.contains("light-theme")) {
            themeToggle.textContent = "🌞"; // Светлая тема
            localStorage.setItem("theme", "light");
        } else {
            themeToggle.textContent = "🌙"; // Темная тема
            localStorage.setItem("theme", "dark");
        }
    });
});


// Автозаполнение для поля поиска
document.addEventListener("DOMContentLoaded", function () {
    const searchToggle = document.getElementById("search-toggle");
    const searchContainer = document.querySelector(".search-container");
    const searchInput = document.getElementById("search-input");
    const searchButton = document.getElementById("search-button");

    searchToggle.addEventListener("click", function (event) {
        searchContainer.classList.toggle("active");
        if (searchContainer.classList.contains("active")) {
            searchInput.focus(); // Автоматически ставим курсор в input
        } else {
            searchInput.value = ""; // Очищаем поле, если скрываем
        }
        event.stopPropagation();
    });

    document.addEventListener("click", function (event) {
        if (!searchContainer.contains(event.target) && event.target !== searchToggle) {
            searchContainer.classList.remove("active");
            searchInput.value = ""; // Очищаем поле ввода
        }
        
    });
});


// Карусель с автоматической сменой слайдов
const carouselImages = document.querySelectorAll('.carousel img');
let currentIndex = 0;

function changeSlide() {
    carouselImages[currentIndex].classList.remove('active');
    currentIndex = (currentIndex + 1) % carouselImages.length;
    carouselImages[currentIndex].classList.add('active');
}

setInterval(changeSlide, 3000); // Смена слайдов каждые 3 секунды