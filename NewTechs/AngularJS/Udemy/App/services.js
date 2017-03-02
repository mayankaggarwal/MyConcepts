// SERVICES
weatherApp.service('cityService', function() {
    this.city = "New York, NY";
});

weatherApp.service('weatherService',['$resource',function($resource) {
    this.GetWeather = function(city,days) {
        var weatherAPI = $resource("http://api.openweathermap.org/data/2.5/forecast/daily?APPID=c48faa94691f2faf7c5dd7d8340265a5",{ 
            callback:"JSON_CALLBACK"
        },{
            get:{method:"JSONP"}
        });
        return weatherAPI.get({ q: city, cnt: days });
    }
}]);
