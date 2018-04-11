// JavaScript source code
(function () {
    app = angular.module("APIModule", []);
})();   


app.config(function ($httpProvider) {
  //  $httpProvider.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';

    $httpProvider.defaults.transformRequest = [function (data) {
        return angular.isObject(data) && String(data) !== '[object File]' ? param(data) : data;
    }];
});

app.service("APIService", function ($http) {
    this.FindFaresService = function (str) {
      
        return  $http({
            method: 'GET',
            url: 'http://localhost:58180/GetFlightFares?s=' + str,
        }).then(function (success) {
            return success.data;
        }, function (error) {

        });
    }

   
});   

app.controller('APIController', function ($scope, APIService) {
   

    $scope.FindFlightFares = {};
    $scope.FindFlightFares.origin = "";
    $scope.FindFlightFares.destination = "";
    $scope.FindFlightFares.lengthofstay = "";
    $scope.FindFlightFares.departuredate = "";
    $scope.FindFlightFares.minfare = "";
    $scope.FindFlightFares.maxfare = "";
    $scope.FindFlightFares.pointofsalecountry = "";
   
   

    $scope.FindFares = function () {
        alert(angular.toJson($scope.FindFlightFares));



        var servCall = APIService.FindFaresService(angular.toJson($scope.FindFlightFares));
        servCall.then(function (d) {
            $scope.FindFlightFaresResult = d;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
      
    }
})   