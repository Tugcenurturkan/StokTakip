$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#rolesTable').DataTable({
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
        },
        "columnDefs": [
            { "visible": false, "targets": 0 }
        ]
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _RoleAddPartial as Modal Form starts from here. */
    $(function () {
        const url = "/Role/Add/";
        const placeHolderDiv = $("#modalPlaceHolder");
        $("#btnAdd").click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _RoleAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as RoleAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                console.log(event);
                event.preventDefault();
                const form = $('#form-role-add');
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
                        const roleAddAjaxModel = jQuery.parseJSON(data);
                        console.log(roleAddAjaxModel);
                        const newFormBody = $('.modal-body', roleAddAjaxModel.RoleAddPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            const newTableRow = dataTable.row.add([
                                roleAddAjaxModel.RoleDto.Role.Id,
                                roleAddAjaxModel.RoleDto.Role.Name,
                                `<td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="roleAddAjaxModel.RoleDto.Role.Id"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="roleAddAjaxModel.RoleDto.Role.Id"><span class="fas fa-minus-circle"></span></button>
                                </td>`
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${roleAddAjaxModel.RoleDto.Role.Id}`);
                            dataTable.row(newTableRow).draw();
                            toastr.success(`${roleAddAjaxModel.RoleDto.Message}`, 'Başarılı İşlem!');
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

    /* Ajax POST / Posting the FormData as RoleAddDto ends here. */

    /* Ajax GET / Getting the _RoleUpdatePartial as Modal Form starts from here. */

    $(function () {
        const url = '/Role/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { roleId: id }).done(function (data) {
                    console.log(data);
                    console.log(placeHolderDiv);
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Bir hata oluştu.");
                });
            });

        /* Ajax POST / Updating a User starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();

                const form = $('#form-role-update');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const roleUpdateAjaxModel = jQuery.parseJSON(data);
                        const id = roleUpdateAjaxModel.RoleDto.Role.Id;
                        console.log(id);
                        const tableRow = $(`[name="${id}"]`);
                        const newFormBody = $('.modal-body', roleUpdateAjaxModel.RoleUpdatePartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            dataTable.row(tableRow).data([
                                roleUpdateAjaxModel.RoleDto.Role.Id,
                                roleUpdateAjaxModel.RoleDto.Role.Name,
                                `<td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${id}"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${id}"><span class="fas fa-minus-circle"></span></button>
                                </td>`
                            ]);
                            tableRow.attr("name", `${id}`);
                            dataTable.row(tableRow).invalidate();
                            toastr.success(`${roleUpdateAjaxModel.RoleDto.Message}`, "Başarılı İşlem!");
                        } else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `*${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
            });

    });

    /* Ajax POST / Deleting a User starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const roleName = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${roleName} adlı rol silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { roleId: id },
                        url: '/Role/Delete/',
                        success: function (data) {
                            const roleDto = jQuery.parseJSON(data);
                            if (roleDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${roleDto.Role.Name} adlı rol başarıyla silinmiştir.`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${roleDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!")
                        }
                    });
                }
            });
        });
});