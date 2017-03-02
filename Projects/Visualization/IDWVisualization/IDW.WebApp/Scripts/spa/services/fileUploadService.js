(function (app) {
    'use strict';
    app.factory('fileUploadService', fileUploadService);
    fileUploadService.$inject = ['$rootScope', '$http', '$timeout', '$upload', 'notificationService'];
    function fileUploadService($rootScope, $http, $timeout, $upload, notificationService) {
        $rootScope.upload = [];
        var service = {
            uploadPackage: uploadPackage
        }
        function uploadPackage($files, callback) {
            //$files: an array of files selected 
            for (var i = 0; i < $files.length; i++) {
                var $file = $files[i];
                (function (index) {
                    $rootScope.upload[index] = $upload.upload({
                        url: "api/cognospackage/packages/upload", // webapi url 
                        method: "POST",
                        file: $file
                    }).progress(function (evt) {
                    }).success(function (data, status, headers, config) {
                        // file is uploaded successfully 
                        notificationService.displaySuccess(data.FileName + ' uploaded successfully');
                        callback();
                    }).error(function (data, status, headers, config) {
                        notificationService.displayError(data.Message);
                    });
                })(i);
            }
        }
        return service;
    }
})(angular.module('common.core'));