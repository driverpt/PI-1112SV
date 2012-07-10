(function () {
    $(function () {
        var query;

        $("#search").bind('keyup', function (e) {
            if ((e.which >= 48 && e.which <= 57) || (e.which >= 65 && e.which <= 90) || (e.which >= 97 && e.which <= 122) || e.which == 8) {
                query = $("#search").val();

                $.ajax({
                    url: "/Search/Index",
                    data: { query: query },
                    success: function (data) {
                        loadData(data);
                    }
                });
            }
        });

        $(document).click(function (e) {
            var target = e.target;

            if (!$(target).is('#search_results') && !$(target).is('#search')) {
                $('#search_results').hide();
            }
        });

        $("#search").click(function () {
            $('#search_results').show();
        });

        function loadData(data) {
            $("#search_results").html(data);

            $("#search_results tr").click(function () {
                window.location = $(this).find("a").attr("href");
            });

            var $this;

            $("#search").keydown(function (e) {
                if ((typeof $this != 'undefined') && e.which == 13) {
                    e.preventDefault();
                    e.stopPropagation();
                    window.location = $this.find("a").attr("href");
                }
            });

            var currentChild = 0;
            var numberOfTr = $("#search_results tr").length;

            $("#search").keyup(function (e) {
                if (e.which == 40) {
                    if ($("#search_results tr:nth-child(" + currentChild++ + ")").length == 0) {
                        currentChild = 1;
                    }
                    $("#search_results tr").css("background", "");

                    $("#search_results tr:nth-child(" + currentChild + ")").css("background", "#D6D6FF");
                    $this = $("#search_results tr:nth-child(" + currentChild + ")");
                }
                else {
                    if (e.which == 38) {
                        if ($("#search_results tr:nth-child(" + currentChild-- + ")").length == 0) {
                            currentChild = numberOfTr;
                        }
                        $("#search_results tr").css("background", "");

                        $("#search_results tr:nth-child(" + currentChild + ")").css("background", "#D6D6FF");
                        $this = $("#search_results tr:nth-child(" + currentChild + ")");
                    }
                }
            });
        }
    });
})();
