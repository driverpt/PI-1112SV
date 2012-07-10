(function () {
    $(function () {
        var currPage = 1;
        //var offHeight = 0; //140 ~ footer height + footer margin top + list content bottom padding

        //ver se tem informação necessária para gerar scroll
        if (checkIfNeedMorePages()) {
            addDataBlock();
        }

        //função para verificar se tem dados suficientes para gerar scroll
        function checkIfNeedMorePages() {
            //alert("Client Height = " + document.body.clientHeight + " Document Element Client Height = " + document.documentElement.clientHeight);
            //alert("$(window).height = " + $(window).height() + "$(window).scrollTop() = " + $(window).scrollTop());
            //alert("$(window).scrollTop = " + $(window).scrollTop() + " $(document).height() = " + $(document).height() + " $(window).height() = " + $(window).height());
            return $(document).height() <= $(window).height();
            // return document.body.clientHeight < document.documentElement.clientHeight; // +offHeight;
        }
        //função para adicionar mais blocos de dados à lista
        function addDataBlock() {
            currPage++;
            var url = window.location.pathname + "/Page/" + currPage;
            //obter próximo bloco de dados
            $.ajax({
                url: url,
                cache: false,
                success: function (data) {
                    //alert(JSON.stringify(data));
                    $("#paging_content").append(data.Content);
                    if (data.CurrentPage === data.TotalPages) {
                        disableInfinteScroll();
                    }
                    else {
                        if (checkIfNeedMorePages()) {
                            addDataBlock();
                        }
                    }
                },
                error: function () {
                    alert("An Error has occurred");
                    disableInfinteScroll();
                }
            });
        }

        //ao realizar scroll, verificar se antigiu o valor definido para obter dados
        $(window).bind("scroll", function () {
            if ($(window).scrollTop() + $(window).height() == $(document).height()) {
                addDataBlock();
            }
        }
        );

        //no caso de ocorrer um resize na janela verificar se tem dados suficientes
        $(window).resize(function () {
            if (checkIfNeedMorePages())
                addDataBlock();
        }
		    );

        //desactivar infite scroll
        function disableInfinteScroll() {
            alert("Infinite Scroll Disabled");
            $(window).unbind('scroll');
            $(window).unbind('resize');
        }
    });
})();