var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
    console.log(req.body);
    res.send({"length":"6",
        "data": [
            {"map_id" : 1, "name" : "서울"},
            {"map_id" : 2, "name" : "대전"},
            {"map_id" : 3, "name" : "대구"},
            {"map_id" : 4, "name" : "울산"},
            {"map_id" : 5, "name" : "부산"},
            {"map_id" : 6, "name" : "찍고"},
        ]})
});


module.exports = router;
