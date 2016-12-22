angular.module('pboApp', [])
    .config(function ($httpProvider) {
        $httpProvider.defaults.useXDomain = false;
    })
    .controller('proudctController', function ($http, $scope) {
        $scope.products = [];
        $scope.showDetails = function (product) {
            console.log('selected product is:', product);
        };
        $http.get('http://adm-newpapi:9000/api/product').then(response => {
            $scope.products = response.data;
        }, error => {
            console.error(error);
        });
    });