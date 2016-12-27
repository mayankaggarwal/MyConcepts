var angularApp = angular.module('angularApp', []);

angularApp.controller('mainController', ['$scope', '$filter', function ($scope, $filter) {
    $scope.handle = '';
    $scope.lowercasehandle = function () {
        return $filter('lowercase')($scope.handle);
    }; 
    
    $scope.character = 5;
    
    $scope.rules = [
        { rulename: "Must not be used elsewhere"},
        { rulename: "Must be 5 characters"},
        { rulename: "Must be cool"}
    ];
    
    console.log($scope.rules);
}]);