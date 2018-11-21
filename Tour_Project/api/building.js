var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Building = require('../database/building_schema');

router.get('/',function(req,res,next){
   Building.find({})
   .sort({id:1})
   .exec(function(err,building){
       if(err){
           res.status(500);
           res.json({success:false, err:err});
       }
       else{
           res.json({success:true, data:building})
       }
   });
});

router.post('/',function(req,res,next){
    Building.findOne({})
    .sort({id:-1})
    .exec(function(err,building){
        if(err){
            res.status(500);
            res.json({sucess:false,err:err});
        }
        else{
            res.locals.lastId = building?building.id:0;
            next();
        }
    });
},
function(req,res,next){
    var newBuilding = new Building(req.body);
    newBuilding.id=res.locals.lastId+1;
    newBuilding.save(function(err,hero){
        if(err){
            res.status(500);
            res.json({success:false, message:err});
        }
        else{
            res.json({success:true, data:building});
        }
    })
});

router.get('/:id',function(req,res,next){
    Building.findOne({id:req.params.id})
    .exec(function(err,building){
        if(err){
            res.status(500);
            res.json({sucess:false, err:err});
        }
        else if(!building){
            res.json({success:false, err:"building not found"});
        }
        else{
            res.json({success:true, data:building});
        }
    });
});

router.put('/:id',function(req,res,next){
    Building.findOneAndUpdate({id:req.params.id}, req.body)
    .exec(function(err,building){
        if(err){
            res.status(500);
            res.json({sucess:false, err:err});
        }
        else if(!building){
            res.json({success:false, err:"building not found"});
        }
        else{
            res.json({success:true,data:building});
        }
    });
});

router.get('/map/:map_id',function(req,res,next){
    Building.find({map_id : req.params.map_id})
    .exec(function(err,map){
        if(err){
            res.status(500);
            res.json({sucess:false,err:err});
        }
        else if(!map){
            res.json({success:false, err:"map not found"});
        }
        else{
            res.json({sucess:true,data:map});
        }
    });
});



module.exports = router;