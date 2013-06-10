function UsuarioCtrl($scope, UsuarioFactory) {
    $scope.viewModel = [];

    $scope.guardar = function (usuario) {
        UsuarioFactory.agregar(usuario).
        success(function (data, status) {
            debugger;
        }).
        error(function (data, status) {
            debugger;
        });
    };

    UsuarioCtrl.CreateViewModel = function () {
        $scope.viewModel = angular.copy(viewModel);
    };

    UsuarioCtrl.CreateViewModel();
}