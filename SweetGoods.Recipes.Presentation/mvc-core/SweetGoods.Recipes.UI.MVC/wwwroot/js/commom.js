$(".autocomplete").autocomplete({
    minLength: 3,
    source: function (request, response) {
        var url = $(this.element).data("url");

        $.ajax({
            url: "/" + url,
            data: { term: request.term },
            success: function (data) {
                console.log(data);
            }
        });
    }
});