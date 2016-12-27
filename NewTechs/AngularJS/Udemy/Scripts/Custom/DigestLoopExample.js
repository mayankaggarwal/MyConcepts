var angularApp = angular.module("angularApp",[]);

angularApp.controller('mainController',['$scope','$filter','$timeout',
function($scope,$filter,$timeout){
    $scope.handle = '';
    
    $scope.lowercasehandle = function(){
        return $filter('lowercase')($scope.handle);
    }
    
    $scope.$watch('handle',function(newValue,oldValue){
        console.info('Changed');
        console.log('Old Value: ' + oldValue);
        console.log('New Value: ' + newValue);
    });
    
    // Below code will not update the DOM as angular will not be watching the handle inside the below thread
    /*setTimeout(function(){
        $scope.handle = 'newtwitterhandle';
        console.log('Scope Changed');
    },3000);*/
    
    setTimeout(function(){
        $scope.$apply(function(){
            $scope.handle = 'newtwitterhandle';
            console.log('scope changed');
        })
    },3000);
    
    $timeout(function(){
        $scope.handle = 'handlewithoutapply';
        console.log('scope changed');                                        
    },5000);
    
}]);
