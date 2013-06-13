function UsuarioCtrl($scope, UsuarioService) {
    $scope.viewModel = [];
    $scope.usuario = {};
    $scope.usuarioFormLabel = "";
    $scope.accionForma = "";
    $scope.estaAgregando = true;

    $scope.abrirUsuarioForm = function (usuario, $index) {
        if (typeof usuario !== 'undefined') {
            $scope.usuario = usuario;
            $scope.usuarioFormLabel = "Editar Usuari";
            $scope.accionForma = "Guardar Cambios";
            $scope.estaAgregando = false;
        } else {
            $scope.usuarioFormLabel = "Guardar Usuario";
            $scope.accionForma = "Guardar Usuario";
            $scope.estaAgregando = true;
        }

        globalDTO.modalForm.modal('show');
    };

    $scope.summitForma = function () {
        if ($scope.estaAgregando) {
            $scope.guardar();
        } else {
            $scope.modificar();
        }
    };

    $scope.guardar = function () {
        UsuarioService.agregar($scope.usuario, function (data) {
            _cerrarFormulario();
        });
    };

    $scope.modificar = function () {
        //TO DO
    };

    UsuarioCtrl.CreateViewModel = function () {
        $scope.viewModel = angular.copy(globalDTO.viewModel);

        globalDTO.modalForm.on('hidden', function () {
            _limpiarFormulario();
        });

        _limpiarUsuario();
    };

    successCallback = function () {
        _cerrarFormulario();
    };

    function _limpiarFormulario() {
        angular.resetForm($scope, 'formaUsuario', {});
        _limpiarUsuario();
    }

    function _limpiarUsuario() {
        $scope.usuario = $scope.viewModel.Usuario;
    }

    function _cerrarFormulario() {
        globalDTO.modalForm.modal('hide');
    }

    UsuarioCtrl.CreateViewModel();
}