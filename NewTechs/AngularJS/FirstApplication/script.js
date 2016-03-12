(function(){
    var app = angular.module("githubViewer",[]);
    
    var MainController = function($scope,$http){
        
        var userComplete = function(response){
            $scope.user = response.data;
            $scope.error = "";
            $http.get($scope.user.repos_url)
            .then(OnRepos,onError);
        };
        
        var OnRepos = function(response){
            $scope.error = "No Error";
            $scope.repos = response.data;
        }
        
        var onError = function(response){
            $scope.error = "Could not fetch the data.";
        };
        
        
        $scope.search = function(userName){
          $http.get("https://api.github.com/users/" + userName)
          .then(userComplete,onError);
        };
        
        $scope.username = "angular";
        $scope.message = "Github Viewer";
        
        /*$http.get("https://api.github.com/users/mayankaggarwal")
        .then(userComplete,onError);*/
    };
    
    app.controller("MainController",["$scope","$http",MainController]);
    
}());