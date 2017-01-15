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
        $http.post('http://localhost:10001/api/products/PostRule','"' + $scope.newRule + '"')
        .success(function (result){
            $scope.rules = result;
            $scope.newRule = '';
        })
        .error(function (data,status) {
            console.log(data);
        })
    }
    
    /*
    $scope.addRule = function(){
      var req = {
        method: 'POST',
        url: 'http://localhost:10001/api/products/PostRule',
        data: {newRule:'Mayank'}
    };
    $http(req)
    .success(function (result){
            $scope.rules = result;
            $scope.newRule = '';
        })
        .error(function (data,status) {
            console.log(data);
        })
    }
    */
}]);