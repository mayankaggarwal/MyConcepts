var myApp = angular.module('myApp',['ngRoute']);

myApp.config(function ($routeProvider) {
   $routeProvider
   
   .when('/',{
       templateUrl : '/pages/main.html',
       controller : 'mainController'
   })
   
   .when('/second', {
       templateUrl : '/pages/second.html',
       controller : 'secondController'
   })
   
   .when('/second/:num', {
       templateUrl : '/pages/second.html',
       controller : 'secondController'
   })
});

myApp.service('nameService', function() {
    var self = this;
   // properties and object for a service
    this.name = 'Mayank';
    
    this.namelength = function() {
        return self.name.length;
    }
});

myApp.controller('mainController',['$scope','$location', '$log','nameService',function($scope,$location,$log,nameService) {
    $log.info($location.path());
    //$scope.name = 'Main Mayank';
    $log.main = "Property from main";
    $log.log($log);
    
    $log.log(nameService.name);
    $log.log(nameService.namelength());
    $scope.name = nameService.name;
    $scope.$watch('name',function() {
        nameService.name = $scope.name;
    });
}]);

myApp.controller('secondController',['$scope','$location', '$log','$routeParams','nameService', '$routeParams',function($scope,$location,$log,$routeParams,nameService) {
    $log.info($location.path());
    //$scope.name = 'On Second page mayank';
    $scope.num = $routeParams.num || 1;
    $log.second = "Property from second";
    $log.log($log);
    $scope.name = nameService.name;
    $scope.$watch('name',function() {
        nameService.name = $scope.name;
    });
}]);