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

myApp.controller('mainController',['$scope','$location', '$log',function($scope,$location,$log) {
    $log.info($location.path());
    $scope.name = 'Main Mayank';
}]);

myApp.controller('secondController',['$scope','$location', '$log', '$routeParams',function($scope,$location,$log,$routeParams) {
    $log.info($location.path());
    $scope.name = 'On Second page mayank';
    $scope.num = $routeParams.num || 1;
    
}]);