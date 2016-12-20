function mapForEach(arr,fn) {
    
    var newArr = [];
    for(var i = 0;i < arr.length; i++) {
        newArr.push(fn(arr[i]));
    }
    
    return newArr;
}

var arr1 = [1,2,3];
log(arr1);

var arr2 = [];

for(var i = 0;i < arr1.length; i++) {
    arr2.push(arr1[i]*2);
}

log(arr2);

log(mapForEach(arr1,function(x) {
    return x*6;
}));

log(mapForEach(arr1,function(x) {
    return x>2;
}));

var checkpastLimit = function(limiter,item) {
    return item > limiter;
}

log('pre-setting limiter using bind');
log(mapForEach(arr1,checkpastLimit.bind(this,1)));

var checkpastLimiterSimplified = function(limiter) {
    return (function(limiter,item) {
        return item > limiter;
    }).bind(this,limiter);
}

log('Simplified limiter');
log(mapForEach(arr2,checkpastLimiterSimplified(5)));
//creating an object with using bind to have its first value preset