$(document).ready(function () {
    $('#questions-datatable').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/question",
            "type": "POST",
            "datatype": "json",
            //"dataSrc": "data.list"
            "dataSrc": function(response) {
                response.recordsTotal = response.data.count;
                response.recordsFiltered = response.data.count; 
                response.draw = response.data.draw;
                return response.data.list;
            }
        },
        "columnDefs": [
            //{
            //    "targets": [0],
            //    "visible": false,
            //    "searchable": false
            //}
        ],
        //"data": { "id": -1, "filterName": "assetFilter" },
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "title", "name": "Title", "autoWidth": true },
            { "data": "text", "name": "Text", "autoWidth": true },
            { "data": "questionType", "name": "QuestionType", "autoWidth": true },
            { "data": "isTimeLimited", "name": "IsTimeLimited", "autoWidth": true },
            {
                //"render": function (data, row) { return "<a href='#' class='btn btn-success' onclick=editCustomer('" + row.id + "'); >Edit</a>"; }
                "render": function (data, type, row, meta) { return "<a class='btn btn-warning' href='/Question/Edit/" + row.id + "'>Edit</a>"; }
            }
        ],
        "pagingType": "simple"
    });
    $('.dataTables_length').addClass('bs-select');
});

function editCustomer() {
    alert('hi'); 
}