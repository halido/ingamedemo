(function() {
    $(function() {

        var _categoryService = abp.services.app.category;
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

        $('.edit-product').click(function (e) {
            var categoryId = $(this).attr("data-category-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Categories/EditCategoryModal?categoryId=' + categoryId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });
        $('.delete-product').click(function () {
            var categoryId = $(this).attr("data-category-id");
            var categoryName = $(this).attr('data-category-name');

            deleteCategory(categoryId, categoryName);
        });
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var product = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _categoryService.create(product).done(function () {
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

        function deleteCategory(categoryId, categoryName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'BestPractice'), categoryName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _categoryService.delete({
                            id: categoryId
                        }).done(function () {
                            refreshProductList();
                        });
                    }
                }
            );
        }
    });
})();