function ToTopOfPage(sender, args) {
    $("html, body").animate({ scrollTop: 0 }, 1000);
}

function ToBottomOfPage(sender, args) {
    $("html, body").animate({ scrollTop: $(document).height() }, 1000);
}

function FadeInReport(sender, args) {
    $("html, body").fadeOut(50);
    $("html, body").fadeIn(230);
}

function ShowProgress() { 
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("modal");
        $('body').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 200);
}

function pageLoad(sender, args) {
    $("#btnSearchReport").click(function () {
        if (Page_ClientValidate("Search")) // check Validation Group - Search before loading the gif icon
            ShowProgress();
    });
}