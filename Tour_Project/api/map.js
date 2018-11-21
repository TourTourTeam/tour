var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Map = require('../database/map_schema');

router.get('/',function(req,res,next){
    Map.find({})
    .sort({id:1})
    .exec(function(err,map){
        if(err){
            res.status(500);
            res.json({success:false, err:err});
        }
        else{
            res.json({success:true, data:map})
        }
    });
 });
 
 router.post('/',function(req,res,next){
     Map.findOne({})
     .sort({id:-1})
     .exec(function(err,map){
         if(err){
             res.status(500);
             res.json({sucess:false,err:err});
         }
         else{
             res.locals.lastId = map?map.id:0;
             next();
         }
     });
 },
 function(req,res,next){
     var newMap = new Map(req.body);
     newMap.id=res.locals.lastId+1;
     newMap.save(function(err,hero){
         if(err){
             res.status(500);
             res.json({success:false, message:err});
         }
         else{
             res.json({success:true, data:map});
         }
     })
 });
 
 router.get('/:id',function(req,res,next){
     Map.findOne({id:req.params.id})
     .exec(function(err,map){
         if(err){
             res.status(500);
             res.json({sucess:false, err:err});
         }
         else if(!map){
             res.json({success:false, err:"map not found"});
         }
         else{
             res.json({success:true, data:map});
         }
     });
 });
 
 router.put('/:id',function(req,res,next){
     Map.findOneAndUpdate({id:req.params.id}, req.body)
     .exec(function(err,map){
         if(err){
             res.status(500);
             res.json({sucess:false, err:err});
         }
         else if(!map){
             res.json({success:false, err:"map not found"});
         }
         else{
             res.json({success:true});
         }
     });
 });

 module.exports = router;