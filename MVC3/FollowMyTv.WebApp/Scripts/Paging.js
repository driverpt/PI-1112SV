(function () {
    $(function () {
        var anchors = $("#paging_content #paging_tab a");

        anchors.live('click', function (e) {
            e.preventDefault();
            /*e.stopPropagation();*/
            var element = $(this);
            var href = element.attr("href");
            $.ajax({
                url: href,
                success: function (data) {
                    var stateObj = { uri: href, selector: "#paging_content" };
                    history.pushState(stateObj, null, href);
                    $("#paging_content").html(data);
                }
            }
            );
        });
    });
})();