function UsuarioCtrl($scope, UsuarioService) {
    $scope.viewModel = [];
    $scope.usuario = {};
    $scope.usuarioFormLabel = "";
    $scope.accionForma = "";
    $scope.estaAgregando = true;
    $scope.usuarioIndex;

    $scope.abrirUsuarioForm = function (usuario, index) {
        if (typeof usuario !== 'undefined') {
            angular.copy(usuario, $scope.usuario);
            $scope.usuarioFormLabel = "Editar Usuario";
            $scope.accionForma = "Guardar Cambios";
            $scope.estaAgregando = false;
            $scope.usuarioIndex = index;
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
        UsuarioService.modificar($scope.usuario, function (data) {
            _cerrarFormulario();
        });
    };

    UsuarioCtrl.CreateViewModel = function () {
        $scope.viewModel = angular.copy(globalDTO.viewModel);

        globalDTO.modalForm.on('hidden', function () {
            _limpiarFormulario();
            _actualizarTabla();
        });

        _limpiarUsuario();
    };

    successCallback = function () {
        _cerrarFormulario();
    };

    function _actualizarTabla() {
    
    }

    function _limpiarFormulario() {
        angular.resetForm($scope, 'formaUsuario', {});
        _limpiarUsuario();
    }

    function _limpiarUsuario() {
        angular.copy($scope.viewModel.Usuario, $scope.usuario);
    }

    function _cerrarFormulario() {
        globalDTO.modalForm.modal('hide');
    }

    UsuarioCtrl.CreateViewModel();
}