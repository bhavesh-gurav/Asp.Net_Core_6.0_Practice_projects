var dtable;

$(document).ready(function () {
    dtable = $('#myTable').DataTable({
        "ajax": {
            "url": "/Admin/Order/AllOrders"
        },

        "columns": [
            { "data": "name" },
            { "data": "phone" },
            { "data": "orderStatus" },
            { "data": "orderTotal" },
            {

                "data": "id",
                "render": function (data) {
                    return `
                            <a href="/Admin/order/OrderDetails?id=${data}"><i class="bi bi-pencil-square"></i></a>
                        `
                }
            },
        ]
    });
});

