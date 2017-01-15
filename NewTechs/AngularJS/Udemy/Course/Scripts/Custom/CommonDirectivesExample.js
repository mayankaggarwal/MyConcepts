var angularApp = angular.module('angularApp', []);

angularApp.controller('mainController', ['$scope', '$filter', function ($scope, $filter) {
    $scope.handle = '';
    $scope.lowercasehandle = function () {
        return $filter('lowercase')($scope.handle);
    }; 
    
    $scope.character = 5;
    /*
    $scope.rules = [
        { rulename: "Must not be used elsewhere"},
        { rulename: "Must be 5 characters"},
        { rulename: "Must be cool"}
    ];
    
    console.log($scope.rules);
    */
    
    var rulesRequest = new XMLHttpRequest();
    rulesRequest.onreadystatechange = function(){
        $scope.$apply(function() {
            if(rulesRequest.readyState == 4 && rulesRequest.status == 200){
                //console.log(rulesRequest.responseText);
                $scope.rules = JSON.parse(rulesRequest.responseText);
                //console.log("Successfully called");
                //console.log($scope.rules);
            }
        });
    }
    
    rulesRequest.open("GET","http://localhost:10001/api/products/get",true);
    rulesRequest.send();
    
    
    
}]);