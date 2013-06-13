function UsuarioCtrl($scope, UsuarioService) {
    $scope.viewModel = [];
    $scope.usuario = {};
    $scope.usuarioFormLabel = "";
    $scope.accionForma = "";
    $scope.usuarioAEliminar = "";
    $scope.usuarioIndex;
    $scope.mostrarAlert = false;
    $scope.claseAlert = "";
    $scope.mensajeAlert = "";

    $scope.abrirUsuarioForm = function (usuario, index) {
        $scope.cerrarAlert();
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

    $scope.abrirEliminarForm = function (usuario, index) {
        $scope.cerrarAlert();
        $scope.usuarioIndex = index;
        $scope.usuarioAEliminar = usuario.NombreUsuario;
        angular.copy(usuario, $scope.usuario);
        globalDTO.modalEliminar.modal('show');
    }

    $scope.summitForma = function () {
        if ($scope.estaAgregando) {
            $scope.guardar($scope.usuario);
        } else {
            $scope.modificar($scope.usuario);
        }
    };

    $scope.eliminar = function () {
        UsuarioService.eliminar($scope.usuario.IdUsuario, function (data) {
            _actualizarTabla(null, "Eliminando", $scope.usuarioIndex);
            _cerrarEliminarForm()
            _mostrarAlert("alert alert-success", "El usuario fue correctamente eliminado.");
        }, function (data) {
            _cerrarFormulario();
            _mostrarAlert("alert alert-error", "Ha ocurrido un error al eliminar el usuario.");
        });
    };

    $scope.guardar = function (item) {
        var usuario = angular.copy(item);
        UsuarioService.agregar(usuario, function (data) {
            usuario.IdUsuario = data;
            _actualizarTabla(usuario, "Agregando");
            _cerrarFormulario();
            _mostrarAlert("alert alert-success", "El usuario fue correctamente guardado.");
        }, function (data) {
            _cerrarFormulario();
            _mostrarAlert("alert alert-error", "Ha ocurrido un error al guardar el usuario.");
        });
    };

    $scope.modificar = function (item) {
        var usuario = angular.copy(item);
        UsuarioService.modificar(usuario, function (data) {
            _actualizarTabla(usuario, "Editando", $scope.usuarioIndex);
            _cerrarFormulario();
            _mostrarAlert("alert alert-success", "El usuario fue correctamente modificado.");
        }, function (data) {
            _cerrarFormulario();
            _mostrarAlert("alert alert-error", "Ha ocurrido un error al modificar el usuario.");
        });
    };

    $scope.cerrarAlert = function () {
        $scope.mostrarAlert = false;
    }

    UsuarioCtrl.CreateViewModel = function () {
        $scope.viewModel = angular.copy(globalDTO.viewModel);

        globalDTO.modalForm.on('hidden', function () {
            _limpiarFormulario();
        });

        globalDTO.modalEliminar.on('hidden', function () {
            _limpiarFormulario();
        });

        _limpiarUsuario();
    };

    function _actualizarTabla(usuario, accion, index) {
        switch (accion) {
            case "Agregando":
                $scope.viewModel.Usuarios.push(usuario);
                break;
            case "Editando":
                $scope.viewModel.Usuarios[index] = usuario;
                break;
            case "Eliminando":
                $scope.viewModel.Usuarios.splice(index, 1);
                break;
        }
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

    function _cerrarEliminarForm() {
        globalDTO.modalEliminar.modal('hide');
    }

    function _mostrarAlert(clase, mensaje) {
        $scope.claseAlert = clase;
        $scope.mensajeAlert = mensaje;
        $scope.mostrarAlert = true;
    }

    UsuarioCtrl.CreateViewModel();
}