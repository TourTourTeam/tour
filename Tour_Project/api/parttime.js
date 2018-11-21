var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Parttime = require('../database/parttime_job_schema');

router.get('/',function(req,res,next){
   Parttime.find({})
   .sort({id:1})
   .exec(function(err,parttime){
       if(err){
           res.status(500);
           res.json({success:false, err:err});
       }
       else{
           res.json({success:true, data:parttime})
       }
   });
});

router.post('/',function(req,res,next){
    Parttime.findOne({})
    .sort({id:-1})
    .exec(function(err,parttime){
        if(err){
            res.status(500);
            res.json({sucess:false,err:err});
        }
        else{
            res.locals.lastId = parttime?parttime.id:0;
            next();
        }
    });
},
function(req,res,next){
    var newParttime = new Parttime(req.body);
    newParttime.id=res.locals.lastId+1;
    newParttime.save(function(err,hero){
        if(err){
            res.status(500);
            res.json({success:false, message:err});
        }
        else{
            res.json({success:true, data:parttime});
        }
    })
});

router.get('/:id',function(req,res,next){
    Parttime.findOne({id:req.params.id})
    .exec(function(err,parttime){
        if(err){
            res.status(500);
            res.json({sucess:false, err:err});
        }
        else if(!parttime){
            res.json({success:false, err:"part time not found"});
        }
        else{
            res.json({success:true, data:parttime});
        }
    });
});

router.put('/:id',function(req,res,next){
    Parttime.findOneAndUpdate({id:req.params.id}, req.body)
    .exec(function(err,parttime){
        if(err){
            res.status(500);
            res.json({sucess:false, err:err});
        }
        else if(!parttime){
            res.json({success:false, err:"part time not found"});
        }
        else{
            res.json({success:true});
        }
    });
});

router.get('/building/:building_id',function(res,req,next){
    Building.find({building_id : req.params.building_id})
    .exec(function(err,building){
        if(err){
            res.status(500);
            res.json({sucess:false,err:err});
        }
        else if(!map){
            res.json({success:false, err:"building not found"});
        }
        else{
            res.json({sucess:true,data:building});
        }
    });
});

module.exports = router;