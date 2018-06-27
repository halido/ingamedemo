(function() {
    $(function() {

        var _productService = abp.services.app.product;
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
            rules: {
                Name: "required"
              
            }
        });

        $('#RefreshButton').click(function () {
            refreshProductList();
        });

        $('.delete-product').click(function () {
            var productId = $(this).attr("data-product-id");
            var productName = $(this).attr('data-product-name');

            deleteProduct(productId, productName);
        });

        $('.edit-product').click(function (e) {
            var productId = $(this).attr("data-product-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Products/EditProductModal?productId=' + productId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var product = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _productService.create(product).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshProductList() {
            location.reload(true); //reload page to see new user!
        }

        function deleteProduct(productId, productName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'BestPractice'), productName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _productService.delete({
                            id: productId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();