var globalDTO;
var globalDTO = function () {
    return {
        viewModel: {},
        modalMessage: {},
        modalForm: {}
    };
} ();

var bibliotecaApp = angular.module('bibliotecaApp', []);

bibliotecaApp.service('UsuarioService', ['$http', function ($http) {
    this.agregar = function (usuario, success, fail) {
        return $http.post('/api/usuarioapi', usuario)
            .success(success)
            .error(fail);
    };
} ]);

angular.resetForm = function (scope, formName, defaults) {
    $('form[name=' + formName + '], form[name=' + formName + '] .ng-dirty').removeClass('ng-dirty').addClass('ng-pristine');
    var form = scope[formName];
    form.$dirty = false;
    form.$pristine = true;
    for (var field in form) {
        if (form[field].$pristine === false) {
            form[field].$pristine = true;
        }
        if (form[field].$dirty === true) {
            form[field].$dirty = false;
        }
    }
    for (var d in defaults) {
        scope[d] = defaults[d];
    }
};