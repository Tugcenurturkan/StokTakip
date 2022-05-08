$(document).ready(function () {
    const dataTable = $('#productEntryActivitiesTable').DataTable({
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

    /* Ajax GET / Getting the _ProductEntryActivitiesAddPartial as Modal Form starts from here. */
    $(function () {
        const url = "/ProductActivities/AddProductEntry/";
        const placeHolderDiv = $("#modalPlaceHolder");
        $("#btnAdd").click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });
        /* Ajax GET / Getting the _ProductEntryActivitiesAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as ProductActivitiesAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                console.log(event);
                event.preventDefault();
                const form = $('#form-productEntryActivities-add');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        debugger;
                        console.log(data);
                        const productActivitiesAddAjaxModel = jQuery.parseJSON(data);
                        console.log(productActivitiesAddAjaxModel);
                        const newFormBody = $('.modal-body', productActivitiesAddAjaxModel.ProductActivitiesAddPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            const newTableRow = dataTable.row.add([
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.ID,
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.Barcode,
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.Name,
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.Price,
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.Amount,
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.Size,
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.ProductType.Name,
                                productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.Date,
                                `<td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.ID"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.ID"><span class="fas fa-minus-circle"></span></button>
                                </td>`
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${productActivitiesAddAjaxModel.ProductActivitiesDto.ProductActivity.ID}`);
                            dataTable.row(newTableRow).draw();
                            toastr.success(`${productActivitiesAddAjaxModel.ProductActivitiesDto.Message}`, 'Başarılı İşlem!');
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

    /* Ajax POST / Posting the FormData as ProductActivitiesDto ends here. */

    /* Ajax GET / Getting the _ProductEntryActivitiesUpdatePartial as Modal Form starts from here. */
    $(function () {
        const url = '/ProductActivities/UpdateProductEntry/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { productEntryId: id }).done(function (data) {
                    console.log(data);
                    console.log(placeHolderDiv);
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Bir hata oluştu.");
                });
            });

        /* Ajax POST / Updating a productActivities starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();

                const form = $('#form-productEntryActivities-update');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const productActivitiesUpdateAjaxModel = jQuery.parseJSON(data);
                        const id = productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.Id;
                        console.log(id);
                        const tableRow = $(`[name="${id}"]`);
                        const newFormBody = $('.modal-body', productActivitiesUpdateAjaxModel.ProductActivitiesUpdatePartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            dataTable.row(tableRow).data([
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.ID,
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.Barcode,
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.Name,
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.Price,
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.Amount,
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.Size,
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.ProductType.Name,
                                productActivitiesUpdateAjaxModel.ProductActivitiesDto.ProductActivity.Date,
                                `<td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${id}"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${id}"><span class="fas fa-minus-circle"></span></button>
                                </td>`
                            ]);
                            tableRow.attr("name", `${id}`);
                            dataTable.row(tableRow).invalidate();
                            toastr.success(`${productActivitiesUpdateAjaxModel.ProductActivitiesDtos.Message}`, "Başarılı İşlem!");
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

    /* Ajax POST / Deleting a entryactivities starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const entryActivitiesName = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${entryActivitiesName} adlı ürün girişi silinicektir!`,
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
                        data: { productEntryId: id },
                        url: '/ProductActivities/DeleteProductEntryActivities/',
                        success: function (data) {
                            const productActivitiesDto = jQuery.parseJSON(data);
                            if (productActivitiesDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${productActivitiesDto.ProductActivity.Name} adlı ürün girişi başarıyla silinmiştir.`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${productActivitiesDto.Message}`,
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