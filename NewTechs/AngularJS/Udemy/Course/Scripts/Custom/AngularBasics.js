// MODULE
var angularApp = angular.module('angularApp', ['ngMessages','ngResource']);

// CONTROLLERS
angularApp.controller('mainController', ['$scope','$log','$filter','$resource','$timeout', function ($scope,$log,$filter,$resource,$timeout) {
    // console.log($scope);
    
    //$log.log('Hello');
    //$log.info("This is some information");
    //$log.warn("Warning!");
    //$log.debug("Some debug information while writing my code.");
    //$log.error("This was an error!!!");
    
    //$scope.name = 'Mayank';
    //$scope.formatedname = $filter('uppercase')($scope.name);
    
    //$log.info($scope.name);
    //$log.info($scope.formatedname);
    
    
    $scope.name = 'Mayank';
    
    $timeout(function(){
        $scope.name = 'Everybody';
    },3000);
    
    $scope.handle = '';
    
    $scope.lowercasehandle = function(){
        return $filter('lowercase')($scope.handle);
    }
    
}]);
/*
var searchable = function(firstName,lastName,height,age,occupation){
    return "Mayank Aggarwal";
}

console.log(angular.injector().annotate(searchable));
*/


