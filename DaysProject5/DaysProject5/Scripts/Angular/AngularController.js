var app = angular.module('myApp', ['ngRoute']);

app.filter('toDate', function ($filter) {
    return function (jsonDate) {
        if (jsonDate !== undefined) {
           return $filter('date')(new Date(parseInt(jsonDate.replace('/Date(', ''))));
        }
        return '';
    }
});

app.controller('movieController', function($scope, $http){
    $http.get("Movies/Read")
    .then(function(response) {
        $scope.MoviesData = response.data.Data;
    });

    $scope.reset = function () {
        $http.get("Movies/Read")
        .then(function (response) {
            $scope.MoviesData = response.data.Data;
        });
        $scope.filter.movie.Release = null;
    };

    $scope.search = function () {
        var parameter = { start: $scope.filter.movie.Release.start, end: $scope.filter.movie.Release.end };
        $http.post("Movies/ReadFromSearch", parameter)
        .then(function (result) {
            $scope.MoviesData = result.data.Data;
        });
    };

});

app.config(function ($routeProvider) {
    $routeProvider
    .when('/Movies/Index',
        {
            controller: 'movieController',
            templateUrl: '/'
        })
    .otherwise({ redirectTo: '/' });
});