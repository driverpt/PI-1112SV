(function () {
    $(function () {
        var anchors = $("#paging_tab a");

        anchors.live('click', function (e) {
            e.preventDefault();
            /*e.stopPropagation();*/
            var element = $(this);
            var href = element.attr("href");
            $.ajax({
                url: href,
                cache: false,
                success: function (data) {
                    alert(data.toString());
                    var stateObj = { uri: href, selector: "#paging_content" };
                    history.pushState(stateObj, null, href);
                    $("#paging_content").html(data.Content);
                    $("#paging_tab").html(data.PagingTabContent);
                }
            }
            );
        });
    });
})();