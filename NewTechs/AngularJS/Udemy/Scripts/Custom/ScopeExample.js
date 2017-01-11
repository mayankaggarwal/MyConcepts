var myApp = angular.module("myApp",['ngRoute']);

myApp.config(function ($routeProvider) {
   $routeProvider
   
   .when('/',{
       templateUrl : '/pages/main2.html',
       controller : 'mainController'
   })
   
   .when('/second', {
       templateUrl : '/pages/second2.html',
       controller : 'secondController'
   })
   
   .when('/second/:num', {
       templateUrl : '/pages/second2.html',
       controller : 'secondController'
   })
});

myApp.controller('mainController',['$scope', '$log', function($scope,$log) {
    $scope.person = { 
        name: "Mayank",
        address : "House Number 230, Kashmiri Mohalla Subathu",
        lastname:"Aggarwal"
    };
    
    $scope.formatedName = function(personVariable) {
        console.log(personVariable);
      return personVariable.name + ' ' + personVariable.lastname;  
    };
                
}]);

myApp.controller('secondController',['$scope', '$log','$routeParams', function($scope,$log,$routeParams) {
    $scope.people = [{
        name:"Mayank2-1",
        address:"Address 2-1"
    },
                    {
        name:"Mayank2-2",
        address:"Address 2-2"
    },
                    {
        name:"Mayank2-3",
        address:"Address 2-3"
    }]
}]);


myApp.directive('searchResult',function() {
    return {
        templateUrl:'/directives/searchresult1.html',
        replace: true
        ,scope:{
            personName:"@personNameVar",
            personAddress:"@",
            personObject:"=personObjectVariable",
            formatedNameFn:"&formatedNameFnDef"
        },
        /*
        compile:function(elem, attrs) {
            console.log('Compiling...');
            //elem.removeAttr('class');
            console.log(elem.html());
            
             return {
                 pre:function(scope,elements,attrs) {
                     console.log('Pre-Linking...');
                     console.log(elements);
                 },
                 post:function(scope,elements,attrs) {
                     console.log('Post-Linking...');
                     console.log(scope);
                     if(scope.personName=='Mayank2-2') {
                         elements.removeAttr('class');
                     }
                     console.log(elements);
                 }
             }
        }
        */
        link:function(scope,elements,attrs) {
                     console.log('Linking...');
                     console.log(scope);
                     if(scope.personName=='Mayank2-2') {
                         elements.removeAttr('class');
                     }
                     console.log(elements);
                 },
        transclude : true
    }
})
