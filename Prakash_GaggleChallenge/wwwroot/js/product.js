var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Product/GetAll"
        },
        "columns": [
            {
                "data": "imageUrl",
                render: function (data) {
                    if (data == null) {
                        return `<img src="images/noimage.png" class="img-thumbnail">`;
                    }
                    return `<img src="${data}" class="img-thumbnail">`;
                }, width: "10%", orderable: false, searchable: false
            },
            { "data": "name", "width": "25%" },
            { "data": "sku", "width": "25%" },
            { "data": "price", "width": "10%" },
            { "data": "qty", "width": "10%" },
            {
                "data": "availability",
                render: function (data) {
                    if (data) {
                        return '<span class="badge badge-pill badge-success">In Stock</span>';
                    }
                    else {
                        return '<span class="badge badge-pill badge-warning">Out of Stock</span>';
                       
                    }
                }, "width": "10%"

            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Product/Upsert/${data}" class="btn btn-outline-info btn-sm" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Product/Delete/${data}") class="btn btn-outline-danger btn-sm" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "10%", "orderable": false, "searchable": false
            }
        ]
    });
}
function Delete(url) {
    swal({
        title: "Are you sure you want to Delete",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }

                }
            });
        }
    });
}