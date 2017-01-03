var angularApp = angular.module('angularApp', []);

angularApp.controller('mainController', ['$scope', '$filter', function ($scope, $filter) {
    $scope.alertClick = function () {
        alert('Clicked');
    };
}]);