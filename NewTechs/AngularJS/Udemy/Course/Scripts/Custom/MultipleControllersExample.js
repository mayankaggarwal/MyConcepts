var myApp = angular.module('myApp',[]);

myApp.controller('mainController', ['$scope','$filter',function($scope,$filter) {
    $scope.name = 'Mayank';
}]);

myApp.controller('secondController',['$scope', function($scope) {
    $scope.name = 'Mayank1';
}])