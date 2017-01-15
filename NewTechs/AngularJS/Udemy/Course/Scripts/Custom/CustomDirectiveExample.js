var myApp = angular.module('myApp',['ngRoute']);

myApp.config(function($routeProvider) {
    
   $routeProvider
   
   .when('/',{
       templateUrl : '/pages/main1.html',
       controller : 'mainController'
   })
   .when('/second',{
       templateUrl : '/pages/second1.html',  
       controller : 'secondController'
   })
   
});

myApp.controller('mainController',['$scope','$log', function($scope,$log) {
    
}]);

myApp.controller('secondController',['$scope','$log', function($scope,$log) {
    
}]);

myApp.directive('searchResult',function() {
    return {
        restrict:'AECM',
        //template: '<a href="#" class="list-group-item"><h4 class="list-group-item-heading">Aggarwal, Mayank</h4><p class="list-group-item-text">House Number 230,Kashimir Mohalla,Subathu</p></a>',
        templateUrl:'/directives/searchresult.html',
        replace: true
    }
})

