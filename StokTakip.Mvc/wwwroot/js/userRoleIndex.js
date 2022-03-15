$(document).ready(function () {
    
    /* DataTables start here. */

    const dataTable = $('#userRolesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara: ",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _UserRoleAddPartial as Modal Form starts from here. */

    $(function () {
        const url = '/UserRole/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _UserRoleAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as UserRoleAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-userRole-add');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        console.log(data);
                        const userRoleAddAjaxModel = jQuery.parseJSON(data);
                        console.log(userRoleAddAjaxModel);
                        const newFormBody = $('.modal-body', userRoleAddAjaxModel.UserRoleAddPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            const newTableRow = dataTable.row.add([
                                userRoleAddAjaxModel.UserRoleDto.Id,
                                userRoleAddAjaxModel.UserRoleDto.User.UserName,
                                userRoleAddAjaxModel.UserRoleDto.Role.Name,
                                `<td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="userRoleAddAjaxModel.UserRoleDto.Id"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="userRoleAddAjaxModel.UserRoleDto.Id"><span class="fas fa-minus-circle"></span></button>
                                </td>`
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${userRoleAddAjaxModel.UserRoleDto.Id}`);
                            dataTable.row(newTableRow).draw();
                            toastr.success(`${userRoleAddAjaxModel.UserRoleDto.Message}`, 'Başarılı İşlem!');
                        } else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `*${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as UserRoleAddDto ends here. */
});