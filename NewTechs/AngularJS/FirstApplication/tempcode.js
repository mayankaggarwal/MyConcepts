angular.module("myapp", []).controller("MainController", function($scope,$http) {
    $scope.message = "Hello Mayank";
    var person = {
        firstname: "Mayank",
        lastname: "Aggarwal",
        imageSrc: "https://avatars.githubusercontent.com/u/7425299?v=3"
    };
    $scope.person = person;
    
    var onError = function(reason){
      $scope.error = "Could not fetch the user";  
    };
    $http.get("https://api.github.com/users/mayankaggarwal")
        .then(function(response){
        $scope.user = response.data;
    }, onError);
});

            <div>
                <div>First Name: {{person.firstname}}</div>
                <div>Last Name: {{person.lastname}}</div>
                <img src="{{person.imageSrc}}" title="{{person.firstname}} {{person.lastname}}">
            </div>