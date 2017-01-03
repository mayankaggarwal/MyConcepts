var angularApp = angular.module('angularApp', []);

angularApp.controller('mainController', ['$scope', '$filter', '$http', 
function ($scope, $filter, $http) {
    $scope.handle = '';
    $scope.name = 'Mayank Aggarwal';
    
    $scope.lowercasehandle = function () {
        return $filter('lowercase')($scope.handle);
    }
    
    $scope.characters = 5;
    
    $http.get('http://localhost:10001/api/products/get')
        .success(function (result){
            $scope.rules = result;
        })
        .error(function (data,status) {
            console.log(data);
        })
    
    $scope.newRule = '';
    $scope.addRule = function(){
        $http.post('http://localhost:49294/api/products/PostRule',{newRule:$scope.newRule})
        .success(function (result){
            $scope.rules = result;
            $scope.newRule = '';
        })
        .error(function (data,status) {
            console.log(data);
        })
    }
}]);