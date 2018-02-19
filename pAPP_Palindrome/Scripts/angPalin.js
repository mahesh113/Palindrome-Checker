
var app = angular.module("myApp", []);


app.controller("PrintCtrl", function ($scope, $http) {

    $scope.dbresult = 'before http call';
    $http({
        method: 'GET',
        url: '/api/PalindromeStrings'
    }).then(function (response) {
       
        var str = response.data.toString();
        
         var str1 = str.replace(/,/g, ", ");
         $scope.str2 = str1.split(", ");
         var str2 = str1.split(", ");
        

        $scope.dbresult = 'Success';
    }).catch(function (error) {
        $scope.dbresult = "Error: "+error.message;
    });

});
app.controller("myCtrl", function ($scope,$http) {
    $scope.myTxt = "";
    $scope.icase = true;
    $scope.dbresult = 'none';

    $scope.onSubmit = function () {
        var input = $scope.txtString;
        var igcase = $scope.icase;
        $scope.dbresult = "";
        if (checkPalindrome(input, igcase)) {
            $scope.result = "yes";
            $scope.myTxt = "Yes " + input+" is a Palindrome";
            $http({
                method: 'POST',
                url: '/api/PalindromeStrings',
                data: { 'value': input },

            }).then(function (data) {
                $scope.dbresult = 'success';
            }).catch(function (error) {
                $scope.dberror = error.message;
            });
        }
        else  {
            $scope.result = "no";
            $scope.myTxt = input + " is NOT a Palindrome";
        }
        
    }
});


 function checkPalindrome (str,c) {

     if (c == false) {
         var st = str.split('').reverse().join('')
         return str.replace(/[^a-zA-Z]/g, "") === st.replace(/[^a-zA-Z]/g, "");
    }
     else {
         var st = str.toLowerCase().split('').reverse().join('')
         return str.toLowerCase().replace(/[^a-zA-Z]/g, "") === st.replace(/[^a-zA-Z]/g, "");
    }
    

}