var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
    console.log(req.body);
    res.send({"length":"11",
        "data": [
            {"x" : 80 , "y" : -330, "money" : 10000},
            {"x" : 80, "y" : -190, "money" : 10000},
            {"x" : 25, "y" : -250, "money" : 10000},
            {"x" : -60, "y" : -330, "money" : 10000},
            {"x" : 20, "y" : 100, "money" : 10000},
            {"x" : -150, "y" : 200, "money" : 10000},
            {"x" : -240, "y" : 30, "money" : 10000},
            {"x" : 170, "y" : 350, "money" : 10000},
            {"x" : -30, "y" : 390, "money" : 10000},
            {"x" : 350, "y" : -210, "money" : 10000},
            {"x" : 240, "y" : -20, "money" : 10000},
        ]})
});



router.get('/map/busan', function(req, res, next) {
    console.log(req.body);
    res.send({"length":"11",
        "data": [
            {"prefabName" : "building2", "userName" : "hhm" , "x" : 80 , "y" : -330, "money" : 10000},
            {"prefabName" : "building4", "userName" : "hhm", "x" : 80, "y" : -190, "money" : 1500},
            {"prefabName" : "building5", "userName" : "hhm", "x" : 25, "y" : -250, "money" : 15000},
            {"prefabName" : "building2", "userName" : "hhm", "x" : -60, "y" : -330, "money" : 13000},
            {"prefabName" : "ride", "userName" : "123", "x" : 20, "y" : 100, "money" : 12000},
            {"prefabName" : "building5", "userName" : "123", "x" : -240, "y" : 30, "money" : 3500},
            {"prefabName" : "building4", "userName" : "123", "x" : 170, "y" : 350, "money" : 4500},
            {"prefabName" : "building3", "userName" : "123", "x" : -30, "y" : 390, "money" : 123456},
        ]})
});

router.get('/map/seoul', function(req, res, next) {
    console.log(req.body);
    res.send({"length":"11",
        "data": [
            {"prefabName" : "building2", "userName" : "123", "x" : 80 , "y" : -330, "money" : 10000},
            {"prefabName" : "building4", "userName" : "123", "x" : 80, "y" : -190, "money" : 10000},
            {"prefabName" : "building5", "userName" : "hhm", "x" : 25, "y" : -250, "money" : 10000},
        ]})
});



router.get('/map/daegu', function(req, res, next) {
    console.log(req.body);
    res.send({"length":"11",
        "data": [
            {"prefabName" : "building2", "userName" : "123", "x" : 80 , "y" : -330, "money" : 10000},
            {"prefabName" : "building4", "userName" : "123", "x" : 80, "y" : -190, "money" : 10000},
            {"prefabName" : "building5", "userName" : "123", "x" : 25, "y" : -250, "money" : 10000},
            {"prefabName" : "building2", "userName" : "123", "x" : -60, "y" : -330, "money" : 10000},
            {"prefabName" : "ride", "userName" : "123", "x" : 20, "y" : 100, "money" : 10000},
            {"prefabName" : "building7", "userName" : "hhm", "x" : -150, "y" : 200, "money" : 10000},
            {"prefabName" : "building5", "userName" : "hhm", "x" : -240, "y" : 30, "money" : 10000},
            {"prefabName" : "building4", "userName" : "hhm", "x" : 170, "y" : 350, "money" : 10000},
            {"prefabName" : "building3", "userName" : "hhm", "x" : -30, "y" : 390, "money" : 10000},
            {"prefabName" : "building7", "userName" : "hhm", "x" : 350, "y" : -210, "money" : 10000},
            {"prefabName" : "building2", "userName" : "hhm", "x" : 240, "y" : -20, "money" : 10000},
        ]})
});


module.exports = router;
