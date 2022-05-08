$(document).ready(function () {
    const dataTable = $('#productTypesTable').DataTable({
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

    /* Ajax GET / Getting the _ProductTypeAddPartial as Modal Form starts from here. */
    $(function () {
        const url = '/ProductType/AddProductType/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _ProductTypeAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as ProductTypeAddDto starts from here. */
        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-productType-add');
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
                        const productTypeAddAjaxModel = jQuery.parseJSON(data);
                        console.log(productTypeAddAjaxModel);
                        const newFormBody = $('.modal-body', productTypeAddAjaxModel.ProductTypeAddPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            const newTableRow = dataTable.row.add([
                                productTypeAddAjaxModel.ProductTypeDto.ProductType.ID,
                                productTypeAddAjaxModel.ProductTypeDto.ProductType.Name,
                                `<td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="productTypeAddAjaxModel.ProductTypeDto.ProductType.ID"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="productTypeAddAjaxModel.ProductTypeDto.ProductType.ID"><span class="fas fa-minus-circle"></span></button>
                                </td>`
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${productTypeAddAjaxModel.ProductTypeDto.ProductType.ID}`);
                            dataTable.row(newTableRow).draw();
                            toastr.success(`${productTypeAddAjaxModel.ProductTypeDto.Message}`, 'Başarılı İşlem!');
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

    /* Ajax POST / Posting the FormData as ProductTypeAddDto ends here. */

    /* Ajax POST / Deleting a ProductType starts from here */
    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const productTypeName = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${productTypeName} adlı ürün türü silinicektir!`,
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
                        data: { productTypeId: id },
                        url: '/ProductType/DeleteProductType/',
                        success: function (data) {
                            const productTypeDto = jQuery.parseJSON(data);
                            if (productTypeDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${productTypeDto.ProductType.Name} adlı ürün türü başarıyla silinmiştir.`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${productTypeDto.Message}`,
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

    /* Ajax GET / Getting the _ProductTypeUpdatePartial as Modal Form starts from here. */
    $(function () {
        const url = '/ProductType/UpdateProductType/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { productTypeId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Bir hata oluştu.");
                });
            });

        /* Ajax POST / Updating a ProductType starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();

                const form = $('#form-productType-update');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        const productTypeUpdateAjaxModel = jQuery.parseJSON(data);
                        const id = productTypeUpdateAjaxModel.ProductTypeDto.ProductType.ID;
                        console.log(id);
                        const tableRow = $(`[name="${id}"]`);
                        const newFormBody = $('.modal-body', productTypeUpdateAjaxModel.ProductTypeUpdatePartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            dataTable.row(tableRow).data([
                                productTypeUpdateAjaxModel.ProductTypeDto.ProductType.ID,
                                productTypeUpdateAjaxModel.ProductTypeDto.ProductType.Name,
                                `<td>
                                    <button class="btn btn-primary btn-sm btn-update" data-id="${id}"><span class="fas fa-edit"></span></button>
                                    <button class="btn btn-danger btn-sm btn-delete" data-id="${id}"><span class="fas fa-minus-circle"></span></button>
                                </td>`
                            ]);
                            tableRow.attr("name", `${id}`);
                            dataTable.row(tableRow).invalidate();
                            toastr.success(`${productTypeUpdateAjaxModel.ProductTypeDto.Message}`, "Başarılı İşlem!");
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
});