// CONTROLLERS
weatherApp.controller('homeController', ['$scope', '$location', 'cityService', function($scope, $location, cityService) {
    
    $scope.city = cityService.city;
    
    $scope.$watch('city', function() {
       cityService.city = $scope.city; 
    });
    
    $scope.submit = function() {
        $location.path('/forecast');
    }
    
}]);

weatherApp.controller('forecastController', ['$scope', '$routeParams', 'cityService','weatherService', function($scope, $routeParams, cityService,weatherService) {
    
    $scope.city = cityService.city;
    
    $scope.days = $routeParams.days || '2';
    
    
    $scope.weatherResult = weatherService.GetWeather($scope.city,$scope.days);
    
    $scope.convertToFahrenheit = function(degK) {
        console.log(degK);
        return Math.round(degK-273.15)
        
    }
    
    $scope.convertToDate = function(dt) { 
        console.log(dt);
        return new Date(dt * 1000);
        
    };
    
}]);