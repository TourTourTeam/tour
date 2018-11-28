var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
    console.log(req.body);
    res.send({"length":"8",
        "data": [
            {"x" : 80 , "y" : -330, "money" : 10000},
            {"x" : 80, "y" : -190, "money" : 10000},
            {"x" : 25, "y" : -250, "money" : 10000},
            {"x" : -60, "y" : -330, "money" : 10000},
            {"x" : -130 , "y" : 150, "money" : 10000},
            {"x" : 240, "y" : -20, "money" : 10000},
            {"x" : 350, "y" : -210, "money" : 10000},
            {"x" : 170, "y" : 350, "money" : 10000},
            {"x" : -30, "y" : 390, "money" : 10000},
            {"x" : 300, "y" : -210, "money" : 10000},
            {"x" : 240, "y" : -20, "money" : 10000},
        ]})
});


module.exports = router;
