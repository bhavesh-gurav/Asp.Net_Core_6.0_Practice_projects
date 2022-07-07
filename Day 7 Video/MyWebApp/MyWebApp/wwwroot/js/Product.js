var dtable;

$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        "ajax": {
            "url": "/Admin/Product/AllProducts"
        },

        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" }
        ]
    });
});