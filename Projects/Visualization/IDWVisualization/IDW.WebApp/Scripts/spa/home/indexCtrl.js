(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function indexCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home';
       
    }

})(angular.module('idw'));