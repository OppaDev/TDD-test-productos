// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function test() {
    var tabsNewAnim = $('#navbarSupportedContent');
    var activeItemNewAnim = tabsNewAnim.find('.active');

    if (activeItemNewAnim.length) {
        var activeWidthNewAnimHeight = activeItemNewAnim.innerHeight();
        var activeWidthNewAnimWidth = activeItemNewAnim.innerWidth();
        var itemPosNewAnim = activeItemNewAnim.position();

        $(".hori-selector").css({
            "top": itemPosNewAnim.top + "px",
            "left": itemPosNewAnim.left + "px",
            "height": activeWidthNewAnimHeight + "px",
            "width": activeWidthNewAnimWidth + "px"
        });
    }
}

// ======== NUEVA LÓGICA DE NAVEGACIÓN ========
function buildNavigationUrl(element) {
    const area = element.data('area') || '';
    const controller = element.data('controller') || 'Home';
    const action = element.data('action') || 'Index';

    return `${area ? `/${area}` : ''}/${controller}/${action}`;
}

function setupNavigation() {
    // Manejar clics en enlaces de navegación
    $(document).on('click', '.js-navigation-link', function (e) {
        e.preventDefault();
        const url = buildNavigationUrl($(this));
        window.location.href = url;
    });

    // Actualizar indicador activo
    function updateActiveIndicator() {
        const activeItem = $('#navbarSupportedContent').find('.active');
        if (activeItem.length) {
            test(); // Reutilizamos la función existente
        }
    }

    // Actualizar al cambiar tamaño
    $(window).on('resize', function () {
        setTimeout(updateActiveIndicator, 500);
    });
}

// ======== MANTENEMOS Y MEJORAMOS LA LÓGICA EXISTENTE ========
$(document).ready(function () {
    setupNavigation();
    setTimeout(test, 100);

    // Sistema de clases activas mejorado
    const pathParts = window.location.pathname.split('/').filter(p => p);
    const currentArea = pathParts[0] === 'Admin' ? pathParts[0] : '';
    const currentController = pathParts[currentArea ? 1 : 0] || 'Home';
    const currentAction = pathParts[currentArea ? 2 : 1] || 'Index';

    $('#navbarSupportedContent ul li').each(function () {
        const link = $(this).find('a');
        if (link.data('controller') === currentController &&
            link.data('action') === currentAction &&
            link.data('area') === currentArea) {
            $(this).addClass('active');
        }
    });
});

$(window).on('resize', function () {
    setTimeout(test, 500);
});

$(".navbar-toggler").click(function () {
    $(".navbar-collapse").slideToggle(300);
    setTimeout(test, 300);
});

