(function (app) {
    'use strict';
    app.controller('cognosPackageCtrl', cognosPackageCtrl);
    cognosPackageCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];
    function cognosPackageCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {
        $scope.cognospackage = {};
        $scope.isReadOnly = false;
        $scope.prepareFiles = prepareFiles;
        $scope.UploadPackage = UploadPackage;

        var cognosPackage = null;
        function UploadPackage() {
            UploadCognosPackage();
        }

        function UploadCognosPackage() {
            fileUploadService.uploadPackage(cognosPackage, $scope.cognospackage.Version);
            apiService.post('api/cognospackage/upload', uploadPackageSucceded, uploadPackageFailed);
        }
        function prepareFiles($files) {
            cognosPackage = $files;
        }

        function uploadPackageSucceded(response) {
            notificationService.displaySuccess($scope.cognospackage.Version + ' has been submitted to Cognos Package');
            //$scope.cognospackage = response.data;
            //if (cognosPackage) {
                fileUploadService.uploadPackage(cognosPackage, $scope.cognospackage.Version);
            //} 
        }
        function uploadPackageFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }



    }
})(angular.module('idw'));