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
            "dataSrc": function (response) {
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
            //{
            //    orderable: false,
            //    className: 'select-checkbox',
            //    targets: 4,
            //    defaultContent: '',
            //    data: null
            //}
        ],
        //"data": { "id": -1, "filterName": "assetFilter" },
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "title", "name": "Title", "autoWidth": true },
            { "data": "text", "name": "Text", "autoWidth": true },
            { "data": "questionType", "name": "QuestionType", "autoWidth": true },
            {
                "data": "isActive", "name": "IsActive", "autoWidth": true
                //"render": function (data, type, row) {
                //    return (data === true) ? '<span class="glyphicon glyphicon-ok"></span>' :
                //        '<span class="glyphicon glyphicon-remove"></span>';
                //}
            },
            { "data": "isTimeLimited", "name": "IsTimeLimited", "autoWidth": true },
            {
                "render": function (data, type, row, meta) { return "<a class='btn btn-success' href='/Question/Edit/" + row.id + "'>Edit</a>"; }
            },
            {
                "render": function (data, type, row, meta) { return "<a class='btn btn-warning' onclick='OnToggleActive(" + row.id + ")'>Active/Inactive</a>"; }
            }
        ],
        "pagingType": "simple"
    });
    $('.dataTables_length').addClass('bs-select');
});

function OnToggleActive(id) {
    $.ajax({
        type: 'GET',
        //url: '/Question/Questions?Handler=ToggleActive',
        url: "?handler=ToggleActive&id=" + id,
        dataType: "json",
        success: function (data) {

            $('#questions-datatable').DataTable().ajax.reload();
        }
    });
}