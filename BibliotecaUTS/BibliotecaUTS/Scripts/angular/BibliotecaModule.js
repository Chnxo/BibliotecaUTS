var viewModel;
(function () {
    viewModel = {};
}) ();

var bibliotecaApp = angular.module('bibliotecaApp', []);

bibliotecaApp.factory('UsuarioFactory', ['$http', function ($http) {
    return {
        agregar: function (usuario) {
            $http.post('api/usuarioapi', usuario);
        }
    }
} ]);