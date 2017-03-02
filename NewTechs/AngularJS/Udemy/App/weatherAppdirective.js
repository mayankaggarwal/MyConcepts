weatherApp.directive('searchResult',function() {
   return {
       templateUrl:'/directives/searchresult.htm',
       replace:true
       ,scope:{
           weatherResult:"=",
           convertToFahrenheit:"&",
           convertToDate:"&",
           dateFormat:"@"
       }
   } 
});