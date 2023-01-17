$(document).ready(function () {
    $('#questions-datatable').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/question",
            "type": "POST",
            "datatype": "json",
            "dataSrc": "data.list"
        },
        "columnDefs": [
            //{
            //    "targets": [0],
            //    "visible": false,
            //    "searchable": false
            //}
        ],
        "data": { "id": -1, "filterName": "assetFilter" },
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "title", "name": "Title", "autoWidth": true },
            { "data": "text", "name": "Text", "autoWidth": true },
            { "data": "questionType", "name": "QuestionType", "autoWidth": true },
            { "data": "isTimeLimited", "name": "IsTimeLimited", "autoWidth": true },
            {
                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + row.id + "'); >Delete</a>"; }
            }
        ],
        "pagingType": "simple"
    });
    $('.dataTables_length').addClass('bs-select');
});